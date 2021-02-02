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
    public partial class ManagerForm : Form
    {
        public ManagerForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm fr2 = new LoginForm();                               //переход на формы необходимы менеджеру
            fr2.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonalData fr2 = new PersonalData();
            fr2.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OborudovanieForm fr2 = new OborudovanieForm();
            fr2.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TestForm fr2 = new TestForm();
            fr2.Show();
            Hide();
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
