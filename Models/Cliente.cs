namespace Fenix.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public Cidade Cidade { get; set; }
        public string Cep { get; set;}
        public string Telefone { get; set; }

        public Cliente(int id, string nome, string endereco, string bairro, Cidade cidade, string cep, string telefone)
        {
            Id = id;
            Nome = nome;
            Endereco = endereco;
            Bairro = bairro;
            Cidade = cidade;
            Cep = cep;
            Telefone = telefone;
        }
    }
}
