using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeluxeMobler.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public static List<UserInfo> UserList = GetUsers();


        public static UserInfo GetUserInfo(string Name)
        {
            var selected = UserList.Where(x => x.Name == Name).FirstOrDefault();
            return selected;
        }
        public static UserInfo GetUserInfo(int id)
        {
            UserInfo userinfo;
            userinfo = UserList.Where(x => x.Id == id).FirstOrDefault();
            return userinfo;
        }

        public static List<UserInfo> GetUsers()
        {
            List<UserInfo> userList = new List<UserInfo>();
            userList.Add(new UserInfo { Id = 1, Name = "Phille", Password = "pwh" });
            userList.Add(new UserInfo { Id = 2, Name = "Phille2", Password = "pwh2" });
            return userList;
    
        }
    }
}