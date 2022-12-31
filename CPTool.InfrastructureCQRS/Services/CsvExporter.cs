using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using CPTool.ApplicationCQRS.Features.MWOTypes.Commands.CreateUpdate;

using CsvHelper;
using System.Globalization;
using System.Text.RegularExpressions;


namespace CPTool.InfrastructureCQRS.Services
{
    public class CsvExporter : ICsvExporter
    {

       

        public byte[] ExportToCsv<TData>(IEnumerable<TData> ExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {

                using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                csvWriter.WriteRecords(ExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
