using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBuy.Domain.Entity
{
  public class Usuario : BaseEntity
  {
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public virtual ICollection<Pedido> Pedidos { get; set; }

    public override void Validate()
    {
      ClearMessageValidation();

      if (string.IsNullOrEmpty(Email))
        AddMessage("O campo E-Mail não pode ficar vazio!");
      if (string.IsNullOrEmpty(Senha))
        AddMessage("Adicione uma senha.");
      if (string.IsNullOrEmpty(Nome))
        AddMessage("O campo Nome não pode ficar vazio!");
      if (string.IsNullOrEmpty(Sobrenome))
        AddMessage("O campo Sobrenome não pode ficar vazio!");
    }
  }
}
