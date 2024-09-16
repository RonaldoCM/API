using APITaskManager.DTO;
using APITaskManager.Model;
using APITaskManager.Repository;

namespace APITaskManager.Services.Tarefas
{
    public class TarefasService : ITarefaService
    {
        private readonly TarefaContext _context;

        public TarefasService(TarefaContext context)
        {
            _context = context;
        }

        public async Task<TarefaDTO> CreateTarefaAsync(TarefaDTO taskDto)
        {
            var task = new Tarefa { Descricao = taskDto.Descricao };
            _context.Tarefas.Add(task);
            await _context.SaveChangesAsync();

            var tarefaDto = new TarefaDTO
            {
                Id = task.Id,
                Descricao = task.Descricao,
                // ... outras propriedades
            };

            return tarefaDto;
        }

        public async Task<bool> UpdateTarefaAsync(TarefaDTO taskDto)
        {
            var task = await _context.Tarefas.FindAsync(taskDto.Id);

            if (task == null)
            {
                return false; // Tarefa não encontrada
            }

            // Atualiza as propriedades da entidade com os dados do DTO
            task.Descricao = taskDto.Descricao;
            // ... outras propriedades a serem atualizadas

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Logar a exceção
                //_logger.LogError(ex, "Erro ao atualizar tarefa");
                return false;
            }
        }

        public async Task<bool> DeleteTarefaAsync(int id)
        {
            var task = await _context.Tarefas.FindAsync(id);

            if (task == null)
            {
                return false; // Tarefa não encontrada
            }

            _context.Tarefas.Remove(task);

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // Logar a exceção
                //_logger.LogError(ex, "Erro ao excluir tarefa");
                return false;
            }
        }

        public Task<IEnumerable<TarefaDTO>> GetAllTarefasAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TarefaDTO> GetTarefaByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    
    }
}
