using Microsoft.EntityFrameworkCore;
using TesteTecnicoCodenApp.Data;
using TesteTecnicoCodenApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("OrcamentosDb"));
builder.Services.AddScoped<OrcamentoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
