namespace Upgrade
{
    partial class Reg_AuthForm
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
            this.panel_chart = new System.Windows.Forms.Panel();
            this.chart = new System.Windows.Forms.PictureBox();
            this.label_reg_login = new System.Windows.Forms.Label();
            this.label_reg_password = new System.Windows.Forms.Label();
            this.label_reg_email = new System.Windows.Forms.Label();
            this.panel_back = new System.Windows.Forms.Panel();
            this.back = new System.Windows.Forms.PictureBox();
            this.login_reg = new System.Windows.Forms.TextBox();
            this.pass_reg = new System.Windows.Forms.TextBox();
            this.email_reg = new System.Windows.Forms.TextBox();
            this.label_empty_email = new System.Windows.Forms.Label();
            this.registration = new AltoControls.AltoButton();
            this.panel_reg = new System.Windows.Forms.Panel();
            this.backgr_reg = new System.Windows.Forms.PictureBox();
            this.login_auth = new System.Windows.Forms.TextBox();
            this.label_auth_password = new System.Windows.Forms.Label();
            this.authorization = new AltoControls.AltoButton();
            this.label_auth_login = new System.Windows.Forms.Label();
            this.pass_auth = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label_for_reg = new System.Windows.Forms.Label();
            this.panel_exit = new System.Windows.Forms.Panel();
            this.exit = new System.Windows.Forms.PictureBox();
            this.label_remember_me = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.remember = new System.Windows.Forms.PictureBox();
            this.backgr_auth = new System.Windows.Forms.PictureBox();
            this.panel_chart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.panel_back.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            this.panel_reg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backgr_reg)).BeginInit();
            this.panel_exit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.remember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgr_auth)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_chart
            // 
            this.panel_chart.BackColor = System.Drawing.Color.DarkBlue;
            this.panel_chart.Controls.Add(this.chart);
            this.panel_chart.Location = new System.Drawing.Point(10, 465);
            this.panel_chart.Name = "panel_chart";
            this.panel_chart.Size = new System.Drawing.Size(350, 92);
            this.panel_chart.TabIndex = 1;
            // 
            // chart
            // 
            this.chart.BackColor = System.Drawing.Color.Transparent;
            this.chart.Image = global::Upgrade.Properties.Resources.chart_background;
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(350, 92);
            this.chart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.chart.TabIndex = 0;
            this.chart.TabStop = false;
            // 
            // label_reg_login
            // 
            this.label_reg_login.AutoSize = true;
            this.label_reg_login.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_reg_login.ForeColor = System.Drawing.Color.DarkBlue;
            this.label_reg_login.Location = new System.Drawing.Point(65, 200);
            this.label_reg_login.Name = "label_reg_login";
            this.label_reg_login.Size = new System.Drawing.Size(74, 16);
            this.label_reg_login.TabIndex = 2;
            this.label_reg_login.Text = "псевдоним";
            // 
            // label_reg_password
            // 
            this.label_reg_password.AutoSize = true;
            this.label_reg_password.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_reg_password.ForeColor = System.Drawing.Color.DarkBlue;
            this.label_reg_password.Location = new System.Drawing.Point(65, 254);
            this.label_reg_password.Name = "label_reg_password";
            this.label_reg_password.Size = new System.Drawing.Size(50, 16);
            this.label_reg_password.TabIndex = 3;
            this.label_reg_password.Text = "пароль";
            // 
            // label_reg_email
            // 
            this.label_reg_email.AutoSize = true;
            this.label_reg_email.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_reg_email.ForeColor = System.Drawing.Color.DarkBlue;
            this.label_reg_email.Location = new System.Drawing.Point(65, 308);
            this.label_reg_email.Name = "label_reg_email";
            this.label_reg_email.Size = new System.Drawing.Size(120, 16);
            this.label_reg_email.TabIndex = 4;
            this.label_reg_email.Text = "электронная почта";
            // 
            // panel_back
            // 
            this.panel_back.BackColor = System.Drawing.Color.DarkBlue;
            this.panel_back.Controls.Add(this.back);
            this.panel_back.Location = new System.Drawing.Point(10, 10);
            this.panel_back.Name = "panel_back";
            this.panel_back.Size = new System.Drawing.Size(51, 36);
            this.panel_back.TabIndex = 2;
            // 
            // back
            // 
            this.back.BackColor = System.Drawing.Color.Transparent;
            this.back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.back.Image = global::Upgrade.Properties.Resources.back_reg;
            this.back.Location = new System.Drawing.Point(0, 0);
            this.back.Name = "back";
            this.back.Size = new System.Drawing.Size(51, 36);
            this.back.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.back.TabIndex = 1;
            this.back.TabStop = false;
            this.back.Click += new System.EventHandler(this.back_Click);
            // 
            // login_reg
            // 
            this.login_reg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.login_reg.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_reg.ForeColor = System.Drawing.Color.Black;
            this.login_reg.Location = new System.Drawing.Point(66, 222);
            this.login_reg.Name = "login_reg";
            this.login_reg.Size = new System.Drawing.Size(242, 20);
            this.login_reg.TabIndex = 7;
            // 
            // pass_reg
            // 
            this.pass_reg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pass_reg.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pass_reg.ForeColor = System.Drawing.Color.Black;
            this.pass_reg.Location = new System.Drawing.Point(65, 276);
            this.pass_reg.Name = "pass_reg";
            this.pass_reg.Size = new System.Drawing.Size(241, 20);
            this.pass_reg.TabIndex = 8;
            // 
            // email_reg
            // 
            this.email_reg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.email_reg.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.email_reg.ForeColor = System.Drawing.Color.Black;
            this.email_reg.Location = new System.Drawing.Point(66, 329);
            this.email_reg.Name = "email_reg";
            this.email_reg.Size = new System.Drawing.Size(241, 20);
            this.email_reg.TabIndex = 9;
            // 
            // label_empty_email
            // 
            this.label_empty_email.AutoSize = true;
            this.label_empty_email.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_empty_email.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_empty_email.ForeColor = System.Drawing.Color.DimGray;
            this.label_empty_email.Location = new System.Drawing.Point(64, 355);
            this.label_empty_email.Name = "label_empty_email";
            this.label_empty_email.Size = new System.Drawing.Size(222, 16);
            this.label_empty_email.TabIndex = 10;
            this.label_empty_email.Text = "нет почты или интернет соединения";
            this.label_empty_email.Click += new System.EventHandler(this.label4_Click);
            this.label_empty_email.MouseLeave += new System.EventHandler(this.label_empty_email_MouseLeave);
            this.label_empty_email.MouseHover += new System.EventHandler(this.label_empty_email_MouseHover);
            // 
            // registration
            // 
            this.registration.Active1 = System.Drawing.Color.AliceBlue;
            this.registration.Active2 = System.Drawing.Color.AliceBlue;
            this.registration.BackColor = System.Drawing.Color.Transparent;
            this.registration.Cursor = System.Windows.Forms.Cursors.Hand;
            this.registration.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.registration.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.registration.ForeColor = System.Drawing.Color.DarkBlue;
            this.registration.Inactive1 = System.Drawing.Color.Transparent;
            this.registration.Inactive2 = System.Drawing.Color.Transparent;
            this.registration.Location = new System.Drawing.Point(95, 409);
            this.registration.Name = "registration";
            this.registration.Radius = 18;
            this.registration.Size = new System.Drawing.Size(180, 35);
            this.registration.Stroke = true;
            this.registration.StrokeColor = System.Drawing.Color.DarkBlue;
            this.registration.TabIndex = 11;
            this.registration.Text = "зарегистрироваться";
            this.registration.Transparency = false;
            this.registration.Click += new System.EventHandler(this.registration_Click);
            // 
            // panel_reg
            // 
            this.panel_reg.BackColor = System.Drawing.Color.Transparent;
            this.panel_reg.Controls.Add(this.panel_back);
            this.panel_reg.Controls.Add(this.label_reg_login);
            this.panel_reg.Controls.Add(this.registration);
            this.panel_reg.Controls.Add(this.login_reg);
            this.panel_reg.Controls.Add(this.label_empty_email);
            this.panel_reg.Controls.Add(this.email_reg);
            this.panel_reg.Controls.Add(this.label_reg_password);
            this.panel_reg.Controls.Add(this.pass_reg);
            this.panel_reg.Controls.Add(this.label_reg_email);
            this.panel_reg.Controls.Add(this.backgr_reg);
            this.panel_reg.Location = new System.Drawing.Point(370, 0);
            this.panel_reg.Name = "panel_reg";
            this.panel_reg.Size = new System.Drawing.Size(370, 465);
            this.panel_reg.TabIndex = 12;
            // 
            // backgr_reg
            // 
            this.backgr_reg.BackColor = System.Drawing.Color.Transparent;
            this.backgr_reg.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.backgr_reg.Image = global::Upgrade.Properties.Resources.RegistrationForm;
            this.backgr_reg.Location = new System.Drawing.Point(0, 0);
            this.backgr_reg.Name = "backgr_reg";
            this.backgr_reg.Size = new System.Drawing.Size(370, 565);
            this.backgr_reg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.backgr_reg.TabIndex = 1;
            this.backgr_reg.TabStop = false;
            // 
            // login_auth
            // 
            this.login_auth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.login_auth.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_auth.ForeColor = System.Drawing.Color.Black;
            this.login_auth.Location = new System.Drawing.Point(65, 230);
            this.login_auth.Name = "login_auth";
            this.login_auth.Size = new System.Drawing.Size(241, 20);
            this.login_auth.TabIndex = 14;
            // 
            // label_auth_password
            // 
            this.label_auth_password.AutoSize = true;
            this.label_auth_password.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_auth_password.ForeColor = System.Drawing.Color.DarkBlue;
            this.label_auth_password.Location = new System.Drawing.Point(62, 262);
            this.label_auth_password.Name = "label_auth_password";
            this.label_auth_password.Size = new System.Drawing.Size(50, 16);
            this.label_auth_password.TabIndex = 15;
            this.label_auth_password.Text = "пароль";
            // 
            // authorization
            // 
            this.authorization.Active1 = System.Drawing.Color.LightSkyBlue;
            this.authorization.Active2 = System.Drawing.Color.LightSkyBlue;
            this.authorization.BackColor = System.Drawing.Color.Transparent;
            this.authorization.Cursor = System.Windows.Forms.Cursors.Hand;
            this.authorization.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.authorization.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.authorization.ForeColor = System.Drawing.Color.DarkBlue;
            this.authorization.Inactive1 = System.Drawing.Color.Transparent;
            this.authorization.Inactive2 = System.Drawing.Color.Transparent;
            this.authorization.Location = new System.Drawing.Point(135, 364);
            this.authorization.Name = "authorization";
            this.authorization.Radius = 18;
            this.authorization.Size = new System.Drawing.Size(100, 35);
            this.authorization.Stroke = true;
            this.authorization.StrokeColor = System.Drawing.Color.DarkBlue;
            this.authorization.TabIndex = 16;
            this.authorization.Text = "войти";
            this.authorization.Transparency = false;
            this.authorization.Click += new System.EventHandler(this.authorization_Click);
            // 
            // label_auth_login
            // 
            this.label_auth_login.AutoSize = true;
            this.label_auth_login.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_auth_login.ForeColor = System.Drawing.Color.DarkBlue;
            this.label_auth_login.Location = new System.Drawing.Point(62, 209);
            this.label_auth_login.Name = "label_auth_login";
            this.label_auth_login.Size = new System.Drawing.Size(74, 16);
            this.label_auth_login.TabIndex = 17;
            this.label_auth_login.Text = "псевдоним";
            this.label_auth_login.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pass_auth
            // 
            this.pass_auth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pass_auth.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pass_auth.ForeColor = System.Drawing.Color.Black;
            this.pass_auth.Location = new System.Drawing.Point(65, 284);
            this.pass_auth.Name = "pass_auth";
            this.pass_auth.Size = new System.Drawing.Size(241, 20);
            this.pass_auth.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("PF DinDisplay Pro", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(61, 421);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(126, 16);
            this.label7.TabIndex = 19;
            this.label7.Text = "У вас нет аккаунта?";
            // 
            // label_for_reg
            // 
            this.label_for_reg.AutoSize = true;
            this.label_for_reg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_for_reg.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_for_reg.ForeColor = System.Drawing.Color.DarkBlue;
            this.label_for_reg.Location = new System.Drawing.Point(182, 421);
            this.label_for_reg.Name = "label_for_reg";
            this.label_for_reg.Size = new System.Drawing.Size(130, 16);
            this.label_for_reg.TabIndex = 20;
            this.label_for_reg.Text = "Зарегистрироваться";
            this.label_for_reg.Click += new System.EventHandler(this.label8_Click);
            // 
            // panel_exit
            // 
            this.panel_exit.BackColor = System.Drawing.Color.DarkBlue;
            this.panel_exit.Controls.Add(this.exit);
            this.panel_exit.Location = new System.Drawing.Point(307, 10);
            this.panel_exit.Name = "panel_exit";
            this.panel_exit.Size = new System.Drawing.Size(51, 36);
            this.panel_exit.TabIndex = 3;
            // 
            // exit
            // 
            this.exit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.exit.Image = global::Upgrade.Properties.Resources.exit;
            this.exit.Location = new System.Drawing.Point(0, 0);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(51, 36);
            this.exit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.exit.TabIndex = 21;
            this.exit.TabStop = false;
            this.exit.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label_remember_me
            // 
            this.label_remember_me.AutoSize = true;
            this.label_remember_me.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_remember_me.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_remember_me.ForeColor = System.Drawing.Color.DimGray;
            this.label_remember_me.Location = new System.Drawing.Point(79, 313);
            this.label_remember_me.Name = "label_remember_me";
            this.label_remember_me.Size = new System.Drawing.Size(106, 16);
            this.label_remember_me.TabIndex = 21;
            this.label_remember_me.Text = "Запомнить меня";
            this.label_remember_me.Click += new System.EventHandler(this.label9_Click);
            this.label_remember_me.MouseLeave += new System.EventHandler(this.label_remember_me_MouseLeave);
            this.label_remember_me.MouseHover += new System.EventHandler(this.label_remember_me_MouseHover);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label10.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(218, 313);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "Забыл пароль";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label10.MouseLeave += new System.EventHandler(this.label10_MouseLeave);
            this.label10.MouseHover += new System.EventHandler(this.label10_MouseHover);
            // 
            // remember
            // 
            this.remember.AccessibleName = "off";
            this.remember.Cursor = System.Windows.Forms.Cursors.Hand;
            this.remember.Image = global::Upgrade.Properties.Resources.rem_0;
            this.remember.Location = new System.Drawing.Point(62, 311);
            this.remember.Name = "remember";
            this.remember.Size = new System.Drawing.Size(20, 20);
            this.remember.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.remember.TabIndex = 23;
            this.remember.TabStop = false;
            this.remember.Click += new System.EventHandler(this.remember_Click);
            // 
            // backgr_auth
            // 
            this.backgr_auth.Image = global::Upgrade.Properties.Resources.AutorizationForm;
            this.backgr_auth.Location = new System.Drawing.Point(0, 0);
            this.backgr_auth.Name = "backgr_auth";
            this.backgr_auth.Size = new System.Drawing.Size(370, 564);
            this.backgr_auth.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.backgr_auth.TabIndex = 13;
            this.backgr_auth.TabStop = false;
            // 
            // Reg_AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 565);
            this.Controls.Add(this.remember);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label_remember_me);
            this.Controls.Add(this.panel_exit);
            this.Controls.Add(this.label_for_reg);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pass_auth);
            this.Controls.Add(this.label_auth_login);
            this.Controls.Add(this.authorization);
            this.Controls.Add(this.label_auth_password);
            this.Controls.Add(this.login_auth);
            this.Controls.Add(this.panel_reg);
            this.Controls.Add(this.panel_chart);
            this.Controls.Add(this.backgr_auth);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reg_AuthForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.RegistrationForm_Shown);
            this.panel_chart.ResumeLayout(false);
            this.panel_chart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.panel_back.ResumeLayout(false);
            this.panel_back.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            this.panel_reg.ResumeLayout(false);
            this.panel_reg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.backgr_reg)).EndInit();
            this.panel_exit.ResumeLayout(false);
            this.panel_exit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.remember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgr_auth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox chart;
        private System.Windows.Forms.Panel panel_chart;
        private System.Windows.Forms.Label label_reg_login;
        private System.Windows.Forms.PictureBox backgr_reg;
        private System.Windows.Forms.Label label_reg_password;
        private System.Windows.Forms.Label label_reg_email;
        private System.Windows.Forms.Panel panel_back;
        private System.Windows.Forms.PictureBox back;
        private System.Windows.Forms.TextBox login_reg;
        private System.Windows.Forms.TextBox pass_reg;
        private System.Windows.Forms.TextBox email_reg;
        private System.Windows.Forms.Label label_empty_email;
        private AltoControls.AltoButton registration;
        private System.Windows.Forms.Panel panel_reg;
        private System.Windows.Forms.PictureBox backgr_auth;
        private System.Windows.Forms.TextBox login_auth;
        private System.Windows.Forms.Label label_auth_password;
        private AltoControls.AltoButton authorization;
        private System.Windows.Forms.Label label_auth_login;
        private System.Windows.Forms.TextBox pass_auth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label_for_reg;
        private System.Windows.Forms.Panel panel_exit;
        private System.Windows.Forms.PictureBox exit;
        private System.Windows.Forms.Label label_remember_me;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox remember;
    }
}

