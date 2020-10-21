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
        public Form1()
        {
            InitializeComponent();
            // Ändrar namnet från Form1 till Podcasts
            this.Text = "Podcasts";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        

    }
}
