using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using myModels;

namespace myInterfaces
{

    public interface IPizza : ILifeTime
    {
        List<Pizza> Get();

        Pizza? GetById(int id);

        ActionResult<List<Pizza>> Create(string name, bool gluten,int price);

        ActionResult<List<Pizza>> UpDate(int id, string name, bool gluten,int price);

        void Delete(int id);
    }
}



 