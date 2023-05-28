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
        private int _id;
        private string _nome;
        private string _descricao;
        private decimal _preco;
        private int _quantidadeEmEstoque;
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
            _id = id;
            _nome = nome;
            _descricao = descricao;
            _preco = preco;
            _quantidadeEmEstoque = quantidadeEmEstoque;
        }
    }
}
