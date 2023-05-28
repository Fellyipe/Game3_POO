using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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

public class Pedido
{
    public int Id { get; private set; }
    public DateTime Data { get; private set; }
    public string Cliente { get; private set; }
    public string Status { get; private set; }
    public List<ItemPedido> Itens { get; private set; }

    public Pedido(int id, DateTime Data, string cliente, string status)
    {
        Id = id;
        Data = Data;
        Cliente = cliente;
        Status = status;
        Itens = new List<ItemPedido>();
    }
}

public class ItemPedido
{
    public int Id { get; private set; }
    public Produto Produto { get; private set; }
    public int Quantidade { get; private set; }
    public decimal PrecoUnitario { get; private set; }
    public Pedido Pedido { get; private set; }

    public ItemPedido(int id, Produto produto, int quantidade, decimal precoUnitario, Pedido pedido)
    {
        Id = id;
        Produto = produto;
        Quantidade = quantidade;
        PrecoUnitario = precoUnitario;
        Pedido = pedido;
    }
}

public interface IPedidoRepository
{
    Pedido GetById(int id);
    void Create(Pedido pedido);
    void Update(Pedido pedido);
    void Delete(int id);
    List<Pedido> GetByCliente(string cliente);
    List<Pedido> GetByStatus(string status);
    List<Pedido> GetByData(DateTime data);
}

public interface IItemPedidoRepository
{
    ItemPedido GetById(int id);
    void Create(ItemPedido itemPedido);
    void Update(ItemPedido itemPedido);
    void Delete(int id);
}





public class Program
{
    static void Main(string[] args)
    {
        // Exemplo de uso
        var connectionString = "your_connection_string";
        var pedidoRepository = new PedidoRepository(connectionString);
        var itemPedidoRepository = new ItemPedidoRepository(connectionString);

        var gerenciamentoDePedidos = new GerenciamentoDePedidos(pedidoRepository, itemPedidoRepository);

        // Criar um novo pedido
        gerenciamentoDePedidos.CriarPedido(DateTime.Now, "João", "Pendente");

        // Adicionar itens a um pedido
        gerenciamentoDePedidos.AdicionarItemPedido(1, 1, 2, 10.99m);
        gerenciamentoDePedidos.AdicionarItemPedido(1, 2, 1, 20.99m);

        // Atualizar o status de um pedido
        gerenciamentoDePedidos.AtualizarStatusPedido(1, "Pago");

        // Remover um pedido
        gerenciamentoDePedidos.RemoverPedido(1);

        // Listar pedidos por cliente, status ou data
        var pedidosCliente = gerenciamentoDePedidos.ListarPedidosPorCliente("João");
        var pedidosStatus = gerenciamentoDePedidos.ListarPedidosPorStatus("Pendente");
        var pedidosData = gerenciamentoDePedidos.ListarPedidosPorData(DateTime.Now);

        // Calcular o valor total de um pedido
        var valorTotalPedido = gerenciamentoDePedidos.CalcularValorTotalPedido(1);
    }
}
