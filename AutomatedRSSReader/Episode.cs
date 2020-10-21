using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedRSSReader
{
    class Episode
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Episode(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
