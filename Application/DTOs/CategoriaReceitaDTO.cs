using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class CategoriaReceitaDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo obrigatório")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }
    }
}
