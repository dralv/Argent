using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Data.Configuration
{
    public class ReceitasConfiguration : IEntityTypeConfiguration<Receita>
    {
        public void Configure(EntityTypeBuilder<Receita> builder)
        {
            builder
                .HasOne(r => r.Categoria)
                .WithMany(c => c.Receitas)
                .HasForeignKey(r => r.CategoriaId);
        }
    }
}
