using KidsFashion.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KidsFashion.Servicos.Interfaces
{
    public interface IServicoDeCadastro<TEntidade> : IServico
       where TEntidade : EntidadeComId
    {
        Task Adicionar(TEntidade entidade);
        Task Atualizar(TEntidade entidade);
        Task Remover(TEntidade item);
        Task<IEnumerable<TEntidade>> ObterTodos();
        Task<IEnumerable<TEntidade>> ObterTodosFiltro(Expression<Func<TEntidade, bool>> predicate, bool rastrear = false);
        Task<IEnumerable<TEntidade>> ObterTodosCompletoRastreamento();
        Task<int> AdicionarRetornarID(TEntidade entidade);

    }
}
