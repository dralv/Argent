using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public class ReceitaDTO
    {
       
        public int Id { get; set; }
        public string Nome { get; set; }
        [DataType(DataType.Date)]
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public CategoriasReceitas Categoria { get; set; }
        [Display(Name ="Categoria")]
        public int CategoriaId { get; set; }
    }
}
