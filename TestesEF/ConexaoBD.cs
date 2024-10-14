using KidsFashion.Dominio;
using KidsFashion.Servicos.CadastrosBasicos;
using Microsoft.VisualStudio.TestPlatform.PlatformAbstractions;
using System.Linq.Expressions;

namespace TestesEF
{
    [TestClass]
    public class ConexaoBD
    {
        [TestMethod]
        public async void PrimeiroTeste()
        {
            try
            {
                var servico = new ServicoCategoria();

                var categoria = new Categoria
                {
                    Descricao = "Categoria Infantil"
                };

                await servico.Adicionar(categoria);

            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}