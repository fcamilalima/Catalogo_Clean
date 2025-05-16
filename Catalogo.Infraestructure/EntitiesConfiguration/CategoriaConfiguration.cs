using Catalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogo.Infraestructure.EntitiesConfiguration;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        builder.HasKey(c => c.ID);
        builder.Property(c => c.Nome).HasMaxLength(100).IsRequired();
        builder.Property(c => c.ImagemURL).HasMaxLength(100).IsRequired();

        builder.HasData(
            new Categoria(1, "Material Escolar", "material1.jpg"),
            new Categoria(2, "Eletrônicos", "eletronicos.jpg"),
            new Categoria(3, "Acessórios", "acessorios.jpg")
        );
    }
}
