using KidsFashion.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFashion.Persistencia.Repositorios
{
    public class RepositorioCategoria : RepositorioAbstratoCadastro<Categoria, PersistContext>
    {
        protected override string Tabela => "Categoria";
    }
}
