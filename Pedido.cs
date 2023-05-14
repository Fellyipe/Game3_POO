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