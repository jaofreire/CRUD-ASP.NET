using ControleDeCadastros.Models;
using ControleDeCadastros.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeCadastros.Controllers
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
          var contatos = _contatoRepositorio.BuscarContatos();
            return View(contatos);
        }

        public IActionResult Criar()
        {

            return View();
        }

        //Modificar contato
        public IActionResult Editar(int ID)
        {
           ContatosModel? contatos = _contatoRepositorio.ListarID(ID);
            return View(contatos);
        }
        [HttpPost]
        public IActionResult AlterarContato(ContatosModel contato)
        {
            if (ModelState.IsValid)
            {
                _contatoRepositorio.AtualizarContato(contato);
                return RedirectToAction("Index");
            }

            return View("Editar", contato);
        }

        public IActionResult RemoverConfirmar(int ID)
        {
            ContatosModel? contatos = _contatoRepositorio.ListarID(ID);
            return View(contatos);
        }

        //Criar/apagar contato
        [HttpPost]
        public IActionResult Criar(ContatosModel NovoContato)
        {
            if (ModelState.IsValid)
            {
                _contatoRepositorio.Adicionar(NovoContato);
                return RedirectToAction("Index");
            }
            return View(NovoContato);
        }

        // [HttpDelete]
        public IActionResult ApagarContato(int ID)
        {
            _contatoRepositorio.ApagarContato(ID);
            return RedirectToAction("Index");
        }
    }
}
