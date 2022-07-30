using Microsoft.AspNetCore.Mvc;

namespace codigonaveia.academias.Application.Controllers
{
    public class ProfessoresController : Controller
    {
        public IActionResult MostrarListaProfessores()
        {
            return View();
        }
    }
}
