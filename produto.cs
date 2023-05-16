using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamificacao3;

namespace Gamificacao3
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int QuantidadeEmEstoque { get; private set; }
        public Produto(int id, string nome, string descricao, decimal preco, int quantidadeEmEstoque)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
            throw new ArgumentException("Nome do produto não pode ser vazio ou nulo.");
            }
            if (string.IsNullOrWhiteSpace(descricao))
            {
            throw new ArgumentException("Descrição do produto não pode ser vazia ou nula.");
            }
            if (preco <= 0)
            {
            throw new ArgumentException("Preço do produto deve ser maior que zero.");
            }
            if (quantidadeEmEstoque < 0)
            {
            throw new ArgumentException("Quantidade em estoque não pode ser negativa.");
            }
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            QuantidadeEmEstoque = quantidadeEmEstoque;
        }
    }
}
