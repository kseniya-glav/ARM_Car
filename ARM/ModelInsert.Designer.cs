namespace ARM
{
    partial class ModelInsert
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
            this.cbMarka = new System.Windows.Forms.ComboBox();
            this.маркиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.carRental2DataSet = new ARM.CarRental2DataSet();
            this.add_Marka = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbModel = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.типыBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.маркиTableAdapter = new ARM.CarRental2DataSetTableAdapters.МаркиTableAdapter();
            this.типыTableAdapter = new ARM.CarRental2DataSetTableAdapters.ТипыTableAdapter();
            this.epMain = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.маркиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.carRental2DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.типыBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Марка:";
            // 
            // cbMarka
            // 
            this.cbMarka.DataSource = this.маркиBindingSource;
            this.cbMarka.DisplayMember = "Название_марки";
            this.cbMarka.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMarka.FormattingEnabled = true;
            this.cbMarka.Location = new System.Drawing.Point(86, 7);
            this.cbMarka.Name = "cbMarka";
            this.cbMarka.Size = new System.Drawing.Size(136, 21);
            this.cbMarka.TabIndex = 5;
            this.cbMarka.ValueMember = "Код_марки";
            this.cbMarka.SelectedIndexChanged += new System.EventHandler(this.tbModel_TextChanged);
            // 
            // маркиBindingSource
            // 
            this.маркиBindingSource.DataMember = "Марки";
            this.маркиBindingSource.DataSource = this.carRental2DataSet;
            // 
            // carRental2DataSet
            // 
            this.carRental2DataSet.DataSetName = "CarRental2DataSet";
            this.carRental2DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // add_Marka
            // 
            this.add_Marka.Location = new System.Drawing.Point(228, 7);
            this.add_Marka.Name = "add_Marka";
            this.add_Marka.Size = new System.Drawing.Size(20, 20);
            this.add_Marka.TabIndex = 7;
            this.add_Marka.Text = "+";
            this.add_Marka.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Модель:";
            // 
            // tbModel
            // 
            this.tbModel.Location = new System.Drawing.Point(85, 35);
            this.tbModel.MaxLength = 20;
            this.tbModel.Name = "tbModel";
            this.tbModel.Size = new System.Drawing.Size(136, 20);
            this.tbModel.TabIndex = 9;
            this.tbModel.TextChanged += new System.EventHandler(this.tbModel_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Тип кузова:";
            // 
            // cbType
            // 
            this.cbType.DataSource = this.типыBindingSource;
            this.cbType.DisplayMember = "Название_типа";
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(85, 61);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(136, 21);
            this.cbType.TabIndex = 4;
            this.cbType.ValueMember = "Код_типа";
            // 
            // типыBindingSource
            // 
            this.типыBindingSource.DataMember = "Типы";
            this.типыBindingSource.DataSource = this.carRental2DataSet;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(15, 88);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 23);
            this.btnOK.TabIndex = 12;
            this.btnOK.Text = "Изменить/Добавить";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(122, 88);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // маркиTableAdapter
            // 
            this.маркиTableAdapter.ClearBeforeFill = true;
            // 
            // типыTableAdapter
            // 
            this.типыTableAdapter.ClearBeforeFill = true;
            // 
            // epMain
            // 
            this.epMain.ContainerControl = this;
            // 
            // ModelInsert
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 122);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbModel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.add_Marka);
            this.Controls.Add(this.cbMarka);
            this.Controls.Add(this.label5);
            this.Name = "ModelInsert";
            this.Text = "ModelInsert";
            this.Load += new System.EventHandler(this.CarRentalInsert_Load);
            ((System.ComponentModel.ISupportInitialize)(this.маркиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.carRental2DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.типыBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbMarka;
        private System.Windows.Forms.Button add_Marka;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbModel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private CarRental2DataSet carRental2DataSet;
        private System.Windows.Forms.BindingSource маркиBindingSource;
        private CarRental2DataSetTableAdapters.МаркиTableAdapter маркиTableAdapter;
        private System.Windows.Forms.BindingSource типыBindingSource;
        private CarRental2DataSetTableAdapters.ТипыTableAdapter типыTableAdapter;
        private System.Windows.Forms.ErrorProvider epMain;
    }
}