using System;
using System.Collections.Generic;
using System.Text;

namespace Team_Project
{
   abstract public class Note
    {
        public string Headline { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        //public string Content { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public Note(string headline, int id, DateTime date,  User user, int userId)
        {
            Headline = headline;
            Id = id;
            Date = date;
            //Content = content;
            User = user;
            UserId = userId;
        }
    }
}
