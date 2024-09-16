using APITaskManager.DTO;
using APITaskManager.Services.Tarefas;
using Microsoft.AspNetCore.Mvc;

namespace APITaskManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase
    {

        private readonly ITarefaService _tarefaService;

        public TarefasController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateTarefa(TarefaDTO tarefaDto)
        {
            try
            {
                var tarefaCriada = await _tarefaService.CreateTarefaAsync(tarefaDto);

                if (tarefaCriada.Erro != null)
                {
                    return BadRequest(tarefaCriada.Erro);
                }

                return CreatedAtAction("GetTarefa", new { id = tarefaCriada.Id }, tarefaCriada);
            }
            catch (Exception ex)
            {
                // Logar a exceção para análise posterior
                _ = (ex, "Erro ao criar tarefa no controller");
                return StatusCode(500, "Ocorreu um erro interno no servidor.");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTarefa(int id, TarefaDTO tarefaDto)
        {
            if (id != tarefaDto.Id)
            {
                return BadRequest("O ID na URL não corresponde ao ID no corpo da requisição.");
            }

            var sucesso = await _tarefaService.UpdateTarefaAsync(tarefaDto);

            if (sucesso)
            {
                return NoContent(); // 204 No Content
            }
            else
            {
                return NotFound(); // 404 Not Found
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefa(int id)
        {
            var sucesso = await _tarefaService.DeleteTarefaAsync(id);

            if (sucesso)
            {
                return NoContent(); // 204 No Content
            }
            else
            {
                return NotFound(); // 404 Not Found
            }
        }

    }
}
