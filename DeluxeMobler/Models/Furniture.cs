using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace DeluxeMobler.Models
{
    public class Furniture
    {
        public string Name { get; set; }
        public int Length { get; set; }
        public int Height { get; set; }
        public int Price { get; set; }
        public int InStock { get; set; }
        public int NumberOfViews { get; set; }
        public int NumberOfTimesBought { get; set; }
        public string PictureURL { get; set; }
        public int Id { get; set; }

        public static string filepath = HttpContext.Current.Server.MapPath("~/App_Data/Storage/library.json");


        public static bool SaveData(List<Furniture> furniturelist)
        {
            furniturelist.OrderBy(o => o.NumberOfViews);
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented
            };
            string json = JsonConvert.SerializeObject(furniturelist.ToArray(), settings);
            System.IO.File.WriteAllText(filepath, json);
            return true;
        }


        public static List<Furniture> GetData()
        {
            List<Furniture> data;
            if (System.IO.File.Exists(filepath))
            {
                var settings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Objects
                };
                var json = System.IO.File.ReadAllText(filepath);
                data = JsonConvert.DeserializeObject<List<Furniture>>(json, settings);
            }
            else
            {
                data = List.CreateList();
            }

            //// Algoritm

            //data = data.OrderBy(x => x.AvailableBooks).ToList();
            //int points = 0;
            //foreach (var d1 in data)
            //{
            //    points = points + 5;
            //    d1.tempPointsInitialCount = points;
            //    d1.Points = points;
            //}


            //data = data.OrderBy(x => x.Borrowed).ToList();
            //points = 0;
            //foreach (var d2 in data)
            //{
            //    points = points + 3;
            //    d2.tempPointsLendCount = points;
            //    d2.Points += points;
            //}

            //data = data.OrderByDescending(x => x.Points).ToList();
            SaveData(data);
            return data;
        }
    }

    public class Table : Furniture
    {
        public int NumberOfLegs { get; set; }
        public bool CanBeFold { get; set; }
        public string Shape { get; set; }
    }

    public class Bed : Furniture
    {
        public int Softness { get; set; }
        public bool IsDouble { get; set; }

    }

    public class Category
    {

    }

    public class Cart
    {

    }
}