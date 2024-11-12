using Microsoft.AspNetCore.Mvc;
using myModels;
using myInterfaces;
using myServices;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;

namespace piza_firstlesson.Controllers{

[ApiController]
[Route("api/[controller]/[action]")]
public class WorkerController : ControllerBase
{
    readonly IWorker _worker;

    public WorkerController(IWorker w){
        _worker=w;
    }

    [HttpGet]
    [Authorize(Policy = "Admin")]
    public List<Worker> Get()
    {
        Console.WriteLine(_worker.Stringi());
        return _worker.Get();
    }

    [HttpGet("{id}")]
    [Authorize(Policy = "Admin")]
    public Worker? GetById(int id)
    {
        Console.WriteLine(_worker.Stringi());
        return _worker.GetById(id);
    }

    [HttpPost("{name}/{password}/{role}")]
    [Authorize(Policy = "Admin")]
    public void Create(string name, string password,string role)
    {
        _worker.Create(name, password, role);
    }

    [HttpPut("{id}/{name}/{password}/{role}")]
    [Authorize(Policy = "Admin")]
    public ActionResult<List<Worker>> UpDate(int id, string name, string password,string role)
    {
        return _worker.UpDate(id, name, password, role);
    }

    [HttpDelete("{id}")]
    [Authorize(Policy = "Admin")]
    public void Delete(int id)
    {
        _worker.Delete(id);
    }   
}
}
