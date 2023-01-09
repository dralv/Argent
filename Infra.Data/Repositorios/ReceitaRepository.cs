using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositorios
{
    public class ReceitaRepository : IReceitaRepository
    {
        private readonly AppDbContext _context;

        public ReceitaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Receita> CriarReceita(Receita receita)
        {
            _context.Receitas.Add(receita);
            await _context.SaveChangesAsync();
            return receita;
        }

        public async Task<IEnumerable<Receita>> RecuperarReceita()
        {
            return await _context.Receitas.ToListAsync();
        }

        public async Task<Receita> RecuperarReceitaPorId(int id)
        {
            return await _context.Receitas.FindAsync(id);
        }

        public async Task<Receita> AtualizarReceita(Receita receita)
        {
            _context.Receitas.Update(receita);
            await _context.SaveChangesAsync();
            return receita;
        }
       
        public async Task<Receita> DeletarReceita(Receita receita)
        {
            _context.Receitas.Remove(receita);
            await _context.SaveChangesAsync();
            return receita;
        }
    }
}
