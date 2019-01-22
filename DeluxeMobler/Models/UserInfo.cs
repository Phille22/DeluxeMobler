using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace DeluxeMobler.Models

    //Klassen för användaren
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Viewed> ViewList { get; set; } //Användarens unika klick på en möbel
        public List<Cart> CartList { get; set; } //Användarens kundvagn


        public static List<UserInfo> UserList = GetUsers(); //Hämta listan med användare


        public static UserInfo GetUserInfo(string Name)
        {
            var selected = UserList.Where(x => x.Name == Name).FirstOrDefault();
            return selected;
        }

        public static UserInfo GetUserInfo(int id) //Metod för att hämta relevant information för en användare
        {
            UserInfo userinfo;
            string filepath = HttpContext.Current.Server.MapPath("~/App_Data/Storage/user" + id + ".json"); //Läs json-filen

            if (System.IO.File.Exists(filepath)) //Om filen existerar, läs den
            {
                var settings = new JsonSerializerSettings()
                {
                    TypeNameHandling = TypeNameHandling.Objects
                };
                var json = System.IO.File.ReadAllText(filepath);
                userinfo = JsonConvert.DeserializeObject<UserInfo>(json, settings);
            }
            else
            {
                userinfo = UserList.Where(x => x.Id == id).FirstOrDefault();
            }
            return userinfo;
        }

        public static void SaveUserInfo(UserInfo user)
        {
            string filepath = HttpContext.Current.Server.MapPath("~/App_Data/Storage/user" + user.Id + ".json"); //Spara filen med användarinfo
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented
            };
            string json = JsonConvert.SerializeObject(user, settings);
            System.IO.File.WriteAllText(filepath, json);
        }

        public static List<UserInfo> GetUsers() //Listan med användare
        {
            List<UserInfo> userList = new List<UserInfo>
            {
                new UserInfo { Id = 1, Name = "Phille", Password = "pwh" },
                new UserInfo { Id = 2, Name = "Phille2", Password = "pwh2" }
            };
            return userList;
    
        }
        public class Viewed //Objekt för antal visningar för den inloggade användaren
        {
            public int nr;
            public int id;
        }
        public class Cart //Kundvagnsobjekt
        {
            public string name;
            public int price;
        }
    }
}