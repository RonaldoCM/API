using APITaskManager.Services.Tarefas.Implements;
using APITaskManager.Services.Tarefas.Model;
using APITaskManager.Services.Tarefas.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TarefaDbContext>(options =>
    options.UseInMemoryDatabase("Tarefas"));

// Registrar o ITarefaService com sua implementação
builder.Services.AddScoped<ITarefaService, TarefaService>();

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