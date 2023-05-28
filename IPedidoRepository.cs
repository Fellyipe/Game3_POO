using Gamificacao3;
using Gamificacao3.Interfaces;

public class PedidoRepository : IPedidoRepository
{
    private readonly string connectionString;

    public PedidoRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public Pedido GetById(int id)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT * FROM Pedidos WHERE Id = @Id";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var pedidoId = reader.GetInt32(0);
                        var Data = reader.GetDateTime(1);
                        var cliente = reader.GetString(2);
                        var status = reader.GetString(3);

                        return new Pedido(pedidoId, Data, cliente, status);
                    }
                }
            }
        }
        return null;
    }

    public void Create(Pedido pedido)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var query = "INSERT INTO Pedidos (Data, Cliente, Status) VALUES (@Data, @Cliente, @Status); SELECT SCOPE_IDENTITY();";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Data", pedido.Data);
                command.Parameters.AddWithValue("@Cliente", pedido.Cliente);
                command.Parameters.AddWithValue("@Status", pedido.Status);

                pedido.Id = Convert.ToInt32(command.ExecuteScalar());
            }
        }
    }

    public void Update(Pedido pedido)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var query = "UPDATE Pedidos SET Data = @Data, Cliente = @Cliente, Status = @Status WHERE Id = @Id";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Data", pedido.Data);
                command.Parameters.AddWithValue("@Cliente", pedido.Cliente);
                command.Parameters.AddWithValue("@Status", pedido.Status);
                command.Parameters.AddWithValue("@Id", pedido.Id);

                command.ExecuteNonQuery();
            }
        }
    }

    public void Delete(int id)
    {
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var query = "DELETE FROM Pedidos WHERE Id = @Id";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
        }
    }

    public List<Pedido> GetByCliente(string cliente)
    {
        var pedidos = new List<Pedido>();
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT * FROM Pedidos WHERE Cliente = @Cliente";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Cliente", cliente);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var pedidoId = reader.GetInt32(0);
                        var Data = reader.GetDateTime(1);
                        var status = reader.GetString(3);

                        pedidos.Add(new Pedido(pedidoId, Data, cliente, status));
                    }
                }
            }
        }
        return pedidos;
    }

    public List<Pedido> GetByStatus(string status)
    {
        var pedidos = new List<Pedido>();
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT * FROM Pedidos WHERE Status = @Status";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Status", status);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var pedidoId = reader.GetInt32(0);
                        var Data = reader.GetDateTime(1);
                        var cliente = reader.GetString(2);

                        pedidos.Add(new Pedido(pedidoId, Data, cliente, status));
                    }
                }
            }
        }
        return pedidos;
    }

    public List<Pedido> GetByData(DateTime data)
    {
        var pedidos = new List<Pedido>();
        using (var connection = new SqlConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT * FROM Pedidos WHERE Data = @Data";
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Data", data);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var pedidoId = reader.GetInt32(0);
                        var cliente = reader.GetString(2);
                        var status = reader.GetString(3);

                        pedidos.Add(new Pedido(pedidoId, data, cliente, status));
                    }
                }
            }
        }
        return pedidos;
    }
}
