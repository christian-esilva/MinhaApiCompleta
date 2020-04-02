using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MinhaApp.Negocios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhaApp.Infraestrutura.Mapeamentos
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Logradouro)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(e => e.Numero)
                .IsRequired()
                .HasColumnType("varchar(30)");

            builder.Property(e => e.Cep)
                .IsRequired()
                .HasColumnType("varchar(8)");

            builder.Property(e => e.Cidade)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(e => e.Estado)
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(e => e.Bairro)
                .IsRequired()
                .HasColumnType("varchar(150)");

            builder.Property(e => e.Complemento)
                .HasColumnType("varchar(50)");

            builder.ToTable("Endereco");
        }
    }
}
