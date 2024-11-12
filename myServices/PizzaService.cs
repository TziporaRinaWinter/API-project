using Microsoft.AspNetCore.Mvc;
using myInterfaces;
using myModels;
using fileService;

namespace myServices
{

    public class PizzaService : myInterfaces.IPizza
    {
        static List<Pizza> Pizzas { get; set; }
        static int nextId=7;
        public DateTime Date { get; set; }
        private IfileService<Pizza> _rw;

        public PizzaService(IfileService<Pizza> rw)
        {
            this._rw=rw;
            _rw.FileName="readwrite.json";
            Date = DateTime.Now;
            Pizzas = new List<Pizza>
            {
            new Pizza(){Id= 1, Gluten =true , Name="olive", Price=35},
            new Pizza(){Id= 2, Gluten =false , Name="tasty!",Price=40},
            new Pizza(){Id= 3, Gluten =true , Name="milkPizza",Price=50}
            };
            List<Pizza> p= _rw.Read<Pizza>();
            nextId= p.Count()+1;
        }
        
        public string Stringi()
        {
            return "the date from pizza: " + Date;
        }

        public Pizza? GetById(int id) 
        {
            //return Pizzas.FirstOrDefault(p => p.Id == id);
            return Get().FirstOrDefault(p => p.Id == id);
        } 
        
        public List<Pizza> Get() 
        {
            return _rw.Read<Pizza>();
            //return Pizzas;
        }

        public ActionResult<List<Pizza>> Create(string name, bool gluten, int price)
        {
            Pizza p = new Pizza(nextId++, name ,gluten,price);
            _rw.Write<Pizza>(p);
            Pizzas.Add(p);
            return Pizzas;
        }

        public ActionResult<List<Pizza>> UpDate(int id, string name, bool gluten,int price)
        {
            List<Pizza> piz= Get();
            foreach (var p in piz)
            {
                if (p.Id == id)
                {
                    p.Name = name;
                    p.Gluten = gluten;
                    p.Price = price;
                    // _rw.DeleteAllLines<Pizza>();
                    // foreach(var pi in piz){
                    //     _rw.Write<Pizza>(pi);
                    // }
                    _rw.Update<Pizza>(piz);
                }
            }
            return piz;
            

        }

        public void Delete(int id)
        {
            List<Pizza> piz= Get();
            foreach (var p in piz)
            {
                if (p.Id == id)
                {
                    piz.Remove(p);
                    _rw.Update(piz);
                    // //Path.Combine(Environment.CurrentDirectory,"File" ,"readwrite.txt").delete();
                    // _rw.DeleteAllLines<Pizza>();
                    // foreach(var pi in piz){
                    //     _rw.Write<Pizza>(pi);
                    // }
                }
            }
        }

        // ActionResult<List<Pizza>> IPizza.Create(string name, bool gluten, int price)
        // {
        //     throw new NotImplementedException();
        // }

        // ActionResult<List<Pizza>> IPizza.UpDate(int id, string name, bool gluten, int price)
        // {
        //     throw new NotImplementedException();
        // }

        // ActionResult<List<Pizza>> IPizza.Delete(int id)
        // {
        //     throw new NotImplementedException();
        // }
    }
}
