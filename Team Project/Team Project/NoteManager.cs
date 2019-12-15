using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Newtonsoft.Json;

namespace Team_Project
{
    public class NoteManager
    {
        private List<Note> notes;

        public NoteManager()
        {
            LoadData();
        }

        private const string NotesFileName = "data/notes.json";

        private T Deserialize<T>(string fileName)
        {
            using (var sr = new StreamReader(fileName))
            {
                using (var jsonReader = new JsonTextReader(sr))
                {
                    var serializer = new JsonSerializer();
                    return serializer.Deserialize<T>(jsonReader);
                }
            }
        }

        private void Serialize<T>(string fileName, T data)
        {
            using (var sw = new StreamWriter(fileName))
            {
                using (var jsonWriter = new JsonTextWriter(sw))
                {
                    jsonWriter.Formatting = Newtonsoft.Json.Formatting.Indented;
                    var serializer = new JsonSerializer();
                    serializer.Serialize(jsonWriter, data);
                }
            }
        }

        private void LoadData()
        {
            notes = Deserialize<List<Note>>(NotesFileName);
        }

        private void SaveNote(DateTime date, string content, int userId)
        {
            int id = notes.Count > 0 ? notes.Max(n => n.Id) + 1 : 1;
            var note = new Note(id, date, content, userId);
            notes.Add(note);
            Serialize(NotesFileName, notes);
        }
    }
}
