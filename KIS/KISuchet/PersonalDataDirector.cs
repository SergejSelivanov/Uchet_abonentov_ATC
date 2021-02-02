using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Uchet_abonetnov_ATC
{
    public partial class PersonalDataDirector : Form
    {
        public PersonalDataDirector()
        {
            InitializeComponent();
            ft_update1();
        }
        private void ft_update1()
        {
            dataGridView1.Rows.Clear();
            DB db = new DB();

            MySqlDataReader reader = null;

            MySqlConnection dbc = db.getConnection();

            db.openConnection();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `PersonalData`", db.getConnection());

            command.ExecuteNonQuery();
            reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                var now = DateTime.Today;

                data.Add(new String[5]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                data[data.Count - 1][3] = reader[3].ToString();
                data[data.Count - 1][4] = reader[4].ToString();
            }

            db.closeConnection();

            foreach (string[] s in data)
            {
                dataGridView1.Rows.Add(s);
            }
        }
        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DirectorForm fr2 = new DirectorForm();
            fr2.Show();
            Hide();
        }

        private void PersonalDataDirector_Load(object sender, EventArgs e)
        {

        }
    }
}
