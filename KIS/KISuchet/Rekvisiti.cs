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
    public partial class Rekvisiti : Form
    {
        public Rekvisiti()
        {
            InitializeComponent();
            ft_update1();
        }
        private void ft_update1()
        {
            dataGridView1.Rows.Clear();                               //очистка датагрид
            DB db = new DB();

            MySqlDataReader reader = null;

            MySqlConnection dbc = db.getConnection();


            db.openConnection();


            MySqlCommand command = new MySqlCommand("SELECT * FROM Rekvisiti as A LEFT JOIN PersonalData as B ON(A.ID_abonenta = B.ID)", db.getConnection());                               //выборка из бд


            command.ExecuteNonQuery();
            reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                var now = DateTime.Today;

                data.Add(new String[3]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();                                //запись в датагрид
                data[data.Count - 1][2] = reader[2].ToString();
                

            }

            db.closeConnection();

            foreach (string[] s in data)
            {
                dataGridView1.Rows.Add(s);
            }
        }
        private void Rekvisiti_Load(object sender, EventArgs e)
        {

        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuchgalterForm fr2 = new BuchgalterForm();                               //переход на форму бухгалтера
            fr2.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddRekvisiti fr = new AddRekvisiti();                               //переход на Форму добавлекния реквизитов
            fr.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlConnection dbc = db.getConnection();
            if (dbc == null)
            {
                return;
            }
            db.openConnection();
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("SELECT * FROM `Rekvisiti` WHERE `ID` = @id ", db.getConnection());
                command1.Parameters.Add("@id", MySqlDbType.VarChar).Value = textBox1.Text;

                adapter.SelectCommand = command1;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    var result = new System.Windows.Forms.DialogResult();
                    result = MessageBox.Show("Точно удалить?", "Внимание!",
                    MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {

                        MySqlCommand command = new MySqlCommand("DELETE FROM `Rekvisiti` WHERE `ID`=@id", db.getConnection());                               //удаление из бд
                        command.Parameters.AddWithValue("id", textBox1.Text);
                        command.ExecuteNonQuery();
                        MessageBox.Show("Вы успешно удалили договор, теперь нажмите на кнопку обновить!");
                    }
                }
                else
                {
                    MessageBox.Show("Поля с данным ID не существует !");
                }
            }
            else
            {
                MessageBox.Show("Укажите ID договора который хотите удалить!");
            }
            db.closeConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DB db = new DB();

            MySqlDataReader reader = null;

            MySqlConnection dbc = db.getConnection();


            db.openConnection();


            MySqlCommand command = new MySqlCommand("SELECT * FROM Rekvisiti as A LEFT JOIN PersonalData as B ON(A.ID_abonenta = B.ID)", db.getConnection());                               //выборка из бд


            command.ExecuteNonQuery();
            reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();
            while (reader.Read())
            {
                var now = DateTime.Today;

                data.Add(new String[3]);
                data[data.Count - 1][0] = reader[0].ToString();
                data[data.Count - 1][1] = reader[1].ToString();
                data[data.Count - 1][2] = reader[2].ToString();
                

            }

            db.closeConnection();

            foreach (string[] s in data)
            {
                dataGridView1.Rows.Add(s);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            editRekvisiti editDog = new editRekvisiti();
            editDog.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
