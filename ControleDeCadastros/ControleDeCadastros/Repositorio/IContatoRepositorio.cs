using ControleDeCadastros.Models;

namespace ControleDeCadastros.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatosModel? ListarID(int? ID);


        List<ContatosModel> BuscarContatos();


        ContatosModel AtualizarContato(ContatosModel contato);

        bool ApagarContato(int? ID);

        ContatosModel Adicionar(ContatosModel contato);
    }
}
