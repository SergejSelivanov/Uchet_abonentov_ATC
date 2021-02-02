using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Uchet_abonetnov_ATC
{
    public partial class PersonalData : Form
    {
        public PersonalData()
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "" && textBox4.Text =="" && textBox5.Text == "" && textBox6.Text =="")
            {
                MessageBox.Show("Заполните поля!");
                return;
            }
                DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `PersonalData` (`Name`, `Passport`, `Adres`, `Pol`) VALUES (@Name, @Passport, @Adres, @Pol)", db.getConnection());

            command.Parameters.Add("@Name", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@Passport", MySqlDbType.VarChar).Value = textBox4.Text;
            command.Parameters.Add("@Adres", MySqlDbType.VarChar).Value = textBox5.Text;
            command.Parameters.Add("@Pol", MySqlDbType.VarChar).Value = textBox6.Text;

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Данные были записаны, нажмите кнопку обновить");
            else
                MessageBox.Show("Не удалось записать данные");

            db.closeConnection();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ft_update1();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
           
             EditPersonalData editDog = new EditPersonalData();                               //переход на форму изменения данных
            editDog.Show();
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            DB db = new DB();

            MySqlDataReader reader = null;

            MySqlConnection dbc = db.getConnection();

            db.openConnection();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `PersonalData`", db.getConnection());                                //обновление данных формы

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

        private void button2_Click(object sender, EventArgs e)
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
                MySqlCommand command1 = new MySqlCommand("SELECT * FROM `PersonalData` WHERE `id` = @id ", db.getConnection());                               //удаление данных
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

                        MySqlCommand command = new MySqlCommand("DELETE FROM `PersonalData` WHERE `ID`=@id", db.getConnection());
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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagerForm fr2 = new ManagerForm();
            fr2.Show();
            Hide();
        }

        private void PersonalData_Load(object sender, EventArgs e)
        {

        }
    }
}
