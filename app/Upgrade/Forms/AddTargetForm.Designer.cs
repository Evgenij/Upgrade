namespace Upgrade.Forms
{
    partial class AddTargetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTargetForm));
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.direction = new System.Windows.Forms.TextBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.addTarget = new AltoControls.AltoButton();
            this.prev = new System.Windows.Forms.PictureBox();
            this.next = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.prev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.next)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(236, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "направление";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(28, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "название";
            // 
            // direction
            // 
            this.direction.BackColor = System.Drawing.Color.White;
            this.direction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.direction.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.direction.Location = new System.Drawing.Point(239, 103);
            this.direction.Name = "direction";
            this.direction.ReadOnly = true;
            this.direction.Size = new System.Drawing.Size(144, 20);
            this.direction.TabIndex = 14;
            // 
            // textBox
            // 
            this.textBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.textBox.Location = new System.Drawing.Point(32, 103);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(190, 20);
            this.textBox.TabIndex = 13;
            // 
            // addTarget
            // 
            this.addTarget.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addTarget.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addTarget.BackColor = System.Drawing.Color.White;
            this.addTarget.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addTarget.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addTarget.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.addTarget.ForeColor = System.Drawing.Color.Indigo;
            this.addTarget.Inactive1 = System.Drawing.Color.Transparent;
            this.addTarget.Inactive2 = System.Drawing.Color.Transparent;
            this.addTarget.Location = new System.Drawing.Point(325, 202);
            this.addTarget.Name = "addTarget";
            this.addTarget.Radius = 17;
            this.addTarget.Size = new System.Drawing.Size(100, 35);
            this.addTarget.Stroke = true;
            this.addTarget.StrokeColor = System.Drawing.Color.Indigo;
            this.addTarget.TabIndex = 17;
            this.addTarget.Text = "создать";
            this.addTarget.Transparency = false;
            this.addTarget.Click += new System.EventHandler(this.addTarget_Click);
            // 
            // prev
            // 
            this.prev.BackColor = System.Drawing.Color.White;
            this.prev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.prev.Image = global::Upgrade.Properties.Resources.prev_off;
            this.prev.Location = new System.Drawing.Point(389, 102);
            this.prev.Name = "prev";
            this.prev.Size = new System.Drawing.Size(17, 23);
            this.prev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.prev.TabIndex = 16;
            this.prev.TabStop = false;
            this.prev.Click += new System.EventHandler(this.prev_Click);
            this.prev.MouseLeave += new System.EventHandler(this.pictureBox4_MouseLeave);
            this.prev.MouseHover += new System.EventHandler(this.pictureBox4_MouseHover);
            // 
            // next
            // 
            this.next.BackColor = System.Drawing.Color.White;
            this.next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.next.Image = global::Upgrade.Properties.Resources.next_off;
            this.next.Location = new System.Drawing.Point(408, 102);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(17, 23);
            this.next.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.next.TabIndex = 15;
            this.next.TabStop = false;
            this.next.Click += new System.EventHandler(this.next_Click);
            this.next.MouseLeave += new System.EventHandler(this.pictureBox3_MouseLeave);
            this.next.MouseHover += new System.EventHandler(this.pictureBox3_MouseHover);
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
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Upgrade.Properties.Resources.Add_target;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(461, 268);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // AddTargetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 268);
            this.Controls.Add(this.addTarget);
            this.Controls.Add(this.prev);
            this.Controls.Add(this.next);
            this.Controls.Add(this.direction);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddTargetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddTargetForm";
            ((System.ComponentModel.ISupportInitialize)(this.prev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.next)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox prev;
        private System.Windows.Forms.PictureBox next;
        private System.Windows.Forms.TextBox direction;
        private System.Windows.Forms.TextBox textBox;
        private AltoControls.AltoButton addTarget;
    }
}