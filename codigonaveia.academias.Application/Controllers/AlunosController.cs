using codigonaveia.academias.Application.Models;
using codigonaveia.academias.Domain.Entities.Alunos;
using codigonaveia.academias.Domain.Intefaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;

namespace codigonaveia.academias.Application.Controllers
{
    public class AlunosController : Controller
    {
        private readonly IAlunosRepository _repository;
        private readonly IUsersRepository _usersRepository;

        public AlunosController(IAlunosRepository repository, IUsersRepository usersRepository)
        {
            _repository = repository;
            _usersRepository = usersRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Registrar()
        {
            var user = await _usersRepository.GetAll();
            ViewBag.Alunos = new SelectList(user, "Id", "FirstName");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registrar(AlunosViewModel model, IFormFile FotoAvatar)
        {
            if (ModelState.IsValid)
            {
                if (FotoAvatar == null)
                {
                    ModelState.AddModelError(string.Empty, "Foto é obrigatória");
                }
                else
                {
                    using(MemoryStream ms = new MemoryStream())
                    {
                        FotoAvatar.OpenReadStream().CopyTo(ms);

                        var alunos = new entidadeAlunos
                        {
                            FotoAvatar = ms.ToArray(),
                            DataRegistro = DateTime.Now,
                            CPF = model.CPF,
                            Celular = model.Celular,
                            Email = model.Email,
                            DataNascimento = model.DataNascimento,
                            Cep = model.Cep,
                            Logradouro = model.Logradouro,
                            Bairro = model.Bairro,
                            Cidade = model.Cidade,
                            Uf = model.Uf,
                            Complemento = model.Complemento,
                            UserId = model.UserId

                        };
                        await _repository.Insert(alunos);
                        TempData["Msg"] = "Registro cadastro com sucesso";
                        return RedirectToAction(nameof(Registrar));
                    }
                }

               





            }
            return View(model);
        }
        public IActionResult MostrarListaAlunos()
        {
            return View();
        }
    }
}
