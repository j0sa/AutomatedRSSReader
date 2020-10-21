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
            description.ReadOnly = true;


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void podcastTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void podcastNew_Click(object sender, EventArgs e)
        {
            Podcast podcast = new Podcast(urlInput.Text);
            podcastList.Items.Add(podcast.Title);
            podcastList.Items.Add(podcast.Description);
        }

        private void podcastSave_Click(object sender, EventArgs e)
        {

        }
    }
}
