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

        public static ViewModel viewModel(List<Furniture> furniturelist, UserInfo userinfo)
        {
            ViewModel VM = new ViewModel();
            VM.FurnitureList = furniturelist;
            VM.UserInfo = userinfo;
            return VM;
        }
    }
}