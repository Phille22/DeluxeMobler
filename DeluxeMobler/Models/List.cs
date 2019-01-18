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

            FurnitureList.Add(new Table {id = 1, Name = "Sven", Price = 300, PictureURL = @"\Content\Images\Dining_table_for_two.jpg" });
            FurnitureList.Add(new Bed {id = 2, Name = "Johanna", Price = 250, PictureURL = @"\Content\Images\Skrapan,_Open_House_Stockholm_2016,_bild_10.jpg" });


            return FurnitureList;
        }
    }
}