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

            FurnitureList.Add(new Table { Name = "Sven", Price = 300, PictureURL = @"/Content/Images/Sofa.svg" });
            FurnitureList.Add(new Bed { Name = "Johanna", Price = 250, PictureURL = @"\Content\Images\Skrapan,_Open_House_Stockholm_2016,_bild_10.jpg" });


            return FurnitureList;
        }
    }
}