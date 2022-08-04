using Lista_Contatos.Models;
using Lista_Contatos.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Lista_Contatos.Controllers
{
    public class ContatosController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatosController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
        public IActionResult Index()
        {
            var contatos = _contatoRepositorio.SearchAll();
            return View(contatos);
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Edit(int id)
        {
            ContatoModel contato = _contatoRepositorio.ContactById(id);
            return View(contato);
        }

        public IActionResult DeleteModal()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ContatoModel contato)
        {
            _contatoRepositorio.Add(contato);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Att(ContatoModel contato)
        {
            _contatoRepositorio.Change(contato);
            return RedirectToAction("Index");
        }
    }
}
