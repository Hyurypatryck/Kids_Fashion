using KidsFashion.Dominio;
using KidsFashion.Persistencia.Extensoes;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KidsFashion.Persistencia.Repositorios
{
    public class RepositorioFornecedor : RepositorioAbstratoCadastro<Fornecedor, PersistContext>
    {
        protected override string Tabela => "Fornecedor";

        public override async Task<IEnumerable<Fornecedor?>> ObterTodosCompletoRastreamento()
        {
            return await DbSet
                .Rastrear(true)
                .Include(m => m.Endereco)
                 .ThenInclude(m => m.Municipio)
                .ToListAsync();
        }

        public async Task RemoverEnderecoPorFornecedorId(long fornecedorId)
        {
            var sql = "DELETE FROM Endereco WHERE Id = (SELECT Endereco_Id FROM Fornecedor WHERE Id = @FornecedorId);";

            var parameters = new[]
            {
                new SqlParameter("@FornecedorId", fornecedorId)
            };

            await Contexto.Database.ExecuteSqlRawAsync(sql, parameters);
        }

    }
}
