using QuickBuy.Domain.ObjetoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBuy.Domain.Entity
{
  public class Pedido : BaseEntity
  {
    public DateTime DataPedido { get; set; }
    public int UsuarioId { get; set; }
    public virtual Usuario Usuario { get; set; }
    public DateTime DataPrevisaoEntrega { get; set; }
    public string CEP { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
    public string EnderecoCompleto { get; set; }
    public int NumeroEndereco { get; set; }
    public int FormaPagamentoId { get; set; }
    public virtual FormaPagamento FormaPagamento { get; set; }
    public virtual ICollection<ItemPedido> ItensPedidos { get; set; }

    public override void Validate()
    {
      ClearMessageValidation();

      if (!ItensPedidos.Any())
        AddMessage("Adicione ao menos um item ao pedido");
      if (string.IsNullOrEmpty(CEP))
        AddMessage("O campo CEP não pode ficar vazio!");
      if (FormaPagamentoId == 0)
        AddMessage("Adicione qual a forma de pagamento!");
    }
  }
}
