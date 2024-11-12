using System.Threading.Tasks;
using myModels;
using Microsoft.AspNetCore.Mvc;

namespace myInterfaces
{

    public interface IWorker : ILifeTime
    {
    List<Worker> Get();
    Worker? GetById(int id);
    void Create(string name, string password,string role);
    ActionResult<List<Worker>> UpDate(int id, string name, string password,string role);
    void Delete(int id);
    }
}
