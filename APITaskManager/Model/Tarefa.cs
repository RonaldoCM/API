using System.ComponentModel.DataAnnotations;

namespace APITaskManager.Model
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
