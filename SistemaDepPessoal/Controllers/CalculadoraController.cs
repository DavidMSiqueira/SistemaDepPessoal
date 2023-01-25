using Microsoft.AspNetCore.Mvc;

namespace SistemaDepPessoal.Controllers
{
    public class CalculadoraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
