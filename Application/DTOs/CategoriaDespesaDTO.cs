using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class CategoriaDespesaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }
    }
}
