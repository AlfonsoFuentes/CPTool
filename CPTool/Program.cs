//using CPTool.Context;



using CPTool.Application;
using CPTool.Identity;
using CPTool.Infrastructure;
using CPTool.Infrastructure.Persistence;
using CPTool.MiddleWare;
using CPTool.UnitsSystem;
using MudBlazor.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);



var asse = Assembly.GetExecutingAssembly();

builder.Services.AddInfrastructureService(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddIdentityServices(builder.Configuration);
builder.Services.AddCors(options =>
options.AddPolicy("CorsPolicy",
builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
UnitManager.RegisterByAssembly(typeof(SIUnitTypes).Assembly);
builder.Services.AddMudServices();

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
app.UseMiddleware<ExceptionMiddleWare>();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();