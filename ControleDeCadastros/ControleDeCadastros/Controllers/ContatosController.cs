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
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.AtualizarContato(contato);
                    TempData["MensagemSucesso"] = "Alterações feitas com sucesso";
                    return RedirectToAction("Index");
                }

                return View("Editar", contato);
            }
            catch (System.Exception error)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro ao fazer alterações: {error.Message}";
                return RedirectToAction("Index");
            }
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
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(NovoContato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";

                    return RedirectToAction("Index");
                }

                return View(NovoContato);

            }
            catch (System.Exception error)
            {

                TempData["MensagemErro"] = $"Algo deu errado, detalhes do problema{error.Message}";
                return RedirectToAction("Index");
            }

        }

        // [HttpDelete]
        public IActionResult ApagarContato(int ID)
        {
            try
            {
                _contatoRepositorio.ApagarContato(ID);
                TempData["MensagemSucesso"] = "Contato removido com sucesso";
                return RedirectToAction("Index");
            }
            catch (System.Exception error)
            {
                TempData["MensagemErro"] = $"Ocorreu um erro ao apagar o contato: {error.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
