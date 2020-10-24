namespace Upgrade.Forms
{
    partial class AddTaskForm
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
            this.task_name = new System.Windows.Forms.TextBox();
            this.addTaskButton = new AltoControls.AltoButton();
            this.dateTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.taskStartHour = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.task_descr = new System.Windows.Forms.TextBox();
            this.flowPanelSubtasks = new System.Windows.Forms.FlowLayoutPanel();
            this.flowPanelDays = new System.Windows.Forms.FlowLayoutPanel();
            this.day1 = new System.Windows.Forms.PictureBox();
            this.day5 = new System.Windows.Forms.PictureBox();
            this.day2 = new System.Windows.Forms.PictureBox();
            this.day6 = new System.Windows.Forms.PictureBox();
            this.day3 = new System.Windows.Forms.PictureBox();
            this.day7 = new System.Windows.Forms.PictureBox();
            this.day4 = new System.Windows.Forms.PictureBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.taskStartMinute = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.taskEndHour = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.taskEndMinute = new System.Windows.Forms.TextBox();
            this.prev = new System.Windows.Forms.PictureBox();
            this.next = new System.Windows.Forms.PictureBox();
            this.target = new System.Windows.Forms.TextBox();
            this.buttonAddSubtask = new System.Windows.Forms.Label();
            this.taskHour = new System.Windows.Forms.Label();
            this.taskMinute = new System.Windows.Forms.Label();
            this.sched_name = new System.Windows.Forms.TextBox();
            this.flowPanelDays.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.day1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.day5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.day2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.day6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.day3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.day7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.day4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.next)).BeginInit();
            this.SuspendLayout();
            // 
            // task_name
            // 
            this.task_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.task_name.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.task_name.ForeColor = System.Drawing.Color.DarkGray;
            this.task_name.Location = new System.Drawing.Point(65, 161);
            this.task_name.Multiline = true;
            this.task_name.Name = "task_name";
            this.task_name.Size = new System.Drawing.Size(236, 37);
            this.task_name.TabIndex = 16;
            this.task_name.Text = "введите текст задачи";
            this.task_name.Enter += new System.EventHandler(this.textBox_Enter);
            this.task_name.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // addTaskButton
            // 
            this.addTaskButton.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addTaskButton.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.addTaskButton.BackColor = System.Drawing.Color.White;
            this.addTaskButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addTaskButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.addTaskButton.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.addTaskButton.ForeColor = System.Drawing.Color.Indigo;
            this.addTaskButton.Inactive1 = System.Drawing.Color.Transparent;
            this.addTaskButton.Inactive2 = System.Drawing.Color.Transparent;
            this.addTaskButton.Location = new System.Drawing.Point(673, 477);
            this.addTaskButton.Name = "addTaskButton";
            this.addTaskButton.Radius = 17;
            this.addTaskButton.Size = new System.Drawing.Size(100, 35);
            this.addTaskButton.Stroke = true;
            this.addTaskButton.StrokeColor = System.Drawing.Color.Indigo;
            this.addTaskButton.TabIndex = 14;
            this.addTaskButton.Text = "создать";
            this.addTaskButton.Transparency = false;
            this.addTaskButton.Click += new System.EventHandler(this.addTaskButton_Click);
            // 
            // dateTime
            // 
            this.dateTime.CalendarTrailingForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dateTime.CustomFormat = "dd.MM.yyyy dddd";
            this.dateTime.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.dateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTime.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.dateTime.Location = new System.Drawing.Point(468, 174);
            this.dateTime.Name = "dateTime";
            this.dateTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTime.RightToLeftLayout = true;
            this.dateTime.Size = new System.Drawing.Size(182, 25);
            this.dateTime.TabIndex = 141;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarTrailingForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dateTimePicker2.CustomFormat = "dd.MM.yyyy dddd";
            this.dateTimePicker2.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.ImeMode = System.Windows.Forms.ImeMode.KatakanaHalf;
            this.dateTimePicker2.Location = new System.Drawing.Point(209, -550);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateTimePicker2.RightToLeftLayout = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(341, 25);
            this.dateTimePicker2.TabIndex = 143;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(468, 171);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(181, 5);
            this.panel3.TabIndex = 142;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(468, 197);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(181, 5);
            this.panel1.TabIndex = 143;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(460, 171);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 31);
            this.panel2.TabIndex = 144;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Location = new System.Drawing.Point(647, 171);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(10, 31);
            this.panel4.TabIndex = 145;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(557, 226);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(10, 37);
            this.textBox3.TabIndex = 147;
            this.textBox3.Text = ":";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // taskStartHour
            // 
            this.taskStartHour.BackColor = System.Drawing.Color.White;
            this.taskStartHour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.taskStartHour.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.taskStartHour.ForeColor = System.Drawing.Color.Gray;
            this.taskStartHour.Location = new System.Drawing.Point(506, 261);
            this.taskStartHour.Name = "taskStartHour";
            this.taskStartHour.ReadOnly = true;
            this.taskStartHour.Size = new System.Drawing.Size(22, 20);
            this.taskStartHour.TabIndex = 149;
            this.taskStartHour.Text = "00";
            this.taskStartHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.taskStartHour.TextChanged += new System.EventHandler(this.taskStartHour_TextChanged);
            // 
            // textBox6
            // 
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.textBox6.ForeColor = System.Drawing.Color.Gray;
            this.textBox6.Location = new System.Drawing.Point(552, 261);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(20, 20);
            this.textBox6.TabIndex = 150;
            this.textBox6.Text = "по";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox8
            // 
            this.textBox8.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox8.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.textBox8.ForeColor = System.Drawing.Color.Gray;
            this.textBox8.Location = new System.Drawing.Point(498, 261);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(10, 20);
            this.textBox8.TabIndex = 152;
            this.textBox8.Text = "с";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // task_descr
            // 
            this.task_descr.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.task_descr.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.task_descr.ForeColor = System.Drawing.Color.DarkGray;
            this.task_descr.Location = new System.Drawing.Point(65, 224);
            this.task_descr.Multiline = true;
            this.task_descr.Name = "task_descr";
            this.task_descr.Size = new System.Drawing.Size(229, 37);
            this.task_descr.TabIndex = 153;
            this.task_descr.Text = "введите описание задачи";
            this.task_descr.Enter += new System.EventHandler(this.textBox_Enter);
            this.task_descr.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // flowPanelSubtasks
            // 
            this.flowPanelSubtasks.AutoScroll = true;
            this.flowPanelSubtasks.BackColor = System.Drawing.Color.White;
            this.flowPanelSubtasks.Location = new System.Drawing.Point(66, 290);
            this.flowPanelSubtasks.Name = "flowPanelSubtasks";
            this.flowPanelSubtasks.Size = new System.Drawing.Size(249, 91);
            this.flowPanelSubtasks.TabIndex = 155;
            // 
            // flowPanelDays
            // 
            this.flowPanelDays.BackColor = System.Drawing.Color.White;
            this.flowPanelDays.Controls.Add(this.day1);
            this.flowPanelDays.Controls.Add(this.day5);
            this.flowPanelDays.Controls.Add(this.day2);
            this.flowPanelDays.Controls.Add(this.day6);
            this.flowPanelDays.Controls.Add(this.day3);
            this.flowPanelDays.Controls.Add(this.day7);
            this.flowPanelDays.Controls.Add(this.day4);
            this.flowPanelDays.Enabled = false;
            this.flowPanelDays.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowPanelDays.Location = new System.Drawing.Point(62, 444);
            this.flowPanelDays.Name = "flowPanelDays";
            this.flowPanelDays.Size = new System.Drawing.Size(235, 74);
            this.flowPanelDays.TabIndex = 156;
            // 
            // day1
            // 
            this.day1.BackColor = System.Drawing.Color.White;
            this.day1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.day1.Image = global::Upgrade.Properties.Resources.box_monday_off;
            this.day1.Location = new System.Drawing.Point(3, 3);
            this.day1.Name = "day1";
            this.day1.Size = new System.Drawing.Size(48, 28);
            this.day1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.day1.TabIndex = 157;
            this.day1.TabStop = false;
            this.day1.Click += new System.EventHandler(this.day1_Click);
            // 
            // day5
            // 
            this.day5.BackColor = System.Drawing.Color.White;
            this.day5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.day5.Image = global::Upgrade.Properties.Resources.box_friday_off;
            this.day5.Location = new System.Drawing.Point(3, 37);
            this.day5.Name = "day5";
            this.day5.Size = new System.Drawing.Size(49, 28);
            this.day5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.day5.TabIndex = 164;
            this.day5.TabStop = false;
            this.day5.Click += new System.EventHandler(this.day5_Click);
            // 
            // day2
            // 
            this.day2.BackColor = System.Drawing.Color.White;
            this.day2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.day2.Image = global::Upgrade.Properties.Resources.box_tuesday_off;
            this.day2.Location = new System.Drawing.Point(58, 3);
            this.day2.Name = "day2";
            this.day2.Size = new System.Drawing.Size(48, 28);
            this.day2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.day2.TabIndex = 159;
            this.day2.TabStop = false;
            this.day2.Click += new System.EventHandler(this.day2_Click);
            // 
            // day6
            // 
            this.day6.BackColor = System.Drawing.Color.White;
            this.day6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.day6.Image = global::Upgrade.Properties.Resources.box_saturday_off;
            this.day6.Location = new System.Drawing.Point(58, 37);
            this.day6.Name = "day6";
            this.day6.Size = new System.Drawing.Size(49, 28);
            this.day6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.day6.TabIndex = 160;
            this.day6.TabStop = false;
            this.day6.Click += new System.EventHandler(this.day6_Click);
            // 
            // day3
            // 
            this.day3.BackColor = System.Drawing.Color.White;
            this.day3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.day3.Image = global::Upgrade.Properties.Resources.box_wednesday_off;
            this.day3.Location = new System.Drawing.Point(113, 3);
            this.day3.Name = "day3";
            this.day3.Size = new System.Drawing.Size(48, 28);
            this.day3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.day3.TabIndex = 161;
            this.day3.TabStop = false;
            this.day3.Click += new System.EventHandler(this.day3_Click);
            // 
            // day7
            // 
            this.day7.BackColor = System.Drawing.Color.White;
            this.day7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.day7.Image = global::Upgrade.Properties.Resources.box_sunday_off;
            this.day7.Location = new System.Drawing.Point(113, 37);
            this.day7.Name = "day7";
            this.day7.Size = new System.Drawing.Size(49, 28);
            this.day7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.day7.TabIndex = 162;
            this.day7.TabStop = false;
            this.day7.Click += new System.EventHandler(this.day7_Click);
            // 
            // day4
            // 
            this.day4.BackColor = System.Drawing.Color.White;
            this.day4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.day4.Image = global::Upgrade.Properties.Resources.box_thursday_off;
            this.day4.Location = new System.Drawing.Point(168, 3);
            this.day4.Name = "day4";
            this.day4.Size = new System.Drawing.Size(48, 28);
            this.day4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.day4.TabIndex = 163;
            this.day4.TabStop = false;
            this.day4.Click += new System.EventHandler(this.day4_Click);
            // 
            // textBox10
            // 
            this.textBox10.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox10.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.textBox10.ForeColor = System.Drawing.Color.Gray;
            this.textBox10.Location = new System.Drawing.Point(529, 261);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(3, 20);
            this.textBox10.TabIndex = 157;
            this.textBox10.Text = ":";
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // taskStartMinute
            // 
            this.taskStartMinute.BackColor = System.Drawing.Color.White;
            this.taskStartMinute.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.taskStartMinute.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.taskStartMinute.ForeColor = System.Drawing.Color.Gray;
            this.taskStartMinute.Location = new System.Drawing.Point(534, 261);
            this.taskStartMinute.Name = "taskStartMinute";
            this.taskStartMinute.ReadOnly = true;
            this.taskStartMinute.Size = new System.Drawing.Size(20, 20);
            this.taskStartMinute.TabIndex = 158;
            this.taskStartMinute.Text = "00";
            this.taskStartMinute.TextChanged += new System.EventHandler(this.taskStartMinute_TextChanged);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.White;
            this.pictureBox3.Image = global::Upgrade.Properties.Resources.label_schedule;
            this.pictureBox3.Location = new System.Drawing.Point(32, 390);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(109, 20);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox3.TabIndex = 156;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::Upgrade.Properties.Resources.button_back;
            this.pictureBox2.Location = new System.Drawing.Point(32, 26);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(49, 17);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Upgrade.Properties.Resources.AddTask;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(820, 550);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // taskEndHour
            // 
            this.taskEndHour.BackColor = System.Drawing.Color.White;
            this.taskEndHour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.taskEndHour.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.taskEndHour.ForeColor = System.Drawing.Color.Gray;
            this.taskEndHour.Location = new System.Drawing.Point(571, 261);
            this.taskEndHour.Name = "taskEndHour";
            this.taskEndHour.ReadOnly = true;
            this.taskEndHour.Size = new System.Drawing.Size(20, 20);
            this.taskEndHour.TabIndex = 159;
            this.taskEndHour.Text = "00";
            this.taskEndHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox7
            // 
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox7.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.textBox7.ForeColor = System.Drawing.Color.Gray;
            this.textBox7.Location = new System.Drawing.Point(592, 261);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(3, 20);
            this.textBox7.TabIndex = 160;
            this.textBox7.Text = ":";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // taskEndMinute
            // 
            this.taskEndMinute.BackColor = System.Drawing.Color.White;
            this.taskEndMinute.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.taskEndMinute.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.taskEndMinute.ForeColor = System.Drawing.Color.Gray;
            this.taskEndMinute.Location = new System.Drawing.Point(597, 261);
            this.taskEndMinute.Name = "taskEndMinute";
            this.taskEndMinute.ReadOnly = true;
            this.taskEndMinute.Size = new System.Drawing.Size(20, 20);
            this.taskEndMinute.TabIndex = 161;
            this.taskEndMinute.Text = "00";
            // 
            // prev
            // 
            this.prev.BackColor = System.Drawing.Color.White;
            this.prev.Cursor = System.Windows.Forms.Cursors.Hand;
            this.prev.Image = global::Upgrade.Properties.Resources.prev_off;
            this.prev.Location = new System.Drawing.Point(265, 99);
            this.prev.Name = "prev";
            this.prev.Size = new System.Drawing.Size(17, 23);
            this.prev.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.prev.TabIndex = 163;
            this.prev.TabStop = false;
            this.prev.Click += new System.EventHandler(this.prev_Click);
            this.prev.MouseLeave += new System.EventHandler(this.prev_MouseLeave);
            this.prev.MouseHover += new System.EventHandler(this.prev_MouseHover);
            // 
            // next
            // 
            this.next.BackColor = System.Drawing.Color.White;
            this.next.Cursor = System.Windows.Forms.Cursors.Hand;
            this.next.Image = global::Upgrade.Properties.Resources.next_off;
            this.next.Location = new System.Drawing.Point(284, 99);
            this.next.Name = "next";
            this.next.Size = new System.Drawing.Size(17, 23);
            this.next.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.next.TabIndex = 162;
            this.next.TabStop = false;
            this.next.Click += new System.EventHandler(this.next_Click);
            this.next.MouseLeave += new System.EventHandler(this.next_MouseLeave);
            this.next.MouseHover += new System.EventHandler(this.next_MouseHover);
            // 
            // target
            // 
            this.target.BackColor = System.Drawing.Color.White;
            this.target.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.target.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.target.Location = new System.Drawing.Point(70, 101);
            this.target.Name = "target";
            this.target.ReadOnly = true;
            this.target.Size = new System.Drawing.Size(189, 20);
            this.target.TabIndex = 164;
            this.target.Text = "цель...";
            // 
            // buttonAddSubtask
            // 
            this.buttonAddSubtask.AutoSize = true;
            this.buttonAddSubtask.BackColor = System.Drawing.Color.White;
            this.buttonAddSubtask.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddSubtask.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.buttonAddSubtask.ForeColor = System.Drawing.Color.DarkGray;
            this.buttonAddSubtask.Location = new System.Drawing.Point(165, 268);
            this.buttonAddSubtask.Name = "buttonAddSubtask";
            this.buttonAddSubtask.Size = new System.Drawing.Size(140, 17);
            this.buttonAddSubtask.TabIndex = 155;
            this.buttonAddSubtask.Text = "+ добавить подзадачу";
            this.buttonAddSubtask.Click += new System.EventHandler(this.buttonAddSubtask_Click);
            this.buttonAddSubtask.MouseLeave += new System.EventHandler(this.buttonAddSubtask_MouseLeave);
            this.buttonAddSubtask.MouseHover += new System.EventHandler(this.buttonAddSubtask_MouseHover);
            // 
            // taskHour
            // 
            this.taskHour.AutoSize = true;
            this.taskHour.BackColor = System.Drawing.Color.White;
            this.taskHour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.taskHour.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.taskHour.ForeColor = System.Drawing.Color.Black;
            this.taskHour.Location = new System.Drawing.Point(519, 227);
            this.taskHour.Name = "taskHour";
            this.taskHour.Size = new System.Drawing.Size(47, 37);
            this.taskHour.TabIndex = 156;
            this.taskHour.Text = "00";
            // 
            // taskMinute
            // 
            this.taskMinute.AutoSize = true;
            this.taskMinute.BackColor = System.Drawing.Color.White;
            this.taskMinute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.taskMinute.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.taskMinute.ForeColor = System.Drawing.Color.Black;
            this.taskMinute.Location = new System.Drawing.Point(561, 227);
            this.taskMinute.Name = "taskMinute";
            this.taskMinute.Size = new System.Drawing.Size(47, 37);
            this.taskMinute.TabIndex = 165;
            this.taskMinute.Text = "00";
            // 
            // sched_name
            // 
            this.sched_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sched_name.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(204)));
            this.sched_name.ForeColor = System.Drawing.Color.DarkGray;
            this.sched_name.Location = new System.Drawing.Point(65, 414);
            this.sched_name.Name = "sched_name";
            this.sched_name.Size = new System.Drawing.Size(236, 20);
            this.sched_name.TabIndex = 166;
            this.sched_name.Text = "введите название расписания";
            this.sched_name.TextChanged += new System.EventHandler(this.sched_name_TextChanged);
            this.sched_name.Enter += new System.EventHandler(this.textBox_Enter);
            this.sched_name.Leave += new System.EventHandler(this.textBox_Leave);
            // 
            // AddTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 550);
            this.Controls.Add(this.sched_name);
            this.Controls.Add(this.buttonAddSubtask);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.taskMinute);
            this.Controls.Add(this.target);
            this.Controls.Add(this.taskHour);
            this.Controls.Add(this.prev);
            this.Controls.Add(this.next);
            this.Controls.Add(this.taskEndMinute);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.taskEndHour);
            this.Controls.Add(this.taskStartMinute);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.flowPanelDays);
            this.Controls.Add(this.flowPanelSubtasks);
            this.Controls.Add(this.task_descr);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.taskStartHour);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dateTime);
            this.Controls.Add(this.task_name);
            this.Controls.Add(this.addTaskButton);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddTaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddTaskForm";
            this.flowPanelDays.ResumeLayout(false);
            this.flowPanelDays.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.day1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.day5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.day2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.day6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.day3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.day7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.day4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.next)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox task_name;
        private AltoControls.AltoButton addTaskButton;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DateTimePicker dateTime;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox taskStartHour;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox task_descr;
        private System.Windows.Forms.FlowLayoutPanel flowPanelSubtasks;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.FlowLayoutPanel flowPanelDays;
        private System.Windows.Forms.PictureBox day1;
        private System.Windows.Forms.PictureBox day2;
        private System.Windows.Forms.PictureBox day6;
        private System.Windows.Forms.PictureBox day3;
        private System.Windows.Forms.PictureBox day7;
        private System.Windows.Forms.PictureBox day4;
        private System.Windows.Forms.PictureBox day5;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox taskStartMinute;
        private System.Windows.Forms.TextBox taskEndHour;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox taskEndMinute;
        private System.Windows.Forms.PictureBox prev;
        private System.Windows.Forms.PictureBox next;
        private System.Windows.Forms.TextBox target;
        private System.Windows.Forms.Label buttonAddSubtask;
        private System.Windows.Forms.Label taskHour;
        private System.Windows.Forms.Label taskMinute;
        private System.Windows.Forms.TextBox sched_name;
    }
}