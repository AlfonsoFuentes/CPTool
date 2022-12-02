using Autofac.Core;
using CPTool.Application.Features.MMOTypeFeatures.CreateEdit;
using CPTool.ApplicationRadzen.FeaturesGeneric;
using CPTool.Domain.Entities;
using CPTool.Persistence.BaseClass;
using CPTool.Services;
using Microsoft.AspNetCore.Mvc;

namespace CPToolRadzen.Controllers
{
    public class ExportPMToolController : ExportController 
    {
        readonly ICommandQuery<EditMWOType> query;

       
        public ExportPMToolController(ICommandQuery<EditMWOType> query)
        {
            this.query = query;
          


        }
        
       
        //[HttpGet("/export/PMTool/MWOType/csv")]
        //[HttpGet("/export/PMTool/MWOType/csv(fileName='{fileName}')")]
        //public async Task<FileStreamResult> ExportToCSV(string fileName = null)
        //{
        //    return ToCSV(ApplyQuery(GlobalTables.MWOTypes , Request.Query), fileName);
        //}
        //[HttpGet("/export/PMTool/MWOType/excel")]
        //[HttpGet("/export/PMTool/MWOType/excel(fileName='{fileName}')")]
        //public async Task<FileStreamResult> ExportToExcel(string fileName = null)
        //{
        //    return ToExcel(ApplyQuery(GlobalTables.MWOTypes, Request.Query), fileName);
        //}
        //[HttpGet("/export/PMTool/MWOType/pdf")]
        //[HttpGet("/export/PMTool/MWOType/pdf(fileName='{fileName}')")]
        //public async Task<FileStreamResult> ExportToPDF(string fileName = null)
        //{
        //    return ToExcel(ApplyQuery(GlobalTables.MWOTypes, Request.Query), fileName);
        //}
    }
}
