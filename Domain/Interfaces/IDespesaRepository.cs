using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IDespesaRepository
    {
        Task<Despesa> CriarDespesa(Despesa despesa);
        Task<IEnumerable<Despesa>> RecuperarDespesas();
        Task<Despesa> RecuperarDespesaPorId(int id);
        Task<Despesa> AtualizarDespesa(Despesa despesa);
        Task<Despesa> DeletarDespesa(Despesa despesa);
    }
}
