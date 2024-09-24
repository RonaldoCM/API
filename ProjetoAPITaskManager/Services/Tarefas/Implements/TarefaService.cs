using APITaskManager.Services.Tarefas.DTO;
using APITaskManager.Services.Tarefas.Model;
using APITaskManager.Services.Tarefas.Repository;
using Microsoft.EntityFrameworkCore;

namespace APITaskManager.Services.Tarefas.Implements
{
    public class TarefaService : ITarefaService
    {
        private readonly TarefaDbContext _context;

        public TarefaService(TarefaDbContext context)
        {
            _context = context;
        }

        public async Task<TarefaDTO> CreateTarefaAsync(TarefaDTO taskDto)
        {
            var task = new Tarefa { Id = taskDto.Id, Titulo = taskDto.Titulo, Descricao = taskDto.Descricao, Vencimento = taskDto.Vencimento, Concluida = taskDto.Concluida  };
            _context.Tarefas.Add(task);
            await _context.SaveChangesAsync();

            var tarefaDto = new TarefaDTO
            {
                Id = task.Id,
                Titulo = task.Titulo,
                Descricao = task.Descricao,
                Vencimento  = task.Vencimento,
                Concluida=task.Concluida
            };

            return tarefaDto;
        }

        public async Task<bool> UpdateTarefaAsync(TarefaDTO taskDto)
        {
            var task = await _context.Tarefas.FindAsync(taskDto.Id);

            if (task == null)
            {
                return false;
            }
            
            task.Descricao = taskDto.Descricao;
            task.Titulo = taskDto.Titulo;
            task.Vencimento = taskDto.Vencimento;
            task.Concluida = taskDto.Concluida;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar tarefa", ex);
            }
        }

        public async Task<bool> DeleteTarefaAsync(int id)
        {
            var task = await _context.Tarefas.FindAsync(id);

            if (task == null)
            {
                return false;
            }

            _context.Tarefas.Remove(task);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {               
                throw new Exception("Erro ao excluir tarefa", ex);
            }
        }

        public async Task<IEnumerable<TarefaDTO>> GetAllTarefasAsync()
        {
            var tarefas = await _context.Tarefas.ToListAsync();

            return tarefas.Select(t => new TarefaDTO
            {
                Id = t.Id,
                Descricao = t.Descricao,
                Concluida = t.Concluida
            });
        }

        public async Task<TarefaDTO> GetTarefaByIdAsync(int id)
        {            
            var tarefa = await _context.Tarefas.FindAsync(id);

            if (tarefa == null)
                throw new Exception("Erro ao buscar tarefa");

            var tarefaDTO = new TarefaDTO
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Vencimento = tarefa.Vencimento
            };

            return tarefaDTO;
        }
    }
}
