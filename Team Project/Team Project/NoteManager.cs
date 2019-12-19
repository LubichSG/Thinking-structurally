using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Newtonsoft.Json;

namespace Team_Project
{
    public class NoteManager : Manager
    {
        private List<NoteHaphazardIdeas> notesHaphazard;
        private List<NoteToDoList> notesToDo;
        private List<User> users;
        public UserManager userManager = new UserManager();


        private class NotesData
        {
            public List<NoteHaphazardIdeas> NotesHaphazard { get; set; }
            public List<NoteToDoList> NotesToDo { get; set; }
        }


        public NoteManager()
        {
            LoadData();
        }

        private const string NotesFileName = "../../../../data/notes.json";
        private const string UsersFileName = "../../../../data/users.json";


        protected override void LoadData()
        {
            var data = Deserialize<NotesData>(NotesFileName);
            notesHaphazard = data?.NotesHaphazard ?? new List<NoteHaphazardIdeas>();
            notesToDo = data?.NotesToDo ?? new List<NoteToDoList>();
            users = Deserialize<List<User>>(UsersFileName);
        }

        protected override void SaveData()
        {
            var data = new NotesData
            {
                NotesHaphazard = notesHaphazard,
                NotesToDo = notesToDo
            };
            Serialize(NotesFileName, data);
        }

        public int SaveNoteHaphazardIdeas(int id, string headline, DateTime date, string content, int userId)
        {

            if (id == 0)
            {
                id = notesToDo.Count > 0 ? notesToDo.Max(n => n.Id) + 1 : 1;
                var user = users.FirstOrDefault(u => u.Id == userId);
                var noteHaphazard = new NoteHaphazardIdeas(headline, id, date, content, user, userId);
                notesHaphazard.Add(noteHaphazard);
            }
            else
            {
                var note = notesHaphazard.FirstOrDefault(u => u.Id == id);
                note.Content = content;
                note.Headline = headline;
                note.Date = date;
            }
            SaveData();
            return id;
        }


        public int SaveNoteToDoList(string headline, int id, DateTime date, List<ContentToDo> notes, int userId)
        {
            if (id == 0)
            {
                id = notesToDo.Count > 0 ? notesToDo.Max(n => n.Id) + 1 : 1;
                var user = users.FirstOrDefault(u => u.Id == userId);
                var noteToDo = new NoteToDoList(headline, id, date, notes, user, userId);
                notesToDo.Add(noteToDo);
            }
            else
            {
                var note = notesToDo.FirstOrDefault(u => u.Id == id);
                note.Notes = notes;
                note.Headline = headline;
                note.Date = DateTime.Now;
            }

            SaveData();
            return id;
        }

        public List<NoteHaphazardIdeas> FindAllUserIdeaNotes(User user)
        {
            List<NoteHaphazardIdeas> notes = new List<NoteHaphazardIdeas>();
            notes.AddRange(notesHaphazard.Where(n => n.User == user).ToList());
            var sortedNotes = from n in notes
                              orderby n.Date descending
                              select n;
            return sortedNotes.ToList();
        }

        public List<NoteToDoList> FindAllUserListNotes(User user)
        {
            List<NoteToDoList> notes = new List<NoteToDoList>();
            notes.AddRange(notesToDo.Where(n => n.User == user).ToList());
            var sortedNotes = from n in notes
                              orderby n.Date descending
                              select n;
            return sortedNotes.ToList();
        }

        public Note FindNoteByUserAndHeadline(User user, string headline)
        {
            List<Note> notes = new List<Note>();
            notes.AddRange(notesHaphazard.Where(n => n.User == user).ToList());
            notes.AddRange(notesToDo.Where(n => n.User == user).ToList());
            return notes.First(n => n.Headline == headline);
        }


        public bool UniqueHeadline(string headline)
        {
            var noteToDo = notesToDo.FirstOrDefault(u => u.Headline == headline);
            var noteHaphazard = notesHaphazard.FirstOrDefault(u => u.Headline == headline);
            if (noteToDo == null && noteHaphazard == null)
            {
                return true;
            }
            else return false;
        }
    }
}
