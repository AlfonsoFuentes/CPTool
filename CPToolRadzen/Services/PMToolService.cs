using CPtool.ExtensionMethods;
using CPTool.Application.Features.Base;
using CPTool.Application.Features.BrandFeatures;
using CPTool.Application.Features.BrandFeatures.CreateEdit;
using CPTool.Application.Features.BrandFeatures.Query.GetById;
using CPTool.Application.Features.BrandFeatures.Query.GetList;
using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Radzen;
using System.Text.Encodings.Web;

namespace CPToolRadzen.Services
{
    //public partial class PMToolService
    //{



    //    private readonly NavigationManager NavigationManager;

    //    public PMToolService(NavigationManager navigationManager)
    //    {

    //        this.NavigationManager = navigationManager;
    //    }

    //    public async Task ExportToExcel(QueryFilter query = null!,string filename=null!)
    //    {
    //        var query1 = query!.ToUrl($"export/pmtool/excel(fileName='{(!string.IsNullOrEmpty(filename) ? UrlEncoder.Default.Encode(filename) : "Export")}')");
    //        var query2 = $"export/pmtool/excel(fileName='{(!string.IsNullOrEmpty(filename) ? UrlEncoder.Default.Encode(filename) : "Export")}')";

    //        NavigationManager.NavigateTo(query != null ? query1 : query2, true);
    //    }
    //    public async Task ExportToCSV(QueryFilter query = null!, string filename = null!)
    //    {
    //        var query1 = query.ToUrl($"export/pmtool/{filename}/csv(fileName='{(!string.IsNullOrEmpty(filename) ? UrlEncoder.Default.Encode(filename) : "Export")}')");
    //        var query2 = $"export/pmtool/{filename}/csv(fileName='{(!string.IsNullOrEmpty(filename) ? UrlEncoder.Default.Encode(filename) : "Export")}')";
    //        NavigationManager.NavigateTo(query != null ? query1 : query2, true);
    //    }



    //}

}