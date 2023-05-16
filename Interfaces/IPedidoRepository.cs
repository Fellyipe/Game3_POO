using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gamificacao3.Interfaces
{
public interface IItemPedidoRepository
{
    ItemPedido CreateItemPedido(ItemPedido itemPedido);
    ItemPedido GetItemPedido(int id);
    ItemPedido UpdateItemPedido(ItemPedido itemPedido);
    void DeleteItemPedido(int id);
    IEnumerable<ItemPedido> GetItemPedidosByPedidoId(int pedidoId);
    
}
}

/*
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
    */