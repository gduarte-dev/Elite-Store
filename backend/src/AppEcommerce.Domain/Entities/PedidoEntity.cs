using System;
using System.Collections.Generic;

namespace AppEcommerce.Domain.Entities
{
    public class PedidoEntity
    {
        public int IdPedido { get; private set; }
        public int IdCliente { get; private set; }
        public DateTime Data { get; private set; }
        public decimal ValorTotal { get; private set; }
        public string Status { get; private set; } = string.Empty;

        public List<ItemPedidoEntity> Itens { get; private set; } = new();
      
        protected PedidoEntity() { }

        public PedidoEntity(int idCliente, List<ItemPedidoEntity> itens, string status)
        {
            Update(idCliente, itens, status);
            Data = DateTime.Now;
        }

        public void Update(int idCliente, List<ItemPedidoEntity> itens, string status)
        {
            if (idCliente <= 0)
                throw new ArgumentException("IdCliente inválido.");

            if (itens == null || itens.Count == 0)
                throw new ArgumentException("Um pedido deve ter ao menos 1 item.");

            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("Status é obrigatório.");

            IdCliente = idCliente;
            Itens = itens;
            Status = status.Trim();

            ValorTotal = 0;
            foreach (var item in itens)
                ValorTotal += item.Subtotal;
        }

        public void AlterarStatus(string novoStatus)
        {
            if (string.IsNullOrWhiteSpace(novoStatus))
                throw new ArgumentException("Status é obrigatório.");

            Status = novoStatus.Trim();
        }

        public void AdicionarItem(ItemPedidoEntity item)
        {
            if (item == null)
                throw new ArgumentException("Item inválido.");

            Itens.Add(item);
            ValorTotal += item.Subtotal;
        }

        public void RemoverItem(ItemPedidoEntity item)
        {
            if (item == null)
                throw new ArgumentException("Item inválido.");

            if (Itens.Remove(item))
                ValorTotal -= item.Subtotal;
        }
    }
}
