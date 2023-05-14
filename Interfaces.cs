using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Pedido
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public string Cliente { get; set; }
    public string Status { get; set; }
    public List<ItemPedido> Itens { get; set; }
}

public class ItemPedido
{
    public int Id { get; set; }
    public Produto Produto { get; set; }
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    public Pedido Pedido { get; set; }
}

// Interface de repositório
public interface IPedidoRepository
{
    void Inserir(Pedido pedido);
    void Atualizar(Pedido pedido);
    void Excluir(int id);
    List<Pedido> ListarPorCliente(string cliente);
    List<Pedido> ListarPorStatus(string status);
    List<Pedido> ListarPorData(DateTime data);
}

public interface IItemPedidoRepository
{
    void Inserir(ItemPedido itemPedido);
    void Atualizar(ItemPedido itemPedido);
    void Excluir(int id);
}