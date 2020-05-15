using Microsoft.EntityFrameworkCore;
using QuickBuy.Domain.Entity;
using QuickBuy.Domain.ObjetoDeValor;
using QuickBuy.Repository.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBuy.Repository.Context
{
  public class QuickBuyContext : DbContext
  {
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Produto> Produtos { get; set; }
    public DbSet<Pedido> Pedidos { get; set; }
    public DbSet<ItemPedido> ItensPedidos { get; set; }
    public DbSet<FormaPagamento> FormaPagamento { get; set; }

    public QuickBuyContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //Classes de mapeamento
      modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
      modelBuilder.ApplyConfiguration(new PedidoConfiguration());
      modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
      modelBuilder.ApplyConfiguration(new ItemPedidoConfiguration());
      modelBuilder.ApplyConfiguration(new FormaPagamentoConfiguration());

      modelBuilder.Entity<FormaPagamento>().HasData(
      new FormaPagamento() 
      { 
        Id = 1,
        Nome = "Boleto",
        Descricao = "Forma de Pagamento por Boleto"
      },
      new FormaPagamento()
      {
        Id = 2,
        Nome = "Cartão de crédito",
        Descricao = "Forma de Pagamento por Cartão de crédito"
      },
      new FormaPagamento()
      {
        Id = 3,
        Nome = "Depósito",
        Descricao = "Forma de Pagamento por Cartão de Depósito"
      });

      base.OnModelCreating(modelBuilder);
    }
  }
}
