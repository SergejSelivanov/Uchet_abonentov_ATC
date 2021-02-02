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
    public partial class GlavBuchForm : Form
    {
        public GlavBuchForm()
        {
            InitializeComponent();
        }

        private void GlavBuchForm_Load(object sender, EventArgs e)
        {

        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm fr2 = new LoginForm();
            fr2.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RekvisitiGlavBuch fr2 = new RekvisitiGlavBuch();
            fr2.Show();
            Hide();
        }
     

        private void button2_Click_1(object sender, EventArgs e)
        {
            SeeGlavBuch fr2 = new SeeGlavBuch();
            fr2.Show();
            Hide();
        }
    }
}
