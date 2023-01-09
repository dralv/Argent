using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Repositorios
{
    public class CategoriaDespesaRepository : ICategoriaDespesaRepository
    {
        private readonly AppDbContext _context;

        public CategoriaDespesaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CategoriasDespesas> CriarCategoriaDespesa(CategoriasDespesas categoriasDespesas)
        {
            _context.CategoriasDespesas.Add(categoriasDespesas);
            await _context.SaveChangesAsync();
            return categoriasDespesas;
        }

        public async Task<IEnumerable<CategoriasDespesas>> RecuperarCategoriasDespesas()
        {
            return await _context.CategoriasDespesas.ToListAsync();
        }

        public async Task<CategoriasDespesas> RecuperarCategoriaDespesaPorId(int id)
        {
            return await _context.CategoriasDespesas.FindAsync(id);
        }

        public async Task<CategoriasDespesas> AtualizarCategoriaDespesa(CategoriasDespesas categoriasDespesas)
        {
            _context.CategoriasDespesas.Update(categoriasDespesas);
            await _context.SaveChangesAsync();
            return categoriasDespesas;
        }

        public async Task<CategoriasDespesas> DeletarCategoriaDespesa(CategoriasDespesas categoriasDespesas)
        {
            _context.CategoriasDespesas.Remove(categoriasDespesas);
            await _context.SaveChangesAsync();
            return categoriasDespesas;
        }
    }
}
