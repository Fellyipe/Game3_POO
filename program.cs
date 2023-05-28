using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using MySql.Data;
using MySql.Data.MySqlClient;

// Entidades


// Implementação do repositório utilizando ADO.NET

/*
Desafio de e-commerce de pedidos
procure aplicar tudo que foi apresentado até o momento
1.Crie duas entidades: Pedido e ItemPedido.

A entidade Pedido deve conter os seguintes atributos:
•Id (chave primária)
•Data do pedido
•Cliente (pode ser apenas um nome)
•Status do pedido (por exemplo, Pendente, Pago, Enviado, Entregue)

A entidade ItemPedido deve conter os seguintes atributos:
•Id (chave primária)
•Produto (utilize a entidade Produto que já criamos)
•Quantidade
•Preço unitário
•Pedido (uma referência ao Pedido ao qual o item pertence)
2.Crie as interfaces de repositório IPedidoRepository e IItemPedidoRepository com os métodos 
necessários para realizar as operações CRUD.
3.Implemente as interfaces de repositório criadas no passo 2, utilizando o SQL Server (ou 
outro banco, menos o SQLite) e fazendo uso exclusivamente do ADO.NET para interagir com o 
banco de dados. Ajuste as instruções de conexão e as consultas SQL de acordo com o banco de 
dados escolhido.
4.Crie uma classe de serviço chamada GerenciamentoDePedidos que utilize os repositórios 
criados nos passos 2 e 3. Esta classe deve ter métodos para:
•Criar um novo pedido
•Adicionar itens a um pedido
•Atualizar o status de um pedido
•Remover um pedido
•Listar pedidos por cliente, status ou data
•Calcular o valor total de um pedido
5.Aplique o conceito de injeção de dependência para injetar as implementações dos 
repositórios na classe GerenciamentoDePedidos.

Ao concluir este desafio, você terá implementado um sistema básico de gerenciamento de 
pedidos para um e-commerce, aplicando os conceitos de Domain-Driven Design, Repository e 
injeção de dependência. Além disso, você terá praticado o uso de um banco de dados diferente 
do SQLite para armazenar os dados das entidades.
*/


/* ------------- ALUNOS -------------------
ÍSIS YASMIM
GUILHERME FAVERO
FELIPE BUENO
*/
using Gamificacao3;
using Gamificacao3.Interfaces;


namespace Gamificacao3
{
    class Program
    {
        public static void Main(string[] args)
        {


            string connectionString = "server=localhost;database=nome_do_banco_de_dados;user=root;password=senha;";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Conexão com o banco de dados estabelecida com sucesso.");

                    // Realize as operações desejadas no banco de dados aqui

                    connection.Close();
                    Console.WriteLine("Conexão com o banco de dados encerrada.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao conectar ao banco de dados: " + ex.Message);
                }
            }











            Console.WriteLine("Hello World!");
        }
    }
}