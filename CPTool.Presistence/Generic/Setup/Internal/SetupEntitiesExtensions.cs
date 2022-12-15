// Copyright (c) 2021 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT license. See License.txt in the project root for license information.

using System.Linq;
using Microsoft.EntityFrameworkCore;
using GenericServices.Internal.Decoders;
namespace GenericServices.Setup.Internal
{
    internal static class SetupEntitiesExtensions
    {
        public static void RegisterEntityClasses(this DbContext context)
        {
            foreach (var entityType in context.Model.GetEntityTypes())
            {
                context.RegisterDecodedEntityClass(entityType.ClrType);
            }
        }
    }
}