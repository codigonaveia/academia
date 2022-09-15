using codigonaveia.academias.Application.Models;
using codigonaveia.academias.Domain.Entities.Alunos;
using codigonaveia.academias.Domain.Intefaces;
using Microsoft.AspNetCore.Mvc;

namespace codigonaveia.academias.Application.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunosRepository _repository;
        public AlunosController(IAlunosRepository repository)
        {
            _repository = repository;
        }
        public IActionResult Registrar()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registrar(AlunosViewModel model)
        {
            if (ModelState.IsValid)
            {
                var alunos = new entidadeAlunos
                {
                    FotoAvatar = model.FotoAvatar,  
                    DataRegistro = DateTime.Now,
                    CPF = model.CPF,
                    Celular = model.Celular,
                    Email = model.Email,
                    DataNascimento = model.DataNascimento

                };

                await _repository.Insert(alunos);
                return RedirectToAction(nameof(Registrar));
            }
            return View();
        }
        public IActionResult MostrarListaAlunos()
        {
            return View();
        }
    }
}
