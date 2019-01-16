using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }

    public class Table : Furniture
    {
        int NumberOfLegs { get; set; }
        bool CanBeFold { get; set; }
        string Shape { get; set; }
    }

    public class Bed : Furniture
    {
        int Softness { get; set; }
        bool IsDouble { get; set; }

    }

    public class Category
    {

    }

    public class Cart
    {

    }
}