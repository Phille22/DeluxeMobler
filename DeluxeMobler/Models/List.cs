using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Denna klass används för att skapa listan med möbler

namespace DeluxeMobler.Models
{
    public class List
    {
       public static List<Furniture> CreateList()
        {
            List<Furniture> FurnitureList = new List<Furniture>
            {
                new Table { Id = 1, Name = "Sven", Price = 3000, Height = 20, Length = 40, CanBeFold = true, Shape = "Rektangulär", NumberOfLegs = 6, InStock = 8, PictureURL = @"\Content\Images\Dining_table_for_two.jpg" },
                new Bed { Id = 2, Name = "Johanna", Price = 250, Height = 300, Length = 400, IsDouble = true, Softness = 2, InStock = 7, PictureURL = @"\Content\Images\Skrapan,_Open_House_Stockholm_2016,_bild_10.jpg" },
                new Bed { Id = 3, Name = "Hedvig", Price = 2399, Height = 458, Length = 654, IsDouble = true, Softness = 3, InStock = 43, PictureURL = @"\Content\Images\Adjustable_Bed.jpg" },
                new Table { Id = 4, Name = "Lars-Erik", Price = 4210, Height = 50, Length = 60, CanBeFold = false, Shape = "Rund", InStock = 29, NumberOfLegs = 3, PictureURL = @"\Content\Images\Candlestand_LACMA_M.2006.51.13_(1_of_2).jpg" },
                new Bed { Id = 5, Name = "Gertrud", Price = 1054, Height = 40, Length = 100, IsDouble = false, Softness = 1, InStock = 19, PictureURL = @"\Content\Images\San_Martino_-_Napoleons_Haus_Bett.jpg" },
                new Table { Id = 6, Name = "Ture", Price = 5690, Height = 80, Length = 30, CanBeFold = false, Shape = "Pentagonal", InStock = 12, NumberOfLegs = 4, PictureURL = @"\Content\Images\Table_pentagonale-Musée_de_la_Folie_Marco_(2).jpg" }
            };

            return FurnitureList;
        }
    }
}