using Microsoft.AspNetCore.Mvc;

namespace codigonaveia.academias.Application.Controllers
{
    public class EquipamentosController : Controller
    {
        public IActionResult MostrarListaEquipamentos()
        {
            return View();
        }
    }
}
