using AppEcommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppEcommerce.Infra.Data.Configurations
{
    public class PedidoConfig : IEntityTypeConfiguration<PedidoEntity>
    {
        public void Configure(EntityTypeBuilder<PedidoEntity> builder)
        {
            builder.ToTable("Pedidos");

            builder.HasKey(p => p.IdPedido);

            builder.Property(p => p.IdPedido)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.IdCliente)
                .IsRequired();

            builder.Property(p => p.DataPedido)
                .IsRequired();

            builder.Property(p => p.ValorTotal)
                .HasColumnType("decimal(18,2)")
                .IsRequired();

            // Relacionamento 1 -> muitos com ItemPedido
            builder
                .HasMany(p => p.Itens)
                .WithOne(i => i.Pedido)
                .HasForeignKey(i => i.IdPedido)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
