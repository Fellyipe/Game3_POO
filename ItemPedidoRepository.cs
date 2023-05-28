using Gamificacao3;
using Gamificacao3.Interfaces;
using MySql.Data;
using MySql.Data.MySqlClient;

public class ItemPedidoRepository : IItemPedidoRepository
{
    private readonly string connectionString;

    public ItemPedidoRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public ItemPedido GetById(int id)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT * FROM ItensPedido WHERE Id = @Id";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var itemPedidoId = reader.GetInt32(0);
                        var produtoId = reader.GetInt32(1);
                        var quantidade = reader.GetInt32(2);
                        var precoUnitario = reader.GetDecimal(3);
                        var pedidoId = reader.GetInt32(4);

                        var produtoRepository = new ProdutoRepository(connectionString);
                        var produto = produtoRepository.GetById(produtoId);

                        var pedidoRepository = new PedidoRepository(connectionString);
                        var pedido = pedidoRepository.GetById(pedidoId);

                        return new ItemPedido(itemPedidoId, produto, quantidade, precoUnitario, pedido);
                    }
                }
            }
        }
        return null;
    }

    public void Create(ItemPedido itemPedido)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "INSERT INTO ItensPedido (ProdutoId, Quantidade, PrecoUnitario, PedidoId) VALUES (@ProdutoId, @Quantidade, @PrecoUnitario, @PedidoId); SELECT SCOPE_IDENTITY();";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProdutoId", itemPedido.Produto.Id);
                command.Parameters.AddWithValue("@Quantidade", itemPedido.Quantidade);
                command.Parameters.AddWithValue("@PrecoUnitario", itemPedido.PrecoUnitario);
                command.Parameters.AddWithValue("@PedidoId", itemPedido.Pedido.Id);

                itemPedido.Id = Convert.ToInt32(command.ExecuteScalar());
            }
        }
    }

    public void Update(ItemPedido itemPedido)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "UPDATE ItensPedido SET ProdutoId = @ProdutoId, Quantidade = @Quantidade, PrecoUnitario = @PrecoUnitario, PedidoId = @PedidoId WHERE Id = @Id";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ProdutoId", itemPedido.Produto.Id);
                command.Parameters.AddWithValue("@Quantidade", itemPedido.Quantidade);
                command.Parameters.AddWithValue("@PrecoUnitario", itemPedido.PrecoUnitario);
                command.Parameters.AddWithValue("@PedidoId", itemPedido.Pedido.Id);
                command.Parameters.AddWithValue("@Id", itemPedido.Id);

                command.ExecuteNonQuery();
            }
        }
    }

    public void Delete(int id)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "DELETE FROM ItensPedido WHERE Id = @Id";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}