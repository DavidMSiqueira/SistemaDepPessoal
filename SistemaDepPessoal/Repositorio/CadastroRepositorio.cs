using SistemaDepPessoal.Data;
using SistemaDepPessoal.Models;

namespace SistemaDepPessoal.Repositorio
{
    public class CadastroRepositorio : ICadastroRepositorio
    {
        private readonly DataContext _context;

        public CadastroRepositorio(DataContext dataContext)
        {
            this._context = dataContext;
        }

        public CadastroModel ListarPorId(int id)
        {
            return _context.Cadastros.FirstOrDefault(predicate: x => x.Id == id);
        }

        public List<CadastroModel> BuscarTodos()
        {
            return _context.Cadastros.ToList();
        }

        public CadastroModel Adicionar(CadastroModel cadastro)
        {
            //Gravar no banco de dados
            _context.Cadastros.Add(cadastro);
            _context.SaveChanges();

            return cadastro;
        }

        public CadastroModel Atualizar(CadastroModel cadastro)
        {
            CadastroModel cadastroDB = ListarPorId(cadastro.Id);

            if (cadastroDB == null) throw new System.Exception("Houvem um erro na atualização do cadastro");

            cadastroDB.Name = cadastro.Name;
            cadastroDB.Last_Name = cadastro.Last_Name;
            cadastroDB.CPF = cadastro.CPF;
            cadastroDB.Cargo = cadastro.Cargo;
            cadastroDB.Setor = cadastro.Setor;
            cadastroDB.Idade = cadastro.Idade;
            cadastroDB.Salario = cadastro.Salario;

            _context.Cadastros.Update(cadastroDB);
            _context.SaveChanges();

            return cadastroDB;
        }
    }
}