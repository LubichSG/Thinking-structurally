using System;
using System.Collections.Generic;
using System.Text;

namespace Team_Project.Models
{
    class NoteHaphazarIdeas: Note
    {
        public ContentHaphazar ContentHaphazar { get;set; }
        public NoteHaphazarIdeas(string headline, int id, DateTime date, int number, DateTime dataEvant, string tast, bool finished,
            User user, int userId) : base(headline, id, date,  user, userId){ }
        
    }
}
