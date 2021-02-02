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
    public partial class AddTest1 : Form
    {
        public AddTest1()
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

            check1 = new MySqlCommand("SELECT * FROM `Linia_charackters`", db.getConnection());

            adapter1.SelectCommand = check1;
            adapter1.Fill(table1);
            comboBox1.DataSource = table1;
            comboBox1.DisplayMember = "ID";
        }

        private void AddTest1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" && textBox1.Text == "")
            {
                MessageBox.Show("Заполните поля!");
                return;
            }
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `Results` (`ID_linii`, `Results`) VALUES (@ID_linii, @Results)", db.getConnection());

            command.Parameters.Add("@ID_linii", MySqlDbType.VarChar).Value = comboBox1.Text;
            command.Parameters.Add("@Results", MySqlDbType.VarChar).Value = textBox1.Text;                               //добавление информации о тестировании линии



            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Данные были записаны, перейдите в раздел просмотра");
            else
                MessageBox.Show("Не удалось записать данные");

            db.closeConnection();
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
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
