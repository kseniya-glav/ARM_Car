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
    public partial class MarkaInsert : Form
    {
        public string LastName = "";
        public int indexCountry = 0;
        public FormType FT;
        public enum FormType
        {
            Insert,
            Update
        }
        public MarkaInsert(FormType frmType)
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
        public string CName
        {
            get { return tbName.Text.ToUpper(); }
            set { tbName.Text = value; }
        }
        public int CCountry
        {
            get { return Convert.ToInt32(cbCountry.SelectedValue); }
            set { cbCountry.SelectedValue = Convert.ToInt32(value); }
        }
        public DateTime Date
        {
            get { return dtPicker.Value; }
            set { dtPicker.Value = value; }
        }
        private void MarkaInsert_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "carRental2DataSet.Страны". При необходимости она может быть перемещена или удалена.
            this.страныTableAdapter.Fill(this.carRental2DataSet.Страны);
            switch (FT)
            {
                case FormType.Update:
                    cbCountry.SelectedValue = indexCountry;
                    break;
            }
        }
        private bool check_Name()
        {
            using (ModelCarRental MRC = new ModelCarRental())
            {
                foreach (Марки count in MRC.Марки)
                {
                    if (tbName.Text.Length < 3)
                    {
                        epMain.SetError(tbName, "Название должно быть от 3 до 20 символов.");
                        return false;
                    }
                    else
                    {
                        epMain.SetError(tbName, "");
                    }
                    if (LastName != tbName.Text.ToUpper() && count.Название_марки == tbName.Text.ToUpper())
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
        private void tbName_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = check_Name();

        }
    }
}
