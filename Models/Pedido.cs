using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gamificacao3;

namespace Gamificacao3
{
    public class Pedido
{
    private int _id;
    private DateTime _data;
    private string _cliente;
    private string _status;
    private List<ItemPedido> _itens;

    public string Status {
        get { return _status; }
        set { _status = value; }
    }

    public Pedido(int id, DateTime Data, string cliente, string status)
    {
        _id = id;
        _data = Data;
        _cliente = cliente;
        _status = status;
        _itens = new List<ItemPedido>();
    }
}

    
}