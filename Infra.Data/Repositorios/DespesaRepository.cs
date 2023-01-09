using Domain.Entities;
using Domain.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositorios
{
    public class DespesaRepository : IDespesaRepository
    {
        private readonly AppDbContext _context;
        public DespesaRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Despesa> CriarDespesa(Despesa despesa)
        {
            _context.Despesas.Add(despesa);
            await _context.SaveChangesAsync();
            return despesa;
        }

        public async Task<IEnumerable<Despesa>> RecuperarDespesas()
        {
            return await _context.Despesas.ToListAsync();
        }

        public async Task<Despesa> RecuperarDespesaPorId(int id)
        {
            return await _context.Despesas
                .Where(d=>d.Id==id)
                .Include(d=>d.Categoria)
                .FirstOrDefaultAsync();
        }

        public async Task<Despesa> AtualizarDespesa(Despesa despesa)
        {
            _context.Despesas.Update(despesa);
            await _context.SaveChangesAsync();
            return despesa;
        }
        public async Task<Despesa> DeletarDespesa(Despesa despesa)
        {
            _context.Despesas.Remove(despesa);
            await _context.SaveChangesAsync();
            return despesa;
        }
    }
}
