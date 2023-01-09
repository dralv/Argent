using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Despesa
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public CategoriasDespesas? Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}
