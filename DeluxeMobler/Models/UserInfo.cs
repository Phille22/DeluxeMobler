using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace DeluxeMobler.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Viewed> ViewList { get; set; }
        public List<Cart> CartList { get; set; }


        public static List<UserInfo> UserList = GetUsers();


        public static UserInfo GetUserInfo(string Name)
        {
            var selected = UserList.Where(x => x.Name == Name).FirstOrDefault();
            return selected;
        }

        public static UserInfo GetUserInfo(int id)
        {
            UserInfo userinfo;
            string filepath = HttpContext.Current.Server.MapPath("~/App_Data/Storage/user" + id + ".json");

            if (System.IO.File.Exists(filepath))
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
            string filepath = HttpContext.Current.Server.MapPath("~/App_Data/Storage/user" + user.Id + ".json");
            var settings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.Objects,
                Formatting = Formatting.Indented
            };
            string json = JsonConvert.SerializeObject(user, settings);
            System.IO.File.WriteAllText(filepath, json);
        }

        public static List<UserInfo> GetUsers()
        {
            List<UserInfo> userList = new List<UserInfo>();
            userList.Add(new UserInfo { Id = 1, Name = "Phille", Password = "pwh" });
            userList.Add(new UserInfo { Id = 2, Name = "Phille2", Password = "pwh2" });
            return userList;
    
        }
        public class Viewed
        {
            public int nr;
            public int id;
        }
        public class Cart
        {
            public string name;
            public int price;
        }
    }
}