using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Domain.Entity;

namespace QuickBuy.Repository.Config
{
  public class ItemPedidoConfiguration : IEntityTypeConfiguration<ItemPedido>
  {
    public void Configure(EntityTypeBuilder<ItemPedido> builder)
    {
      builder.HasKey(x => x.Id);

      builder.Property(x => x.ProdutoId)
        .IsRequired();

      builder.Property(x => x.Quantidade)
        .IsRequired();
    }
  }
}
