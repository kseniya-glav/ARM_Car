using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Npgsql;

namespace ARM
{
    public partial class Registration : Form
    {
        NpgsqlConnectionStringBuilder sb;

        public Registration()
        {
            InitializeComponent();
            btnOK.Enabled = false;
            sb = new NpgsqlConnectionStringBuilder();
            sb.Database = "carrental2";
            sb.Host = "localhost";
            sb.Username = "postgres";
            sb.Password = "12345";
        }
        public string Login
        {
            get { return tbLogin.Text.ToLower(); }
            set { tbLogin.Text = value.ToLower(); }
        }
        public string Password
        {
            get { return tbPassword.Text; }
        }
        
        private bool inspection(string s)
        {
            Regex r = new Regex(@"^[а-яА-Яa-zA-Z0-9-_ёЁ]{4,15}$");
            return r.IsMatch(s);
        }
        private bool inspection_Login()
        {
            bool flag = false;
            if (tbLogin.Text.Length >= 4)
            {
                btnOK.Enabled = inspection(Login);

                using (var sConn = new NpgsqlConnection(sb.ToString()))
                {
                    sConn.Open();
                    NpgsqlCommand selectLogin = new NpgsqlCommand
                    {
                        Connection = sConn,
                        CommandText = @"SELECT count(*) FROM users WHERE users.login = @Login"
                    };
                    selectLogin.Parameters.AddWithValue("@Login", Login.ToLowerInvariant());               
                    int m = Int32.Parse(selectLogin.ExecuteScalar().ToString().Trim());
                    if (m == 1)
                    {
                        //логин занят
                        epMain.SetError(tbLogin, "К сожалению, логин занят");
                    }
                    else
                    {
                        //логин свободен
                        epMain.SetError(tbLogin, "");
                        flag = true;
                    }
                }
            }
            else
            {
                epMain.SetError(tbLogin, "Логин должен быть от 4 до 15, состоящий из букв, цифр, знаков тире и подчеркивания");
                flag = false;
            }
            return flag;
        }
        private bool inspection_Password()
        {
            bool flag = false;
            if (tbPassword.Text != "")
            {
                epMain.SetError(tbPassword, "");
                flag = true;
            }
            else
            {
                epMain.SetError(tbPassword, "Придумайте пароль");
                flag = false;
            }
            return flag;
        }
        private void tbLogin_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = inspection_Login() && inspection_Password();
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = inspection_Password() && inspection_Login();

        }
    }
}
