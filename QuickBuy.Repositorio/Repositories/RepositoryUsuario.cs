using QuickBuy.Domain.Contract;
using QuickBuy.Domain.Entity;
using QuickBuy.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Repository.Repositories
{
  public class RepositoryUsuario : RepositoryBase<Usuario>, IRepositoryUsuario
  {
    public RepositoryUsuario(QuickBuyContext quickBuyContext) : base(quickBuyContext)
    {
    }
  }
}
