using Gamificacao3;

namespace Gamificacao3
{
    public class ItemPedido
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public Pedido Pedido { get; set; }
    }
}