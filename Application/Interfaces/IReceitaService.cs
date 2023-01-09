using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IReceitaService
    {
        Task CadastrarReceita(ReceitaDTO receitaDTO);
        Task<IEnumerable<ReceitaDTO>> RecuperarReceitas();
        Task<ReceitaDTO> RecuperarReceitaPorId(int id);
        Task AtualizarReceita(ReceitaDTO receitaDTO);
        Task DeletarReceita(int id);

    }
}
