using Microsoft.AspNetCore.Mvc;

namespace codigonaveia.academias.Application.Controllers
{
    public class AlunosController : Controller
    {
        public IActionResult MostrarListaAlunos()
        {
            return View();
        }
    }
}
