using APITaskManager.Model;
using Microsoft.EntityFrameworkCore;

namespace APITaskManager.Repository
{
    public class TarefaContext : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }

        public TarefaContext(DbContextOptions<TarefaContext> options)

            : base(options)
        {
        }
    }
}