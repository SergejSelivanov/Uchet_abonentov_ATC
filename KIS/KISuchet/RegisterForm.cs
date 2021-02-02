using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Uchet_abonetnov_ATC
{
    public partial class RegisterForm : Form
    { 
       public RegisterForm()
        {
            InitializeComponent();
            UserRegField.Text = "Создайте логин";
            UserRegField.ForeColor = Color.Gray;
            PassRegField.Text = "Создайте пароль";                               //первоначально занечение в текстбоксе
            PassRegField.ForeColor = Color.Gray;
            PositionRegField.Text = "Выберите должность";
            PositionRegField.ForeColor = Color.Gray;
        }

        Point lastPoint;
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

       

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void UserRegField_TextChanged(object sender, EventArgs e)
        {

        }

        private void UserRegField_Enter(object sender, EventArgs e)
        {
            if (UserRegField.Text == "Создайте логин")
            {
                UserRegField.Text = "";
                UserRegField.ForeColor = Color.Black;
            }
        }

        private void UserRegField_Leave(object sender, EventArgs e)
        {
            if (UserRegField.Text == "")
            {
                UserRegField.Text = "Создайте логин";
                UserRegField.ForeColor = Color.Gray;
            }
        }

        private void PassRegField_Enter(object sender, EventArgs e)
        {
            if (PassRegField.Text == "Создайте пароль")
            {
                PassRegField.Text = "";
                PassRegField.ForeColor = Color.Black;
            }
        }

        private void PassRegField_Leave(object sender, EventArgs e)
        {
            if (PassRegField.Text == "")
            {
                PassRegField.Text = "Создайте пароль";
                PassRegField.ForeColor = Color.Gray;
            }
        }

        private void PositionRegField_Enter(object sender, EventArgs e)
        {
            if (PositionRegField.Text == "Выберите должность")
            {
                PositionRegField.Text = "";
                PositionRegField.ForeColor = Color.Black;
            }
        }

        private void PositionRegField_Leave(object sender, EventArgs e)
        {
            if (PositionRegField.Text == "")
            {
                PositionRegField.Text = "Выберите должность";
                PositionRegField.ForeColor = Color.Gray;
            }
        }

        private void наАвторизациюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginForm fr2 = new LoginForm();
            fr2.Show();
            Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private  void  buttonReg_Click(object sender, EventArgs e)
        {
            if (UserRegField.Text == "Создайте логин")
            {
                MessageBox.Show("Поле 'логин' не заполнено");                                //месседж боксы которые проверяют заполнение
                return;
            }
            if (PassRegField.Text == "Создайте пароль")
            {
                MessageBox.Show("Поле 'пароль' не заполнено");
                return;
            }
            if (PositionRegField.Text == "Выберите должность" )
            {
                MessageBox.Show("Поле 'должность' не заполнено");
                return;
            }
            if (PositionRegField.Text != "Директор" && PositionRegField.Text != "Менеджер" && PositionRegField.Text != "Бухгалтер" && PositionRegField.Text != "Оператор ПК" && PositionRegField.Text != "Главный Бухгалтер") // проверка, на наличие должности
            {
                MessageBox.Show("Такой должности нет");
                return;
            }

            if (isUserExists())
                return;

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `Users` (`Login`, `Password`, `Position`) VALUES (@login, @password, @position)" , db.getConnection());
            
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = UserRegField.Text;
            command.Parameters.Add("@password", MySqlDbType.VarChar).Value = PassRegField.Text;
            command.Parameters.Add("@position", MySqlDbType.VarChar).Value = PositionRegField.Text;                               //добавление в базу данных

            db.openConnection();

            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("Аккаунт был создан");
            else
                MessageBox.Show("Аккаунт не был создан");                               //месседжбокс который подтверждает регистрацию

            db.closeConnection();
        }

        public Boolean isUserExists()
        {
            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `Users` WHERE `Login` = @uL ", db.getConnection());                               //проверка есть ли такой логин в базе данных
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = UserRegField.Text;
          

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Пользователь с таким логином уже есть");
                return true;
            }

            else
                return false;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
