using ControleDeCadastros.Data;
using ControleDeCadastros.Models;

namespace ControleDeCadastros.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;

        //Construtor
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        //Buscar toda as informações do banco de dados e listar
        public List<ContatosModel> BuscarContatos()
        {
            return _bancoContext.ContatosTabel.ToList();
        }

        public ContatosModel? ListarID(int? ID)
        {
            var contatos = _bancoContext.ContatosTabel.FirstOrDefault(x => x.Id == ID);

            if (contatos != null)
            {
                return contatos;
            }
            else
            {
                return null;
            }

        }

        //Adicionar contato ao banco
        public ContatosModel Adicionar(ContatosModel contato)
        {
            _bancoContext.ContatosTabel.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public ContatosModel ApagarContato(ContatosModel contato)
        {
            _bancoContext.ContatosTabel.Remove(contato);
            _bancoContext.SaveChanges();
            return contato;
        }


        public ContatosModel AtualizarContato(ContatosModel contato)
        {
            ContatosModel? contatoDB = ListarID(contato.Id) ?? throw new System.Exception("Houve um erro na atualização do contato");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;

            _bancoContext.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
        }

        public bool ApagarContato(int? ID)
        {
            ContatosModel? contatoDB = ListarID(ID) ?? throw new System.Exception("Houve um erro em deletar o contato");

            _bancoContext.ContatosTabel.Remove(contatoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
