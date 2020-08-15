namespace Upgrade.Classes.Blocks
{
    partial class AddDirectionForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.addDirection = new AltoControls.AltoButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.color_mark = new AltoControls.AltoButton();
            this.textBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Upgrade.Properties.Resources.AddDirection;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(461, 268);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::Upgrade.Properties.Resources.button_back;
            this.pictureBox2.Location = new System.Drawing.Point(31, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 17);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // addDirection
            // 
            this.addDirection.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addDirection.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addDirection.BackColor = System.Drawing.Color.White;
            this.addDirection.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addDirection.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addDirection.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.addDirection.ForeColor = System.Drawing.Color.Indigo;
            this.addDirection.Inactive1 = System.Drawing.Color.Transparent;
            this.addDirection.Inactive2 = System.Drawing.Color.Transparent;
            this.addDirection.Location = new System.Drawing.Point(325, 205);
            this.addDirection.Name = "addDirection";
            this.addDirection.Radius = 17;
            this.addDirection.Size = new System.Drawing.Size(100, 35);
            this.addDirection.Stroke = true;
            this.addDirection.StrokeColor = System.Drawing.Color.Indigo;
            this.addDirection.TabIndex = 4;
            this.addDirection.Text = "создать";
            this.addDirection.Transparency = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("PF DinDisplay Pro", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(28, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "направление";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("PF DinDisplay Pro", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(28, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "цвет метки";
            // 
            // color_mark
            // 
            this.color_mark.Active1 = System.Drawing.Color.Gainsboro;
            this.color_mark.Active2 = System.Drawing.Color.Gainsboro;
            this.color_mark.BackColor = System.Drawing.Color.White;
            this.color_mark.Cursor = System.Windows.Forms.Cursors.Hand;
            this.color_mark.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.color_mark.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.color_mark.ForeColor = System.Drawing.Color.Indigo;
            this.color_mark.Inactive1 = System.Drawing.Color.Gainsboro;
            this.color_mark.Inactive2 = System.Drawing.Color.Gainsboro;
            this.color_mark.Location = new System.Drawing.Point(31, 162);
            this.color_mark.Name = "color_mark";
            this.color_mark.Radius = 14;
            this.color_mark.Size = new System.Drawing.Size(90, 30);
            this.color_mark.Stroke = true;
            this.color_mark.StrokeColor = System.Drawing.Color.DarkGray;
            this.color_mark.TabIndex = 7;
            this.color_mark.Transparency = false;
            this.color_mark.Click += new System.EventHandler(this.color_mark_Click);
            // 
            // textBox
            // 
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.textBox.Location = new System.Drawing.Point(31, 104);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(394, 20);
            this.textBox.TabIndex = 8;
            this.textBox.Text = "направление";
            // 
            // AddDirectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 268);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.color_mark);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addDirection);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddDirectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddDirectionForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private AltoControls.AltoButton addDirection;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private AltoControls.AltoButton color_mark;
        private System.Windows.Forms.TextBox textBox;
    }
}