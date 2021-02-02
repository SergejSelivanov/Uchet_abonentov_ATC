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
    public partial class AddOborudovanie : Form
    {
        public AddOborudovanie()
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
            
            check1 = new MySqlCommand("SELECT * FROM `PersonalData`", db.getConnection());
           
            adapter1.SelectCommand = check1;
            adapter1.Fill(table1);
            comboBox1.DataSource = table1;
            comboBox1.DisplayMember = "ID";
          
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" && textBox1.Text == "" && textBox2.Text == "" )
            {
                MessageBox.Show("Заполните поля!");
                return;
            }
            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `Oborudovanie` (`ID_abonenta`, `Phone`, `NameOfOborudovanie`) VALUES (@ID_abonenta, @Phone, @NameOfOborudovanie)", db.getConnection());

            command.Parameters.Add("@ID_abonenta", MySqlDbType.VarChar).Value = comboBox1.Text;
            command.Parameters.Add("@Phone", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@NameOfOborudovanie", MySqlDbType.VarChar).Value = textBox2.Text;                               //добавление оборудования


            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Данные были записаны, нажмите кнопку обновить!");
            else
                MessageBox.Show("Не удалось записать данные");

            db.closeConnection();


        }

        private void AddOborudovanie_Load(object sender, EventArgs e)
        {

        }
    }
}
