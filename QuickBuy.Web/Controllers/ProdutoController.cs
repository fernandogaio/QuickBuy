using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QuickBuy.Domain.Contract;
using QuickBuy.Domain.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace QuickBuy.Web.Controllers
{
  [Route("api/[Controller]")]
  public class ProdutoController : Controller
  {
    private readonly IRepositoryProduto _repositoryProduto;
    private IHttpContextAccessor _httpContextAccessor;
    private IHostingEnvironment _hostingEnvironment;

    public ProdutoController(IRepositoryProduto repositoryProduto, 
                             IHttpContextAccessor httpContextAccessor,
                             IHostingEnvironment hostingEnvironment)
    {
      _repositoryProduto = repositoryProduto;
      _httpContextAccessor = httpContextAccessor;
      _hostingEnvironment = hostingEnvironment;
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

    [HttpGet("GetById")]
    public IActionResult GetById(int id)
    {
      try
      {
        return Ok(_repositoryProduto.GetById(id));
      }
      catch (Exception ex)
      {
        return BadRequest(ex.ToString());
      }
    }

    [HttpPost]
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

    [HttpPost("UploadFile")]
    public IActionResult UploadFile([FromBody]Produto produto)
    {
      try
      {
        var formFile = _httpContextAccessor.HttpContext.Request.Form.Files["fileSent"];
        var fileName = formFile.Name;
        var extension = fileName.Split(".").Last();
        string newFileName = GerNewFileName(fileName, extension);
        var fileFolder = _hostingEnvironment.WebRootPath + "\\files\\";
        var fullName = fileFolder = newFileName;

        using (var fileStream = new FileStream(fullName, FileMode.Create))
        {
          formFile.CopyTo(fileStream);
        }

        return Json(newFileName);
      }
      catch (Exception ex)
      {
        return BadRequest(ex.ToString());
      }
    }

    private string GerNewFileName(string fileName, string extension)
    {
      var arrayCompactName = Path.GetFileNameWithoutExtension(fileName).Take(10).ToArray();
      var newFileName = new string(arrayCompactName).Replace(" ", " - ") + "." + extension;
      newFileName = $"{newFileName}_{DateTime.Now.Year}{DateTime.Now.Month}{DateTime.Now.Day}{DateTime.Now.Hour}{DateTime.Now.Minute}{DateTime.Now.Second}.{extension}";
      return newFileName;
    }
  }
}