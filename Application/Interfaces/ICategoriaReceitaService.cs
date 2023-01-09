using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICategoriaReceitaService
    {
        Task CadastrarCategoriaReceita(CategoriaReceitaDTO categoriaReceitaDTO);
        Task<IEnumerable<CategoriaReceitaDTO>> RecuperarCategoriasReceitas();
        Task<CategoriaReceitaDTO> RecuperarCategoriaReceitaPorId(int id);
        Task AtualizarCateriaReceita(CategoriaReceitaDTO categoriaReceitaDTO);
        Task RemoverCategoriaReceita(int id);
    }
}
