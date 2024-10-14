using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsFashion.Persistencia.Extensoes
{
    public static class ExtensaoDeIQueryable
    {
        public static IQueryable<TEntity> Rastrear<TEntity>(this IQueryable<TEntity> source, bool rastrear = true) where TEntity : class
        {
            return rastrear ? source.AsTracking() : source.AsNoTracking();
        }
    }
}
