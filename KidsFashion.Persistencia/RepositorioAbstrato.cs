using KidsFashion.Dominio;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFashion.Persistencia
{
    public abstract class RepositorioAbstrato<TEntidade, TContexto> : IRepositorio, IDisposable
        where TEntidade : EntidadeComId?
        where TContexto : PersistContext
    {
        public readonly DbContext Contexto;
        public DbSet<TEntidade> DbSet;

        public RepositorioAbstrato()
        {
            Contexto = Activator.CreateInstance<TContexto>();
            DbSet = Contexto.Set<TEntidade>();
        }

        public RepositorioAbstrato(DbConnection conexao)
        {
            Contexto = (TContexto)Activator.CreateInstance(typeof(TContexto), conexao);
            DbSet = Contexto.Set<TEntidade>();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return Contexto.Database.BeginTransaction();
        }

        public void UseTransaction(IDbContextTransaction transacao)
        {
            Contexto.Database.UseTransaction(transacao.GetDbTransaction());
        }

        public DbConnection GetDbConnection()
        {
            return Contexto.Database.GetDbConnection();
        }

        public async Task<int> SaveChanges()
        {
            try
            {
                return await Contexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Dispose()
        {
            Contexto.Dispose();
        }
    }
}
