using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamificacao3.Interfaces
{
    public interface IPedidoRepository
    {
        Pedido CreatePedido(Pedido pedido);
        Pedido GetPedido(int id);
        Pedido UpdatePedido(Pedido pedido);
        void DeletePedido(int id);
        IEnumerable<Pedido> GetPedidos(Func<Pedido, bool> predicate);
    }
}