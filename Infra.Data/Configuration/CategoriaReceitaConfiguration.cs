using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Configuration
{
    public class CategoriaReceitaConfiguration : IEntityTypeConfiguration<CategoriasReceitas>
    {
        public void Configure(EntityTypeBuilder<CategoriasReceitas> builder)
        {
            builder.HasData(
                new CategoriasReceitas(1, "Salário"),
                new CategoriasReceitas(2, "Vale Alimentação")
                );
        }
    }
}
