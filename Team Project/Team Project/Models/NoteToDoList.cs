using System;
using System.Collections.Generic;
using System.Text;

namespace Team_Project.Models
{
    class NoteToDoList: Note
    {
        public string Content { get; set; }

        public NoteToDoList(string headline, int id, DateTime date, string content, User user, int userId) : base(headline, id, date, user, userId) { }
    }
}
