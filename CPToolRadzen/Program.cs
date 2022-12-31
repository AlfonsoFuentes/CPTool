using Autofac.Features.Variance;
using BlazorDownloadFile;
using CPTool.Application;


using CPTool.Infrastructure;
using CPTool.Infrastructure.Persistence;
using CPTool.Services;
using CPTool.UnitsSystem;
using CPToolRadzen;
using CPToolRadzen.Services;
using CPToolRadzen.Services.Tables;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddInfrastructureService(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddBlazorDownloadFile();

builder.Services.CurrencyService();


builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
builder.Services.AddScoped<RadzenTables>();
UnitManager.RegisterByAssembly(typeof(SIUnitTypes).Assembly);
var app = builder.Build();
//app.Services.InitializeDatabase();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
