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
                    //await UpdateEquipmentItem(context);
                    //await UpdatePiping(context);
                    //await UpdateInstrument(context);
                    //context.SaveChanges();
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
                nomeclador = 1;
                foreach (var item in mwo.MWOItems.Where(x => x.BudgetItem == true).OrderBy(x=>x.ChapterId).ThenBy(x => x.Id))
                {
                    item.Nomenclatore = $"{item.TagLetter}{nomeclador}";
                    nomeclador++;
                }
            }
        }
    }
}
