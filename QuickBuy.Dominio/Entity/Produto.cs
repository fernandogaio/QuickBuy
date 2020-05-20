using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBuy.Domain.Entity
{
  public class Produto : BaseEntity
  {
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public string NomeProduto { get; set; }

    public override void Validate()
    {
      ClearMessageValidation();

      if (string.IsNullOrEmpty(Nome))
        AddMessage("O campo nome não pode ficar vazio!");
      if (Preco >= 0)
        AddMessage("Preço deve ser maior que 0!");
    }
  }
}
