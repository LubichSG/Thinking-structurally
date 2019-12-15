using System;
using System.Collections.Generic;
using System.Text;

namespace Team_Project.Models
{
    abstract class ContentHaphazar
    {
        public int Number { get; set; }
        public DateTime DataEvant { get; set; }
        public string Task { get; set; }
        public bool Finished { get; set; }
    }
}
