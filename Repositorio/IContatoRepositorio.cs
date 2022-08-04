using Lista_Contatos.Models;

namespace Lista_Contatos.Repositorio
{
    public interface IContatoRepositorio
    {
        ContatoModel ContactById(int id);
        List<ContatoModel> SearchAll();
        ContatoModel Add(ContatoModel contato);
        ContatoModel Change(ContatoModel contato);

        bool Remove(int id);
    }
}
