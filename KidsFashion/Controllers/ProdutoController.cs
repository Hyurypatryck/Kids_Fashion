using AutoMapper;
using KidsFashion.Models;
using KidsFashion.Servicos.CadastrosBasicos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace KidsFashion.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly IMapper _mapper;

        public ProdutoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var servicoProduto = new ServicoProduto();

            var produtos = await servicoProduto.ObterTodos();

            var retorno = _mapper.Map<List<ProdutoViewModel>>(produtos);

            return View("Listagem", retorno);
        }

        public async Task<IActionResult> CreateAsync()
        {
            var servicoFornecedor = new ServicoFornecedor();
            var servicoCategoria = new ServicoCategoria();

            var fornecedores = await servicoFornecedor.ObterTodos();
            var categorias = await servicoCategoria.ObterTodos();

            var vm = new ProdutoViewModel
            {
                FornecedorOptions = new SelectList(fornecedores, "Id", "Nome"),
                CategoriaOptions = new SelectList(categorias, "Id", "Descricao")
            };

            return View("Create", vm);
        }

    }
}
