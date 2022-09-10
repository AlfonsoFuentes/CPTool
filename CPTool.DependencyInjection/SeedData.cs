using CPTool.Context;
using CPTool.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.DependencyInjection
{
    public static class SeedData
    {
        public static void InitializeDatabase(this IServiceProvider service)
        {
            var scopeFactory = service.GetRequiredService<IServiceScopeFactory>();
            using (var scope = scopeFactory.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<TableContext>();
                if (!db.Chapters!.Any())
                {
                    AddChapters(db);
                }
                if (!db.MWOTypes!.Any())
                {
                    AddMWOType(db);
                }
            }
        }
        
        static void AddChapters(TableContext context)
        {
            var chapters = new Chapter[]
            {
                new Chapter()
                {    
                    //Id = 1,
                        Name = "Alterations and Other P&L Expense Items",
                        Letter="A"
                },
                new Chapter()
                {
                        //Id = 2,
                        Name = "Foundations",
                        Letter="B"

                },
                new Chapter()
                {
                        //Id = 3,
                        Name = "Structural",
                        Letter="C"
                },
                new Chapter()
                {
                        //Id = 4,
                        Name = "Equipment",
                        Letter="D"
                },
                new Chapter()
                {
                        //Id = 5,
                        Name = "Electrical",
                        Letter="E"
                },
                new Chapter()
                {
                        //Id = 6,
                        Name = "Piping",
                        Letter="F"
                },
                new Chapter()
                {
                        //Id = 7,
                        Name = "Instruments",
                        Letter="G"
                },
                new Chapter()
                {
                        //Id = 8,
                        Name = "Insulation",
                        Letter="H"
                },
                new Chapter()
                {
                        //Id = 9,
                        Name = "Painting",
                        Letter="I"
                },
                new Chapter()
                {
                        //Id = 10,
                        Name = "EOHS",
                        Letter="K"
                },
                new Chapter()
                {
                        //Id = 11,
                        Name = "Taxes/Freight/Insurance/Duties/Consular Fees",
                        Letter="L"
                },
                new Chapter()
                {
                        //Id = 12,
                        Name = "Testing/Inspection/Start-up",
                        Letter="N"
                },
                new Chapter()
                {
                        //Id = 13,
                        Name = "Engineering Cost",
                        Letter="O"
                },
                new Chapter()
                {
                        //Id = 14,
                        Name = "Escalation/Unforseen/Contingency",
                        Letter="P"
                },
            };
            context.Chapters!.AddRange(chapters);

            context.SaveChanges();
        }
        static void AddMWOType(TableContext context)
        {
            var mwotype = new MWOType[]
            {
                new MWOType()
                {    
                    //Id = 1,
                        Name = "SAVINGS",

                },
                new MWOType()
                {
                        //Id = 2,
                        Name = "IMPROVEMENT",

                },
                new MWOType()
                {
                        //Id = 3,
                        Name = "REPLACEMENT",

                },
                new MWOType()
                {
                        //Id = 4,
                        Name = "EHS",

                },

            };
            context.MWOTypes!.AddRange(mwotype);

            context.SaveChanges();
        }
    }
}
