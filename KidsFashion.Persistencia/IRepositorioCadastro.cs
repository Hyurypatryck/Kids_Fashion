using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KidsFashion.Persistencia
{
    public interface IRepositorioCadastro<TEntidade> : IRepositorio
    {
        Task Adicionar(TEntidade entidade);
        Task Atualizar(TEntidade entidade);
        Task Remover(TEntidade item);
        Task<int> SaveChanges();
        Task<TEntidade> Obter(Expression<Func<TEntidade, bool>> predicate, bool rastrear = false);
        Task<IEnumerable<TEntidade>> ObterTodos(bool rastrear = false);
        Task<IEnumerable<TEntidade>> ObterTodosFiltro(Expression<Func<TEntidade, bool>> predicate, bool rastrear = false);
        Task<IEnumerable<TEntidade>> ObterTodosCompletoRastreamento();
        Task<int> AdicionarRetornarID(TEntidade entidade);
    }
}
