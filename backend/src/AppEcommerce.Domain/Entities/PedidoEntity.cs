using System.Collections.Generic;

namespace AppEcommerce.Domain.Entities
{
    public class PedidoEntity
    {
        public int IdPedido { get; private set; }
        public decimal Total { get; private set; }

        private readonly List<ItemPedidoEntity> _itens = new List<ItemPedidoEntity>();
        public IReadOnlyCollection<ItemPedidoEntity> Itens => _itens.AsReadOnly();

        protected PedidoEntity() { }

        public PedidoEntity(List<ItemPedidoEntity> itens)
        {
            AdicionarItens(itens);
            CalcularTotal();
        }

        private void AdicionarItens(List<ItemPedidoEntity> itens)
        {
            foreach (var item in itens)
            {
                item.AtribuirPedido(IdPedido, this); 
                _itens.Add(item);
            }
        }

        private void CalcularTotal()
        {
            decimal total = 0;
            foreach (var item in _itens)
            {
                total += item.Subtotal;
            }
            Total = total;
        }
    }
}
