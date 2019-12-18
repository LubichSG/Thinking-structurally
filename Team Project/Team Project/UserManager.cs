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
    public class UserManager
    {
        private List<User> users;
        private List<Note> userNotes;

        public UserManager()
        {
            LoadData();  
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

        private const string UsersFileName = "../../../../data/users.json";

        private T Deserialize<T>(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                using (var jsonReader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<T>(jsonReader);
                }
            }
        }

        private void Serialize<T>(string fileName, T data)
        {
            using (var sw = new StreamWriter(fileName))
            {
                using (var jsonWriter = new JsonTextWriter(sw))
                {
                    jsonWriter.Formatting = Newtonsoft.Json.Formatting.Indented;
                    var serializer = new JsonSerializer();
                    serializer.Serialize(jsonWriter, data);
                }
            }
        }

        private void LoadData()
        {
            users = Deserialize<List<User>>(UsersFileName);
        }

        public void SaveUser(string name, string surname, string phone, string login, string password)
        {
            int id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;
            var user = new User(id, name, surname, phone, login, PasswordHash(password));
            users.Add(user);
            Serialize(UsersFileName, users);
        }

        public User FindUserByLogin(string login)
        {
            return users.FirstOrDefault(u => u.Login == login);
        }

        
        //public string getLogin(User user)
        //{
        //    return user.Login;
        //}
    }
}
