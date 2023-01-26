using CPToolCQRS.Infrastructure.Persistence;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;

namespace CPTool.UIApp
{
    public static class ResetDatabase
    {
        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<TableContext>();
                if (context != null)
                {
                    await UpdateNomenclador(context);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
            await Task.CompletedTask;
        }
        static async Task UpdateNomenclador(TableContext db)
        {
            var mwolist = await db.MWOs.Include(x => x.MWOItems).ThenInclude(x => x.Chapter).OrderBy(x => x.Id).ToListAsync();
            int nomeclador = 1;
            foreach (var mwo in mwolist)
            {

                var chapters = mwo.MWOItems.Select(x => x.Chapter).GroupBy(x=>x).Select(x=>x.Key).ToList();
                foreach (var row in chapters)
                {

                    nomeclador = 1;
                    var items = mwo.MWOItems.Where(x => x.BudgetItem == true && x.ChapterId == row.Id).OrderBy(x => x.Id).ToList();
                    foreach (var item in items)
                    {
                    
                        item.Order = nomeclador;
                        nomeclador++;
                        db.MWOItems.Update(item);
                    }
                }


            }
        }
    }
}
