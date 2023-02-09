using Microsoft.EntityFrameworkCore;
using SistemaDepPessoal.Models;

namespace SistemaDepPessoal.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<CadastroModel> Cadastros { get; set; }
    }
}
