using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBuy.Domain.Entity
{
  public abstract class BaseEntity
  {
    public int Id { get; set; }
    private List<string> _messageValidation { get; set; }
    private List<string> messageValidation
    {
      get { return _messageValidation ?? (_messageValidation = new List<string>()); }
    }

    protected void AddMessage(string msg)
    {
      messageValidation.Add(msg);
    }

    protected void ClearMessageValidation() 
    {
      messageValidation.Clear();
    }

    public abstract void Validate();
    protected bool IsValid
    {
      get { return !messageValidation.Any(); }
    }
  }
}
