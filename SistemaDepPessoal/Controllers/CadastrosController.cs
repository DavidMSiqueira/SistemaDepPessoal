using Microsoft.AspNetCore.Mvc;
using SistemaDepPessoal.Models;
using SistemaDepPessoal.Repositorio;

namespace SistemaDepPessoal.Controllers
{
    public class CadastrosController : Controller
    {
        private readonly ICadastroRepositorio _cadastroRepositorio;
        public CadastrosController(ICadastroRepositorio cadastroRepositorio)
        {
            _cadastroRepositorio = cadastroRepositorio;
        }

        public IActionResult Index()
        {
            var cadastros = _cadastroRepositorio.BuscarTodos();
            return View(cadastros);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            CadastroModel cadastro = _cadastroRepositorio.ListarPorId(id);
            return View(cadastro);
        }

        public IActionResult ApagarConfirmacao(int id)
        {
            CadastroModel cadastro = _cadastroRepositorio.ListarPorId(id);

            return View(cadastro);
        }

        [HttpGet]
        public IActionResult Apagar(int id)
        {
            _cadastroRepositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(CadastroModel cadastro)
        {
            _cadastroRepositorio.Adicionar(cadastro);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Alterar(CadastroModel cadastro)
        {
            _cadastroRepositorio.Atualizar(cadastro);
            return RedirectToAction("Index");
        }
    }
}
