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
    public partial class EditTest : Form
    {
        public EditTest()
        {
            InitializeComponent();
        }

        private void назадToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestForm fr2 = new TestForm();
            fr2.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DB db = new DB();
            MySqlConnection dbc = db.getConnection();

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox2.Text) )
            {
                db.openConnection();
                var result = new System.Windows.Forms.DialogResult();
                result = MessageBox.Show("Точно отредактировать?", "Внимание!",
                MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    MySqlCommand command = new MySqlCommand("UPDATE `Results` SET `Results`=@Results  WHERE `ID`=@ID", db.getConnection());
                    command.Parameters.AddWithValue("Results", textBox2.Text);  //изменение данных о тестах линии в бд

                    command.Parameters.AddWithValue("ID", textBox1.Text);



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

        private void EditTest_Load(object sender, EventArgs e)
        {

        }
    }
}
