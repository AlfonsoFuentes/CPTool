﻿using CPTool.Domain.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.PersistenceCQRS.Extensions
{
    public static class MediatorExtensions
    {
        public static async Task DispatchDomainEvents(this IMediator mediator, DbContext context)
        {
            var entities = GetEntitiesWithPendingEvents(context);
            while (entities.Any())
            {
                foreach (var entity in entities)
                    foreach (var domainEvent in entity.DomainEvents.ToList())
                    {
                        await mediator.Publish(domainEvent);
                        entity.RemoveDomainEvent(domainEvent);
                    }
                entities = GetEntitiesWithPendingEvents(context);
            }
        }

        private static List<BaseEntity> GetEntitiesWithPendingEvents(DbContext context)
        {
            return context.ChangeTracker
                .Entries<BaseEntity>()
                .Where(e => e.Entity.DomainEvents.Any())
                .Select(e => e.Entity)
                .ToList();
        }
    }
}
