using APITaskManager.DTO;

namespace APITaskManager.Services.Tarefas
{

    public interface ITarefaService
    {
        Task<TarefaDTO> CreateTarefaAsync(TarefaDTO taskDto);

        Task<bool> UpdateTarefaAsync(TarefaDTO taskDto);

        Task<bool> DeleteTarefaAsync(int id);

        Task<TarefaDTO> GetTarefaByIdAsync(int id);
        
        Task<IEnumerable<TarefaDTO>> GetAllTarefasAsync();        
    }

}
