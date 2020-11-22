namespace Upgrade.Forms
{
    partial class AddDataServiceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddDataServiceForm));
            this.flowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addServiceDataButton = new AltoControls.AltoButton();
            this.login = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.em_phone = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelIcon = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // flowPanel
            // 
            this.flowPanel.AutoScroll = true;
            this.flowPanel.BackColor = System.Drawing.Color.White;
            this.flowPanel.Location = new System.Drawing.Point(35, 120);
            this.flowPanel.Name = "flowPanel";
            this.flowPanel.Size = new System.Drawing.Size(285, 125);
            this.flowPanel.TabIndex = 3;
            // 
            // addServiceDataButton
            // 
            this.addServiceDataButton.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addServiceDataButton.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addServiceDataButton.BackColor = System.Drawing.Color.White;
            this.addServiceDataButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addServiceDataButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addServiceDataButton.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.addServiceDataButton.ForeColor = System.Drawing.Color.Indigo;
            this.addServiceDataButton.Inactive1 = System.Drawing.Color.Transparent;
            this.addServiceDataButton.Inactive2 = System.Drawing.Color.Transparent;
            this.addServiceDataButton.Location = new System.Drawing.Point(410, 330);
            this.addServiceDataButton.Name = "addServiceDataButton";
            this.addServiceDataButton.Radius = 17;
            this.addServiceDataButton.Size = new System.Drawing.Size(100, 35);
            this.addServiceDataButton.Stroke = true;
            this.addServiceDataButton.StrokeColor = System.Drawing.Color.Indigo;
            this.addServiceDataButton.TabIndex = 15;
            this.addServiceDataButton.Text = "создать";
            this.addServiceDataButton.Transparency = false;
            this.addServiceDataButton.Click += new System.EventHandler(this.addTaskButton_Click);
            // 
            // login
            // 
            this.login.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.login.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.login.ForeColor = System.Drawing.Color.DarkGray;
            this.login.Location = new System.Drawing.Point(336, 127);
            this.login.Multiline = true;
            this.login.Name = "login";
            this.login.Size = new System.Drawing.Size(179, 21);
            this.login.TabIndex = 17;
            this.login.Text = "введите логин";
            this.login.Enter += new System.EventHandler(this.textBox_Enter);
            this.login.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // password
            // 
            this.password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.password.ForeColor = System.Drawing.Color.DarkGray;
            this.password.Location = new System.Drawing.Point(336, 168);
            this.password.Multiline = true;
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(179, 21);
            this.password.TabIndex = 18;
            this.password.Text = "введите пароль";
            this.password.Enter += new System.EventHandler(this.textBox_Enter);
            this.password.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // em_phone
            // 
            this.em_phone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.em_phone.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.em_phone.ForeColor = System.Drawing.Color.DarkGray;
            this.em_phone.Location = new System.Drawing.Point(336, 209);
            this.em_phone.Multiline = true;
            this.em_phone.Name = "em_phone";
            this.em_phone.Size = new System.Drawing.Size(179, 21);
            this.em_phone.TabIndex = 19;
            this.em_phone.Text = "введите тел. или email";
            this.em_phone.Enter += new System.EventHandler(this.textBox_Enter);
            this.em_phone.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(28, 28);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 17);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 16;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(544, 396);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // labelIcon
            // 
            this.labelIcon.AutoSize = true;
            this.labelIcon.BackColor = System.Drawing.Color.White;
            this.labelIcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelIcon.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.labelIcon.ForeColor = System.Drawing.Color.Gray;
            this.labelIcon.Location = new System.Drawing.Point(35, 255);
            this.labelIcon.Name = "labelIcon";
            this.labelIcon.Size = new System.Drawing.Size(109, 17);
            this.labelIcon.TabIndex = 21;
            this.labelIcon.Text = "добавить иконку";
            this.labelIcon.Click += new System.EventHandler(this.labelIcon_Click);
            this.labelIcon.MouseLeave += new System.EventHandler(this.labelIcon_MouseLeave);
            this.labelIcon.MouseHover += new System.EventHandler(this.labelIcon_MouseHover);
            // 
            // AddDataServiceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 396);
            this.Controls.Add(this.labelIcon);
            this.Controls.Add(this.em_phone);
            this.Controls.Add(this.password);
            this.Controls.Add(this.login);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.addServiceDataButton);
            this.Controls.Add(this.flowPanel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddDataServiceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddServiceData";
            this.Load += new System.EventHandler(this.AddDataService_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowPanel;
        private AltoControls.AltoButton addServiceDataButton;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TextBox login;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.TextBox em_phone;
        private System.Windows.Forms.Label labelIcon;
    }
}