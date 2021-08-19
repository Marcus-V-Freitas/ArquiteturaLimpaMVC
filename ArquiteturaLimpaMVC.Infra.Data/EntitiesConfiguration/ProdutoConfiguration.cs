using ArquiteturaLimpaMVC.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArquiteturaLimpaMVC.Infra.Data.EntitiesConfiguration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Descricao)
                    .HasMaxLength(200)
                    .IsRequired();

            builder.Property(x => x.Preco)
                   .HasPrecision(10, 2);

            builder.HasOne(x => x.Categoria)
                   .WithMany(x => x.Produtos)
                   .HasForeignKey(x => x.CategoriaId);
        }
    }
}
