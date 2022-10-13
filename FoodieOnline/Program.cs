global using Microsoft.EntityFrameworkCore;
global using FoodieOnline.Model;
global using FoodieOnline.Context;
global using System.ComponentModel.DataAnnotations;
global using FoodieOnline.Interface;
global using FoodieOnline.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<FoodieContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConn")),ServiceLifetime.Transient
    ); //Context Classss
builder.Services.AddScoped<IAccountRepository,AccountRepository>();
builder.Services.AddScoped<ICatagoeryRepository, CatagoeryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();

app.UseDeveloperExceptionPage();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseStaticFiles();
app.Run();
