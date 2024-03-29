﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fenix.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }

        [ForeignKey("cidadeId")]
        public Cidade Cidade { get; set; }
        public string Cep { get; set;}
        public string Telefone { get; set; }
    }
}
