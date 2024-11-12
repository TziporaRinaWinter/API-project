using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace myModels
{

    public class Pizza
    {
        [StringLength(10)]
        public string? Name { get; set; }
        [Required]
        public bool Gluten { get; set; }
        public int Id { get; set; }
        [Range(0,600)]
        public int Price { get; set; }

        public Pizza(){
            this.Id=0;
            this.Name="";
            this.Gluten=false;
            this.Price=45;
        }
        public Pizza(int id, string name, bool gluten, int price){
            this.Id=id;
            this.Name=name;
            this.Gluten=gluten;
            this.Price=price;
        }

    }
}