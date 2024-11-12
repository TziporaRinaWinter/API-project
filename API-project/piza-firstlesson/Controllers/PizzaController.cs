using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using myModels;
using myInterfaces;
using myServices; 
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace piza_firstlesson.Controllers{

[ApiController]
[Route("api/[controller]/[action]")]
public class PizzaController : ControllerBase
{
    readonly IPizza _pizza;
    public PizzaController(IPizza p){
       _pizza=p;
    }

    [HttpGet]
    public List<Pizza> Get()
    {
        Console.WriteLine(_pizza.Stringi());
        return _pizza.Get();
    }

    [HttpGet("{id}")]
    public Pizza? GetById(int id)
    {
        Console.WriteLine(_pizza.Stringi());
        return _pizza.GetById(id);
    }

    [HttpPost("{name}/{gluten}/{price}")]
    [Authorize(Policy = "SuperWorker")]
    public ActionResult<List<Pizza>> Create([StringLength(10)]string name,bool gluten, [Range(20,600)]int price)
    {
        return _pizza.Create(name, gluten, price);
    }

    [HttpPut("{id}/{name}/{gluten}/{price}")]
    [Authorize(Policy = "SuperWorker")]
    public ActionResult<List<Pizza>> UpDate(int id, string name, bool gluten, int price)
    {
        return _pizza.UpDate(id, name, gluten, price);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "SuperWorker")]
    public void Delete(int id)
    {
        _pizza.Delete(id);
    }
    
}
internal class HttpCreateAttribute : Attribute
{

}
}

