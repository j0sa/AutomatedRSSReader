﻿using System;
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

namespace AutomatedRSSReader
{
    public partial class Form1 : Form
    {
        private Timer timer = new Timer();

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
            DisplayPodcasts();
            DisplayCategories();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void podcastNew_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(urlInput.Text))
            {
                if (Validation.IfCorrectURL(urlInput.Text))
                {
                    string selectedCategory = categorySelect.Text;

                    if (!string.IsNullOrWhiteSpace(updateFreqSelect.Text) || !string.IsNullOrWhiteSpace(selectedCategory))
                    {
                        podcasts.Add(new Podcast(urlInput.Text, podcastName.Text, int.Parse(updateFreqSelect.Text), selectedCategory));
                    }

                    urlInput.Text = "";
                    podcastName.Text = "";

                    OtherSerializer serializer = new OtherSerializer();
                    serializer.Serialize(podcasts);
                    podcastList.Items.Clear();
                    foreach (Podcast podcast in podcasts)
                    {
                        int numberOfEpisodes = podcast.NumberOfEpisodes;
                        string name = podcast.Name;
                        string category = podcast.Category;
                        int freq = podcast.UpdateFreq;

                        podcastList.Items.Add($"{numberOfEpisodes}, {name}, {freq}, {category}");
                    }
                }
            }
            DisplayPodcasts();
        }

        private void podcastSave_Click(object sender, EventArgs e)
        {
            OtherSerializer serializer = new OtherSerializer();

            if (urlInput.Text != null || podcastName != null || categorySelect.Text != null)
            {
                selectedPodcast.Url = urlInput.Text;
                selectedPodcast.Name = podcastName.Text;
                selectedPodcast.UpdateFreq = int.Parse(updateFreqSelect.Text);
                selectedPodcast.Category = categorySelect.Text;
            }

            serializer.Serialize(podcasts);
            podcastList.Items.Clear();
            DisplayPodcasts();
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
            DisplayPodcasts();
        }

        protected void CreateListOfPodcasts()
        {
            string currentDir = Directory.GetCurrentDirectory();
            string filePath = @"\podcastListData.xml";

            if (File.Exists(currentDir + filePath))
            {
                OtherSerializer serializer = new OtherSerializer();
                List<Podcast> podcastList = serializer.DeserializeList();

                podcasts.AddRange(podcastList);

                DisplayPodcasts();

                foreach (Podcast podcast in podcasts)
                {
                    categoryList.Add(podcast.Category);
                }
            }
        }

        protected void DisplayPodcasts()
        {
            podcastList.Items.Clear();
            foreach (Podcast podcast in podcasts)
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

                    OtherSerializer serializer = new OtherSerializer();
                    serializer.Serialize(podcasts);

                    categoryList.Remove(selectedCat);
                    DisplayCategories();
                    DisplayPodcasts();
                }
            }
        }

        private void categorySave_Click(object sender, EventArgs e)
        {
            OtherSerializer serializer = new OtherSerializer();
            string oldCatName = categories.SelectedItem.ToString();
            string newCatName = categoryInput.Text;

            foreach (Podcast podcast in podcasts)
            {
                if (podcast.Category.Equals(oldCatName))
                {
                    podcast.Category = newCatName;
                }
            }

            serializer.Serialize(podcasts);

            categoryList.Clear();
            podcasts.Clear();

            CreateListOfPodcasts();
            DisplayPodcasts();
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
            DisplayPodcasts();
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
            DisplayPodcasts();
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
