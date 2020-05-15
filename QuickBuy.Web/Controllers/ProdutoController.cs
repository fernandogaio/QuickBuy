using Microsoft.AspNetCore.Mvc;
using QuickBuy.Domain.Contract;
using QuickBuy.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBuy.Web.Controllers
{
  [Route("api/[Controller]")]
  public class ProdutoController : Controller
  {
    private readonly IRepositoryProduto _repositoryProduto;

    public ProdutoController(IRepositoryProduto repositoryProduto)
    {
      _repositoryProduto = repositoryProduto;
    }

    [HttpGet]
    public IActionResult Get()
    {
      try
      {
        return Ok(_repositoryProduto.GetAll());
      }
      catch (Exception ex)
      {
        return BadRequest(ex.ToString());
      }
    }

    public IActionResult Post([FromBody]Produto produto)
    {
      try
      {
        _repositoryProduto.Add(produto);
        return Created("api/produto", produto);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.ToString());
      }
    }
  }
}