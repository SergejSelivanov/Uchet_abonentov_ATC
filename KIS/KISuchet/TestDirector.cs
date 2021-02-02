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
    public partial class TestDirector : Form
    {
        public TestDirector()
        {
            InitializeComponent();
            ft_update1();
        }
        private void ft_update1()
        {
            dataGridView1.Rows.Clear();
            DB db = new DB();

            MySqlDataReader reader = null;

            MySqlConnection dbc = db.getConnection();                               //подключение к бд


            db.openConnection();


            MySqlCommand command = new MySqlCommand("SELECT * FROM Results as A LEFT JOIN Linia_charackters as B ON(A.ID_linii = B.ID)", db.getConnection());


            command.ExecuteNonQuery();
            reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                var now = DateTime.Today;

                data.Add(new String[3]);
                data[data.Count - 1][0] = reader[0].ToString();                               //выбор данных из бд
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();


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


        private void TestDirector_Load(object sender, EventArgs e)
        {

        }
    }
}
