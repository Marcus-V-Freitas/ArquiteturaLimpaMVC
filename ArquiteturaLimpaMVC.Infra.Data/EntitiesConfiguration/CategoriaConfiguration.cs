using ArquiteturaLimpaMVC.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArquiteturaLimpaMVC.Infra.Data.EntitiesConfiguration
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome)
                    .HasMaxLength(100)
                    .IsRequired();

            builder.HasData(
                new Categoria(1, "Material Escolar"),
                new Categoria(2, "Eletrônicos"),
                new Categoria(3, "Acessórios"));
        }
    }
}