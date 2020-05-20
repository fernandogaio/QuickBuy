using QuickBuy.Domain.Contract;
using QuickBuy.Domain.Entity;
using QuickBuy.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickBuy.Repository.Repositories
{
  public class RepositoryUsuario : RepositoryBase<Usuario>, IRepositoryUsuario
  {
    public RepositoryUsuario(QuickBuyContext quickBuyContext) : base(quickBuyContext)
    {
    }

    public Usuario Get(string email, string senha)
    {
      return QuickBuyContext.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
    }

    public Usuario Get(string email)
    {
      return QuickBuyContext.Usuarios.FirstOrDefault(u => u.Email == email);
    }
  }
}