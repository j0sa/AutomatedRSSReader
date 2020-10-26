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

namespace AutomatedRSSReader
{
    public partial class Form1 : Form
    {

        public SyndicationFeed feed;
        public List<Podcast> podcasts = new List<Podcast>();

        public Form1()
        {
            InitializeComponent();
            // Ändrar namnet från Form1 till Podcasts
            this.Text = "Podcasts";
            episodeDescription.ReadOnly = true;
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
                    ListViewItem item = new ListViewItem(numberOfEpisodes.ToString());

                    item.SubItems.Add(name);
                    item.SubItems.Add(freq.ToString());
                    item.SubItems.Add(category);

                    podcastList.Items.Add(item);
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

        public void updateListViewPodcast()
        {
            
            //string fornamn = "Johan";
            //string efternamn = "Birgersson";
            //string frekvens = "5";
            //string kategori = "sport";
            //ListViewItem item = new ListViewItem(fornamn);
            //item.SubItems.Add(efternamn);
            //item.SubItems.Add(frekvens);
            //item.SubItems.Add(kategori);

            //listViewPodcast.Items.Add(item);

            OtherSerializer serializer = new OtherSerializer();
            Podcast podcast = serializer.Deserialize();

            int numberOfEpisodes = podcast.NumberOfEpisodes;
            string name = podcast.Title;
            string category = podcast.Category;
            decimal freq = podcast.UpdateFreq;
            Console.WriteLine(numberOfEpisodes.ToString(), freq, name, category);
            ListViewItem item = new ListViewItem(numberOfEpisodes.ToString());

            item.SubItems.Add(name);
            item.SubItems.Add(freq.ToString());
            item.SubItems.Add(category);

            podcastList.Items.Add(item);
        }

        private void podcastList_MouseClick(object sender, MouseEventArgs e)
        {
            OtherSerializer serializer = new OtherSerializer();
            Podcast podcast = serializer.Deserialize();

            string item = podcastList.SelectedItems[0].SubItems[1].Text;

            if (item.Contains(podcast.Title))
            {
                foreach (Episode episode in podcast.Episodes)
                {
                    episodeList.Items.Add($"{episode.UploadDate}: {episode.Title}");
                }
            }
        }

        private void episodeList_MouseClick(object sender, MouseEventArgs e)
        {
            OtherSerializer serializer = new OtherSerializer();
            Podcast podcast = serializer.Deserialize();

            string item = episodeList.SelectedItem.ToString();

            foreach (Episode episode in podcast.Episodes)
            {
                if (item.Contains(episode.Title))
                {
                    episodeDescription.Text = episode.Description;
                }
            }
        }
    }
}
