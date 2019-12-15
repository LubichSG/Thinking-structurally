using System;
using System.Collections.Generic;
using System.Text;

namespace Team_Project.Models
{
    class NoteHaphazarIdeas: Note
    {
        public NoteHaphazarIdeas(string headline, int id, DateTime date, string content, User user, int userId) : base(headline, id, date, content, user, userId) { }
        
    }
}
