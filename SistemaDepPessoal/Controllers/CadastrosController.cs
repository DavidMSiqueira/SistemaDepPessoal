using Microsoft.AspNetCore.Mvc;

namespace SistemaDepPessoal.Controllers
{
    public class CadastrosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
