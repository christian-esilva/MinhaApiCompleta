using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaApp.Negocios.Entidades;

namespace MinhaApp.Infraestrutura.Mapeamentos
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(p => p.Descricao)
            .IsRequired()
            .HasColumnType("varchar(300)");

            builder.Property(p => p.Imagem)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.Valor).HasColumnType("decimal(18,2)");

            builder.ToTable("Produto");
        }
    }
}
