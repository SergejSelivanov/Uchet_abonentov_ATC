using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uchet_abonetnov_ATC
{
    public partial class DirectorForm : Form
    {
        public DirectorForm()
        {
            InitializeComponent();
        }

        private void разлогаутитьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm fr2 = new LoginForm();
            fr2.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonalDataDirector fr2 = new PersonalDataDirector();
            fr2.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OborudovanieDirector fr2 = new OborudovanieDirector();
            fr2.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TestDirector fr2 = new TestDirector();
            fr2.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RekvisitiDirector fr2 = new RekvisitiDirector();
            fr2.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CharactersDirector fr2 = new CharactersDirector();
            fr2.Show();
            Hide();
        }

        private void DirectorForm_Load(object sender, EventArgs e)
        {

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://xn--80abdabhib1a1ac1aghc2b.xn--p1acf/");
        }
    }
}
