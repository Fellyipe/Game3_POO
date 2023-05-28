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

        public int Id{
            get { return _id; }
            set { _id = value; }
        }

        public Produto Produto{
            get { return _produto; }
        }

        public int Quantidade{
            get { return _quantidade; }
        }
        public decimal PrecoUnitario{
            get { return _precoUnitario; }
        }

        public Pedido Pedido{
            get { return _pedido; }
        }

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