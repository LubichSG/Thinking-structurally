using System;
using System.Collections.Generic;
using System.Text;

namespace Team_Project
{
    public class Note
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Content { get; set; }

        public Note(int id, DateTime date, string content)
        {
            ID = id;
            Date = date;
            Content = content;
        }
    }
}
