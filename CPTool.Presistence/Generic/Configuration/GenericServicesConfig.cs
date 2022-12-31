﻿// Copyright (c) 2021 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT license. See License.txt in the project root for license information.

using System;
using System.Reflection;
using CPTool.Persistence.Generic;
using Microsoft.EntityFrameworkCore;


namespace GenericServices.Configuration
{
    /// <summary>
    /// This is the delegate for the method that matches name/type to a property's name/type
    /// </summary>
    /// <param name="name"></param>
    /// <param name="type"></param>
    /// <param name="propertyInfo"></param>
    /// <returns></returns>
    public delegate PropertyMatch MatchNameAndType(string name, Type type, PropertyInfo propertyInfo);

    /// <summary>
    /// This is the global configuration for GenericServices. It is read once during startup.
    /// You can set values to alter the way GenericServices works
    /// </summary>
    public class GenericServicesConfig : IGenericServicesConfig
    {
        /// <inheritdoc />
        public MatchNameAndType NameMatcher { get; set; } = DefaultNameMatcher.MatchCamelAndPascalName;

        /// <inheritdoc />
        public bool NoErrorOnReadSingleNull { get; set; }

        /// <inheritdoc />
        public bool DirectAccessValidateOnSave { get; set; }

        /// <inheritdoc />
        public bool DtoAccessValidateOnSave { get; set;  }
        public BeforeSaveChanges BeforeSaveChanges { get; set; }

        public Func<Exception, DbContext, IStatusGeneric> SaveChangesExceptionHandler { get;  } = (exception, dbContext) => null; // default is to return null

        /// <inheritdoc />

    }
}