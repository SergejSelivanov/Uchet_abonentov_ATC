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
    public partial class editRekvisiti : Form
    {
        public editRekvisiti()
        {
            InitializeComponent();
        }

        private void editRekvisiti_Load(object sender, EventArgs e)
        {

        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BuchgalterForm fr2 = new BuchgalterForm();
            fr2.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlConnection dbc = db.getConnection();

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                db.openConnection();
                var result = new System.Windows.Forms.DialogResult();
                result = MessageBox.Show("Точно отредактировать?", "Внимание!",
                MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    MySqlCommand command = new MySqlCommand("UPDATE `Rekvisiti` SET `Rekvisiti`=@Rekvisiti WHERE `ID`=@ID", db.getConnection());
                    command.Parameters.AddWithValue("Rekvisiti", textBox2.Text);
                    
                    command.Parameters.AddWithValue("ID", textBox1.Text);               //изменение данных о реквизитах в бд



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

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
