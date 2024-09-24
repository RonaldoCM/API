using APITaskManager.Services.Tarefas.DTO;
using APITaskManager.Services.Tarefas.Model;

namespace APITaskManager.Services.Tarefas.Implements
{
    public class FakeTarefaService : ITarefaService
    {
        Task<TarefaDTO> ITarefaService.CreateTarefaAsync(TarefaDTO taskDto)
        {
            throw new NotImplementedException();
        }

        Task<bool> ITarefaService.DeleteTarefaAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<TarefaDTO>> ITarefaService.GetAllTarefasAsync()
        {
            throw new NotImplementedException();
        }

        Task<TarefaDTO> ITarefaService.GetTarefaByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> ITarefaService.UpdateTarefaAsync(TarefaDTO taskDto)
        {
            throw new NotImplementedException();
        }
    }
}
