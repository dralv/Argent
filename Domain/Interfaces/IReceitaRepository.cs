using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IReceitaRepository
    {
        Task<Receita> CriarReceita(Receita receita);
        Task<IEnumerable<Receita>> RecuperarReceita();
        Task<Receita> RecuperarReceitaPorId(int id);
        Task<Receita> AtualizarReceita(Receita receita);
        Task<Receita> DeletarReceita(Receita receita);
    }
}
