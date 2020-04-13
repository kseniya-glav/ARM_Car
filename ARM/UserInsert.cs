using System;
using System.Drawing;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Npgsql;

namespace ARM
{
    public partial class UserInsert : Form
    {
        NpgsqlConnectionStringBuilder sb;

        public bool isPassword = false, isLogin = false; //Переменная определяет меняли ли пароль
        public int indexLevel = 0;
      
        public enum FormType
        {
            Insert,
            Update
        }
        public string Login
        {
            get { return tbLogin.Text.ToLower(); }
            set { tbLogin.Text = value.ToLower(); }
        }
        public int Access
        {
            get { return Convert.ToInt32(comboBoxAccess.SelectedValue); }
            set { comboBoxAccess.SelectedValue = Convert.ToInt32(value); }
        }
        public string Password
        {
            get { return tbPassword.Text; }
        }
        public DateTime Date
        {
            get { return dtPicker.Value; }
            set { dtPicker.Value = value; }
        }
        public string LastLogin { get; set; }
        public string salt { get; set; }
        public UserInsert(string LastName, FormType frmType)
        {
            InitializeComponent();
            sb = new NpgsqlConnectionStringBuilder();
            sb.Database = "carrental2";
            sb.Host = "localhost";
            sb.Username = "postgres";
            sb.Password = "12345";
            LastLogin = LastName;
            switch (frmType)
            {
                case FormType.Insert:
                    indexLevel = 1;
                    this.Text = @"Добавить пользователя";
                    btnOK.Text = @"Добавить";
                    btnOK.Enabled = false;
                    btChangePassword.Visible = false;
                    tbPassword.Size = new System.Drawing.Size(tbLogin.Size.Width, 20);
                    break;
                case FormType.Update:
                    this.Text = @"Изменить пользователя";
                    btnOK.Text = @"Изменить";
                    btnOK.Enabled = true;
                    tbPassword.ReadOnly = true;
                    tbPassword.BackColor = SystemColors.Control;
                    break;
            }
        }
        private bool inspection_Login()
        {
            bool flag = false;
            if (!isLogin)
            {
                LastLogin = Login;
                isLogin = !isLogin;
            }
            if (tbLogin.Text.Length >= 4)
            {
                btnOK.Enabled = inspection(Login);

                using (var sConn = new NpgsqlConnection(sb.ToString()))
                {
                    sConn.Open();
                    var selectLogin = new NpgsqlCommand
                    {
                        Connection = sConn,
                        CommandText = @"SELECT count(*) FROM users WHERE users.login = @Login"
                    };
                    selectLogin.Parameters.AddWithValue("@Login", Login.ToLowerInvariant());
                    int m = Int32.Parse(selectLogin.ExecuteScalar().ToString().Trim());
                    if (m == 1 && Login.ToLower() != LastLogin.ToLower() && btnOK.Text == "Изменить" || m == 1 && btnOK.Text == "Добавить")
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
            if (!tbPassword.ReadOnly) btnOK.Enabled = inspection_Login() && inspection_Password();
            else btnOK.Enabled = inspection_Login();
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = inspection_Password() && inspection_Login();
        }
        private bool inspection(string s)
        {
            Regex r = new Regex(@"^[а-яА-Яa-zA-Z0-9-_ёЁ]{4,15}$");
            return r.IsMatch(s);
        }

        private void UserInsert_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "carRental2DataSet.Уровни_доступа". При необходимости она может быть перемещена или удалена.
            this.уровни_доступаTableAdapter.Fill(this.carRental2DataSet.Уровни_доступа);
            Access = indexLevel;

        }

        private void btChangePassword_Click(object sender, EventArgs e)
        {
            tbPassword.BackColor = System.Drawing.SystemColors.Window;
            tbPassword.ReadOnly = false;
            btnOK.Enabled = btChangePassword.Enabled = inspection_Login() && inspection_Password();
        }
    }
}
