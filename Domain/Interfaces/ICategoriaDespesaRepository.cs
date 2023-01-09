using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ICategoriaDespesaRepository
    {
        Task<CategoriasDespesas> CriarCategoriaDespesa(CategoriasDespesas categoriasDespesas);
        Task<IEnumerable<CategoriasDespesas>> RecuperarCategoriasDespesas();
        Task<CategoriasDespesas> RecuperarCategoriaDespesaPorId(int id);
        Task<CategoriasDespesas> AtualizarCategoriaDespesa(CategoriasDespesas categoriasDespesas);
        Task<CategoriasDespesas> DeletarCategoriaDespesa(CategoriasDespesas categoriasDespesas);
    }
}
