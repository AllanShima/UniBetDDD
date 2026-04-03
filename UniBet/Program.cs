using Microsoft.EntityFrameworkCore;
using UniBet.Contexts.Billing.Data;
using UniBet.Contexts.Billing.DTOs.Interfaces.IRepositories;
using UniBet.Contexts.Billing.DTOs.Interfaces.IServices;
using UniBet.Contexts.Billing.DTOs.Interfaces.Services;
using UniBet.Contexts.Billing.DTOs.Interfaces.UseCases.GameCases;
using UniBet.Contexts.Billing.DTOs.Repositories;
using UniBet.Contexts.Billing.DTOs.Services;
using UniBet.Contexts.Billing.DTOs.UseCases.GameCases;
using UniBet.Contexts.Billing.Interfaces.IRepositories;
using UniBet.Contexts.Billing.Interfaces.IServices;
using UniBet.Contexts.Billing.Interfaces.Services;
using UniBet.Contexts.Billing.Interfaces.UseCases.GameCases;
using UniBet.Contexts.Billing.Repositories;
using UniBet.Contexts.Billing.Services;
using UniBet.Contexts.Billing.UseCases.GameCases;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Use Cases precisam entrar aqui tbm
builder.Services.AddScoped<PlaceGameUseCase>();
builder.Services.AddScoped<ListGamesUseCase>();
builder.Services.AddScoped<GameActiveUseCase>();

string connectionString = builder.Configuration.GetConnectionString("Database");
builder.Services.AddDbContext<Context>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
