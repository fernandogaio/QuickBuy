using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Domain.Entity
{
  public class ItemPedido : BaseEntity
  {
    public int ProdutoId { get; set; }
    public virtual Produto Produto { get; set; }
    public int Quantidade { get; set; }

    public override void Validate()
    {
      ClearMessageValidation();

      if (ProdutoId == 0)
        AddMessage("Produto não identificado.");
      if (Quantidade == 0)
        AddMessage("Quantidade não informada.");
    }
  }
}
