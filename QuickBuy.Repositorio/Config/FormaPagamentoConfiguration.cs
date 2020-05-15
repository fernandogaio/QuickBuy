using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuickBuy.Domain.ObjetoDeValor;

namespace QuickBuy.Repository.Config
{
  public class FormaPagamentoConfiguration : IEntityTypeConfiguration<FormaPagamento>
  {
    public void Configure(EntityTypeBuilder<FormaPagamento> builder)
    {
      builder.HasKey(x => x.Id);

      builder.Property(x => x.Nome)
        .IsRequired()
        .HasMaxLength(50);

      builder.Property(x => x.Descricao)
        .IsRequired()
        .HasMaxLength(100);
    }
  }
}
