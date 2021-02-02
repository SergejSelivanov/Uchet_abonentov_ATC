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
    public partial class RekvisitiGlavBuch : Form
    {
        public RekvisitiGlavBuch()
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


            MySqlCommand command = new MySqlCommand("SELECT * FROM Rekvisiti as A LEFT JOIN PersonalData as B ON(A.ID_abonenta = B.ID)", db.getConnection());                                //выбор данных из пд


            command.ExecuteNonQuery();
            reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                var now = DateTime.Today;

                data.Add(new String[3]);
                data[data.Count - 1][0] = reader[0].ToString();                               //добавление в датагрид
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
            GlavBuchForm fr2 = new GlavBuchForm();                               //переход на форму главного Бухгалтера
            fr2.Show();
            Hide();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
