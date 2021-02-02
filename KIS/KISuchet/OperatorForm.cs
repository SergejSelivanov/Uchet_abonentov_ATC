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
    public partial class OperatorForm : Form
    {
        public OperatorForm()
        {
            InitializeComponent();
        }

        private void разлогинитьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm fr2 = new LoginForm();                               //переход на формы и возврат на предыдущию
            fr2.Show();
            Hide();
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm fr = new LoginForm();
            fr.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Linia_Characters fr = new Linia_Characters();
            fr.Show();
        }

        private void OperatorForm_Load(object sender, EventArgs e)
        {

        }
    }
}
