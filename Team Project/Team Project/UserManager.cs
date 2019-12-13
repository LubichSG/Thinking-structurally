using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Team_Project
{
    public class UserManager
    {
        private List<User> users;
        private List<Note> userNotes;
        private string PasswordHash(string password)
        {
            MD5 md5 = MD5.Create();
            var hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashBytes);
        }
    }
}
