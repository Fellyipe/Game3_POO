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

    public ItemPedido? GetById(int id)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT * FROM tb_itempedido WHERE Id = @Id";
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
            var query = "INSERT INTO tb_itempedido (tb_produtoId, Quantidade, PrecoUnitario, tb_pedidoId) VALUES (@tb_produtoId, @Quantidade, @PrecoUnitario, @tb_pedidoId); SELECT LAST_INSERT_ID();";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@tb_produtoId", itemPedido?.Produto?.Id);
                command.Parameters.AddWithValue("@Quantidade", itemPedido?.Quantidade);
                command.Parameters.AddWithValue("@PrecoUnitario", itemPedido?.PrecoUnitario);
                command.Parameters.AddWithValue("@tb_pedidoId", itemPedido?.Pedido?.Id);

                itemPedido.Id = Convert.ToInt32(command.ExecuteScalar());
            }
        }
    }

    public void Update(ItemPedido itemPedido)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "UPDATE tb_itempedido SET tb_produtoId = @tb_produtoId, Quantidade = @Quantidade, PrecoUnitario = @PrecoUnitario, tb_pedidoId = @tb_pedidoId WHERE Id = @Id";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@tb_produtoId", itemPedido?.Produto?.Id);
                command.Parameters.AddWithValue("@Quantidade", itemPedido?.Quantidade);
                command.Parameters.AddWithValue("@PrecoUnitario", itemPedido?.PrecoUnitario);
                command.Parameters.AddWithValue("@tb_pedidoId", itemPedido?.Pedido?.Id);
                command.Parameters.AddWithValue("@Id", itemPedido?.Id);

                command.ExecuteNonQuery();
            }
        }
    }

    public void Delete(int id)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "DELETE FROM tb_itempedido WHERE Id = @Id";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }
}