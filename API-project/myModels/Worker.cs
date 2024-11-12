using System;
using System.Collections.Generic;

namespace myModels
{

    public class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PassWord { get; set; }
        public string Role { get; set; }

        public Worker(){
            this.Id=0;
            this.Name="";
            this.PassWord="";
            this.Role="worker";
        }
        public Worker(int id, string name, string passWord, string role){
            this.Id=id;
            this.Name=name;
            this.PassWord=passWord;
            this.Role=role;
        }
    }
    // public enum ERole
    // {
    //     Admin,
    //     SuperWorker,
    //     Worker
    // }
    
}