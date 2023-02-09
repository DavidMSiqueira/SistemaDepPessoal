namespace SistemaDepPessoal.Models
{
    public class CadastroModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Last_Name { get; set; }
        public string CPF { get; set; }
        public string Cargo { get; set; }
        public string Setor { get; set; }
        public int Idade { get; set; }
        public double Salario { get; set; }
    }
}
