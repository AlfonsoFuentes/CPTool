﻿// Copyright (c) 2021 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT license. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using GenericServices.Configuration.Internal;
using Microsoft.EntityFrameworkCore;
using CPTool.Persistence.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GenericServices.Internal.Decoders
{
    // ReSharper disable once InconsistentNaming
    internal enum EntityStyles
    {
        [Display(Description = "An entity with a parameterless constructor and some, or all, parameters with a public setter.")]
        Standard,
        [Display(Description = "An entity where all the parameters have private setters and there are public methods, constructors and/or static methods.")]
        DDDStyled,
        [Display(Description = "Is is a DDD-styled entity, but with some standard features, such as some properties with public setters.")]
        Hybrid,
        [Display(Description = "The entity cannot be update, but is can be created, read or deleted")]
        NotUpdatable,
        [Display(Description = "The entity cannot be created or updated, but it can be read or deleted.")]
        ReadOnly,
        [Display(Description = "This entity has no primary key, so its read-only.")]
        HasNoKey,
        [Display(Description = "You cannot link to a OwnedType.")]
        OwnedType,
        [Display(Description = "You cannot link to a Property Bag. Please create a entity class to replace the property bag")]
        PropertyBag

    }

    /// <summary>
    /// This defines lots of information on an entity class around the properties and any methods
    /// Using this data it works what type of <see cref="EntityStyle"/> the entity class is - see <see cref="EntityStyles"/>.
    /// The <see cref="EntityStyle"/> is used to work out what way the developer can access the entity class.
    /// </summary>
    internal class DecodedEntityClass
    {
        private readonly string[] _methodNamesToIgnore;

        public DecodedEntityClass(Type entityType, DbContext context)
        {
            EntityType = entityType ?? throw new ArgumentNullException(nameof(entityType));
            if (entityType == typeof(Dictionary<string, object>))
            {
                EntityStyle = EntityStyles.PropertyBag;
                return;
            }

            //// This replaces 'context.Model.FindEntityType(entityType)' because that didn't provide Owned Types
            //var efType = context.Model.GetEntityTypes(entityType)
            //    //You can multiple Owned types
            //    .FirstOrDefault();
            var efEntityTypes = context.Model.GetEntityTypes();
            var efType = efEntityTypes.Where(x => x.ClrType.Name == entityType.Name)
                                      .FirstOrDefault();

            if (efType == null)
            {
                throw new InvalidOperationException($"The class {entityType.Name} was not found in the {context.GetType().Name} DbContext."+
                                                    " The class must be either be an entity class derived from the GenericServiceDto/Async class.");
            }

            if (efType.IsOwned())
            {
                //This is an owned type that doesn't have a key in it, so we mark this entity 
                EntityStyle = EntityStyles.OwnedType;
                return;
            }

            if (efType.FindPrimaryKey() == null)
            {
                //Read only, so we don't do any further setup
                EntityStyle = EntityStyles.HasNoKey;
                return;
            }

            var primaryKeys = efType.GetKeys().Where(x => (x == x.DeclaringEntityType.FindPrimaryKey())).ToImmutableList();
            if (primaryKeys.Count != 1)
            {
                throw new InvalidOperationException($"The class {entityType.Name} has {primaryKeys.Count} primary keys. I can't handle that.");
            }

            PrimaryKeyProperties = primaryKeys.Single().Properties.Select(x => x.PropertyInfo).ToImmutableList();

            PublicCtors = entityType.GetConstructors();
            var allPublicProperties = entityType.GetProperties();
            _methodNamesToIgnore = allPublicProperties.Where(pp => pp.GetMethod?.IsPublic ?? false).Select(x => x.GetMethod.Name)
                .Union(allPublicProperties.Where(pp => pp.SetMethod?.IsPublic ?? false).Select(x => x.SetMethod.Name)).ToArray();
            PublicSetterMethods = GetMethodsThatGenericServicesCanCall(entityType);
            var staticMethods = entityType.GetMethods(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);
            if (staticMethods.Any())
            {
                PublicStaticCreatorMethods = (from method in staticMethods
                    let genericArgs = (method.ReturnType.IsGenericType
                        ? method.ReturnType.GetGenericArguments()
                        : new Type[0])
                    where genericArgs.Length == 1 && genericArgs[0] == entityType &&
                          method.ReturnType.GetInterface(nameof(IStatusGeneric)) != null
                    select method).ToArray();
            }
            PropertiesWithPublicSetter = allPublicProperties.Where(x => x.SetMethod?.IsPublic ?? false).ToArray();

            var possStandard = CanBeCreatedViaAutoMapper || CanBeUpdatedViaProperties;
            var possDddStyled = CanBeCreatedByCtorOrStaticMethod || CanBeUpdatedViaMethods;
            if (possStandard && !possDddStyled)
                EntityStyle = EntityStyles.Standard;
            else if (possStandard)
                EntityStyle = EntityStyles.Hybrid;
            else 
            {
                if (CanBeCreatedByCtorOrStaticMethod)
                {
                    EntityStyle = CanBeUpdatedViaMethods ? EntityStyles.DDDStyled : EntityStyles.NotUpdatable;
                }
                else
                {
                    EntityStyle = EntityStyles.ReadOnly;
                }
            }

        }

        public Type EntityType { get; }
        public EntityStyles EntityStyle { get; }

        public ImmutableList<PropertyInfo> PrimaryKeyProperties { get; private set; }

        public ConstructorInfo[] PublicCtors { get; }
        public MethodInfo[] PublicStaticCreatorMethods { get; } = new MethodInfo[0];
        public MethodInfo[] PublicSetterMethods { get; }
        public PropertyInfo[] PropertiesWithPublicSetter { get; }

        public bool CanBeCreatedViaAutoMapper => HasPublicParameterlessCtor && CanBeUpdatedViaProperties;
        public bool CanBeUpdatedViaProperties => PropertiesWithPublicSetter.Any();
        public bool HasPublicParameterlessCtor => PublicCtors.Any(x => !x.GetParameters().Any());
        public bool CanBeUpdatedViaMethods => PublicSetterMethods.Any();
        public bool CanBeCreatedByCtorOrStaticMethod => PublicCtors.Any(x => x.GetParameters().Length > 0) || PublicStaticCreatorMethods.Any();

        private MethodInfo[] GetMethodsThatGenericServicesCanCall(Type entityType)
        {
            var methodsToInspect = FindAllMethodsInType(entityType);
            var inherited = entityType.BaseType;
            while (inherited != typeof(object))
            {
                methodsToInspect.AddRange(FindAllMethodsInType(inherited));
                inherited = inherited?.BaseType;
            }

            return methodsToInspect.Where(x => x.ReturnType == typeof(void) ||
                                               x.ReturnType == typeof(IStatusGeneric)).ToArray();
        }

        private List<MethodInfo> FindAllMethodsInType(Type entityType)
        {
            return entityType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
                .Where(pm => !_methodNamesToIgnore.Contains(pm.Name)).ToList();
        }

        /// <summary>
        /// This will throw an exception if the cud type doesn't fit the entity style
        /// </summary>
        /// <param name="cudType">either create, update or delete</param>
        public void CheckCanDoOperation(CrudTypes cudType)
        {
            if (EntityStyle == EntityStyles.HasNoKey || 
                EntityStyle == EntityStyles.OwnedType ||
                EntityStyle == EntityStyles.PropertyBag ||
                (EntityStyle == EntityStyles.ReadOnly && cudType != CrudTypes.Delete))
                throw new InvalidOperationException($"The class {EntityType.Name} of style {EntityStyle} cannot be used in {cudType}.");

        }

        public override string ToString()
        {
            return $"Entity {EntityType.Name} is {EntityStyle.ToString().SplitPascalCase()} " + (EntityStyle == EntityStyles.Standard
                       ? $"with {PropertiesWithPublicSetter?.Length ?? 0} settable properties"
                       : $"with {PublicSetterMethods?.Length ?? 0} methods, {PublicCtors?.Length == 0} public ctors, and {PublicStaticCreatorMethods?.Length ?? 0} static class factories.");
        }
    }
}
