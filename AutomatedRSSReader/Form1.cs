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
        public List<string> categoryList = new List<string>();
        public Form1()
        {
            InitializeComponent();
            // Ändrar namnet från Form1 till Podcasts
            this.Text = "Podcasts";
            episodeDescription.ReadOnly = true;
            CreateListOfPodcasts();
            DisplayListItems();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void podcastNew_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(urlInput.Text))
            {
                string selectedCategory = categorySelect.Text;
                podcasts.Add(new Podcast(urlInput.Text, updateFreqSelect.Value, selectedCategory));
                urlInput.Text = "";
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
                DisplayListItems();
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
            if (episodeList.SelectedItem != null)
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
        }

        private void podcastRemove_Click(object sender, EventArgs e)
        {
            podcasts.Remove(selectedPodcast);
            OtherSerializer serializer = new OtherSerializer();
            serializer.Serialize(podcasts);
            DisplayListItems();
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

                foreach (Podcast podcast in podcasts)
                {
                    categoryList.Add(podcast.Category);
                }
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
            categories.Items.Clear();
            categorySelect.Items.Clear();
            foreach (string category in categoryList)
            {
                categories.Items.Add(category);
                categorySelect.Items.Add(category);
            }
        }

        private void podcastList_MouseClick(object sender, MouseEventArgs e)
        {
            if (podcastList.SelectedItem != null)
            {
                string item = podcastList.SelectedItem.ToString();

                episodeList.Items.Clear();
                episodeDescription.Text = "";

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

        private void categoryNew_Click(object sender, EventArgs e)
        {
            string category = categoryInput.Text;
            categoryList.Add(category);
            DisplayListItems();
        }
    }
}
