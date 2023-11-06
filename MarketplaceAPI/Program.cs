using MarketplaceAPI.Contracts.DataAccess.QueryProviders;
using MarketplaceAPI.Contracts.Domain.Services;
using MarketplaceAPI.Data;
using MarketplaceAPI.DataAccess.QueryProviders;
using MarketplaceAPI.Domain.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AuctionsContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("AuctionsContext")));

builder.Services.AddTransient<IAuctionsQueryProvider, AuctionsQueryProvider>();
builder.Services.AddTransient<IAuctionsService, AuctionsService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

