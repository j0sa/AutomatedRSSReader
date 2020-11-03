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
using System.Data.SqlTypes;
using System.Runtime.Serialization;
using Business;
using Models;
using Data;

namespace AutomatedRSSReader
{
    public partial class Form1 : Form
    {
        private Timer timer = new Timer();
        LogicController lc = new LogicController();
        public SyndicationFeed feed;
        public List<Podcast> podcasts = new List<Podcast>();
        public Podcast selectedPodcast;
        public List<string> categoryList = new List<string>();

        public Form1()
        {
            InitializeComponent();

            timer.Interval = 30000;
            timer.Tick += TimerTick;
            timer.Start();
            
            // Ändrar namnet från Form1 till Podcasts
            this.Text = "Podcasts";
            episodeDescription.ReadOnly = true;
            CreateListOfPodcasts();
            DisplayPodcasts(podcasts);
            DisplayCategories();
        }

        private void podcastNew_Click(object sender, EventArgs e)
        {
            string url = urlInput.Text;
            string category = categorySelect.Text;
            string updateFreq = updateFreqSelect.Text;
            string name = podcastName.Text;

            lc.AddNewPodcast(url, category, updateFreq, name);
            DisplayPodcasts(podcasts);
        }

        private void podcastSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (urlInput.Text != null || podcastName != null || !string.IsNullOrWhiteSpace(categorySelect.Text))
            {
                selectedPodcast.Url = urlInput.Text;
                selectedPodcast.Name = podcastName.Text;
                selectedPodcast.UpdateFreq = int.Parse(updateFreqSelect.Text);
                selectedPodcast.Category = categorySelect.Text;
                lc.newSerialiazion(podcasts);
            }
            }
            catch(Exception wrong)
            {
                Console.WriteLine(wrong.Message);
            }
            podcastList.Items.Clear();
            categories.Items.Clear();
            DisplayPodcasts(podcasts);
            DisplayCategories();
        }

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
            lc.newSerialiazion(podcasts);
            DisplayPodcasts(podcasts);
        }

        protected void CreateListOfPodcasts()
        {
            string currentDir = Directory.GetCurrentDirectory();
            string filePath = @"\podcastListData.xml";

            if (File.Exists(currentDir + filePath))
            {

                List<Podcast> podcastList = lc.GetAll();

                podcasts.AddRange(podcastList);

                DisplayPodcasts(podcasts);

                foreach (Podcast podcast in podcasts)
                {
                    categoryList.Add(podcast.Category);
                }
            }
        }

        protected void DisplayPodcasts(List<Podcast> poddar)
        {
            podcastList.Items.Clear();
            foreach (Podcast podcast in poddar)
            {
                int numberOfEpisodes = podcast.NumberOfEpisodes;
                string name = podcast.Name;
                string category = podcast.Category;
                int freq = podcast.UpdateFreq;

                podcastList.Items.Add($"{name}; {numberOfEpisodes}, {freq}, {category}");
            }
        }

        protected void DisplayCategories()
        {
            categories.Items.Clear();
            categorySelect.Items.Clear();

            var noDupes = new HashSet<string>(categoryList).ToList();
            foreach (string category in noDupes)
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
                    if (item.Contains(podcast.Name))
                    {
                        selectedPodcast = podcast;

                        urlInput.Text = podcast.Url;
                        podcastName.Text = podcast.Name;

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
            DisplayCategories();
        }

        private void categoryRemove_Click(object sender, EventArgs e)
        {
            if (categories.SelectedItem != null)
            {
                // Hämtar ut den valda kategorin som användaren väljer
                string selectedCat = categories.SelectedItem.ToString();

                // Variabler med information samt valmöjlighet
                string message = "Are you sure you want to delete this category? ";
                string caption = "Message from the program";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // För att visa en MessageBox samt raderar vald kategori med LINQ
                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    podcasts.RemoveAll(x => x.Category == selectedCat);

                    lc.newSerialiazion(podcasts);

                    categoryList.Remove(selectedCat);
                    DisplayCategories();
                    DisplayPodcasts(podcasts);
                }
            }
        }

        private void categorySave_Click(object sender, EventArgs e)
        {
            try {
                string oldCatName = categories.SelectedItem.ToString();
                string newCatName = categoryInput.Text;

                foreach (Podcast podcast in podcasts)
                {
                    if (podcast.Category.Equals(oldCatName))
                    {
                        podcast.Category = newCatName;
                    }
                }
            }
            catch(Exception wrong1)
            {
                Console.WriteLine(wrong1.Message);
            }

            lc.newSerialiazion(podcasts);

            categoryList.Clear();
            podcasts.Clear();

            CreateListOfPodcasts();
            DisplayPodcasts(podcasts);
            DisplayCategories();
        }

        private void categories_MouseClick(object sender, MouseEventArgs e)
        {
            if (categories.SelectedItem != null)
            {
                string item = categories.SelectedItem.ToString();
                categoryInput.Text = item;

                podcastList.Items.Clear();

                foreach (Podcast podcast in podcasts)
                {
                    if (podcast.Category.Equals(item))
                    {
                        int numberOfEpisodes = podcast.NumberOfEpisodes;
                        string name = podcast.Name;
                        string category = podcast.Category;
                        int freq = podcast.UpdateFreq;

                        podcastList.Items.Add($"{name}, {numberOfEpisodes}, {freq}, {category}");
                    }
                }
            }
        }

        private void categories_Leave(object sender, EventArgs e)
        {
            DisplayPodcasts(podcasts);
        }

        private void TimerTick(object sender, EventArgs e)
        {
            foreach (Podcast podcast in podcasts)
            {
                if (podcast.NeedsUpdate)
                {
                    podcast.Update();
                }
                else
                {
                    Console.WriteLine(podcast.Name + ".NeedsUpdate == false");
                }
            }

            categoryList.Clear();
            podcasts.Clear();

            CreateListOfPodcasts();
            DisplayPodcasts(podcasts);
            DisplayCategories();
        }

        private void getEntityType_Click(object sender, EventArgs e)
        {
            string selectedEntity = "You have selected:\n";
            bool anythingWasSelected = false;
            if (episodeList.SelectedItems.Count == 1)
            {
                selectedEntity += new Episode().EntityType();
                anythingWasSelected = true;
            }
            if (podcastList.SelectedItems.Count == 1)
            {
                selectedEntity += new Podcast().EntityType();
                anythingWasSelected = true;
            }
            if (anythingWasSelected)
            {
                MessageBox.Show(selectedEntity);
            }
            else
            {
                MessageBox.Show("You have not selected anything!");
            }
        }
    }
}
