using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedRSSReader
{
    public class Episode
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int IndexNumber { get; set; }

        public Episode(string title, string description, int indexNumber)
        {
            Title = title;
            Description = description;
            IndexNumber = indexNumber;
        }
    }
}
