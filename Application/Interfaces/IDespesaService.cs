using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IDespesaService
    {
        Task CadastrarDespesa(DespesaDTO despesaDTO);
        Task<IEnumerable<DespesaDTO>> RecuperarDespesas();
        Task<DespesaDTO> RecuperarDespesaPorId(int id);
        Task AtualizarDespesa(DespesaDTO despesaDTO);
        Task RemoverDespesa(int id);
    }
}
