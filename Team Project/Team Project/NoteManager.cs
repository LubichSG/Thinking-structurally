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
            LoadData();
        }

        public NoteHaphazardIdeas SaveNoteHaphazardIdeas(int id, string headline, DateTime date, string content, int userId)
        {
            NoteHaphazardIdeas note;
            if (id == 0)
            {
                id = notesToDo.Count > 0 ? notesToDo.Max(n => n.Id) + 1 : 1;
                var user = users.FirstOrDefault(u => u.Id == userId);
                note = new NoteHaphazardIdeas(headline, id, date, content, user, userId);
                notesHaphazard.Add(note);
            }
            else
            {
                
                int index = notesHaphazard.FindIndex(u => u.Id == id);
                notesHaphazard[index].Content = content;
                notesHaphazard[index].Headline = headline;
                notesHaphazard[index].Date = date;
                note = notesHaphazard[index];
            }
            SaveData();
            return note;
        }


        public NoteToDoList SaveNoteToDoList(string headline, int id, DateTime date, List<ContentToDo> notes, int userId)
        {
            NoteToDoList note;
            if (id == 0)
            {
                id = notesToDo.Count > 0 ? notesToDo.Max(n => n.Id) + 1 : 1;
                var user = users.FirstOrDefault(u => u.Id == userId);
                note = new NoteToDoList(headline, id, date, notes, user, userId);
                notesToDo.Add(note);
            }
            else
            {
                int index = notesToDo.FindIndex(u => u.Id == id);
                notesToDo[index].Notes = notes;
                notesToDo[index].Headline = headline;
                notesToDo[index].Date = date;
                note = notesToDo[index];
            }

            SaveData();
            return note;
        }


        public void DeleteNote(int noteId)
        {
            try
            {
                notesHaphazard.Remove(notesHaphazard.First(n => n.Id == noteId));
            }
            catch
            {
                notesToDo.Remove(notesToDo.First(n => n.Id == noteId));
            }

            SaveData();
        }

        public List<NoteHaphazardIdeas> FindAllUserIdeaNotes(int userId)
        {
            List<NoteHaphazardIdeas> notes = new List<NoteHaphazardIdeas>();
            notes.AddRange(notesHaphazard.Where(n => n.UserId == userId).ToList());
            var sortedNotes = from n in notes
                              orderby n.Date descending
                              select n;
            return sortedNotes.ToList();
        }

        public List<NoteToDoList> FindAllUserListNotes(int userId)
        {
            List<NoteToDoList> notes = new List<NoteToDoList>();
            notes.AddRange(notesToDo.Where(n => n.UserId == userId).ToList());
            var sortedNotes = from n in notes
                              orderby n.Date descending
                              select n;
            return sortedNotes.ToList();
        }

        public Note FindNoteByUserAndHeadline(int userId, string headline)
        {
            List<Note> notes = new List<Note>();
            notes.AddRange(notesHaphazard.Where(n => n.UserId == userId).ToList());
            notes.AddRange(notesToDo.Where(n => n.UserId == userId).ToList());
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
