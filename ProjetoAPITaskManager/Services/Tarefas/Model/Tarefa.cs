using System.ComponentModel.DataAnnotations;

namespace APITaskManager.Services.Tarefas.Model
{
    public class Tarefa
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Titulo { get; set; }

        [Required]
        [MaxLength(100)]
        public string Descricao { get; set; }

        [Required]
        public DateTime Vencimento { get; set; }

        [Required]
        public bool Concluida { get; set; }
    }
}
