using APITaskManager.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adiciona serviços ao container
builder.Services.AddDbContext<TarefaContext>(options =>
    options.UseInMemoryDatabase("Tarefas"));

var app = builder.Build();

// Configura o pipeline de requisições
app.MapGet("/tarefas", (TarefaContext db) =>
{
    return db.Tarefas.ToList();
});

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