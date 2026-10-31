using Proyecto;
using Proyecto.Services;
using Proyecto.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddScoped<IProductoService, ProductoService>();
// Register the services and repositories
builder.Services.AddScoped<IProductoRepository, ProductoRepositoryInMemory>();
builder.Services.AddControllers();
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
