using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeluxeMobler.Models

    //Viewmodel
{
    public class ViewModel
    {
        public List<Furniture> FurnitureList { get; set; }
        public UserInfo UserInfo { get; set; }
        public int Id { get; set; }

        public static ViewModel Viewmodel(List<Furniture> furniturelist, UserInfo userinfo, int id)
        {
            ViewModel VM = new ViewModel
            {
                FurnitureList = furniturelist,
                UserInfo = userinfo,
                Id = id
            };
            return VM;
        }
    }
}