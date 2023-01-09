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
    public class CategoriaDespesaConfiguration : IEntityTypeConfiguration<CategoriasDespesas>
    {
        public void Configure(EntityTypeBuilder<CategoriasDespesas> builder)
        {
            builder.HasData
                (
                new CategoriasDespesas(1, "Alimentos"),
                new CategoriasDespesas(2, "Eletrônicos")
                );
        }
    }
}
