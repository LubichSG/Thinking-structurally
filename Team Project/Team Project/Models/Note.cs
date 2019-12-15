using System;
using System.Collections.Generic;
using System.Text;

namespace Team_Project
{
    public class Note
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }

        public int UserId { get; set; }

        public Note(int id, DateTime date, string content, int userId)
        {
            Id = id;
            Date = date;
            Content = content;
            UserId = userId;
        }
    }
}
