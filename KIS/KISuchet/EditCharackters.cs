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
    public partial class EditCharackters : Form
    {
        public EditCharackters()
        {
            InitializeComponent();
        }

        private void EditCharackters_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
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
            DB db = new DB();
            MySqlConnection dbc = db.getConnection();

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox3.Text))
            {
                db.openConnection();
                var result = new System.Windows.Forms.DialogResult();
                result = MessageBox.Show("Точно отредактировать?", "Внимание!",
                MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    MySqlCommand command = new MySqlCommand("UPDATE `Linia_charackters` SET `Linia_charackters`=@Linia_charackters, `Parametrs`= @Parametrs WHERE `ID`=@ID", db.getConnection());
                    command.Parameters.AddWithValue("Linia_charackters", textBox2.Text);
                    command.Parameters.AddWithValue("Parametrs", textBox3.Text);
                    command.Parameters.AddWithValue("ID", textBox1.Text);                               //изменение данных в бд



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
    }
}
