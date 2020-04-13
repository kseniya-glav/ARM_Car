using System;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
//using System.Data.SqlClient;
using System.Data;
using Npgsql;

namespace ARM
{
    public partial class Authorization : Form
    {
        private ToolTip tt = new ToolTip();
        public bool isLoginValid { get; set; }
        public bool isClosed { get; set; }
        public Users User { get; set; }
        NpgsqlConnectionStringBuilder sb;


        public Authorization()
        {
            InitializeComponent();
            sb = new NpgsqlConnectionStringBuilder();
            sb.Database = "carrental2";
            sb.Host = "localhost";
            sb.Username = "postgres";
            sb.Password = "12345";
            
            tt.SetToolTip(Login, "Логин должен быть от 4 до 15, состоящий из букв, цифр, знаков тире и подчеркивания");
            tt.SetToolTip(btnEND, "Выход");
            tt.SetToolTip(LoginBT, "Войти");
            tt.SetToolTip(RegBT, "Регистрация");
            tt.SetToolTip(checkBox1, "Вход под учетной записью гостя");
        }


        private bool inspection_Password()
        {
            bool flag = false;
            if (Password.Text != "")
            {
                epMain.SetError(Password, "");
                flag = true;
            }
            else
            {
                epMain.SetError(Password, "Введите пароль");
                flag = false;
            }
            return flag;
        }
        private bool inspection_Login()
        {
            bool flag = false;
            if (Login.Text.Length >= 4)
            {
                LoginBT.Enabled = inspection(Login.Text);

                using (NpgsqlConnection sConn = new NpgsqlConnection(sb.ToString()))
                {
                    sConn.Open();
                    var selectLogin = new NpgsqlCommand
                    {
                        Connection = sConn,
                        CommandText = @"SELECT count(*) FROM users WHERE users.login = @Login"
                    };
                    selectLogin.Parameters.AddWithValue("@Login", Login.Text.ToLowerInvariant());
                    int m = Int32.Parse(selectLogin.ExecuteScalar().ToString().Trim());
                    if (m == 1)
                    {
                        //логин существует
                        epMain.SetError(Login, "");
                        flag = true;
                    }
                    else
                    {
                        //логин не существует
                        epMain.SetError(Login, "Такого логина не существует");
                    }
                }
            }
            else
            {
                epMain.SetError(Login, "Логин должен быть от 4 до 15, состоящий из букв, цифр, знаков тире и подчеркивания");
                flag = false;
            }
            return flag;
        }
        private void Login_TextChanged(object sender, EventArgs e)
        {
            LoginBT.Enabled = inspection_Login() && inspection_Password();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Login.Enabled = false;
                Password.Enabled = false;
                LoginBT.Enabled = true;
            }
            else
            {
                Login.Enabled = true;
                Password.Enabled = true;
                LoginBT.Enabled = false;
            }
        }
        private bool inspection(string s)
        {
            Regex r = new Regex(@"^[а-яА-Яa-zA-Z0-9-_ёЁ]{4,15}$");
            return r.IsMatch(s);
        }
        private void LoginBT_Click(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                if (Login.Text != "" && Password.Text != "")
                {
                    using (NpgsqlConnection sConn = new NpgsqlConnection(sb.ToString()))
                    {
                        sConn.Open();
                        NpgsqlCommand sCommand = new NpgsqlCommand()
                        {
                            Connection = sConn,
                            CommandText = @"SELECT  hashpassword, prefixpassword, level FROM users where login = @Login"
                        };
                        sCommand.Parameters.AddWithValue("@Login", Login.Text.ToLower());
                        var reader = sCommand.ExecuteReader();

                        if (reader.Read())
                        {
                            //логин найден
                            string prefixpassword = (string)reader["prefixpassword"];
                            string hashpassword1 = (string)reader["hashpassword"];
                            int level = (int)reader["level"];
                            string hashpassword2 = CalcHash(Password.Text + prefixpassword);
                            if (hashpassword2 == hashpassword1)
                            {
                                MessageBox.Show(@"Вы вошли в систему как " + Login.Text);
                                User = new Users();
                                User.login = Login.Text;
                                User.level = level;
                                isLoginValid = true;
                                isClosed = false;
                                epMain.SetError(Login, "");
                                epMain.SetError(Password, "");
                            }
                            else
                            {
                                isLoginValid = false;
                                isClosed = true;
                                epMain.SetError(Password, "Неверный пароль");
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(@"Вы вошли в систему как гость");
                User = new Users();
                User.login = "Гость";
                Password.Enabled = true;
                User.level = 0;
                isLoginValid = true;
                isClosed = false;
            }
        }
        private static string CalcHash(string path)
        {
            using (SHA1CryptoServiceProvider cp = new SHA1CryptoServiceProvider())//Вычисляет значение хэша SHA1 для входных данных с помощью реализации, предоставляемой поставщиком служб шифрования (CSP).
            {
                Encoding enc = Encoding.UTF8;//Получает кодировку для формата UTF-8.
                return BitConverter.ToString(cp.ComputeHash(enc.GetBytes(path))).Replace("-", "");
            }
        }
        private void RegBT_Click(object sender, EventArgs e)
        {
            User = Insert_User();
            if (User != null)
            {
                LoginBT.Enabled = true;
                MessageBox.Show("Вы зарегистрировались в системе как оператор, ваш логин для входа: \"" + User.login + "\"");
                Login.Text = User.login;
                Password.Focus();
            }
        }
        private Users Insert_User()
        {
            Users Item = null;
            Registration f = new Registration();
            if (f.ShowDialog() == DialogResult.OK)
            {
                using (ModelCarRental MRC = new ModelCarRental())
                {
                    Item = new Users();
                    Item.login = f.Login;
                    Item.prefixpassword = Guid.NewGuid().ToString().Replace("-", "");
                    Item.hashpassword = CalcHash(f.Password + Item.prefixpassword);
                    Item.level = 2;
                    Item.date = DateTime.Now;

                    MRC.Users.Add(Item);
                    MRC.SaveChanges();
                }
            }
            return Item;
        }
        private void btnEND_Click(object sender, EventArgs e)
        {
            Close();
            isClosed = true;
            isLoginValid = true;
        }
    }
}
