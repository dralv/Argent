using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositorios
{
    public class CategoriaReceitaRepository : ICategoriaReceitaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaReceitaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CategoriasReceitas> AtualizarCategoriaReceita(CategoriasReceitas categoriasReceitas)
        {
            _context.CategoriasReceitas.Update(categoriasReceitas);
            await _context.SaveChangesAsync();
            return categoriasReceitas;
        }

        public async Task<CategoriasReceitas> CriarCategoriaReceita(CategoriasReceitas categoriasReceitas)
        {
            _context.CategoriasReceitas.Add(categoriasReceitas);
            await _context.SaveChangesAsync();
            return categoriasReceitas;
        }

        public async Task<CategoriasReceitas> DeletarCategoriaReceita(CategoriasReceitas categoriasReceitas)
        {
            _context.CategoriasReceitas.Remove(categoriasReceitas);
            await _context.SaveChangesAsync();
            return categoriasReceitas;
        }

        public async Task<CategoriasReceitas> RecuperarCategoriaReceitaPorId(int id)
        {
            return await _context.CategoriasReceitas.FindAsync(id);
        }

        public async Task<IEnumerable<CategoriasReceitas>> RecuperarCategoriasReceitas()
        {
            return await _context.CategoriasReceitas.ToListAsync();
        }
    }
}
