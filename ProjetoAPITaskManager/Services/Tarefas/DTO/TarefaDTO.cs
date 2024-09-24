namespace APITaskManager.Services.Tarefas.DTO
{
    public class TarefaDTO
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime Vencimento { get; set; }

        public bool Concluida { get; set; }

    }
}
