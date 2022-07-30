using Microsoft.AspNetCore.Mvc;

namespace codigonaveia.academias.Application.Controllers
{
    public class FinanceiroController : Controller
    {
        public IActionResult ListaDebitosPendentes()
        {
            return View();
        }
    }
}
