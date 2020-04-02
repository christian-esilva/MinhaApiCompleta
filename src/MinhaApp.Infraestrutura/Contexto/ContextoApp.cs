using Microsoft.EntityFrameworkCore;
using MinhaApp.Negocios.Entidades;
using System.Linq;

namespace MinhaApp.Infraestrutura.Contexto
{
    public class ContextoApp : DbContext
    {
        public ContextoApp(DbContextOptions opcoes) : base(opcoes)
        {

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //propriedades de texto não mapeadas serão criadas como varchar(100)
            foreach (var prop in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
                prop.Relational().ColumnType = "varchar(100)";

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextoApp).Assembly);

            //evitar exclusão cascata
            foreach (var relacionamento in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relacionamento.DeleteBehavior = DeleteBehavior.ClientSetNull;

        }
    }
}
