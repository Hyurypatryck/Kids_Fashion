using KidsFashion.Dominio;
using KidsFashion.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KidsFashion.Servicos.Interfaces
{
    public abstract class ServicoAbstratoDeCadastro<TEntidade, TRepositorio, TContexto> : IServicoDeCadastro<TEntidade>
        where TEntidade : EntidadeComId
        where TRepositorio : RepositorioAbstratoCadastro<TEntidade, TContexto>
        where TContexto : PersistContext
    {
        public virtual async Task Adicionar(TEntidade entidade)
        {
            using (var repositorio = CrieRepositorio())
            {
                await repositorio.Adicionar(entidade);
                await repositorio.SaveChanges();
            }
        }

        public async Task Atualizar(TEntidade entidade)
        {
            using (var repositorio = CrieRepositorio())
            {
                await repositorio.Atualizar(entidade);
                await repositorio.SaveChanges();
            }
        }

        public async Task Remover(TEntidade item)
        {
            using (var repositorio = CrieRepositorio())
            {
                await repositorio.Remover(item);
                await repositorio.SaveChanges();
            }
        }
        public async virtual Task<IEnumerable<TEntidade>> ObterTodos()
        {
            using (var repositorio = CrieRepositorio())
            {
                return await repositorio.ObterTodos();
            }
        }

        public async virtual Task<IEnumerable<TEntidade>> ObterTodosFiltro(Expression<Func<TEntidade, bool>> predicate, bool rastrear = false)
        {
            using (var repositorio = CrieRepositorio())
            {
                return await repositorio.ObterTodosFiltro(predicate, rastrear);
            }
        }

        public TRepositorio CrieRepositorio()
        {
            var tipo = typeof(TRepositorio);
            return (TRepositorio)Activator.CreateInstance(tipo);
        }

        public async Task<IEnumerable<TEntidade>> ObterTodosCompletoRastreamento()
        {
            using (var repositorio = CrieRepositorio())
            {
                return await repositorio.ObterTodosCompletoRastreamento();
            }
        }

        public async Task<int> AdicionarRetornarID(TEntidade entidade)
        {
            using (var repositorio = CrieRepositorio())
            {
                return await repositorio.AdicionarRetornarID(entidade);
            }
        }
    }
}
