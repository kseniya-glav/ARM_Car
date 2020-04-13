namespace ARM
{
    partial class Authorization
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Login = new System.Windows.Forms.TextBox();
            this.LoginBT = new System.Windows.Forms.Button();
            this.RegBT = new System.Windows.Forms.Button();
            this.btnEND = new System.Windows.Forms.Button();
            this.epMain = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(249, 164);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Авторизация";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(60, 141);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(108, 17);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "Войти как гость";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Password);
            this.groupBox2.Location = new System.Drawing.Point(14, 80);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 55);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Пароль";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(6, 19);
            this.Password.MaxLength = 32;
            this.Password.Name = "Password";
            this.Password.PasswordChar = '*';
            this.Password.Size = new System.Drawing.Size(195, 20);
            this.Password.TabIndex = 1;
            this.Password.TextChanged += new System.EventHandler(this.Login_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Login);
            this.groupBox1.Location = new System.Drawing.Point(14, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 55);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Логин";
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(6, 21);
            this.Login.MaxLength = 15;
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(195, 20);
            this.Login.TabIndex = 0;
            this.Login.TextChanged += new System.EventHandler(this.Login_TextChanged);
            // 
            // LoginBT
            // 
            this.LoginBT.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.LoginBT.Enabled = false;
            this.LoginBT.Location = new System.Drawing.Point(26, 182);
            this.LoginBT.Name = "LoginBT";
            this.LoginBT.Size = new System.Drawing.Size(220, 30);
            this.LoginBT.TabIndex = 10;
            this.LoginBT.Text = "Войти в систему";
            this.LoginBT.UseVisualStyleBackColor = true;
            this.LoginBT.Click += new System.EventHandler(this.LoginBT_Click);
            // 
            // RegBT
            // 
            this.RegBT.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.RegBT.Location = new System.Drawing.Point(26, 218);
            this.RegBT.Name = "RegBT";
            this.RegBT.Size = new System.Drawing.Size(105, 30);
            this.RegBT.TabIndex = 11;
            this.RegBT.Text = "Регистрация";
            this.RegBT.UseVisualStyleBackColor = true;
            this.RegBT.Click += new System.EventHandler(this.RegBT_Click);
            // 
            // btnEND
            // 
            this.btnEND.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEND.Location = new System.Drawing.Point(141, 218);
            this.btnEND.Name = "btnEND";
            this.btnEND.Size = new System.Drawing.Size(105, 30);
            this.btnEND.TabIndex = 12;
            this.btnEND.Text = "Выход";
            this.btnEND.UseVisualStyleBackColor = true;
            this.btnEND.Click += new System.EventHandler(this.btnEND_Click);
            // 
            // epMain
            // 
            this.epMain.ContainerControl = this;
            // 
            // Authorization
            // 
            this.AcceptButton = this.LoginBT;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnEND;
            this.ClientSize = new System.Drawing.Size(279, 261);
            this.ControlBox = false;
            this.Controls.Add(this.btnEND);
            this.Controls.Add(this.RegBT);
            this.Controls.Add(this.LoginBT);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Authorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Аутентификация";
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epMain)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox Login;
        private System.Windows.Forms.Button LoginBT;
        private System.Windows.Forms.Button RegBT;
        private System.Windows.Forms.Button btnEND;
        private System.Windows.Forms.ErrorProvider epMain;
    }
}

