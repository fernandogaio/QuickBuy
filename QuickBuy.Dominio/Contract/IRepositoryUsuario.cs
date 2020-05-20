using QuickBuy.Domain.Entity;

namespace QuickBuy.Domain.Contract
{
  public interface IRepositoryUsuario : IRepositoryBase<Usuario>
  {
    Usuario Get(string email, string senha);
    Usuario Get(string email);
  }
}
