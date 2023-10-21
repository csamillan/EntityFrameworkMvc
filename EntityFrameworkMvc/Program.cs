using EntityFrameworkMvc.Mappers;
using EntityFrameworkMvc.Model;
using EntityFrameworkMvc.Services;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Creacion la variable de conexion para la base de datos.
builder.Services.AddDbContext<ModelDBContext>(options =>
{
    var connectionStr = builder.Configuration.GetConnectionString("MvcEF") ??
        throw new Exception("Connetion string 'MvcEF' not found");
    options.UseSqlServer(connectionStr);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(Assembly.Load("EntityFrameWorkMvc"));
builder.Services.AddValidatorsFromAssembly(Assembly.Load("EntityFrameWorkMvc"));

//Agregamos los controladores
builder.Services.AddScoped<IEditorialService, EditorialService>();
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

//Utilizacion de la conexion y creacion de base de datos.
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ModelDBContext>();
    //context.Database.EnsureDeleted(); //Eliminar Base de datos.
    context.Database.EnsureCreated();
}

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
