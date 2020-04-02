using Microsoft.EntityFrameworkCore;
using MinhaApp.Infraestrutura.Contexto;
using MinhaApp.Negocios.Entidades;
using MinhaApp.Negocios.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MinhaApp.Infraestrutura.Repositorios
{
    public abstract class Repositorio<TEntidade> : IRepositorio<TEntidade> where TEntidade : Entidade, new()
    {
        protected readonly ContextoApp Contexto;
        protected readonly DbSet<TEntidade> DbSet;

        public Repositorio(ContextoApp contexto)
        {
            this.Contexto = contexto;
            this.DbSet = Contexto.Set<TEntidade>();
        }

        public async Task<IEnumerable<TEntidade>> Buscar(Expression<Func<TEntidade, bool>> predicado)
        {
            return await DbSet.AsNoTracking().Where(predicado).ToListAsync();
        }

        public virtual async Task<TEntidade> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntidade>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Adicionar(TEntidade entidade)
        {
            DbSet.Add(entidade);
            await SaveChanges();
        }

        public virtual async Task Atualizar(TEntidade entidade)
        {
            DbSet.Update(entidade);
            await SaveChanges();
        }

        public virtual async Task Remover(Guid id)
        {
            DbSet.Remove(new TEntidade { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Contexto.SaveChangesAsync();
        }

        public void Dispose() => Contexto?.Dispose();
    }
}
