using APITaskManager.Services.Tarefas.DTO;
using APITaskManager.Services.Tarefas.Model;
using Microsoft.AspNetCore.Mvc;

namespace APITaskManager.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {

        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateTarefa(TarefaDTO tarefaDto)
        {
            try
            {
                var tarefaCriada = await _tarefaService.CreateTarefaAsync(tarefaDto);

                if (tarefaCriada == null)
                {
                    return BadRequest("Não foi possível criar a tarefa.");
                }

                return Created($"/api/tarefas/{tarefaCriada.Id}", tarefaCriada);

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criar tarefa no controller", ex);
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
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefa(int id)
        {
            var sucesso = await _tarefaService.DeleteTarefaAsync(id);

            if (sucesso)
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetTarefaByIdAsync(int id)
        {
            var tarefa = await _tarefaService.GetTarefaByIdAsync(id);

            if (tarefa == null)
            {
                return NotFound("Tarefa não encontrada.");
            }

            return Ok(tarefa);

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarefaDTO>>> GetAllTarefas()
        {
            var tarefas = await _tarefaService.GetAllTarefasAsync();
            return Ok(tarefas);
        }
    }
}