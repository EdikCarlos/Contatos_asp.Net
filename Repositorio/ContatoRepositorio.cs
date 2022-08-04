using Lista_Contatos.Data;
using Lista_Contatos.Models;

namespace Lista_Contatos.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;

        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public List<ContatoModel> SearchAll()
        {
            return _bancoContext.Contatos.ToList();
        }
        public ContatoModel Add(ContatoModel contato)
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public ContatoModel ContactById(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public ContatoModel Change(ContatoModel contato)
        {
            ContatoModel contatoDB = ContactById(contato.Id);

            if (contatoDB == null) throw new Exception("Houve um erro!");

            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Telefone = contato.Telefone;

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
        }

        public bool Remove(int id)
        {
            ContatoModel contatoDB = ContactById(id);

            if (contatoDB == null) throw new Exception("Houve um erro!");

            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();
            return true;
        }
    }
}
