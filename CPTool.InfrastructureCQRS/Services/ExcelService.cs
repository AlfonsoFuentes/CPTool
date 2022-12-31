using ClosedXML.Excel;
using CPTool.ApplicationCQRS.Contracts;
using CPTool.ApplicationCQRS.Contracts.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CPTool.InfrastructureCQRS.Services
{
    public class ExcelService : IExcelService
    {


        public ExcelService()
        {

        }

        public async Task<byte[]> CreateTemplateAsync(IEnumerable<string> fields, string sheetName = "Sheet1")
        {
            using (var workbook = new XLWorkbook())
            {
                workbook.Properties.Author = "";
                var ws = workbook.Worksheets.Add(sheetName);
                var colIndex = 1;
                var rowIndex = 1;
                foreach (var header in fields)
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
                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    //var base64 = Convert.ToBase64String(stream.ToArray());
                    stream.Seek(0, SeekOrigin.Begin);
                    return await Task.FromResult(stream.ToArray());
                }
            }
        }

        public async Task<byte[]> ExportAsync<TData>(IEnumerable<TData> data , Dictionary<string, Func<TData, object?>> mappers, string sheetName = "Sheet1")
        {
            using (var workbook = new XLWorkbook())
            {
                workbook.Properties.Author = "";
                var ws = workbook.Worksheets.Add(sheetName);
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
                var dataList = data.ToList();
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

        public async Task<IResult<IEnumerable<TEntity>>> ImportAsync<TEntity>(byte[] data, Dictionary<string, Func<DataRow, TEntity, object?>> mappers, string sheetName = "Sheet1")
        {

            using (var workbook = new XLWorkbook(new MemoryStream(data)))
            {
                if (!workbook.Worksheets.Contains(sheetName))
                {
                    return await Result<IEnumerable<TEntity>>.FailAsync(string.Format("Sheet with name {0} does not exist!", sheetName));
                }
                var ws = workbook.Worksheet(sheetName);
                var dt = new DataTable();
                var titlesInFirstRow = true;

                foreach (var firstRowCell in ws.Range(1, 1, 1, ws.LastCellUsed().Address.ColumnNumber).Cells())
                {
                    dt.Columns.Add(titlesInFirstRow ? firstRowCell.GetString() : $"Column {firstRowCell.Address.ColumnNumber}");
                }
                var startRow = titlesInFirstRow ? 2 : 1;
                var headers = mappers.Keys.Select(x => x).ToList();
                var errors = new List<string>();
                foreach (var header in headers)
                {
                    if (!dt.Columns.Contains(header))
                    {
                        errors.Add(string.Format("Header '{0}' does not exist in table!", header));
                    }
                }
                if (errors.Any())
                {
                    return await Result<IEnumerable<TEntity>>.FailAsync(errors);
                }
                var lastrow = ws.LastRowUsed();
                var list = new List<TEntity>();
                foreach (IXLRow row in ws.Rows(startRow, lastrow.RowNumber()))
                {
                    try
                    {
                        DataRow datarow = dt.Rows.Add();
                        var item = (TEntity?)Activator.CreateInstance(typeof(TEntity)) ?? throw new NullReferenceException($"{nameof(TEntity)}");
                        foreach (IXLCell cell in row.Cells())
                        {
                            if (cell.DataType == XLDataType.DateTime)
                            {
                                datarow[cell.Address.ColumnNumber - 1] = cell.GetDateTime().ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            else
                            {
                                datarow[cell.Address.ColumnNumber - 1] = cell.Value.ToString();
                            }
                        }
                        headers.ForEach(x => mappers[x](datarow, item));
                        list.Add(item);
                    }
                    catch (Exception e)
                    {
                        return await Result<IEnumerable<TEntity>>.FailAsync(string.Format("Sheet name {0}:{1}", sheetName, e.Message));
                    }
                }


                return await Result<IEnumerable<TEntity>>.SuccessAsync(list);
            }
        }
    }
}
