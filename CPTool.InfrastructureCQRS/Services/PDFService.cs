using ClosedXML.Excel;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.InfrastructureCQRS.Services
{
    public static class Extensions
    {
        public static float ToDpi(this float centimeter)
        {
            var inch = centimeter / 2.54;
            return (float)(inch * 72);
        }
    }
    public class PDFService: IPDFService
    {
        public async Task<byte[]> ExportToPDF<TData>(IEnumerable<TData> ExportDtos, Dictionary<string, Func<TData, object?>> mappers, string sheetName = "Sheet1")
        {
           
            using (var workbook = new XLWorkbook())
            {
               
                workbook.Properties.Author = "";
                var ws = workbook.Worksheets.Add(nameof(TData));
                var colIndex = 1;
                var rowIndex = 1;
                var headers = mappers.Keys.Select(x => x).ToList();
                foreach (var header in headers)
                {
                    var cell = ws.Cell(rowIndex, colIndex);
                    var fill = cell.Style.Fill;
                    fill.PatternType = XLFillPatternValues.Solid;
                    fill.SetBackgroundColor(XLColor.LightBlue);
                    var border = cell.Style.Border;
                    border.BottomBorder =
                        border.BottomBorder =
                            border.BottomBorder =
                                border.BottomBorder = XLBorderStyleValues.Thin;

                    cell.Value = header;

                    colIndex++;
                }
                var dataList = ExportDtos.ToList();
                foreach (var item in dataList)
                {
                    colIndex = 1;
                    rowIndex++;

                    var result = headers.Select(header => mappers[header](item)).ToList();

                    foreach (var value in result)
                    {
                        try
                        {
                            ws.Cell(rowIndex, colIndex++).Value = value;
                        }
                        catch (Exception ex)
                        {
                            string exm = ex.Message;
                        }


                    }
                }
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    //var base64 = Convert.ToBase64String(stream.ToArray());
                    stream.Seek(0, SeekOrigin.Begin);
                    return await Task.FromResult(stream.ToArray());
                }
            }
        }
    }
}
