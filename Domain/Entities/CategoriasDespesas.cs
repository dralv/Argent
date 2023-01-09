using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CategoriasDespesas
    {
        private int v1;
        private string v2;

        public CategoriasDespesas(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Despesa> Despesas{ get; set; }
    }
}
