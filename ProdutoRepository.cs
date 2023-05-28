using Gamificacao3;
using Gamificacao3.Interfaces;
using MySql.Data;
using MySql.Data.MySqlClient;

public class ProdutoRepository
{
    private readonly string connectionString;

    public ProdutoRepository(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public Produto GetById(int id)
    {
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            var query = "SELECT * FROM tb_produto WHERE Id = @Id";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Id", id);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        var produtoId = reader.GetInt32(0);
                        var nome = reader.GetString(1);
                        var descricao = reader.GetString(2);
                        var preco = reader.GetDecimal(3);
                        var quantidadeEmEstoque = reader.GetInt32(4);

                        return new Produto(produtoId, nome, descricao, preco, quantidadeEmEstoque);
                    }
                }
            }
        }
        return null;
    }
}