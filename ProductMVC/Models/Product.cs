using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductMVC.Models
{
    public class Product
    {
        public Product(int id, string nome, string fabricante, string codigoBarras, decimal preco, int estoque)
        {
            Id = id;
            Nome = nome;
            Fabricante = fabricante;
            CodigoBarras = codigoBarras;
            Preco = preco;
            Estoque = estoque;
        }

        //public ou protected nesse caso?
        public Product() { }

        public int Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Fabricante { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string CodigoBarras { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public int Estoque { get; set; }



    }
}
