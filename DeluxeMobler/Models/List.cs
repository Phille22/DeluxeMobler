using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeluxeMobler.Models
{
    public class List
    {
       public static List<Furniture> CreateList()
        {
            List<Furniture> FurnitureList = new List<Furniture>();

            FurnitureList.Add(new Table { Name = "Sven", Price = 300 });
            FurnitureList.Add(new Bed { Name = "Johanna", Price = 250 });


            return FurnitureList;
        }
    }
}