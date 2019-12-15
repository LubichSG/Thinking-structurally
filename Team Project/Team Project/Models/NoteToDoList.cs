using System;
using System.Collections.Generic;
using System.Text;

namespace Team_Project.Models
{
    class NoteToDoList: Note
    {
        public NoteToDoList(string headline, int id, DateTime date, string content, User user, int userId) : base(headline, id, date, content, user, userId) { }
    }
}
