using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARM
{
    public partial class CarRentalInsert : Form
    {
        public string LastName = "";
        public int index = 0;
        public FormType FT;
        public enum FormType
        {
            Insert,
            Update
        }
        public string CName
        {
            get { return tbName.Text; }
            set { tbName.Text = value; }
        }
        public string COwner
        {
            get { return tbOwner.Text; }
            set { tbOwner.Text = value; }
        }
        public string CAddress
        {
            get { return tbAddress.Text; }
            set { tbAddress.Text = value; }
        }
        public string CAccount
        {
            get { return tbAccount.Text; }
            set { tbAccount.Text = value; }
        }
        public int CBank
        {
            get { return Convert.ToInt32(cbBank.SelectedValue); }
            set { cbBank.SelectedValue = Convert.ToInt32(value); }
        }
        public CarRentalInsert(FormType frmType)
        {
            InitializeComponent();
            FT = frmType;
            switch (frmType)
            {
                case FormType.Insert:
                    btnOK.Text = @"Добавить";
                    break;
                case FormType.Update:
                    btnOK.Text = @"Изменить";
                    btnOK.Enabled = true;
                    break;
            }
        }

        private void CarRentalInsert_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "carRental2DataSet.Банки". При необходимости она может быть перемещена или удалена.
            this.банкиTableAdapter.Fill(this.carRental2DataSet.Банки);
            switch (FT)
            {
                case FormType.Update:
                    cbBank.SelectedValue = index;
                    break;
            }
        }
        private bool check_Name()
        {
            using (ModelCarRental MRC = new ModelCarRental())
            {
                foreach (Автопрокаты count in MRC.Автопрокаты)
                {
                    if (tbName.Text.Length > 20 || tbName.Text.Length < 4)
                    {
                        epMain.SetError(tbName, "Название должно быть от 4 до 20 символов.");
                        return false;
                    }
                    else
                    {
                        epMain.SetError(tbName, "");
                    }
                    if (LastName != tbName.Text && count.Название_автопроката == tbName.Text)
                    {
                        epMain.SetError(tbName, "Такое название уже есть.\nНазвание должно быть уникальным.");
                        return false;
                    }
                    else
                    {
                        epMain.SetError(tbName, "");
                    }
                }
            }
            return true;
        }

        private bool check_Address()
        {
            if (tbAddress.Text.Length > 50 || tbAddress.Text.Length < 3)
            {
                epMain.SetError(tbAddress, "Адрес должен состоять не менее чем\nиз 3 символов, и не более чем из 50 символов.");
                return false;
            }
            else
            {
                epMain.SetError(tbAddress, "");
            }
            return true;
        }

        private bool check_Account()
        {
            if (tbAccount.Text.Length != 20)
            { epMain.SetError(tbAccount, "Реквизиты должны быть из 20 цифр."); return false; }
            else
            { epMain.SetError(tbAccount, ""); }
            return true;
        }

        private bool check_Owner()
        {
            if (tbOwner.Text.Length > 20 || tbOwner.Text.Length < 7)
            {
                epMain.SetError(tbOwner, "ФИО собственника должно состоять не менее чем\nиз 7 символов, и не более чем из 20 символов.");
                return false;
            }
            else
            {
                epMain.SetError(tbOwner, "");
            }
            return true;
        }
        private void tbName_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = check_Name() && check_Owner() && check_Address() && check_Account();
        }

        private void tbAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) e.Handled = true;

        }
    }
}
