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
            updateListViewPodcast();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void podcastTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void podcastNew_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(urlInput.Text))
            {
                Podcast podcast = new Podcast(urlInput.Text, updateFreqSelect.Value, "asdsadsadsadsa");
                OtherSerializer serializer = new OtherSerializer();
                serializer.Serialize(podcast);

                foreach (Episode episode in podcast.Episodes)
                {
                    DateTimeOffset uploadDate = episode.UploadDate;
                    string title = episode.Title;
                    episodeList.Items.Add($"{uploadDate}: {title}");
                    //podcastList.Items.Add(episode.Description);
                }
            }
        }

        private void podcastSave_Click(object sender, EventArgs e)
        {
            OtherSerializer serializer = new OtherSerializer();
            Podcast podcast = serializer.Deserialize();

            foreach (Episode episode in podcast.Episodes)
            {
                DateTimeOffset uploadDate = episode.UploadDate;
                string title = episode.Title;
                episodeList.Items.Add($"{uploadDate}: {title}");
                //podcastList.Items.Add(episode.Description);
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
            string item = episodeList.SelectedItem.ToString();
            episodeDescription.Text = item;
        }
    }
}
