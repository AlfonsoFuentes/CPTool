using CPTool.Context;

using CPTool.DependencyInjection;
using CPTool.Services;
using CPTool.Shared;
using CPTool.UnitsSystem;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using System.Reflection;
using AutoMapper;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCPToolServices(builder.Configuration);
var asse = Assembly.GetExecutingAssembly();

builder.Services.CurrencyService();
//builder.Services.AddServiceMapper();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
UnitManager.RegisterByAssembly(typeof(SIUnitTypes).Assembly);
builder.Services.AddMudServices();
builder.Services.AddScoped<TablesService>();
builder.Services.AddScoped<ToolDialogService>();
var app = builder.Build();
app.Services.InitializeDatabase();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();