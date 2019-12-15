using System;
using System.Collections.Generic;
using System.Text;

namespace Team_Project
{
    class ContentToDo
    {
        public int Number { get; set; }
        public DateTime DataEvent { get; set; }
        public string Task { get; set; }
        public bool Finished { get; set; }
        public ContentToDo(int number, DateTime dataEvent, string task, bool finished)
        {
            Number = number;
            DataEvent = dataEvent;
            Task = task;
            Finished = finished;
        }
    }
    
}
