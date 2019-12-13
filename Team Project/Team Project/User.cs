using System;
using System.Collections.Generic;
using System.Text;

namespace Team_Project
{
    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public List<Note> Notes { get; set; }
        public User(int id, string name, string surname, string phone, string login, string password, List<Note> notes)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Phone = phone;
            Login = login;
            Password = password;
            Notes = notes;
        }

    }
}
