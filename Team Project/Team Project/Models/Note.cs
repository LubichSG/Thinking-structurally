using System;
using System.Collections.Generic;
using System.Text;

namespace Team_Project
{
    public class Note
    {
        public string Headline { get; set; }
        public int Id { get; set; }
        public DateTime Date { get; set; }
        //public string Content { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public Note(string headline, int id, DateTime date, string content, User user, int userId)
        {
            Id = id;
            Date = date;
            //Content = content;
            User = user;
            UserId = userId;
        }
    }
}
