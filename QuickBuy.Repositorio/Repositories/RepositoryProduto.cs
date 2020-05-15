using QuickBuy.Domain.Contract;
using QuickBuy.Domain.Entity;
using QuickBuy.Repository.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Repository.Repositories
{
  public class RepositoryProduto : RepositoryBase<Produto>, IRepositoryProduto
  {
    public RepositoryProduto(QuickBuyContext quickBuyContext) : base(quickBuyContext)
    {

    }
  }
}
