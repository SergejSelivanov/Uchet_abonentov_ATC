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
    public partial class EditPersonalData : Form
    {
        public EditPersonalData()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlConnection dbc = db.getConnection();
          
            if (!string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox5.Text))
            {
                db.openConnection();
                var result = new System.Windows.Forms.DialogResult();
                result = MessageBox.Show("Точно отредактировать?", "Внимание!",
                MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    MySqlCommand command = new MySqlCommand("UPDATE `PersonalData` SET `name`=@Name, `passport`=@Passport, `adres` = @Adres, `pol` =@Pol WHERE `id`=@id", db.getConnection());
                    command.Parameters.AddWithValue("Name", textBox2.Text);
                    command.Parameters.AddWithValue("Passport", textBox3.Text);    //изменение данных о персонале в бд
                    command.Parameters.AddWithValue("Adres", textBox4.Text);
                    command.Parameters.AddWithValue("Pol", textBox5.Text);
                    command.Parameters.AddWithValue("id", textBox1.Text);

                    command.ExecuteNonQuery();
                    MessageBox.Show("Вы успешно отредактировали элемент! После закрытия формы обновите данные!");
                    this.Close();
                }
                db.closeConnection();
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }

        private void EditPersonalData_Load(object sender, EventArgs e)
        {

        }
    }
}
