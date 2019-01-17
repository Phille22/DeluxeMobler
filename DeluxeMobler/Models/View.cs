using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeluxeMobler.Models
{
    public class ViewModel
    {
        public List<Furniture> FurnitureList { get; set; }
        public UserInfo UserInfo { get; set; }
        public int id { get; set; }

        public static ViewModel viewModel(List<Furniture> furniturelist, UserInfo userinfo, int id)
        {
            ViewModel VM = new ViewModel();
            VM.FurnitureList = furniturelist;
            VM.UserInfo = userinfo;
            VM.id = id;
            return VM;
        }
    }
}