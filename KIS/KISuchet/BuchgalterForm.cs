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
    public partial class BuchgalterForm : Form
    {
        public BuchgalterForm()
        {
            InitializeComponent();
        }

        private void BuchgalterForm_Load(object sender, EventArgs e)
        {

        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm fr2 = new LoginForm();
            fr2.Show();
            Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Rekvisiti fr2 = new Rekvisiti();
            fr2.Show();
            Hide();
        }
    }
}
