using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.ServiceModel.Syndication;
using System.IO;

namespace AutomatedRSSReader
{
    public partial class Form1 : Form
    {

        public SyndicationFeed feed;
        public List<Podcast> podcasts = new List<Podcast>();
        public Podcast selectedPodcast;
        public Form1()
        {
            InitializeComponent();
            // Ändrar namnet från Form1 till Podcasts
            this.Text = "Podcasts";
            episodeDescription.ReadOnly = true;
            CreateListOfPodcasts();
            checkIfFileExists();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void podcastNew_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(urlInput.Text))
            {
                podcasts.Add(new Podcast(urlInput.Text, updateFreqSelect.Value, "asdsadsadsadsa"));
                OtherSerializer serializer = new OtherSerializer();
                serializer.Serialize(podcasts);
                podcastList.Items.Clear();
                foreach (Podcast podcast in podcasts)
                {
                    int numberOfEpisodes = podcast.NumberOfEpisodes;
                    string name = podcast.Title;
                    string category = podcast.Category;
                    decimal freq = podcast.UpdateFreq;

                    podcastList.Items.Add($"{numberOfEpisodes}, {name}, {freq}, {category}");
                }
            }
        }

        private void podcastSave_Click(object sender, EventArgs e)
        {
            OtherSerializer serializer = new OtherSerializer();
            Podcast podcast = serializer.Deserialize();

            foreach (Episode episode in podcast.Episodes)
            {
                episodeList.Items.Add($"{episode.UploadDate}: {episode.Title}");
            }
        }

        // Dessa metoder tillhör uppdatering av lista med titlar - Test för att se att den fungerar!

        private void episodeList_MouseClick(object sender, MouseEventArgs e)
        {
            string item = episodeList.SelectedItem.ToString();

            foreach (Episode episode in selectedPodcast.Episodes)
            {
                if (item.Contains(episode.Title))
                {
                    episodeDescription.Text = episode.Description;
                }
            }
        }

        private void podcastRemove_Click(object sender, EventArgs e)
        {
            OtherSerializer serializer = new OtherSerializer();
            serializer.DeserializeList();
        }

        protected void CreateListOfPodcasts()
        {
            string filePath = @"C:\Users\Admin\source\repos\AutomatedRSSReader\AutomatedRSSReader\bin\Debug\podcastListData.xml";

            if (File.Exists(filePath))
            {
                OtherSerializer serializer = new OtherSerializer();
                List<Podcast> podcastList = serializer.DeserializeList();

                podcasts.AddRange(podcastList);

                DisplayListItems();
            }
        }

        protected void DisplayListItems()
        {
            podcastList.Items.Clear();
            foreach (Podcast podcast in podcasts)
            {
                int numberOfEpisodes = podcast.NumberOfEpisodes;
                string name = podcast.Title;
                string category = podcast.Category;
                decimal freq = podcast.UpdateFreq;

                podcastList.Items.Add($"{numberOfEpisodes}, {name}, {freq}, {category}");
            }
        }

        protected void checkIfFileExists()
        {
            string filePath = @"C:\Users\Admin\source\repos\AutomatedRSSReader\AutomatedRSSReader\bin\Debug\podcastListData.xml";

            Console.WriteLine(File.Exists(filePath) ? "Exists" : "Does not exist");
        }

        private void podcastList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string item = podcastList.SelectedItem.ToString();

            foreach (Podcast podcast in podcasts)
            {
                if (item.Contains(podcast.Title))
                {
                    foreach (Episode episode in podcast.Episodes)
                    {
                        selectedPodcast = podcast;
                        episodeList.Items.Add($"{episode.UploadDate}: {episode.Title}");
                    }
                }
            }
        }

        private void podcastList_MouseClick(object sender, MouseEventArgs e)
        {
            string item = podcastList.SelectedItem.ToString();

            foreach (Podcast podcast in podcasts)
            {
                if (item.Contains(podcast.Title))
                {
                    selectedPodcast = podcast;
                    foreach (Episode episode in podcast.Episodes)
                    {
                        episodeList.Items.Add($"{episode.UploadDate}: {episode.Title}");
                    }
                }
            }
        }
    }
}
