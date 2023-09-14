using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Modelos;
using Profiles;
using Repositorios;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
ConfigurationManager configuration = builder.Configuration;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepositoriosBBDD, RepositorioBBDD>();

builder.Services.AddDbContext<ContextoConversor>(options =>
          {
              options.UseSqlServer(builder.Configuration["ConnectionStrings:PruebaExamenProjectContext"]);
          });

builder.Services.AddAutoMapper(typeof(PersonasProfile));//PARA CUANDO SAQUEMOS PROFILE

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