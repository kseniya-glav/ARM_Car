namespace ARM
{
    partial class CarInsert
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label5 = new System.Windows.Forms.Label();
            this.cbCarRental = new System.Windows.Forms.ComboBox();
            this.addCarRental = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.cbMarka = new System.Windows.Forms.ComboBox();
            this.addMarka = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbModel = new System.Windows.Forms.ComboBox();
            this.addModel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btColor = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cbСondition = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbDealer = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.carRental2DataSet = new ARM.CarRental2DataSet();
            this.автопрокатыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.автопрокатыTableAdapter = new ARM.CarRental2DataSetTableAdapters.АвтопрокатыTableAdapter();
            this.маркиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.маркиTableAdapter = new ARM.CarRental2DataSetTableAdapters.МаркиTableAdapter();
            this.маркиМоделиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.моделиTableAdapter = new ARM.CarRental2DataSetTableAdapters.МоделиTableAdapter();
            this.диллерыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.диллерыTableAdapter = new ARM.CarRental2DataSetTableAdapters.ДиллерыTableAdapter();
            this.epMain = new System.Windows.Forms.ErrorProvider(this.components);
            this.CD = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.carRental2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.автопрокатыBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.маркиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.маркиМоделиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.диллерыBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Автопрокат:";
            // 
            // cbCarRental
            // 
            this.cbCarRental.DataSource = this.автопрокатыBindingSource;
            this.cbCarRental.DisplayMember = "Название_автопроката";
            this.cbCarRental.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCarRental.FormattingEnabled = true;
            this.cbCarRental.Location = new System.Drawing.Point(87, 6);
            this.cbCarRental.Name = "cbCarRental";
            this.cbCarRental.Size = new System.Drawing.Size(136, 21);
            this.cbCarRental.TabIndex = 4;
            this.cbCarRental.ValueMember = "Код_автопроката";
            // 
            // addCarRental
            // 
            this.addCarRental.Location = new System.Drawing.Point(229, 5);
            this.addCarRental.Name = "addCarRental";
            this.addCarRental.Size = new System.Drawing.Size(22, 22);
            this.addCarRental.TabIndex = 9;
            this.addCarRental.Text = "+";
            this.addCarRental.UseVisualStyleBackColor = true;
            this.addCarRental.Click += new System.EventHandler(this.addCarRental_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 37);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Марка:";
            // 
            // cbMarka
            // 
            this.cbMarka.DataSource = this.маркиBindingSource;
            this.cbMarka.DisplayMember = "Название_марки";
            this.cbMarka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMarka.FormattingEnabled = true;
            this.cbMarka.Location = new System.Drawing.Point(87, 34);
            this.cbMarka.Name = "cbMarka";
            this.cbMarka.Size = new System.Drawing.Size(136, 21);
            this.cbMarka.TabIndex = 4;
            this.cbMarka.ValueMember = "Код_марки";
            // 
            // addMarka
            // 
            this.addMarka.Location = new System.Drawing.Point(229, 34);
            this.addMarka.Name = "addMarka";
            this.addMarka.Size = new System.Drawing.Size(22, 22);
            this.addMarka.TabIndex = 9;
            this.addMarka.Text = "+";
            this.addMarka.UseVisualStyleBackColor = true;
            this.addMarka.Click += new System.EventHandler(this.addMarka_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Модель:";
            // 
            // cbModel
            // 
            this.cbModel.DataSource = this.маркиМоделиBindingSource;
            this.cbModel.DisplayMember = "Название_модели";
            this.cbModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModel.FormattingEnabled = true;
            this.cbModel.Location = new System.Drawing.Point(87, 63);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(136, 21);
            this.cbModel.TabIndex = 15;
            this.cbModel.ValueMember = "Код_модели";
            // 
            // addModel
            // 
            this.addModel.Location = new System.Drawing.Point(229, 63);
            this.addModel.Name = "addModel";
            this.addModel.Size = new System.Drawing.Size(22, 22);
            this.addModel.TabIndex = 9;
            this.addModel.Text = "+";
            this.addModel.UseVisualStyleBackColor = true;
            this.addModel.Click += new System.EventHandler(this.addModel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Цвет:";
            // 
            // btColor
            // 
            this.btColor.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btColor.Location = new System.Drawing.Point(87, 90);
            this.btColor.Name = "btColor";
            this.btColor.Size = new System.Drawing.Size(136, 21);
            this.btColor.TabIndex = 5;
            this.btColor.UseVisualStyleBackColor = true;
            this.btColor.Click += new System.EventHandler(this.btColor_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Состояние:";
            // 
            // cbСondition
            // 
            this.cbСondition.DataSource = this.диллерыBindingSource;
            this.cbСondition.DisplayMember = "Название_фирмы";
            this.cbСondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbСondition.FormattingEnabled = true;
            this.cbСondition.Location = new System.Drawing.Point(87, 117);
            this.cbСondition.Name = "cbСondition";
            this.cbСondition.Size = new System.Drawing.Size(136, 21);
            this.cbСondition.TabIndex = 4;
            this.cbСondition.ValueMember = "Код_диллера";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Дилер:";
            // 
            // cbDealer
            // 
            this.cbDealer.DataSource = this.диллерыBindingSource;
            this.cbDealer.DisplayMember = "Название_фирмы";
            this.cbDealer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDealer.FormattingEnabled = true;
            this.cbDealer.Location = new System.Drawing.Point(87, 147);
            this.cbDealer.Name = "cbDealer";
            this.cbDealer.Size = new System.Drawing.Size(136, 21);
            this.cbDealer.TabIndex = 4;
            this.cbDealer.ValueMember = "Код_диллера";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 181);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Цена за сутки:";
            // 
            // tbPrice
            // 
            this.tbPrice.Location = new System.Drawing.Point(101, 178);
            this.tbPrice.MaxLength = 5;
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(122, 20);
            this.tbPrice.TabIndex = 24;
            this.tbPrice.TextChanged += new System.EventHandler(this.tbPrice_TextChanged);
            this.tbPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPrice_KeyPress);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(12, 204);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 23);
            this.btnOK.TabIndex = 25;
            this.btnOK.Text = "Изменить/Добавить";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(123, 204);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // carRental2DataSet
            // 
            this.carRental2DataSet.DataSetName = "CarRental2DataSet";
            this.carRental2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // автопрокатыBindingSource
            // 
            this.автопрокатыBindingSource.DataMember = "Автопрокаты";
            this.автопрокатыBindingSource.DataSource = this.carRental2DataSet;
            // 
            // автопрокатыTableAdapter
            // 
            this.автопрокатыTableAdapter.ClearBeforeFill = true;
            // 
            // маркиBindingSource
            // 
            this.маркиBindingSource.DataMember = "Марки";
            this.маркиBindingSource.DataSource = this.carRental2DataSet;
            // 
            // маркиTableAdapter
            // 
            this.маркиTableAdapter.ClearBeforeFill = true;
            // 
            // маркиМоделиBindingSource
            // 
            this.маркиМоделиBindingSource.DataMember = "Марки_Модели";
            this.маркиМоделиBindingSource.DataSource = this.маркиBindingSource;
            // 
            // моделиTableAdapter
            // 
            this.моделиTableAdapter.ClearBeforeFill = true;
            // 
            // диллерыBindingSource
            // 
            this.диллерыBindingSource.DataMember = "Диллеры";
            this.диллерыBindingSource.DataSource = this.carRental2DataSet;
            // 
            // диллерыTableAdapter
            // 
            this.диллерыTableAdapter.ClearBeforeFill = true;
            // 
            // epMain
            // 
            this.epMain.ContainerControl = this;
            // 
            // CarInsert
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(254, 231);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tbPrice);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbDealer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbСondition);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addModel);
            this.Controls.Add(this.cbModel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addMarka);
            this.Controls.Add(this.cbMarka);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.addCarRental);
            this.Controls.Add(this.cbCarRental);
            this.Controls.Add(this.label5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(270, 270);
            this.MinimumSize = new System.Drawing.Size(270, 270);
            this.Name = "CarInsert";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить";
            this.Load += new System.EventHandler(this.CarInsert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.carRental2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.автопрокатыBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.маркиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.маркиМоделиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.диллерыBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbCarRental;
        private System.Windows.Forms.Button addCarRental;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbMarka;
        private System.Windows.Forms.Button addMarka;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbModel;
        private System.Windows.Forms.Button addModel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btColor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbСondition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbDealer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbPrice;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private CarRental2DataSet carRental2DataSet;
        private System.Windows.Forms.BindingSource автопрокатыBindingSource;
        private CarRental2DataSetTableAdapters.АвтопрокатыTableAdapter автопрокатыTableAdapter;
        private System.Windows.Forms.BindingSource маркиBindingSource;
        private CarRental2DataSetTableAdapters.МаркиTableAdapter маркиTableAdapter;
        private System.Windows.Forms.BindingSource маркиМоделиBindingSource;
        private CarRental2DataSetTableAdapters.МоделиTableAdapter моделиTableAdapter;
        private System.Windows.Forms.BindingSource диллерыBindingSource;
        private CarRental2DataSetTableAdapters.ДиллерыTableAdapter диллерыTableAdapter;
        private System.Windows.Forms.ErrorProvider epMain;
        private System.Windows.Forms.ColorDialog CD;
    }
}