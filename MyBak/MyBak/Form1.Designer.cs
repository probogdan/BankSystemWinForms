namespace MyBak
{
    partial class AuthorizationForm
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
            this.EnterBut = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.Your_Login = new System.Windows.Forms.Label();
            this.Your_Password = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EnterBut
            // 
            this.EnterBut.Location = new System.Drawing.Point(265, 67);
            this.EnterBut.Name = "EnterBut";
            this.EnterBut.Size = new System.Drawing.Size(75, 23);
            this.EnterBut.TabIndex = 0;
            this.EnterBut.Text = "Входим";
            this.EnterBut.UseVisualStyleBackColor = true;
            this.EnterBut.Click += new System.EventHandler(this.button1_Click);
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(110, 52);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(149, 20);
            this.Login.TabIndex = 1;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(110, 93);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(149, 20);
            this.Password.TabIndex = 2;
            // 
            // Your_Login
            // 
            this.Your_Login.AutoSize = true;
            this.Your_Login.Location = new System.Drawing.Point(117, 36);
            this.Your_Login.Name = "Your_Login";
            this.Your_Login.Size = new System.Drawing.Size(38, 13);
            this.Your_Login.TabIndex = 3;
            this.Your_Login.Text = "Логин";
            // 
            // Your_Password
            // 
            this.Your_Password.AutoSize = true;
            this.Your_Password.Location = new System.Drawing.Point(117, 77);
            this.Your_Password.Name = "Your_Password";
            this.Your_Password.Size = new System.Drawing.Size(45, 13);
            this.Your_Password.TabIndex = 4;
            this.Your_Password.Text = "Пароль";
            // 
            // AuthorizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 181);
            this.Controls.Add(this.Your_Password);
            this.Controls.Add(this.Your_Login);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.EnterBut);
            this.Name = "AuthorizationForm";
            this.Text = "AuthorizationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button EnterBut;
        private System.Windows.Forms.TextBox Login;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label Your_Login;
        private System.Windows.Forms.Label Your_Password;
    }
}

