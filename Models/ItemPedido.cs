using Gamificacao3;

namespace Gamificacao3
{
    public class ItemPedido
    {
        private int _id;
        private Produto _produto;
        private int _quantidade;
        private decimal _precoUnitario;
        private Pedido _pedido;

        public ItemPedido(int id, Produto produto, int quantidade, decimal precoUnitario, Pedido pedido)
        {
            _id = id;
            _produto = produto;
            _quantidade = quantidade;
            _precoUnitario = precoUnitario;
            _pedido = pedido;
        }
    }
}