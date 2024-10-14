using KidsFashion.Dominio;
using KidsFashion.Persistencia.Extensoes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KidsFashion.Persistencia
{
    public abstract class RepositorioAbstratoCadastro<TEntidade, TContexto> : RepositorioAbstrato<TEntidade?, TContexto>, IRepositorioCadastro<TEntidade?>
        where TEntidade : EntidadeComId?
        where TContexto : PersistContext?
    {
        public RepositorioAbstratoCadastro()
        {
        }

        public RepositorioAbstratoCadastro(DbConnection conexao) : base(conexao)
        {
        }

        protected abstract string Tabela { get; }

        public virtual async Task Adicionar(TEntidade entidade)
        {
            await DbSet.AddAsync(entidade);
        }

        public virtual async Task Atualizar(TEntidade entidade)
        {
            try
            {
                await Task.Run(() =>
                {
                    DbSet.Update(entidade);
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<IEnumerable<TEntidade>> ObterTodos(bool rastrear = false)
        {
            return await DbSet.Rastrear(rastrear).ToListAsync();
        }

        public async virtual Task<TEntidade> Obter(Expression<Func<TEntidade, bool>> predicate, bool rastrear = false)
        {
            return await DbSet.Rastrear(rastrear).FirstOrDefaultAsync(predicate);
        }

        public async virtual Task<IEnumerable<TEntidade>> ObterTodosFiltro(Expression<Func<TEntidade, bool>> condition, bool rastrear = false)
        {
            IQueryable<TEntidade> query = DbSet.Rastrear(rastrear);

            if (condition != null)
            {
                query = query.Where(condition);
            }

            return await query.ToListAsync();
        }

        public virtual Task Remover(TEntidade item)
        {
            return Task.Run(() => DbSet.Remove(item));
        }

        public virtual async Task<IEnumerable<TEntidade>> ObterTodosCompletoRastreamento()
        {
            return await DbSet.Rastrear(true).ToListAsync();
        }

        public async Task<int> AdicionarRetornarID(TEntidade? entidade)
        {
            try
            {
                await DbSet.AddAsync(entidade);
                await SaveChanges();
                return entidade.Id.Value;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            // O ID da entidade será preenchido automaticamente pelo Entity Framework após a inserção.
        }
    }
}
