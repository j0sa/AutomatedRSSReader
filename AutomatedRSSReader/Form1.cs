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

        private void podcastTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void podcastNew_Click(object sender, EventArgs e)
        {
            Podcast podcast = new Podcast(urlInput.Text, updateFreqSelect.Value);
            OtherSerializer serializer = new OtherSerializer();
            serializer.Serialize(podcast);

            List<Episode> episodes = podcast.createListOfEpisodes();
            try
            {
                episodes.Reverse();
            } catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            
            foreach (Episode episode in episodes)
            {
                int indexNumber = episode.IndexNumber;
                string title = episode.Title;
                podcastList.Items.Add($"Episode {indexNumber}: {title}");
                //podcastList.Items.Add(episode.Description);
            }
        }

        

        private void podcastSave_Click(object sender, EventArgs e)
        {
            OtherSerializer serializer = new OtherSerializer();
            Podcast podcast = serializer.Deserialize();

            List<Episode> episodes = podcast.createListOfEpisodes();
            foreach (Episode episode in episodes)
            {
                int indexNumber = episode.IndexNumber;
                string title = episode.Title;
                podcastList.Items.Add($"Episode {indexNumber}: {title}");
                //podcastList.Items.Add(episode.Description);
            }
        }



        // Dessa metoder tillhör uppdatering av lista med titlar - Test för att se att den fungerar!

        public void updateListViewPodcast()
        {
            
            string fornamn = "Johan";
            string efternamn = "Birgersson";
            string frekvens = "5";
            string kategori = "sport";
            ListViewItem item = new ListViewItem(fornamn);
            item.SubItems.Add(efternamn);
            item.SubItems.Add(frekvens);
            item.SubItems.Add(kategori);

            listViewPodcast.Items.Add(item);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateListViewPodcast();
        }
    }
}
