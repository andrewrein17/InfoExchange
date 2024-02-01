using InfoExchange.Components;
using InfoExchange.Models;
using InfoExchange.Controllers;
using Microsoft.EntityFrameworkCore;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

//var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
//builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<UserInfoGlobal>();

//Put before the build line below
builder.Services.AddDbContextFactory<UserDBContext>(opt =>
    opt.UseSqlServer("Data Source=infoexchangedbserver.database.windows.net;Initial Catalog=InfoExchange_db;User ID=andrewrein17;Password=Tantan456!;Trusted_Connection=False;Connect Timeout=60;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"));

builder.Services.AddDbContextFactory<PostDBContext>(opt =>
    opt.UseSqlServer("Data Source=infoexchangedbserver.database.windows.net;Initial Catalog=InfoExchange_db;User ID=andrewrein17;Password=Tantan456!;Trusted_Connection=False;Connect Timeout=60;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
