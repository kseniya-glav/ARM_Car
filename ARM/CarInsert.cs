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
    public partial class CarInsert : Form
    {
        public string LastCondition = "";
        public int indexCarRental = 0, indexColor = 0, indexModel = 0, indexDealer = 0, indexMarka = 0;
        public FormType FT;
        public enum FormType
        {
            Insert,
            Update
        }
        public int CCarRental
        {
            get { return Convert.ToInt32(cbCarRental.SelectedValue); }
            set { cbCarRental.SelectedValue = Convert.ToInt32(value); }
        }
        public int CMarka
        {
            get { return Convert.ToInt32(cbMarka.SelectedValue); }
            set { cbMarka.SelectedValue = Convert.ToInt32(value); }
        }
        public int CColor
        {
            get { return btColor.BackColor.ToArgb(); }
        }
        public string Color
        {
            set { btColor.Tag = Convert.ToString(value); }
        }
        public string CСondition
        {
            get { return cbСondition.Text; }
            set { cbСondition.Text = value; }
        }
        public string CPrice
        {
            get { return tbPrice.Text; }
            set { tbPrice.Text = value; }
        }

        private void addCarRental_Click(object sender, EventArgs e)
        {
            CarRentalInsert f = new CarRentalInsert(CarRentalInsert.FormType.Insert);
            if (f.ShowDialog() == DialogResult.OK)
            {
                using (ModelCarRental MRC = new ModelCarRental())
                {
                    Автопрокаты Item = new Автопрокаты();
                    Item.Название_автопроката = f.CName;
                    Item.Собственник_автопроката = f.COwner;
                    Item.Адрес_автопроката = f.CAddress;
                    Item.Расчетный_счет = f.CAccount;
                    Item.Код_банка = f.CBank;
                    MRC.Автопрокаты.Add(Item);
                    MRC.SaveChanges();
                    cbCarRental.SelectedValue = Item.Код_автопроката;
                }
            }
        }

        private void addModel_Click(object sender, EventArgs e)
        {
            ModelInsert f = new ModelInsert(ModelInsert.FormType.InsertCld);
            f.indexMarka = CMarka;
            f.indexType = 1;
            if (f.ShowDialog() == DialogResult.OK)
            {

                using (ModelCarRental MRC = new ModelCarRental())
                {
                    Модели Item = new Модели();
                    Item.Название_модели = f.CModel;
                    Item.Код_марки = f.CMarka;
                    Item.Код_типа = f.CType;
                    MRC.Модели.Add(Item);
                    MRC.SaveChanges();
                    this.моделиTableAdapter.Fill(this.carRental2DataSet.Модели);
                    cbModel.SelectedValue = Item.Код_модели;
                }

            }
        }

        private void addMarka_Click(object sender, EventArgs e)
        {
            MarkaInsert f = new MarkaInsert(MarkaInsert.FormType.Insert);
            if (f.ShowDialog() == DialogResult.OK)
            {
                using (ModelCarRental MRC = new ModelCarRental())
                {
                    Марки Item = new Марки();
                    Item.Название_марки = f.CName;
                    Item.Код_страны = f.CCountry;
                    Item.Дата_создания = f.Date;
                    MRC.Марки.Add(Item);
                    MRC.SaveChanges();
                    this.маркиTableAdapter.Fill(this.carRental2DataSet.Марки);
                    cbMarka.SelectedValue = Item.Код_марки;
                }
            }
        }

        private void btColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                btColor.BackColor = cd.Color;
            }
        }

        private void tbPrice_TextChanged(object sender, EventArgs e)
        {
            {
                if (tbPrice.Text == "")
                {
                    epMain.SetError(tbPrice, "Поле не может быть пустым.");
                    btnOK.Enabled = false;
                    return;
                }
                else
                {
                    epMain.SetError(tbPrice, "");
                    btnOK.Enabled = true;
                }
                if (Convert.ToInt32(tbPrice.Text) > 25000)
                {
                    epMain.SetError(tbPrice, "Стоимость аренды должна быть не более 25000.");
                    btnOK.Enabled = false;
                    return;
                }
                else
                {
                    epMain.SetError(tbPrice, "");
                    btnOK.Enabled = true;
                }
                if (cbModel.SelectedValue == null)
                {
                    epMain.SetError(tbPrice, "Укажите модель");
                    btnOK.Enabled = false;
                    return;
                }
                else
                {
                    epMain.SetError(tbPrice, "");
                    btnOK.Enabled = true;
                }
                btnOK.Enabled = true;
            }
        }

        private void tbPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8) e.Handled = true;

        }

        public int CDealer
        {
            get { return Convert.ToInt32(cbDealer.SelectedValue); }
            set { cbDealer.SelectedValue = Convert.ToInt32(value); }
        }
        public int Model
        {
            get { return Convert.ToInt32(cbModel.SelectedValue); }
            set { cbModel.SelectedValue = Convert.ToInt32(value); }
        }
        public CarInsert(FormType frmType)
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
            string[] mas = { "не удовлетворительно", "удовлетворительно", "хорошо", "отлично" };
            cbСondition.DataSource = mas;

        }

        private void CarInsert_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "carRental2DataSet.Диллеры". При необходимости она может быть перемещена или удалена.
            this.диллерыTableAdapter.Fill(this.carRental2DataSet.Диллеры);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "carRental2DataSet.Модели". При необходимости она может быть перемещена или удалена.
            this.моделиTableAdapter.Fill(this.carRental2DataSet.Модели);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "carRental2DataSet.Марки". При необходимости она может быть перемещена или удалена.
            this.маркиTableAdapter.Fill(this.carRental2DataSet.Марки);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "carRental2DataSet.Автопрокаты". При необходимости она может быть перемещена или удалена.
            this.автопрокатыTableAdapter.Fill(this.carRental2DataSet.Автопрокаты);
            btColor.BackColor = System.Drawing.Color.FromArgb(indexColor);
            cbСondition.SelectedIndex = cbСondition.FindString(LastCondition);
            switch (FT)
            {
                case FormType.Update:
                    cbDealer.SelectedValue = indexDealer;
                    cbMarka.SelectedValue = indexMarka;
                    cbModel.SelectedValue = indexModel;
                    cbCarRental.SelectedValue = indexCarRental;
                    btnOK.Enabled = true;
                    break;
            }
        }
    }
}
