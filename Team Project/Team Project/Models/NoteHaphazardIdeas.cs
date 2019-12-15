using System;
using System.Collections.Generic;
using System.Text;

namespace Team_Project
{
    class NoteHaphazardIdeas: Note
    {
        public string Content { get; set; }

        public NoteHaphazardIdeas(string headline, int id, DateTime date, string content, User user, int userId) : base(headline, id, date, user, userId) 
        {
            Content = content;
        }
        
        
    }
}
