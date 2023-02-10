using Fenix.Enum;

namespace Fenix.Models
{
    public class Cidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public UF UF { get; set; }

        public Cidade(int id, string nome, UF uf) 
        { 
            Id = id;
            Nome = nome;
            UF = uf;
        }
    }
}
