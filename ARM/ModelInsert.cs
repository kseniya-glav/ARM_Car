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
    public partial class ModelInsert : Form
    {
        public string LastModel = "";
        public int indexMarka = 0, indexModel = 0, indexType = 0;
        public FormType FT;
        public enum FormType
        {
            Insert,
            InsertCld,
            Update
        }
        public int CMarka
        {
            get { return Convert.ToInt32(cbMarka.SelectedValue); }
            set { cbMarka.SelectedValue = Convert.ToInt32(value); }
        }
        public int CType
        {
            get { return Convert.ToInt32(cbType.SelectedValue); }
            set { cbType.SelectedValue = Convert.ToInt32(value); }
        }
        public string CModel
        {
            get { return tbModel.Text; }
            set { tbModel.Text = value; }
        }
        public ModelInsert(FormType frmType)
        {
            InitializeComponent();
            FT = frmType;
            switch (frmType)
            {
                case FormType.Insert:
                    btnOK.Text = @"Добавить";
                    btnOK.Enabled = false;
                    break;
                case FormType.InsertCld:
                    btnOK.Text = @"Добавить";
                    btnOK.Enabled = false;
                    break;
                case FormType.Update:
                    btnOK.Text = @"Изменить";
                    btnOK.Enabled = true;
                    break;
            }
        }

        private void CarRentalInsert_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "carRental2DataSet.Типы". При необходимости она может быть перемещена или удалена.
            this.типыTableAdapter.Fill(this.carRental2DataSet.Типы);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "carRental2DataSet.Марки". При необходимости она может быть перемещена или удалена.
            this.маркиTableAdapter.Fill(this.carRental2DataSet.Марки);

            switch (FT)
            {
                case FormType.InsertCld:
                    cbMarka.SelectedValue = indexMarka;
                    cbType.SelectedValue = indexType;
                    break;
                case FormType.Update:
                    cbMarka.SelectedValue = indexMarka;
                    cbType.SelectedValue = indexType;
                    break;
            }
        }

       

        private void tbModel_TextChanged(object sender, EventArgs e)
        {
            using (ModelCarRental MRC = new ModelCarRental())
            {
                Модели g = new Модели();
                g.Название_модели = tbModel.Text;
                foreach (Модели count in MRC.Модели)
                {
                    if (tbModel.Text.Length < 2 || tbModel.Text.Length > 20)
                    {
                        epMain.SetError(tbModel, "Название должно быть от 2 до 20 символов.");
                        btnOK.Enabled = false;
                        return;
                    }
                    else
                    {
                        epMain.SetError(tbModel, "");
                        btnOK.Enabled = true;
                    }
                    if (g.Название_модели != LastModel && count.Название_модели == g.Название_модели && count.Код_марки == Convert.ToInt32(cbMarka.SelectedValue))
                    {
                        epMain.SetError(tbModel, "Такая модель уже есть.\nНазвание модели должно быть уникальным в рамках марки.");
                        btnOK.Enabled = false;
                        return;
                    }
                    else
                    {
                        epMain.SetError(tbModel, "");
                        btnOK.Enabled = true;
                    }
                }
                btnOK.Enabled = true;
            }
        }
    }
}
