using System;
using System.Collections.Generic;
using System.Text;

namespace Team_Project
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public User(int id, string name, string surname, string phone, string login, string password)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Phone = phone;
            Login = login;
            Password = password;
        }

        //public string getLogin()
        //{
        //    return Login;
        //}

    }
}
