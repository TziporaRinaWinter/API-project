using myModels;
using myInterfaces;
using Microsoft.AspNetCore.Mvc;
using fileService;

namespace myServices
{

    public class WorkerService : myInterfaces.IWorker
    {
        static int nextId=0;
        private IfileService<Worker> _rw;
        public DateTime Date { get; set; }

        public WorkerService(IfileService<Worker> rw)
        {
            _rw=rw;
            _rw.FileName="workers.json";
            Date = DateTime.Now;
            List<Worker> w= _rw.Read<Worker>();
            nextId= w.Count()+1;
        }

        public string Stringi()
        {
            return "the date from worker: " + Date;
        }

        public Worker? GetById(int id){
            return Get().FirstOrDefault(w => w.Id == id);
        }

        public List<Worker> Get()
        {
            return _rw.Read<Worker>();
        }

        public void Create(string name, string password,string role)
        {
            Worker w = new Worker(nextId++, name, password, role);
            _rw.Write<Worker>(w);
        }

        public ActionResult<List<Worker>> UpDate(int id, string name, string password,string role)
        {
            List<Worker> work= Get();
            foreach (var w in work)
            {
                if (w.Id == id)
                {
                    w.Name = name;
                    w.PassWord = password;
                    w.Role = role;
                    _rw.Update<Worker>(work);
                    // _rw.DeleteAllLines<Worker>();
                    // foreach(var wo in work){
                    //     _rw.Write<Worker>(wo);
                    // }
                }
            }
            return work;
        }

        public void Delete(int id)
        {
            List<Worker> work= Get();
            foreach (var w in work)
            {
                if (w.Id == id)
                {
                    work.Remove(w);
                    _rw.Update<Worker>(work);
                    // _rw.DeleteAllLines<Worker>();
                    // foreach(var wo in work){
                    //     _rw.Write<Worker>(wo);
                    // }
                }
            }
        }
    }
}