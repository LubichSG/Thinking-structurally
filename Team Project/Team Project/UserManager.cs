using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using Newtonsoft.Json;


namespace Team_Project
{
    public class UserManager : Manager
    {
        private List<User> users;

        public UserManager()
        {
            LoadData();  
        }

        private const string UsersFileName = "../../../../data/users.json";

        protected override void LoadData()
        {
            users = Deserialize<List<User>>(UsersFileName);
        }

        protected override void SaveData()
        {
            throw new NotImplementedException();
        }

        public void SaveUser(string name, string surname, string phone, string login, string password)
        {
            int id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;
            var user = new User(id, name, surname, phone, login, PasswordHash(password));
            users.Add(user);
            Serialize(UsersFileName, users);
        }

        private string PasswordHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashBytes);
        }

        public bool CheckUserExists(string login, string password)
        {
            return users.Any(u => u.Login == login && u.Password == PasswordHash(password));
        }


        public User FindUserByLogin(string login)
        {
            return users.FirstOrDefault(u => u.Login == login);
        }
    }
}
