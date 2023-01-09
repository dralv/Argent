using Domain.Entities;
using Infra.Data.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Context
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly); //com essa configuraçõ irá procupar configurações
        }

        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<CategoriasDespesas> CategoriasDespesas { get; set; }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<CategoriasReceitas> CategoriasReceitas { get; set; }
    }
}
