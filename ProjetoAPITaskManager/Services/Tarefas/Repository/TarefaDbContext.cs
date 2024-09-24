using APITaskManager.Services.Tarefas.Model;
using Microsoft.EntityFrameworkCore;

namespace APITaskManager.Services.Tarefas.Repository
{
    public class TarefaDbContext : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }

        public TarefaDbContext(DbContextOptions<TarefaDbContext> options)

            : base(options)
        {
        }

    }
}