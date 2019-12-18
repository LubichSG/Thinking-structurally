using System;
using System.Collections.Generic;
using System.Text;

namespace Team_Project
{
    class NoteToDoList: Note
    {
        
        public ContentToDo ContentToDo { get; set; }
        public NoteToDoList(string headline, int id, DateTime date, int number, DateTime eventDate, string task, bool finished,
            User user, int userId) : base(headline, id, date, user, userId) 
        {
            ContentToDo = new ContentToDo(number, eventDate, task, finished);  
        }

    }
}
