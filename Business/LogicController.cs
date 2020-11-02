using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Data;

namespace Business
{
    public class LogicController
    {
        public List<Podcast> podcasts = new List<Podcast>();
        public List<Podcast> AddNewPodcast(string url, string category, string updateFreq, string name)
        {
            if (!String.IsNullOrEmpty(url))
            {
                if (Validation.IfCorrectURL(url))
                {
                    string selectedCategory = category;

                    if (!string.IsNullOrWhiteSpace(updateFreq) || !string.IsNullOrWhiteSpace(selectedCategory))
                    {
                        podcasts.Add(new Podcast(url, name, int.Parse(updateFreq), selectedCategory));
                    }

                    OtherSerializer serializer = new OtherSerializer();
                    serializer.Serialize(podcasts);
                    
                }
            } return podcasts;
        }
    }
}
