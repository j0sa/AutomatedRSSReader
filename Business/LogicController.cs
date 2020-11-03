using System;
using System.Collections.Generic;
using System.Text;
using Models;
using Data;
using System.Threading.Tasks;

namespace Business
{
    public class LogicController
    {
        public List<Podcast> podds;
        public LogicController()
        {
            podds = new List<Podcast>();
            podds = GetAll();
        }

        public List<Podcast> GetAll()
        {
            OtherSerializer serializer = new OtherSerializer();
            return serializer.DeserializeList();
        }

        public void newSerialiazion(List<Podcast> podcasts)
        {
            OtherSerializer serializer = new OtherSerializer();
            serializer.Serialize(podcasts);
        }


        public Task <List<Podcast>> AddNewPodcast(string url, string category, string updateFreq, string name)
        {
            if (!String.IsNullOrEmpty(url))
            {
                if (Validation.IfCorrectURL(url))
                {
                    string selectedCategory = category;

                    if (!string.IsNullOrWhiteSpace(updateFreq) || !string.IsNullOrWhiteSpace(selectedCategory))
                    {
                        podds.Add(new Podcast(url, name, int.Parse(updateFreq), selectedCategory));
                    }
                    OtherSerializer serializer = new OtherSerializer();
                    serializer.Serialize(podds);
                }
            } return Task.FromResult (podds);
        }
        
    }
}
