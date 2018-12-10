namespace WindowsFormsApp1
{
    partial class Form1
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Enter_Button = new System.Windows.Forms.Button();
            this.Login_Lable = new System.Windows.Forms.Label();
            this.Password_Lable = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(253, 20);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(9, 114);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(253, 20);
            this.textBox2.TabIndex = 1;
            // 
            // Enter_Button
            // 
            this.Enter_Button.Location = new System.Drawing.Point(9, 162);
            this.Enter_Button.Name = "Enter_Button";
            this.Enter_Button.Size = new System.Drawing.Size(125, 64);
            this.Enter_Button.TabIndex = 2;
            this.Enter_Button.Text = "Войти";
            this.Enter_Button.UseVisualStyleBackColor = true;
            this.Enter_Button.Click += new System.EventHandler(this.Enter_Button_Click);
            // 
            // Login_Lable
            // 
            this.Login_Lable.AutoSize = true;
            this.Login_Lable.Location = new System.Drawing.Point(12, 39);
            this.Login_Lable.Name = "Login_Lable";
            this.Login_Lable.Size = new System.Drawing.Size(38, 13);
            this.Login_Lable.TabIndex = 3;
            this.Login_Lable.Text = "Логин";
            this.Login_Lable.Click += new System.EventHandler(this.label1_Click);
            // 
            // Password_Lable
            // 
            this.Password_Lable.AutoSize = true;
            this.Password_Lable.Location = new System.Drawing.Point(12, 98);
            this.Password_Lable.Name = "Password_Lable";
            this.Password_Lable.Size = new System.Drawing.Size(45, 13);
            this.Password_Lable.TabIndex = 4;
            this.Password_Lable.Text = "Пароль";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(140, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 64);
            this.button1.TabIndex = 5;
            this.button1.Text = "Зарегистрироваться";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(274, 238);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Password_Lable);
            this.Controls.Add(this.Login_Lable);
            this.Controls.Add(this.Enter_Button);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.MaximumSize = new System.Drawing.Size(330, 389);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button Enter_Button;
        private System.Windows.Forms.Label Login_Lable;
        private System.Windows.Forms.Label Password_Lable;
        private System.Windows.Forms.Button button1;
    }
}

