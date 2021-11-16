
namespace SoftSunlightIM
{
    partial class LoginForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbAccount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCofirmRegister = new System.Windows.Forms.Button();
            this.tbRegisterPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbRegisterAccount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRegisterConfirmPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnRegister);
            this.panel1.Controls.Add(this.btnLogin);
            this.panel1.Controls.Add(this.tbPassword);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbAccount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(60, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 174);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "账号";
            // 
            // tbAccount
            // 
            this.tbAccount.Location = new System.Drawing.Point(95, 27);
            this.tbAccount.Name = "tbAccount";
            this.tbAccount.Size = new System.Drawing.Size(206, 21);
            this.tbAccount.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "密码";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(95, 76);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '·';
            this.tbPassword.Size = new System.Drawing.Size(206, 21);
            this.tbPassword.TabIndex = 3;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(95, 128);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(207, 128);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(75, 23);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "注册";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tbRegisterConfirmPassword);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.btnCofirmRegister);
            this.panel2.Controls.Add(this.tbRegisterPassword);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.tbRegisterAccount);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(50, 221);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(362, 174);
            this.panel2.TabIndex = 1;
            this.panel2.Visible = false;
            // 
            // btnCofirmRegister
            // 
            this.btnCofirmRegister.Location = new System.Drawing.Point(155, 141);
            this.btnCofirmRegister.Name = "btnCofirmRegister";
            this.btnCofirmRegister.Size = new System.Drawing.Size(75, 23);
            this.btnCofirmRegister.TabIndex = 4;
            this.btnCofirmRegister.Text = "确定";
            this.btnCofirmRegister.UseVisualStyleBackColor = true;
            // 
            // tbRegisterPassword
            // 
            this.tbRegisterPassword.Location = new System.Drawing.Point(95, 62);
            this.tbRegisterPassword.Name = "tbRegisterPassword";
            this.tbRegisterPassword.PasswordChar = '·';
            this.tbRegisterPassword.Size = new System.Drawing.Size(206, 21);
            this.tbRegisterPassword.TabIndex = 3;
            this.tbRegisterPassword.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(49, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "密码";
            // 
            // tbRegisterAccount
            // 
            this.tbRegisterAccount.Location = new System.Drawing.Point(95, 27);
            this.tbRegisterAccount.Name = "tbRegisterAccount";
            this.tbRegisterAccount.Size = new System.Drawing.Size(206, 21);
            this.tbRegisterAccount.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "账号";
            // 
            // tbRegisterConfirmPassword
            // 
            this.tbRegisterConfirmPassword.Location = new System.Drawing.Point(95, 96);
            this.tbRegisterConfirmPassword.Name = "tbRegisterConfirmPassword";
            this.tbRegisterConfirmPassword.PasswordChar = '·';
            this.tbRegisterConfirmPassword.Size = new System.Drawing.Size(206, 21);
            this.tbRegisterConfirmPassword.TabIndex = 6;
            this.tbRegisterConfirmPassword.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(36, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "确认密码";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 270);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IM";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbAccount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbRegisterConfirmPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCofirmRegister;
        private System.Windows.Forms.TextBox tbRegisterPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbRegisterAccount;
        private System.Windows.Forms.Label label4;
    }
}

