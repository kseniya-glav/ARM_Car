using System;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
namespace ARM
{
    public partial class WorkSpace : Form
    {
        Users User;
        public WorkSpace(Users U)
        {
            InitializeComponent();
            UpdateForm(U);

        }
        public void UpdateForm(Users U)
        {
            User = U;
            if (User.level != 0)
                using (ModelCarRental MCR = new ModelCarRental())
                {
                    level.Text = MCR.Уровни_доступа.Find(User.level).Уровень_доступа;
                    login.Text = User.login;
                }
            else
            {
                level.Text = "Гость";
                login.Text = User.login;
            }
            InitializeList();
            ListTable.SelectedIndex = 0;
            switch (User.level)
            {
                case 0:
                    добавитьToolStripMenuItem.Enabled = false;
                    удалитьToolStripMenuItem.Enabled = false;
                    изменитьToolStripMenuItem.Enabled = false;
                    LbCRUDdata.Visible = false;
                    LbCRUDusers.Visible = false;
                    break;
                case 2:
                    добавитьToolStripMenuItem.Enabled = true;
                    удалитьToolStripMenuItem.Enabled = true;
                    изменитьToolStripMenuItem.Enabled = true;
                    LbCRUDdata.Visible = true;
                    LbCRUDusers.Visible = false;
                    break;
                default:
                    добавитьToolStripMenuItem.Enabled = true;
                    удалитьToolStripMenuItem.Enabled = true;
                    изменитьToolStripMenuItem.Enabled = true;
                    LbCRUDdata.Visible = true;
                    LbCRUDusers.Visible = true;
                    break;
            }
        }
        private void EnterBTN_Click(object sender, EventArgs e)
        {
            User = null;
            Authorization A = new Authorization();
            while (!A.isLoginValid)
                if (A.ShowDialog() == DialogResult.OK)
                {
                    if (!A.isClosed)
                    {
                        User = new Users();
                        User = A.User;
                        UpdateForm(User);
                    }
                }
        }
        private void InitializeList()
        {
            ListTable.Items.Clear();
            ListTable.Items.Add("Автопрокаты");
            ListTable.Items.Add("Автомобили");
            ListTable.Items.Add("Модели");
            ListTable.Items.Add("Марки");
            if (User.level == 1)
                ListTable.Items.Add("Users");
        }
        private void Initialize_CarRental()
        {
            LView.Clear();
            LView.Columns.Add("Название");
            LView.Columns.Add("Собственник");
            LView.Columns.Add("Адрес");
            LView.Columns.Add("Расчетный счет");
            LView.Columns.Add("Банк");

            ModelCarRental b = new ModelCarRental();
            string[] bank = new string[b.Банки.Count() + 1];
            using (ModelCarRental MCR = new ModelCarRental())
            {
                int h = 1;
                foreach (Банки a in MCR.Банки)
                {
                    bank[h] = a.Название_банка;
                    h++;
                }
                foreach (Автопрокаты mu in MCR.Автопрокаты)
                {
                    ListViewItem lvi = new ListViewItem(new[]
                    {
                        mu.Название_автопроката,
                        mu.Собственник_автопроката,
                        mu.Адрес_автопроката,
                        mu.Расчетный_счет.ToString(),
                        mu.Банки.Название_банка,
                    })
                    {
                        Tag = mu
                    };
                    this.LView.Items.Add(lvi);
                }
                LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
        private void Initialize_Car()
        {
            LView.Clear();
            LView.Columns.Add("Инд. №");
            LView.Columns.Add("Автопрокат");
            LView.Columns.Add("Марка");
            LView.Columns.Add("Модель");
            LView.Columns.Add("Цвет");
            LView.Columns.Add("Состояние");
            LView.Columns.Add("Дилер");
            LView.Columns.Add("Цена за сутки");
            ModelCarRental b = new ModelCarRental();
            string[] nameModel = new string[b.Модели.Count() + 1];
            string[] nameMarki = new string[b.Марки.Count() + 1];
            string[] nameDiler = new string[b.Дилеры.Count() + 1];
            string[] nameProkat = new string[b.Автопрокаты.Count() + 1];
            using (ModelCarRental MCR = new ModelCarRental())
            {
                int h = 1;
                foreach (Автопрокаты a in MCR.Автопрокаты)
                {
                    nameProkat[h] = a.Название_автопроката;
                    h++;
                }
                h = 1;
                foreach (Марки a in MCR.Марки)
                {
                    nameMarki[h] = a.Название_марки;
                    h++;
                }
                h = 1;
                foreach (Модели a in MCR.Модели)
                {
                    nameModel[h] = a.Название_модели;
                    h++;
                }
                h = 1;
                foreach (Дилеры a in MCR.Дилеры)
                {
                    nameDiler[h] = a.Название_фирмы;
                    h++;
                }
                foreach (Автомобили mu in MCR.Автомобили)
                {
                    ListViewItem lvi = new ListViewItem(new[]
                    {
                        mu.Номер_автомобиля.ToString(),
                        mu.Автопрокаты.Название_автопроката,
                        MCR.Марки.Find(mu.Модели.Код_марки).Название_марки,
                        mu.Модели.Название_модели,
                        "",
                        mu.Состояние,
                        mu.Дилеры.Название_фирмы,
                        mu.Цена_за_сутки.ToString(),
                    })
                    {
                        Tag = mu
                    };
                    this.LView.Items.Add(lvi);
                    lvi.UseItemStyleForSubItems = false;
                    lvi.SubItems[4].BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(mu.Основной_цвет));
                }
                LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
        private void Initialize_Model()
        {
            LView.Clear();
            LView.Columns.Add("Марка");
            LView.Columns.Add("Модель");
            LView.Columns.Add("Тип кузова");
            ModelCarRental b = new ModelCarRental();
            string[] Tip = new string[b.Типы.Count() + 1];
            string[] nameMarki = new string[b.Марки.Count() + 1];
            using (ModelCarRental MCR = new ModelCarRental())
            {
                int h = 1;
                foreach (Типы a in MCR.Типы)
                {
                    Tip[h] = a.Название_типа;
                    h++;
                }
                h = 1;
                foreach (Марки a in MCR.Марки)
                {
                    nameMarki[h] = a.Название_марки;
                    h++;
                }
                foreach (Модели mu in MCR.Модели)
                {
                    ListViewItem lvi = new ListViewItem(new[]
                    {
                        mu.Марки.Название_марки,
                        mu.Название_модели,
                        mu.Типы.Название_типа,
                    })
                    {
                        Tag = mu
                    };
                    this.LView.Items.Add(lvi);
                }
                LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }
        private void Initialize_Brands()
        {
            LView.Clear();
            LView.Columns.Add("Марка");
            LView.Columns.Add("Дата создания");
            LView.Columns.Add("Страна");
            ModelCarRental b = new ModelCarRental();
            string[] Country = new string[b.Страны.Count() + 1];
            using (ModelCarRental MCR = new ModelCarRental())
            {
                int h = 1;
                foreach (Страны a in MCR.Страны)
                {
                    Country[h] = a.Название_страны;
                    h++;
                }
                foreach (Марки mu in MCR.Марки)
                {
                    ListViewItem lvi = new ListViewItem(new[]
                    {
                        mu.Название_марки,
                        mu.Дата_создания.ToLongDateString(),
                        MCR.Страны.Find(mu.Код_страны).Название_страны,
                    })
                    {
                        Tag = mu
                    };
                    this.LView.Items.Add(lvi);
                }
                LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void Initialize_Users()
        {
            LView.Clear();
            LView.Columns.Add("Логин");
            LView.Columns.Add("Уровень доступа");
            LView.Columns.Add("Дата регистрация");
            ModelCarRental b = new ModelCarRental();
            string[] Lvl = new string[b.Уровни_доступа.Count() + 1];
            using (ModelCarRental MCR = new ModelCarRental())
            {
                int h = 1;
                foreach (Уровни_доступа a in MCR.Уровни_доступа)
                {
                    Lvl[h] = a.Уровень_доступа;
                    h++;
                }
                foreach (Users mu in MCR.Users)
                {
                    ListViewItem lvi = new ListViewItem(new[]
                    {
                        mu.login,
                        mu.Уровни_доступа.Уровень_доступа,
                        mu.date.ToShortDateString(),
                    })
                    {
                        Tag = mu
                    };
                    this.LView.Items.Add(lvi);
                }
                LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void Delete_Brands()
        {
            try
            {
                foreach (ListViewItem selectedItem in LView.SelectedItems)
                {
                    using (ModelCarRental MRC = new ModelCarRental())
                    {
                        Марки n = (Марки)selectedItem.Tag;
                        MRC.Марки.Attach(n);
                        MRC.Марки.Remove(n);
                        MRC.SaveChanges();
                        LView.Items.Remove(selectedItem);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка удаления. Имеется связанная таблица!");
            }
        }

        private void Insert_Brands()
        {
            MarkaInsert f = new MarkaInsert(MarkaInsert.FormType.Insert);
            if (f.ShowDialog() == DialogResult.OK)
            {
                using (ModelCarRental MRC = new ModelCarRental())
                {
                    Марки Item = new Марки();
                    foreach (Марки c in MRC.Марки) ;
                    int count = MRC.Марки.Local.Count;
                    Item.Код_марки = count + 1;
                    Item.Название_марки = f.CName;
                    Item.Код_страны = f.CCountry;
                    Item.Дата_создания = f.Date;
                    MRC.Марки.Add(Item);
                    MRC.SaveChanges();
                    ListViewItem lvi = new ListViewItem(new[]
                    {
                        Item.Название_марки,
                        Item.Дата_создания.ToLongDateString(),
                        MRC.Страны.Find(f.CCountry).Название_страны,
                    });
                    lvi.Tag = Item;
                    this.LView.Items.Add(lvi);
                }

            }
        }
        private void Update_Brands()
        {

            foreach (ListViewItem selectedItem in LView.SelectedItems)
            {

                Марки Item = (Марки)selectedItem.Tag;
                MarkaInsert f = new MarkaInsert(MarkaInsert.FormType.Update)
                {
                    LastName = Item.Название_марки,
                    CName = Item.Название_марки,
                    indexCountry = Item.Код_страны,
                    Date = Item.Дата_создания
                };
                if (f.ShowDialog() == DialogResult.OK)
                {
                    using (ModelCarRental MRC = new ModelCarRental())
                    {
                        MRC.Марки.Attach(Item);
                        Item.Название_марки = f.CName;
                        Item.Код_страны = f.CCountry;
                        Item.Дата_создания = f.Date;
                        MRC.SaveChanges();

                        selectedItem.SubItems[0].Text = f.CName;
                        selectedItem.SubItems[1].Text = f.Date.ToLongDateString();
                        selectedItem.SubItems[2].Text = MRC.Страны.Find(f.CCountry).Название_страны;

                        selectedItem.Tag = Item;

                        LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                        LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    }
                }
            }
        }
        private void ListTable_SelectedIndexChanged(object sender, EventArgs e)
        {
            gb3.Text = ListTable.SelectedItem.ToString();
            switch (ListTable.SelectedItem.ToString())
            {
                case "Автопрокаты":
                    {
                        Initialize_CarRental();
                        break;
                    }
                case "Автомобили":
                    {
                        Initialize_Car();
                        break;
                    }
                case "Модели":
                    {
                        Initialize_Model();
                        break;
                    }
                case "Марки":
                    {
                        Initialize_Brands();
                        break;
                    }
                case "Users":
                    {
                        Initialize_Users();
                        break;
                    }
            }
        }
        private void Delete_CarRental()
        {
            try
            {
                foreach (ListViewItem selectedItem in LView.SelectedItems)
                {
                    using (ModelCarRental MRC = new ModelCarRental())
                    {
                        Автопрокаты n = (Автопрокаты)selectedItem.Tag;
                        if (MRC.Автомобили.Find(n.Код_автопроката) != null)
                        {
                            throw new Exception("error");
                        };
                        MRC.Автопрокаты.Attach(n);
                        MRC.Автопрокаты.Remove(n);
                        MRC.SaveChanges();
                        LView.Items.Remove(selectedItem);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка удаления. Сначала удалите всех партнёров!");
            }
        }
        private void Delete_Car()
        {
            try
            {
                foreach (ListViewItem selectedItem in LView.SelectedItems)
                {
                    using (ModelCarRental MRC = new ModelCarRental())
                    {
                        Автомобили n = (Автомобили)selectedItem.Tag;
                        MRC.Автомобили.Attach(n);
                        MRC.Автомобили.Remove(n);
                        MRC.SaveChanges();
                        LView.Items.Remove(selectedItem);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка удаления. Имеется связанная таблица!");
            }
        }
        private void Delete_Model()
        {
            try
            {
                foreach (ListViewItem selectedItem in LView.SelectedItems)
                {
                    using (ModelCarRental MRC = new ModelCarRental())
                    {
                        Модели n = (Модели)selectedItem.Tag;
                        if (MRC.Автомобили.Find(n.Код_модели) != null)
                        {
                            throw new Exception("error");
                        };
                        MRC.Модели.Attach(n);
                        MRC.Модели.Remove(n);
                        MRC.SaveChanges();
                        LView.Items.Remove(selectedItem);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ошибка удаления. Имеется связанная таблица!");
            }
        }
        private void Update_CarRental()
        {
            foreach (ListViewItem selectedItem in LView.SelectedItems)
            {

                Автопрокаты Item = (Автопрокаты)selectedItem.Tag;
                CarRentalInsert f = new CarRentalInsert(CarRentalInsert.FormType.Update)
                {
                    LastName = Item.Название_автопроката,
                    CName = Item.Название_автопроката,
                    COwner = Item.Собственник_автопроката,
                    CAddress = Item.Адрес_автопроката,
                    CAccount = Item.Расчетный_счет,
                    index = Item.Банки.Код_банка,
                };
                if (f.ShowDialog() == DialogResult.OK)
                {
                    using (ModelCarRental MRC = new ModelCarRental())
                    {
                        MRC.Автопрокаты.Attach(Item);
                        Item.Название_автопроката = f.CName;
                        Item.Собственник_автопроката = f.COwner;
                        Item.Адрес_автопроката = f.CAddress;
                        Item.Расчетный_счет = f.CAccount;
                        Item.Код_банка = f.CBank;
                        MRC.SaveChanges();

                        selectedItem.SubItems[0].Text = f.CName;
                        selectedItem.SubItems[1].Text = f.COwner;
                        selectedItem.SubItems[2].Text = f.CAddress;
                        selectedItem.SubItems[3].Text = f.CAccount;
                        selectedItem.SubItems[4].Text = MRC.Банки.Find(f.CBank).Название_банка;

                        selectedItem.Tag = Item;

                        LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                        LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    }
                }
            }
        }
        private void Update_Car()
        {
            foreach (ListViewItem selectedItem in LView.SelectedItems)
            {

                Автомобили Item = (Автомобили)selectedItem.Tag;
                CarInsert f = new CarInsert(CarInsert.FormType.Update)
                {
                    indexCarRental = Item.Код_автопроката,
                    indexMarka = Item.Модели.Марки.Код_марки,
                    indexModel = Item.Код_модели,
                    indexColor = Convert.ToInt32(Item.Основной_цвет),
                    LastCondition = Item.Состояние,
                    indexDealer = Item.Код_диллера,
                    CPrice = Item.Цена_за_сутки.ToString(),
                };
                if (f.ShowDialog() == DialogResult.OK)
                {
                    using (ModelCarRental MRC = new ModelCarRental())
                    {
                        MRC.Автомобили.Attach(Item);
                        Item.Код_модели = f.Model;
                        Item.Код_автопроката = f.CCarRental;
                        Item.Основной_цвет = f.CColor.ToString();
                        Item.Состояние = f.CСondition;
                        Item.Код_диллера = f.CDealer;
                        Item.Цена_за_сутки = Convert.ToInt32(f.CPrice);
                        MRC.SaveChanges();

                        selectedItem.SubItems[1].Text = MRC.Автопрокаты.Find(Item.Код_автопроката).Название_автопроката;
                        selectedItem.SubItems[2].Text = MRC.Марки.Find(f.CMarka).Название_марки;
                        selectedItem.SubItems[3].Text = MRC.Модели.Find(Item.Код_модели).Название_модели;
                        selectedItem.UseItemStyleForSubItems = false;
                        selectedItem.SubItems[4].BackColor = System.Drawing.Color.FromArgb(f.CColor);
                        selectedItem.SubItems[5].Text = f.CСondition;
                        selectedItem.SubItems[6].Text = MRC.Дилеры.Find(Item.Код_диллера).Название_фирмы;
                        selectedItem.SubItems[7].Text = Convert.ToString(f.CPrice);

                        selectedItem.Tag = Item;

                        LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                        LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    }
                }
            }
        }


        private void Update_Model()
        {
            foreach (ListViewItem selectedItem in LView.SelectedItems)
            {
                Модели Item = (Модели)selectedItem.Tag;
                ModelInsert f = new ModelInsert(ModelInsert.FormType.Update)
                {
                    LastModel = Item.Название_модели,
                    indexMarka = Item.Код_марки,
                    CModel = Item.Название_модели,
                    indexType = Item.Код_типа,
                };
                if (f.ShowDialog() == DialogResult.OK)
                {
                    using (ModelCarRental MRC = new ModelCarRental())
                    {
                        MRC.Модели.Attach(Item);
                        Item.Код_марки = f.CMarka;
                        Item.Название_модели = f.CModel;
                        Item.Код_типа = f.CType;
                        MRC.SaveChanges();

                        selectedItem.SubItems[0].Text = MRC.Марки.Find(Item.Код_марки).Название_марки;
                        selectedItem.SubItems[1].Text = f.CModel;
                        selectedItem.SubItems[2].Text = MRC.Типы.Find(Item.Код_типа).Название_типа;

                        selectedItem.Tag = Item;

                        LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                        LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    }
                }
            }
        }
        public void Insert_CarRental()
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

                    ListViewItem lvi = new ListViewItem(new[]
                        {
                        Item.Название_автопроката,
                        Item.Собственник_автопроката,
                        Item.Адрес_автопроката,
                        Item.Расчетный_счет,
                        MRC.Банки.Find(Item.Код_банка).Название_банка,
                    });
                    lvi.Tag = Item;
                    this.LView.Items.Add(lvi);
                    LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                    LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                }
            }
        }
        private void Insert_Car()
        {
            CarInsert f = new CarInsert(CarInsert.FormType.Insert);
            if (f.ShowDialog() == DialogResult.OK)
            {
                using (ModelCarRental MRC = new ModelCarRental())
                {
                    Автомобили Item = new Автомобили();
                    foreach (Автомобили c in MRC.Автомобили) ;
                    int count = MRC.Автомобили.Local.Count;
                    Item.Номер_автомобиля = count + 1;
                    Item.Код_автопроката = f.CCarRental;
                    Item.Код_модели = f.Model;
                    Item.Основной_цвет = f.CColor.ToString();
                    Item.Состояние = f.CСondition;
                    Item.Код_диллера = f.CDealer;
                    Item.Цена_за_сутки = Convert.ToInt32(f.CPrice);

                    MRC.Автомобили.Add(Item);
                    MRC.SaveChanges();

                    ListViewItem lvi = new ListViewItem(new[]
                        {
                            Item.Номер_автомобиля.ToString(),
                            MRC.Автопрокаты.Find(Item.Код_автопроката).Название_автопроката,
                            MRC.Марки.Find(f.CMarka).Название_марки,
                            MRC.Модели.Find(Item.Код_модели).Название_модели,
                            "",
                            Item.Состояние,
                            MRC.Дилеры.Find(Item.Код_диллера).Название_фирмы,
                            Item.Цена_за_сутки.ToString(),
                        });
                    lvi.Tag = Item;
                    lvi.UseItemStyleForSubItems = false;
                    lvi.SubItems[4].BackColor = System.Drawing.Color.FromArgb(f.CColor);
                    this.LView.Items.Add(lvi);
                }
            }
        }
        private void Insert_Model()
        {
            ModelInsert f = new ModelInsert(ModelInsert.FormType.Insert);
            if (f.ShowDialog() == DialogResult.OK)
            {
                using (ModelCarRental MRC = new ModelCarRental())
                {
                    Модели Item = new Модели();
                    foreach (Модели c in MRC.Модели) ;
                    int count = MRC.Модели.Local.Count;
                    Item.Код_модели = count + 1;                    
                    Item.Название_модели = f.CModel;
                    Item.Код_марки = f.CMarka;
                    Item.Код_типа = f.CType;

                    MRC.Модели.Add(Item);
                    MRC.SaveChanges();

                    ListViewItem lvi = new ListViewItem(new[]
                    {
                        MRC.Марки.Find(Item.Код_марки).Название_марки,
                        MRC.Модели.Find(Item.Код_модели).Название_модели,
                        MRC.Типы.Find(Item.Код_типа).Название_типа,
                    });
                    lvi.Tag = Item;
                    this.LView.Items.Add(lvi);
                }

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
        private void Insert_User()
        {
            UserInsert f = new UserInsert("", UserInsert.FormType.Insert);
            if (f.ShowDialog() == DialogResult.OK)
            {
                using (ModelCarRental MRC = new ModelCarRental())
                {
                    Users Item = new Users();
                    //foreach (Users c in MRC.Users) ;
                    //int count = MRC.Users.Local.Count;
                    //Item.id = count + 1;
                    Item.login = f.Login;
                    Item.prefixpassword = Guid.NewGuid().ToString().Replace("-", "");
                    Item.hashpassword = CalcHash(f.Password + Item.prefixpassword);
                    Item.level = f.Access;
                    Item.date = f.Date;

                    MRC.Users.Add(Item);
                    MRC.SaveChanges();

                    ListViewItem lvi = new ListViewItem(new[]
                    {
                        Item.login,
                        MRC.Уровни_доступа.Find(Item.level).Уровень_доступа,
                        Item.date.ToShortDateString(),
                    });
                    lvi.Tag = Item;
                    this.LView.Items.Add(lvi);
                }

            }
            LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void Delete_User()
        {
            try
            {
                foreach (ListViewItem selectedItem in LView.SelectedItems)
                {
                    using (ModelCarRental MRC = new ModelCarRental())
                    {
                        Users n = (Users)selectedItem.Tag;
                        MRC.Users.Attach(n);
                        MRC.Users.Remove(n);
                        MRC.SaveChanges();
                        LView.Items.Remove(selectedItem);
                    }
                }
                LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
            catch
            {
                MessageBox.Show("Ошибка удаления");
            }
        }
        private void Update_User()
        {
            foreach (ListViewItem selectedItem in LView.SelectedItems)
            {
                Users Item = (Users)selectedItem.Tag;
                UserInsert f = new UserInsert(Item.login, UserInsert.FormType.Update)
                {
                    Login = Item.login,
                    Date = Item.date,
                    indexLevel = Item.Уровни_доступа.id,
                };
                if (f.ShowDialog() == DialogResult.OK)
                {
                    using (ModelCarRental MRC = new ModelCarRental())
                    {
                        MRC.Users.Attach(Item);
                        Item.login = f.Login;
                        if (f.isPassword)
                        {
                            Item.prefixpassword = Guid.NewGuid().ToString().Replace("-", "");
                            Item.hashpassword = CalcHash(f.Password + Item.prefixpassword);
                        }
                        Item.level = f.Access;
                        Item.date = f.Date;
                        MRC.SaveChanges();

                        selectedItem.SubItems[0].Text = Item.login;
                        selectedItem.SubItems[1].Text = MRC.Уровни_доступа.Find(Item.level).Уровень_доступа;
                        selectedItem.SubItems[2].Text = Item.date.ToShortDateString();
                        selectedItem.Tag = Item;

                        LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                        LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                    }
                }
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (ListTable.SelectedItem.ToString())
            {
                case "Автопрокаты": Insert_CarRental(); break;
                case "Автомобили": Insert_Car(); break;
                case "Модели": Insert_Model(); break;
                case "Марки": Insert_Brands(); break;
                case "Users": Insert_User(); break;
            }
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (ListTable.SelectedItem.ToString())
            {
                case "Автопрокаты": Update_CarRental(); break;
                case "Автомобили": Update_Car(); break;
                case "Модели": Update_Model(); break;
                case "Марки": Update_Brands(); break;
                case "Users": Update_User(); break;
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (ListTable.SelectedItem.ToString())
            {
                case "Автопрокаты": Delete_CarRental(); break;
                case "Автомобили": Delete_Car(); break;
                case "Модели": Delete_Model(); break;
                case "Марки": Delete_Brands(); break;
                case "Users": Delete_User(); break;
            }
        }

        private void дешёвыеАвтомобилиВОтличномСостоянииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListTable.SelectedIndex = 1;
            LView.Clear();
            LView.Columns.Add("Инд. №");
            LView.Columns.Add("Автопрокат");
            LView.Columns.Add("Марка");
            LView.Columns.Add("Модель");
            LView.Columns.Add("Цвет");
            LView.Columns.Add("Состояние");
            LView.Columns.Add("Дилер");
            LView.Columns.Add("Цена за сутки");
            ModelCarRental b = new ModelCarRental();
            string[] nameModel = new string[b.Модели.Count() + 1];
            string[] nameMarki = new string[b.Марки.Count() + 1];
            string[] nameDiler = new string[b.Дилеры.Count() + 1];
            string[] nameProkat = new string[b.Автопрокаты.Count() + 1];
            using (ModelCarRental MCR = new ModelCarRental())
            {
                int h = 1;
                foreach (Автопрокаты a in MCR.Автопрокаты)
                {
                    nameProkat[h] = a.Название_автопроката;
                    h++;
                }
                h = 1;
                foreach (Марки a in MCR.Марки)
                {
                    nameMarki[h] = a.Название_марки;
                    h++;
                }
                h = 1;
                foreach (Модели a in MCR.Модели)
                {
                    nameModel[h] = a.Название_модели;
                    h++;
                }
                h = 1;
                foreach (Дилеры a in MCR.Дилеры)
                {
                    nameDiler[h] = a.Название_фирмы;
                    h++;
                }
                foreach (Автомобили mu in MCR.Автомобили)
                {
                    if (mu.Состояние == "отлично" && mu.Цена_за_сутки <= 1500)
                    {
                        ListViewItem lvi = new ListViewItem(new[]
                        {
                            mu.Номер_автомобиля.ToString(),
                            mu.Автопрокаты.Название_автопроката,
                            MCR.Марки.Find(mu.Модели.Код_марки).Название_марки,
                            mu.Модели.Название_модели,
                            "",
                            mu.Состояние,
                            mu.Дилеры.Название_фирмы,
                            mu.Цена_за_сутки.ToString(),
                        })
                        {
                            Tag = mu
                        };
                        this.LView.Items.Add(lvi);
                        lvi.UseItemStyleForSubItems = false;
                        lvi.SubItems[4].BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(mu.Основной_цвет));
                    }
                }
                LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void российскиеАвтомобилиВХорошемСостоянииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListTable.SelectedIndex = 1;
            LView.Clear();
            LView.Columns.Add("Инд. №");
            LView.Columns.Add("Автопрокат");
            LView.Columns.Add("Марка");
            LView.Columns.Add("Модель");
            LView.Columns.Add("Цвет");
            LView.Columns.Add("Состояние");
            LView.Columns.Add("Дилер");
            LView.Columns.Add("Цена за сутки");
            ModelCarRental b = new ModelCarRental();
            string[] nameModel = new string[b.Модели.Count() + 1];
            string[] nameMarki = new string[b.Марки.Count() + 1];
            string[] nameDiler = new string[b.Дилеры.Count() + 1];
            string[] nameProkat = new string[b.Автопрокаты.Count() + 1];
            using (ModelCarRental MCR = new ModelCarRental())
            {
                int h = 1;
                foreach (Автопрокаты a in MCR.Автопрокаты)
                {
                    nameProkat[h] = a.Название_автопроката;
                    h++;
                }
                h = 1;
                foreach (Марки a in MCR.Марки)
                {
                    nameMarki[h] = a.Название_марки;
                    h++;
                }
                h = 1;
                foreach (Модели a in MCR.Модели)
                {
                    nameModel[h] = a.Название_модели;
                    h++;
                }
                h = 1;
                foreach (Дилеры a in MCR.Дилеры)
                {
                    nameDiler[h] = a.Название_фирмы;
                    h++;
                }
                foreach (Автомобили mu in MCR.Автомобили)
                {
                    if (mu.Состояние == "хорошо" && MCR.Марки.Find(mu.Модели.Код_марки).Код_страны == 1)
                    {
                        ListViewItem lvi = new ListViewItem(new[]
                        {
                            mu.Номер_автомобиля.ToString(),
                            mu.Автопрокаты.Название_автопроката,
                            MCR.Марки.Find(mu.Модели.Код_марки).Название_марки,
                            mu.Модели.Название_модели,
                            "",
                            mu.Состояние,
                            mu.Дилеры.Название_фирмы,
                            mu.Цена_за_сутки.ToString(),
                        })
                        {
                            Tag = mu
                        };
                        this.LView.Items.Add(lvi);
                        lvi.UseItemStyleForSubItems = false;
                        lvi.SubItems[4].BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(mu.Основной_цвет));
                    }
                }
                LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void иномаркиВКузовеХетчбекToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListTable.SelectedIndex = 1;
            LView.Clear();
            LView.Columns.Add("Инд. №");
            LView.Columns.Add("Автопрокат");
            LView.Columns.Add("Марка");
            LView.Columns.Add("Модель");
            LView.Columns.Add("Цвет");
            LView.Columns.Add("Состояние");
            LView.Columns.Add("Дилер");
            LView.Columns.Add("Цена за сутки");
            ModelCarRental b = new ModelCarRental();
            string[] nameModel = new string[b.Модели.Count() + 1];
            string[] nameMarki = new string[b.Марки.Count() + 1];
            string[] nameDiler = new string[b.Дилеры.Count() + 1];
            string[] nameProkat = new string[b.Автопрокаты.Count() + 1];
            using (ModelCarRental MCR = new ModelCarRental())
            {
                int h = 1;
                foreach (Автопрокаты a in MCR.Автопрокаты)
                {
                    nameProkat[h] = a.Название_автопроката;
                    h++;
                }
                h = 1;
                foreach (Марки a in MCR.Марки)
                {
                    nameMarki[h] = a.Название_марки;
                    h++;
                }
                h = 1;
                foreach (Модели a in MCR.Модели)
                {
                    nameModel[h] = a.Название_модели;
                    h++;
                }
                h = 1;
                foreach (Дилеры a in MCR.Дилеры)
                {
                    nameDiler[h] = a.Название_фирмы;
                    h++;
                }
                foreach (Автомобили mu in MCR.Автомобили)
                {
                    if (mu.Модели.Код_типа == 6 && MCR.Марки.Find(mu.Модели.Код_марки).Код_страны != 1)
                    {
                        ListViewItem lvi = new ListViewItem(new[]
                        {
                            mu.Номер_автомобиля.ToString(),
                            mu.Автопрокаты.Название_автопроката,
                            MCR.Марки.Find(mu.Модели.Код_марки).Название_марки,
                            mu.Модели.Название_модели,
                            "",
                            mu.Состояние,
                            mu.Дилеры.Название_фирмы,
                            mu.Цена_за_сутки.ToString(),
                        })
                        {
                            Tag = mu
                        };
                        this.LView.Items.Add(lvi);
                        lvi.UseItemStyleForSubItems = false;
                        lvi.SubItems[4].BackColor = System.Drawing.Color.FromArgb(Convert.ToInt32(mu.Основной_цвет));
                    }
                }
                LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                LView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            }

        }
    }
}
