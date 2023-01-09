using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICategoriaDespesaService
    {
        Task CadastraCategoriaDespesa(CategoriaDespesaDTO categoriaDespesaDTO);
        Task<IEnumerable<CategoriaDespesaDTO>> RecuperarCategoriasDespesas();
        Task<CategoriaDespesaDTO> RecuperarCategoriasDespesasPorId(int id);
        Task AtualizarCategoriaDespesa(CategoriaDespesaDTO categoriaDespesaDTO);
        Task RemoverCategoriaDespesa(int id);
    }
}
