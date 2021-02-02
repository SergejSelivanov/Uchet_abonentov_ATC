using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Uchet_abonetnov_ATC
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.PassField.AutoSize = false;
            this.PassField.Size = new Size(this.PassField.Size.Width, 64);
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PassField_TextChanged(object sender, EventArgs e)
        {

        }

        private void выходToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            выходToolStripMenuItem.ForeColor = Color.Green;
        }

        private void выходToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            выходToolStripMenuItem.ForeColor = Color.Black;
        }

        Point lastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            String loginUser = UserField.Text;
            String passUser = PassField.Text;
            String Ozu = null;
            String Videokarta = null;
            String Processor = null;
            String Memory = null;
            DateTime date1 = DateTime.Today;
            String Os = null;

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `Users` WHERE `Login` = @uL AND `Password` = @uP", db.getConnection());                                //форма авторизации 
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
            command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;                               //ппроверка существование логина и пароля

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                string role = table.Rows[0][3].ToString();
                if (role == "Менеджер")
                {
                    this.Hide();
                    ManagerForm ManagerForm = new ManagerForm();                               //переход на главное меню в зависимости от должности
                    ManagerForm.Show();
                }
                if (role == "Бухгалтер")
                {
                    this.Hide();
                    BuchgalterForm fr = new BuchgalterForm();
                    fr.Show();
                }
                if (role == "Оператор ПК")
                {
                    this.Hide();
                    OperatorForm fr = new OperatorForm();
                    fr.Show();
                }
                if (role == "Директор")
                {
                    this.Hide();
                    DirectorForm fr = new DirectorForm();
                    fr.Show();
                }
                if (role == "Главный Бухгалтер")
                {
                    this.Hide();
                    GlavBuchForm fr = new GlavBuchForm();
                    fr.Show();
                }
            }
            else
                MessageBox.Show("Неверные данные");

            MySqlCommand DataAddcommand = new MySqlCommand("INSERT INTO `Computerinfo` (`Ozu`, `Videokarta`, `Processor`, `Memory`, `Os`, `DataMounth`) VALUES (@Ozu, @Videokarta, @Processor, @Memory, @Os, @DataMounth)", db.getConnection());

            ManagementObjectSearcher searcher11 =
            new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController");

            foreach (ManagementObject queryObj in searcher11.Get())
            {
                Videokarta = string.Format("Caption: {0}", queryObj["Caption"]);
            }
            ManagementObjectSearcher searcher12 =
            new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PhysicalMemory");

            foreach (ManagementObject queryObj1 in searcher12.Get())
            {
                Ozu = string.Format("Name: {0}", queryObj1["BankLabel"]);
            }
            ManagementObjectSearcher searcher13 =
            new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Keyboard");

            foreach (ManagementObject queryObj2 in searcher13.Get())
            {
                 Os  = string.Format("Name: {0}", queryObj2["Name"]);
            }
            ManagementObjectSearcher searcher14 =
          new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_MotherboardDevice");

            foreach (ManagementObject queryObj2 in searcher14.Get())
            {
                Memory = string.Format("Name: {0}", queryObj2["Name"]);
            }
            ManagementObjectSearcher searcher15 =
         new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");

            foreach (ManagementObject queryObj2 in searcher15.Get())
            {
                Processor = string.Format("Name: {0}", queryObj2["Name"]);
            }

            DataAddcommand.Parameters.Add("@Ozu", MySqlDbType.VarChar).Value = Ozu;
            DataAddcommand.Parameters.Add("@Videokarta", MySqlDbType.VarChar).Value = Videokarta;
            DataAddcommand.Parameters.Add("@Processor", MySqlDbType.VarChar).Value = Processor;
            DataAddcommand.Parameters.Add("@Memory", MySqlDbType.VarChar).Value = Memory;
            DataAddcommand.Parameters.Add("@Os", MySqlDbType.VarChar).Value = Os;
            DataAddcommand.Parameters.Add("@DataMounth", MySqlDbType.VarChar).Value = date1.ToString();

            db.openConnection();

            DataAddcommand.ExecuteNonQuery();

            db.closeConnection();
        }

      

        private void зарегистрироватьсяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegisterForm fr2 = new RegisterForm();
            fr2.Show();
            Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void UserField_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
