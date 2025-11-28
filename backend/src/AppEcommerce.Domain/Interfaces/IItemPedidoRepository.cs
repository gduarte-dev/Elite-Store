using AppEcommerce.Domain.Entities;

namespace AppEcommerce.Domain.Interfaces
{
    public interface IItemPedidoRepository
    {
        // Retorna um item de pedido específico
        Task<ItemPedidoEntity?> GetByIdAsync(int id);

        // Retorna todos os itens cadastrados
        Task<IEnumerable<ItemPedidoEntity>> GetAllAsync();

        // Adiciona um novo item de pedido
        Task AddAsync(ItemPedidoEntity itemPedido);

        // Atualiza os dados de um item de pedido existente
        Task UpdateAsync(ItemPedidoEntity itemPedido);

        // Remove um item de pedido
        Task DeleteAsync(ItemPedidoEntity itemPedido);
    }
}
