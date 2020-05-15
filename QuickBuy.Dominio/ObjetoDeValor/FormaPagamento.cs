using QuickBuy.Domain.Enumerator;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Domain.ObjetoDeValor
{
  public class FormaPagamento
  {
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }

    public bool IsBoleto
    {
      get { return Id == (int)EFormaPagamento.Boleto; }
    }
    public bool IsCartaoCredito
    {
      get { return Id == (int)EFormaPagamento.CartaoCredito; }
    }
    public bool IsDeposito
    {
      get { return Id == (int)EFormaPagamento.Deposito; }
    }
    public bool IsNaoDefinido
    {
      get { return Id == (int)EFormaPagamento.NaoDefinido; }
    }
  }
}
