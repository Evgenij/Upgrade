namespace Upgrade
{
    partial class RegistrationForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel_back = new System.Windows.Forms.Panel();
            this.back = new System.Windows.Forms.PictureBox();
            this.login = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.background = new System.Windows.Forms.PictureBox();
            this.altoButton1 = new AltoControls.AltoButton();
            this.panel_chart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.panel_back.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).BeginInit();
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
            this.chart.Click += new System.EventHandler(this.chart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(62, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "псевдоним";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(62, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(62, 306);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "электронная почта";
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
            // login
            // 
            this.login.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.login.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login.ForeColor = System.Drawing.Color.Black;
            this.login.Location = new System.Drawing.Point(65, 221);
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(242, 20);
            this.login.TabIndex = 7;
            this.login.Text = "Мыхайло";
            // 
            // password
            // 
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.password.ForeColor = System.Drawing.Color.Black;
            this.password.Location = new System.Drawing.Point(66, 275);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(241, 20);
            this.password.TabIndex = 8;
            this.password.Text = "пароль";
            // 
            // email
            // 
            this.email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.email.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.email.ForeColor = System.Drawing.Color.Black;
            this.email.Location = new System.Drawing.Point(66, 329);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(241, 20);
            this.email.TabIndex = 9;
            this.email.Text = "email@list.ru";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(62, 356);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "нет почты или интернет соединения";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // background
            // 
            this.background.BackColor = System.Drawing.Color.Transparent;
            this.background.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.background.Image = global::Upgrade.Properties.Resources.RegistrationForm;
            this.background.Location = new System.Drawing.Point(0, 0);
            this.background.Name = "background";
            this.background.Size = new System.Drawing.Size(370, 565);
            this.background.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.background.TabIndex = 1;
            this.background.TabStop = false;
            // 
            // altoButton1
            // 
            this.altoButton1.Active1 = System.Drawing.Color.WhiteSmoke;
            this.altoButton1.Active2 = System.Drawing.Color.WhiteSmoke;
            this.altoButton1.BackColor = System.Drawing.Color.Transparent;
            this.altoButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.altoButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.altoButton1.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 10F);
            this.altoButton1.ForeColor = System.Drawing.Color.DarkBlue;
            this.altoButton1.Inactive1 = System.Drawing.Color.Transparent;
            this.altoButton1.Inactive2 = System.Drawing.Color.Transparent;
            this.altoButton1.Location = new System.Drawing.Point(96, 403);
            this.altoButton1.Name = "altoButton1";
            this.altoButton1.Radius = 18;
            this.altoButton1.Size = new System.Drawing.Size(188, 35);
            this.altoButton1.Stroke = true;
            this.altoButton1.StrokeColor = System.Drawing.Color.DarkBlue;
            this.altoButton1.TabIndex = 11;
            this.altoButton1.Text = "зарегистрироваться";
            this.altoButton1.Transparency = false;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 565);
            this.Controls.Add(this.altoButton1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.email);
            this.Controls.Add(this.password);
            this.Controls.Add(this.login);
            this.Controls.Add(this.panel_back);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel_chart);
            this.Controls.Add(this.background);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panel_chart.ResumeLayout(false);
            this.panel_chart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.panel_back.ResumeLayout(false);
            this.panel_back.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.background)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox chart;
        private System.Windows.Forms.Panel panel_chart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox background;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel_back;
        private System.Windows.Forms.PictureBox back;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label4;
        private AltoControls.AltoButton altoButton1;
    }
}

