using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ICategoriaReceitaRepository
    {
        Task<CategoriasReceitas> CriarCategoriaReceita(CategoriasReceitas categoriasReceitas);
        Task<IEnumerable<CategoriasReceitas>> RecuperarCategoriasReceitas();
        Task<CategoriasReceitas> RecuperarCategoriaReceitaPorId(int id);
        Task<CategoriasReceitas> AtualizarCategoriaReceita(CategoriasReceitas categoriasReceitas);
        Task<CategoriasReceitas> DeletarCategoriaReceita(CategoriasReceitas categoriasReceitas);
    }
}
