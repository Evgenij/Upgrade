namespace Upgrade.Classes
{
    partial class MainWorkingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWorkingForm));
            this.panel_menu = new System.Windows.Forms.Panel();
            this.active_item = new System.Windows.Forms.PictureBox();
            this.settings = new System.Windows.Forms.PictureBox();
            this.schedule = new System.Windows.Forms.PictureBox();
            this.stat = new System.Windows.Forms.PictureBox();
            this.targets = new System.Windows.Forms.PictureBox();
            this.profile = new System.Windows.Forms.PictureBox();
            this.picture_menu = new System.Windows.Forms.PictureBox();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tab_profile = new System.Windows.Forms.TabPage();
            this.flowTasks = new System.Windows.Forms.FlowLayoutPanel();
            this.tab_targets = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tab_stat = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.tab_sched = new System.Windows.Forms.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.tab_sett = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.nLabelControl1 = new Nevron.Nov.WinFormControls.NLabelControl();
            this.panel_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.active_item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.settings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.targets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.profile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_menu)).BeginInit();
            this.tabs.SuspendLayout();
            this.tab_profile.SuspendLayout();
            this.tab_targets.SuspendLayout();
            this.tab_stat.SuspendLayout();
            this.tab_sched.SuspendLayout();
            this.tab_sett.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_menu
            // 
            this.panel_menu.BackColor = System.Drawing.Color.Green;
            this.panel_menu.Controls.Add(this.active_item);
            this.panel_menu.Controls.Add(this.settings);
            this.panel_menu.Controls.Add(this.schedule);
            this.panel_menu.Controls.Add(this.stat);
            this.panel_menu.Controls.Add(this.targets);
            this.panel_menu.Controls.Add(this.profile);
            this.panel_menu.Controls.Add(this.picture_menu);
            this.panel_menu.Location = new System.Drawing.Point(10, 10);
            this.panel_menu.Name = "panel_menu";
            this.panel_menu.Size = new System.Drawing.Size(70, 748);
            this.panel_menu.TabIndex = 2;
            // 
            // active_item
            // 
            this.active_item.AccessibleName = "profile";
            this.active_item.BackColor = System.Drawing.Color.Transparent;
            this.active_item.Image = global::Upgrade.Properties.Resources.profile;
            this.active_item.Location = new System.Drawing.Point(6, 100);
            this.active_item.Name = "active_item";
            this.active_item.Size = new System.Drawing.Size(90, 90);
            this.active_item.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.active_item.TabIndex = 8;
            this.active_item.TabStop = false;
            // 
            // settings
            // 
            this.settings.BackColor = System.Drawing.Color.Transparent;
            this.settings.Cursor = System.Windows.Forms.Cursors.Hand;
            this.settings.Image = global::Upgrade.Properties.Resources.settings_icon;
            this.settings.Location = new System.Drawing.Point(20, 372);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(28, 28);
            this.settings.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.settings.TabIndex = 12;
            this.settings.TabStop = false;
            this.settings.Click += new System.EventHandler(this.settings_Click);
            // 
            // schedule
            // 
            this.schedule.BackColor = System.Drawing.Color.Transparent;
            this.schedule.Cursor = System.Windows.Forms.Cursors.Hand;
            this.schedule.Image = global::Upgrade.Properties.Resources.schedule_icon;
            this.schedule.Location = new System.Drawing.Point(21, 314);
            this.schedule.Name = "schedule";
            this.schedule.Size = new System.Drawing.Size(26, 22);
            this.schedule.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.schedule.TabIndex = 11;
            this.schedule.TabStop = false;
            this.schedule.Click += new System.EventHandler(this.schedule_Click);
            // 
            // stat
            // 
            this.stat.BackColor = System.Drawing.Color.Transparent;
            this.stat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.stat.Image = global::Upgrade.Properties.Resources.stat_icon;
            this.stat.Location = new System.Drawing.Point(21, 253);
            this.stat.Name = "stat";
            this.stat.Size = new System.Drawing.Size(26, 23);
            this.stat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.stat.TabIndex = 10;
            this.stat.TabStop = false;
            this.stat.Click += new System.EventHandler(this.stat_Click);
            // 
            // targets
            // 
            this.targets.BackColor = System.Drawing.Color.Transparent;
            this.targets.Cursor = System.Windows.Forms.Cursors.Hand;
            this.targets.Image = global::Upgrade.Properties.Resources.tardets_icon;
            this.targets.Location = new System.Drawing.Point(21, 192);
            this.targets.Name = "targets";
            this.targets.Size = new System.Drawing.Size(26, 26);
            this.targets.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.targets.TabIndex = 9;
            this.targets.TabStop = false;
            this.targets.Click += new System.EventHandler(this.targets_Click);
            // 
            // profile
            // 
            this.profile.BackColor = System.Drawing.Color.Transparent;
            this.profile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.profile.Image = ((System.Drawing.Image)(resources.GetObject("profile.Image")));
            this.profile.Location = new System.Drawing.Point(22, 133);
            this.profile.Name = "profile";
            this.profile.Size = new System.Drawing.Size(26, 23);
            this.profile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.profile.TabIndex = 6;
            this.profile.TabStop = false;
            this.profile.Click += new System.EventHandler(this.profile_Click);
            // 
            // picture_menu
            // 
            this.picture_menu.BackColor = System.Drawing.Color.Transparent;
            this.picture_menu.Image = global::Upgrade.Properties.Resources.menu_panel;
            this.picture_menu.Location = new System.Drawing.Point(0, 0);
            this.picture_menu.Name = "picture_menu";
            this.picture_menu.Size = new System.Drawing.Size(70, 748);
            this.picture_menu.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picture_menu.TabIndex = 1;
            this.picture_menu.TabStop = false;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tab_profile);
            this.tabs.Controls.Add(this.tab_targets);
            this.tabs.Controls.Add(this.tab_stat);
            this.tabs.Controls.Add(this.tab_sched);
            this.tabs.Controls.Add(this.tab_sett);
            this.tabs.ItemSize = new System.Drawing.Size(0, 1);
            this.tabs.Location = new System.Drawing.Point(-4, -5);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1375, 780);
            this.tabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabs.TabIndex = 3;
            this.tabs.TabStop = false;
            // 
            // tab_profile
            // 
            this.tab_profile.Controls.Add(this.nLabelControl1);
            this.tab_profile.Controls.Add(this.flowTasks);
            this.tab_profile.Location = new System.Drawing.Point(4, 5);
            this.tab_profile.Name = "tab_profile";
            this.tab_profile.Padding = new System.Windows.Forms.Padding(3);
            this.tab_profile.Size = new System.Drawing.Size(1367, 771);
            this.tab_profile.TabIndex = 0;
            this.tab_profile.Text = "tabPage1";
            this.tab_profile.UseVisualStyleBackColor = true;
            // 
            // flowTasks
            // 
            this.flowTasks.AutoScroll = true;
            this.flowTasks.Location = new System.Drawing.Point(113, 57);
            this.flowTasks.Name = "flowTasks";
            this.flowTasks.Size = new System.Drawing.Size(485, 249);
            this.flowTasks.TabIndex = 0;
            // 
            // tab_targets
            // 
            this.tab_targets.Controls.Add(this.label2);
            this.tab_targets.Location = new System.Drawing.Point(4, 5);
            this.tab_targets.Name = "tab_targets";
            this.tab_targets.Padding = new System.Windows.Forms.Padding(3);
            this.tab_targets.Size = new System.Drawing.Size(1367, 771);
            this.tab_targets.TabIndex = 1;
            this.tab_targets.Text = "tabPage2";
            this.tab_targets.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "targets";
            // 
            // tab_stat
            // 
            this.tab_stat.Controls.Add(this.label3);
            this.tab_stat.Location = new System.Drawing.Point(4, 5);
            this.tab_stat.Name = "tab_stat";
            this.tab_stat.Size = new System.Drawing.Size(1367, 771);
            this.tab_stat.TabIndex = 2;
            this.tab_stat.Text = "tabPage1";
            this.tab_stat.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(105, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "stat";
            // 
            // tab_sched
            // 
            this.tab_sched.Controls.Add(this.label4);
            this.tab_sched.Location = new System.Drawing.Point(4, 5);
            this.tab_sched.Name = "tab_sched";
            this.tab_sched.Size = new System.Drawing.Size(1367, 771);
            this.tab_sched.TabIndex = 3;
            this.tab_sched.Text = "tabPage2";
            this.tab_sched.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(112, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "sched";
            // 
            // tab_sett
            // 
            this.tab_sett.Controls.Add(this.label5);
            this.tab_sett.Location = new System.Drawing.Point(4, 5);
            this.tab_sett.Name = "tab_sett";
            this.tab_sett.Size = new System.Drawing.Size(1367, 771);
            this.tab_sett.TabIndex = 4;
            this.tab_sett.Text = "tabPage3";
            this.tab_sett.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(106, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "settings";
            // 
            // pictureBox1
            // 
            this.pictureBox1.AccessibleName = "profile";
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Upgrade.Properties.Resources.panel_profile;
            this.pictureBox1.Location = new System.Drawing.Point(1006, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(348, 748);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // nLabelControl1
            // 
            this.nLabelControl1.AutoSize = false;
            this.nLabelControl1.DesignTimeState = resources.GetString("nLabelControl1.DesignTimeState");
            this.nLabelControl1.Location = new System.Drawing.Point(716, 240);
            this.nLabelControl1.Name = "nLabelControl1";
            this.nLabelControl1.Size = new System.Drawing.Size(75, 23);
            this.nLabelControl1.TabIndex = 1;
            // 
            // MainWorkingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 768);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel_menu);
            this.Controls.Add(this.tabs);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainWorkingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainWorkingForm";
            this.panel_menu.ResumeLayout(false);
            this.panel_menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.active_item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.settings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.targets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.profile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_menu)).EndInit();
            this.tabs.ResumeLayout(false);
            this.tab_profile.ResumeLayout(false);
            this.tab_targets.ResumeLayout(false);
            this.tab_targets.PerformLayout();
            this.tab_stat.ResumeLayout(false);
            this.tab_stat.PerformLayout();
            this.tab_sched.ResumeLayout(false);
            this.tab_sched.PerformLayout();
            this.tab_sett.ResumeLayout(false);
            this.tab_sett.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox picture_menu;
        private System.Windows.Forms.Panel panel_menu;
        private System.Windows.Forms.PictureBox profile;
        private System.Windows.Forms.PictureBox active_item;
        private System.Windows.Forms.PictureBox targets;
        private System.Windows.Forms.PictureBox stat;
        private System.Windows.Forms.PictureBox schedule;
        private System.Windows.Forms.PictureBox settings;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tab_profile;
        private System.Windows.Forms.TabPage tab_targets;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage tab_stat;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage tab_sched;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tab_sett;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel flowTasks;
        private Nevron.Nov.WinFormControls.NLabelControl nLabelControl1;
    }
}