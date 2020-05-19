using Microsoft.AspNetCore.Mvc;
using QuickBuy.Domain.Contract;
using QuickBuy.Domain.Entity;
using System;

namespace QuickBuy.Web.Controllers
{
  [Route("api/[Controller]")]
  public class UsuarioController : Controller
  {
    private readonly IRepositoryUsuario _repositoryUsuario;                             
    public UsuarioController(IRepositoryUsuario repositoryUsuario)
    {
      _repositoryUsuario = repositoryUsuario;
    }

    [HttpGet]
    public ActionResult Get()
    {
      try
      {
        return Ok();
      }
      catch (Exception ex)
      {
        return BadRequest(ex.ToString());
      }
    }

    [HttpPost("VerifyUser")]
    public ActionResult VerifyUser([FromBody] Usuario user)
    {
      try
      {
        if(_repositoryUsuario.Get(user.Email, user.Senha) != null)
          return Ok(user);

        return BadRequest("Usuário ou senha inválido");
      }
      catch (Exception ex)
      {
        return BadRequest(ex.ToString());
      }
    }

    [HttpPost]
    public ActionResult Post()
    {
      try
      {
        return Ok();
      }
      catch (Exception ex)
      {

        throw;
      }
    }

  }
}
