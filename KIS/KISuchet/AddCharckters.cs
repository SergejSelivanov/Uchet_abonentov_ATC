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
    public partial class AddCharckters : Form
    {
        public AddCharckters()
        {
            InitializeComponent();
            DB db = new DB();
            MySqlConnection dbc = db.getConnection();
            if (dbc == null)
            {
                return;
            }
            MySqlCommand check1;

            DataTable table1 = new DataTable();

            MySqlDataAdapter adapter1 = new MySqlDataAdapter();

            check1 = new MySqlCommand("SELECT * FROM `Oborudovanie`", db.getConnection());

            adapter1.SelectCommand = check1;
            adapter1.Fill(table1);
            comboBox1.DataSource = table1;
            comboBox1.DisplayMember = "ID";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Linia_Characters fr2 = new Linia_Characters();
            fr2.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" && textBox1.Text == "" && textBox2.Text == "")
            {
                MessageBox.Show("Заполните поля!");
                return;
            }
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `Linia_charackters` (`ID_Oborudovania`, `Linia_charackters`, `Parametrs`) VALUES (@ID_Oborudovania, @Linia_charackters, @Parametrs)", db.getConnection());

            command.Parameters.Add("@ID_Oborudovania", MySqlDbType.VarChar).Value = comboBox1.Text;
            command.Parameters.Add("@Linia_charackters", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@Parametrs", MySqlDbType.VarChar).Value = textBox2.Text;                               //добавление характеристик линии связи


            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Данные были записаны, перейдите в раздел просмотра");
            else
                MessageBox.Show("Не удалось записать данные");

            db.closeConnection();

        }

        private void AddCharckters_Load(object sender, EventArgs e)
        {

        }
    }
}
