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
            this.login_auth = new System.Windows.Forms.TextBox();
            this.label_auth_password = new System.Windows.Forms.Label();
            this.authorization = new AltoControls.AltoButton();
            this.label_auth_login = new System.Windows.Forms.Label();
            this.pass_auth = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label_for_reg = new System.Windows.Forms.Label();
            this.panel_exit = new System.Windows.Forms.Panel();
            this.label_remember_me = new System.Windows.Forms.Label();
            this.rest_pass = new System.Windows.Forms.Label();
            this.panel_reg_code = new System.Windows.Forms.Panel();
            this.panel_rest_pass = new System.Windows.Forms.Panel();
            this.pass_rest = new System.Windows.Forms.TextBox();
            this.rest_pass_back = new System.Windows.Forms.Label();
            this.label_pass_rest = new System.Windows.Forms.Label();
            this.label_data_rest = new System.Windows.Forms.Label();
            this.accept_code_reg = new AltoControls.AltoButton();
            this.label_reg_later = new System.Windows.Forms.Label();
            this.data_box = new System.Windows.Forms.TextBox();
            this.eye = new System.Windows.Forms.PictureBox();
            this.remember = new System.Windows.Forms.PictureBox();
            this.exit = new System.Windows.Forms.PictureBox();
            this.panel_reg = new System.Windows.Forms.Panel();
            this.domen_list = new System.Windows.Forms.ComboBox();
            this.panel_back = new System.Windows.Forms.Panel();
            this.back = new System.Windows.Forms.PictureBox();
            this.label_reg_login = new System.Windows.Forms.Label();
            this.registration = new AltoControls.AltoButton();
            this.login_reg = new System.Windows.Forms.TextBox();
            this.label_empty_email = new System.Windows.Forms.Label();
            this.email_reg = new System.Windows.Forms.TextBox();
            this.label_reg_password = new System.Windows.Forms.Label();
            this.pass_reg = new System.Windows.Forms.TextBox();
            this.label_reg_email = new System.Windows.Forms.Label();
            this.backgr_reg = new System.Windows.Forms.PictureBox();
            this.chart = new System.Windows.Forms.PictureBox();
            this.backgr_auth = new System.Windows.Forms.PictureBox();
            this.panel_chart.SuspendLayout();
            this.panel_exit.SuspendLayout();
            this.panel_reg_code.SuspendLayout();
            this.panel_rest_pass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eye)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.remember)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit)).BeginInit();
            this.panel_reg.SuspendLayout();
            this.panel_back.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.back)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgr_reg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
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
            // login_auth
            // 
            this.login_auth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.login_auth.Font = new System.Drawing.Font("PF DinDisplay Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_auth.ForeColor = System.Drawing.Color.Gray;
            this.login_auth.Location = new System.Drawing.Point(65, 230);
            this.login_auth.Name = "login_auth";
            this.login_auth.Size = new System.Drawing.Size(241, 20);
            this.login_auth.TabIndex = 14;
            this.login_auth.Text = "введите ваш псевдоним";
            this.login_auth.Enter += new System.EventHandler(this.Enter);
            this.login_auth.Leave += new System.EventHandler(this.Leave);
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
            this.pass_auth.Font = new System.Drawing.Font("PF DinDisplay Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pass_auth.ForeColor = System.Drawing.Color.Gray;
            this.pass_auth.Location = new System.Drawing.Point(65, 284);
            this.pass_auth.Name = "pass_auth";
            this.pass_auth.Size = new System.Drawing.Size(215, 20);
            this.pass_auth.TabIndex = 18;
            this.pass_auth.Text = "введите пароль";
            this.pass_auth.Enter += new System.EventHandler(this.Enter);
            this.pass_auth.Leave += new System.EventHandler(this.Leave);
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
            // rest_pass
            // 
            this.rest_pass.AutoSize = true;
            this.rest_pass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rest_pass.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rest_pass.ForeColor = System.Drawing.Color.DimGray;
            this.rest_pass.Location = new System.Drawing.Point(218, 313);
            this.rest_pass.Name = "rest_pass";
            this.rest_pass.Size = new System.Drawing.Size(91, 16);
            this.rest_pass.TabIndex = 22;
            this.rest_pass.Text = "Забыл пароль";
            this.rest_pass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.rest_pass.Click += new System.EventHandler(this.rest_pass_Click);
            this.rest_pass.MouseLeave += new System.EventHandler(this.label10_MouseLeave);
            this.rest_pass.MouseHover += new System.EventHandler(this.label10_MouseHover);
            // 
            // panel_reg_code
            // 
            this.panel_reg_code.BackColor = System.Drawing.Color.Transparent;
            this.panel_reg_code.BackgroundImage = global::Upgrade.Properties.Resources.restoring_access;
            this.panel_reg_code.Controls.Add(this.panel_rest_pass);
            this.panel_reg_code.Controls.Add(this.rest_pass_back);
            this.panel_reg_code.Controls.Add(this.label_pass_rest);
            this.panel_reg_code.Controls.Add(this.label_data_rest);
            this.panel_reg_code.Controls.Add(this.accept_code_reg);
            this.panel_reg_code.Controls.Add(this.label_reg_later);
            this.panel_reg_code.Controls.Add(this.data_box);
            this.panel_reg_code.Location = new System.Drawing.Point(47, 79);
            this.panel_reg_code.Name = "panel_reg_code";
            this.panel_reg_code.Size = new System.Drawing.Size(274, 380);
            this.panel_reg_code.TabIndex = 25;
            this.panel_reg_code.Visible = false;
            // 
            // panel_rest_pass
            // 
            this.panel_rest_pass.Controls.Add(this.pass_rest);
            this.panel_rest_pass.Location = new System.Drawing.Point(18, 241);
            this.panel_rest_pass.Name = "panel_rest_pass";
            this.panel_rest_pass.Size = new System.Drawing.Size(239, 35);
            this.panel_rest_pass.TabIndex = 17;
            // 
            // pass_rest
            // 
            this.pass_rest.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pass_rest.Font = new System.Drawing.Font("PF DinDisplay Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pass_rest.ForeColor = System.Drawing.Color.Gray;
            this.pass_rest.Location = new System.Drawing.Point(16, 7);
            this.pass_rest.Name = "pass_rest";
            this.pass_rest.Size = new System.Drawing.Size(208, 20);
            this.pass_rest.TabIndex = 13;
            this.pass_rest.Visible = false;
            // 
            // rest_pass_back
            // 
            this.rest_pass_back.AutoSize = true;
            this.rest_pass_back.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rest_pass_back.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rest_pass_back.ForeColor = System.Drawing.Color.DimGray;
            this.rest_pass_back.Location = new System.Drawing.Point(102, 346);
            this.rest_pass_back.Name = "rest_pass_back";
            this.rest_pass_back.Size = new System.Drawing.Size(69, 16);
            this.rest_pass_back.TabIndex = 16;
            this.rest_pass_back.Text = "вернуться";
            this.rest_pass_back.Click += new System.EventHandler(this.rest_pass_back_Click);
            // 
            // label_pass_rest
            // 
            this.label_pass_rest.AutoSize = true;
            this.label_pass_rest.Cursor = System.Windows.Forms.Cursors.Default;
            this.label_pass_rest.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_pass_rest.ForeColor = System.Drawing.Color.DimGray;
            this.label_pass_rest.Location = new System.Drawing.Point(31, 225);
            this.label_pass_rest.Name = "label_pass_rest";
            this.label_pass_rest.Size = new System.Drawing.Size(77, 16);
            this.label_pass_rest.TabIndex = 15;
            this.label_pass_rest.Text = "ваш пароль";
            this.label_pass_rest.Visible = false;
            // 
            // label_data_rest
            // 
            this.label_data_rest.AutoSize = true;
            this.label_data_rest.Cursor = System.Windows.Forms.Cursors.Default;
            this.label_data_rest.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_data_rest.ForeColor = System.Drawing.Color.DimGray;
            this.label_data_rest.Location = new System.Drawing.Point(31, 173);
            this.label_data_rest.Name = "label_data_rest";
            this.label_data_rest.Size = new System.Drawing.Size(88, 16);
            this.label_data_rest.TabIndex = 14;
            this.label_data_rest.Text = "ваши данные";
            this.label_data_rest.Visible = false;
            // 
            // accept_code_reg
            // 
            this.accept_code_reg.Active1 = System.Drawing.Color.AliceBlue;
            this.accept_code_reg.Active2 = System.Drawing.Color.AliceBlue;
            this.accept_code_reg.BackColor = System.Drawing.Color.Transparent;
            this.accept_code_reg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.accept_code_reg.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.accept_code_reg.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.accept_code_reg.ForeColor = System.Drawing.Color.DarkBlue;
            this.accept_code_reg.Inactive1 = System.Drawing.Color.Transparent;
            this.accept_code_reg.Inactive2 = System.Drawing.Color.Transparent;
            this.accept_code_reg.Location = new System.Drawing.Point(67, 308);
            this.accept_code_reg.Name = "accept_code_reg";
            this.accept_code_reg.Radius = 18;
            this.accept_code_reg.Size = new System.Drawing.Size(138, 35);
            this.accept_code_reg.Stroke = true;
            this.accept_code_reg.StrokeColor = System.Drawing.Color.DarkBlue;
            this.accept_code_reg.TabIndex = 12;
            this.accept_code_reg.Text = "подтвердить";
            this.accept_code_reg.Transparency = false;
            this.accept_code_reg.Click += new System.EventHandler(this.accept_code_reg_Click);
            // 
            // label_reg_later
            // 
            this.label_reg_later.AutoSize = true;
            this.label_reg_later.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_reg_later.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_reg_later.ForeColor = System.Drawing.Color.DimGray;
            this.label_reg_later.Location = new System.Drawing.Point(93, 224);
            this.label_reg_later.Name = "label_reg_later";
            this.label_reg_later.Size = new System.Drawing.Size(88, 16);
            this.label_reg_later.TabIndex = 12;
            this.label_reg_later.Text = "ввести позже";
            this.label_reg_later.Click += new System.EventHandler(this.label_reg_later_Click);
            this.label_reg_later.MouseLeave += new System.EventHandler(this.label_reg_later_MouseLeave);
            this.label_reg_later.MouseHover += new System.EventHandler(this.label_reg_later_MouseHover);
            // 
            // data_box
            // 
            this.data_box.AccessibleName = "code";
            this.data_box.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.data_box.Font = new System.Drawing.Font("PF DinDisplay Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.data_box.ForeColor = System.Drawing.Color.Gray;
            this.data_box.Location = new System.Drawing.Point(97, 195);
            this.data_box.Name = "data_box";
            this.data_box.Size = new System.Drawing.Size(80, 20);
            this.data_box.TabIndex = 12;
            this.data_box.Text = "ваш код";
            this.data_box.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.data_box.Enter += new System.EventHandler(this.Enter);
            this.data_box.Leave += new System.EventHandler(this.Leave);
            // 
            // eye
            // 
            this.eye.AccessibleName = "off";
            this.eye.Cursor = System.Windows.Forms.Cursors.Hand;
            this.eye.Image = global::Upgrade.Properties.Resources.eye_off;
            this.eye.Location = new System.Drawing.Point(286, 285);
            this.eye.Name = "eye";
            this.eye.Size = new System.Drawing.Size(20, 18);
            this.eye.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.eye.TabIndex = 24;
            this.eye.TabStop = false;
            this.eye.Click += new System.EventHandler(this.eye_Click);
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
            // panel_reg
            // 
            this.panel_reg.BackColor = System.Drawing.Color.Transparent;
            this.panel_reg.BackgroundImage = global::Upgrade.Properties.Resources.RegistrationForm;
            this.panel_reg.Controls.Add(this.domen_list);
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
            this.panel_reg.Size = new System.Drawing.Size(370, 463);
            this.panel_reg.TabIndex = 12;
            // 
            // domen_list
            // 
            this.domen_list.BackColor = System.Drawing.Color.White;
            this.domen_list.Cursor = System.Windows.Forms.Cursors.Hand;
            this.domen_list.DropDownHeight = 70;
            this.domen_list.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.domen_list.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.domen_list.FormattingEnabled = true;
            this.domen_list.IntegralHeight = false;
            this.domen_list.ItemHeight = 19;
            this.domen_list.Items.AddRange(new object[] {
            "@mail.ru",
            "@bk.ru",
            "@inbox.ru",
            "@list.ru",
            "@gmail.com",
            "@yandex.ua",
            "@outlook.com",
            "@yahoo.com",
            "@rambler.ru"});
            this.domen_list.Location = new System.Drawing.Point(203, 326);
            this.domen_list.MaxDropDownItems = 4;
            this.domen_list.Name = "domen_list";
            this.domen_list.Size = new System.Drawing.Size(105, 27);
            this.domen_list.TabIndex = 26;
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
            // label_reg_login
            // 
            this.label_reg_login.AutoSize = true;
            this.label_reg_login.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_reg_login.ForeColor = System.Drawing.Color.DarkBlue;
            this.label_reg_login.Location = new System.Drawing.Point(63, 200);
            this.label_reg_login.Name = "label_reg_login";
            this.label_reg_login.Size = new System.Drawing.Size(74, 16);
            this.label_reg_login.TabIndex = 2;
            this.label_reg_login.Text = "псевдоним";
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
            // login_reg
            // 
            this.login_reg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.login_reg.Font = new System.Drawing.Font("PF DinDisplay Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.login_reg.ForeColor = System.Drawing.Color.Gray;
            this.login_reg.Location = new System.Drawing.Point(66, 222);
            this.login_reg.Name = "login_reg";
            this.login_reg.Size = new System.Drawing.Size(241, 20);
            this.login_reg.TabIndex = 7;
            this.login_reg.Text = "введите ваш псевдоним";
            this.login_reg.Enter += new System.EventHandler(this.Enter);
            this.login_reg.Leave += new System.EventHandler(this.Leave);
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
            // email_reg
            // 
            this.email_reg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.email_reg.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.email_reg.ForeColor = System.Drawing.Color.Gray;
            this.email_reg.Location = new System.Drawing.Point(66, 330);
            this.email_reg.Name = "email_reg";
            this.email_reg.Size = new System.Drawing.Size(135, 20);
            this.email_reg.TabIndex = 9;
            this.email_reg.Text = "evgenij.ermolenko";
            this.email_reg.Enter += new System.EventHandler(this.Enter);
            this.email_reg.Leave += new System.EventHandler(this.Leave);
            // 
            // label_reg_password
            // 
            this.label_reg_password.AutoSize = true;
            this.label_reg_password.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_reg_password.ForeColor = System.Drawing.Color.DarkBlue;
            this.label_reg_password.Location = new System.Drawing.Point(64, 254);
            this.label_reg_password.Name = "label_reg_password";
            this.label_reg_password.Size = new System.Drawing.Size(50, 16);
            this.label_reg_password.TabIndex = 3;
            this.label_reg_password.Text = "пароль";
            // 
            // pass_reg
            // 
            this.pass_reg.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.pass_reg.Font = new System.Drawing.Font("PF DinDisplay Pro", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pass_reg.ForeColor = System.Drawing.Color.Gray;
            this.pass_reg.Location = new System.Drawing.Point(67, 276);
            this.pass_reg.Name = "pass_reg";
            this.pass_reg.Size = new System.Drawing.Size(241, 20);
            this.pass_reg.TabIndex = 8;
            this.pass_reg.Text = "введите пароль";
            this.pass_reg.Enter += new System.EventHandler(this.Enter);
            this.pass_reg.Leave += new System.EventHandler(this.Leave);
            // 
            // label_reg_email
            // 
            this.label_reg_email.AutoSize = true;
            this.label_reg_email.Font = new System.Drawing.Font("PF DinDisplay Pro Medium", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_reg_email.ForeColor = System.Drawing.Color.DarkBlue;
            this.label_reg_email.Location = new System.Drawing.Point(63, 308);
            this.label_reg_email.Name = "label_reg_email";
            this.label_reg_email.Size = new System.Drawing.Size(120, 16);
            this.label_reg_email.TabIndex = 4;
            this.label_reg_email.Text = "электронная почта";
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
            this.ClientSize = new System.Drawing.Size(370, 564);
            this.Controls.Add(this.panel_reg_code);
            this.Controls.Add(this.eye);
            this.Controls.Add(this.remember);
            this.Controls.Add(this.rest_pass);
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
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Reg_AuthForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Shown += new System.EventHandler(this.RegistrationForm_Shown);
            this.panel_chart.ResumeLayout(false);
            this.panel_chart.PerformLayout();
            this.panel_exit.ResumeLayout(false);
            this.panel_exit.PerformLayout();
            this.panel_reg_code.ResumeLayout(false);
            this.panel_reg_code.PerformLayout();
            this.panel_rest_pass.ResumeLayout(false);
            this.panel_rest_pass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eye)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.remember)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.exit)).EndInit();
            this.panel_reg.ResumeLayout(false);
            this.panel_reg.PerformLayout();
            this.panel_back.ResumeLayout(false);
            this.panel_back.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.back)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgr_reg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backgr_auth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox chart;
        private System.Windows.Forms.Panel panel_chart;
        private System.Windows.Forms.Label label_reg_login;
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
        private System.Windows.Forms.Label rest_pass;
        private System.Windows.Forms.PictureBox remember;
        private System.Windows.Forms.PictureBox eye;
        private System.Windows.Forms.Panel panel_reg_code;
        private System.Windows.Forms.TextBox data_box;
        private System.Windows.Forms.PictureBox backgr_reg;
        private AltoControls.AltoButton accept_code_reg;
        private System.Windows.Forms.Label label_reg_later;
        private System.Windows.Forms.ComboBox domen_list;
        private System.Windows.Forms.Label label_pass_rest;
        private System.Windows.Forms.Label label_data_rest;
        private System.Windows.Forms.TextBox pass_rest;
        private System.Windows.Forms.Label rest_pass_back;
        private System.Windows.Forms.Panel panel_rest_pass;
    }
}

