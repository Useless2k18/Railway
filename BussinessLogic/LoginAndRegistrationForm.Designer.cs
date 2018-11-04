namespace BussinessLogic
{
    partial class LoginAndRegistrationForm
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
            this.components = new System.ComponentModel.Container();
            this.PanelLeft = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.PanelRight = new System.Windows.Forms.Panel();
            this.LoginRegisterTabControl = new System.Windows.Forms.TabControl();
            this.TabLogin = new System.Windows.Forms.TabPage();
            this.LoginButton = new ToolBoxControls.RoundedButton();
            this.label4 = new System.Windows.Forms.Label();
            this.RememberMeCheckBox = new Bunifu.Framework.UI.BunifuCheckbox();
            this.Password = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.Username = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TabRegister = new System.Windows.Forms.TabPage();
            this.DateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.EmailId = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.ConfirmPassword = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.RegisterPassword = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.FullName = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.PictureBoxUser = new System.Windows.Forms.PictureBox();
            this.ButtonClose = new System.Windows.Forms.Button();
            this.NextFirst = new System.Windows.Forms.Button();
            this.ButtonClose2 = new System.Windows.Forms.Button();
            this.PictureBoxIRCTC = new System.Windows.Forms.PictureBox();
            this.PanelLeft.SuspendLayout();
            this.PanelRight.SuspendLayout();
            this.LoginRegisterTabControl.SuspendLayout();
            this.TabLogin.SuspendLayout();
            this.TabRegister.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxIRCTC)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelLeft
            // 
            this.PanelLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(170)))), ((int)(((byte)(245)))));
            this.PanelLeft.Controls.Add(this.label1);
            this.PanelLeft.Controls.Add(this.PictureBoxIRCTC);
            this.PanelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PanelLeft.Location = new System.Drawing.Point(0, 0);
            this.PanelLeft.Name = "PanelLeft";
            this.PanelLeft.Size = new System.Drawing.Size(333, 511);
            this.PanelLeft.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(113, 252);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 48);
            this.label1.TabIndex = 1;
            this.label1.Text = "IRCTC";
            // 
            // PanelRight
            // 
            this.PanelRight.BackColor = System.Drawing.SystemColors.Control;
            this.PanelRight.Controls.Add(this.LoginRegisterTabControl);
            this.PanelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelRight.Location = new System.Drawing.Point(333, 0);
            this.PanelRight.Name = "PanelRight";
            this.PanelRight.Size = new System.Drawing.Size(341, 511);
            this.PanelRight.TabIndex = 1;
            // 
            // LoginRegisterTabControl
            // 
            this.LoginRegisterTabControl.Controls.Add(this.TabLogin);
            this.LoginRegisterTabControl.Controls.Add(this.TabRegister);
            this.LoginRegisterTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginRegisterTabControl.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginRegisterTabControl.Location = new System.Drawing.Point(0, 0);
            this.LoginRegisterTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.LoginRegisterTabControl.Name = "LoginRegisterTabControl";
            this.LoginRegisterTabControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LoginRegisterTabControl.SelectedIndex = 0;
            this.LoginRegisterTabControl.Size = new System.Drawing.Size(341, 511);
            this.LoginRegisterTabControl.TabIndex = 0;
            this.LoginRegisterTabControl.SelectedIndexChanged += new System.EventHandler(this.LoginRegisterTabControl_SelectedIndexChanged);
            // 
            // TabLogin
            // 
            this.TabLogin.BackColor = System.Drawing.Color.White;
            this.TabLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TabLogin.Controls.Add(this.PictureBoxUser);
            this.TabLogin.Controls.Add(this.ButtonClose);
            this.TabLogin.Controls.Add(this.LoginButton);
            this.TabLogin.Controls.Add(this.label4);
            this.TabLogin.Controls.Add(this.RememberMeCheckBox);
            this.TabLogin.Controls.Add(this.Password);
            this.TabLogin.Controls.Add(this.Username);
            this.TabLogin.Controls.Add(this.label3);
            this.TabLogin.Controls.Add(this.label2);
            this.TabLogin.Font = new System.Drawing.Font("Calibri", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(170)))), ((int)(((byte)(245)))));
            this.TabLogin.Location = new System.Drawing.Point(4, 53);
            this.TabLogin.Margin = new System.Windows.Forms.Padding(0);
            this.TabLogin.Name = "TabLogin";
            this.TabLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TabLogin.Size = new System.Drawing.Size(333, 454);
            this.TabLogin.TabIndex = 0;
            this.TabLogin.Text = "Login";
            this.TabLogin.ToolTipText = "Already Registered? Login Here";
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(170)))), ((int)(((byte)(245)))));
            this.LoginButton.FlatAppearance.BorderSize = 0;
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("Calibri", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginButton.ForeColor = System.Drawing.Color.White;
            this.LoginButton.Location = new System.Drawing.Point(20, 370);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(291, 57);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "LOGIN";
            this.LoginButton.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(112, 310);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(179, 35);
            this.label4.TabIndex = 3;
            this.label4.Text = "Remember Me";
            // 
            // RememberMeCheckBox
            // 
            this.RememberMeCheckBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(170)))), ((int)(((byte)(245)))));
            this.RememberMeCheckBox.ChechedOffColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(135)))), ((int)(((byte)(140)))));
            this.RememberMeCheckBox.Checked = true;
            this.RememberMeCheckBox.CheckedOnColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(170)))), ((int)(((byte)(245)))));
            this.RememberMeCheckBox.ForeColor = System.Drawing.Color.White;
            this.RememberMeCheckBox.Location = new System.Drawing.Point(500, 2301);
            this.RememberMeCheckBox.Margin = new System.Windows.Forms.Padding(0);
            this.RememberMeCheckBox.Name = "RememberMeCheckBox";
            this.RememberMeCheckBox.Size = new System.Drawing.Size(20, 20);
            this.RememberMeCheckBox.TabIndex = 2;
            // 
            // Password
            // 
            this.Password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Password.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Password.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Password.HintForeColor = System.Drawing.SystemColors.Control;
            this.Password.HintText = "";
            this.Password.isPassword = true;
            this.Password.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(170)))), ((int)(((byte)(245)))));
            this.Password.LineIdleColor = System.Drawing.Color.Gray;
            this.Password.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(170)))), ((int)(((byte)(245)))));
            this.Password.LineThickness = 2;
            this.Password.Location = new System.Drawing.Point(20, 237);
            this.Password.Margin = new System.Windows.Forms.Padding(4);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(291, 39);
            this.Password.TabIndex = 1;
            this.Password.Text = "Password";
            this.Password.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.Password.Enter += new System.EventHandler(this.Password_Enter);
            this.Password.Leave += new System.EventHandler(this.Password_Leave);
            // 
            // Username
            // 
            this.Username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.Username.ForeColor = System.Drawing.Color.Black;
            this.Username.HintForeColor = System.Drawing.Color.Gray;
            this.Username.HintText = "Enter User Name";
            this.Username.isPassword = false;
            this.Username.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(170)))), ((int)(((byte)(245)))));
            this.Username.LineIdleColor = System.Drawing.Color.Gray;
            this.Username.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(170)))), ((int)(((byte)(245)))));
            this.Username.LineThickness = 2;
            this.Username.Location = new System.Drawing.Point(20, 139);
            this.Username.Margin = new System.Windows.Forms.Padding(4);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(291, 39);
            this.Username.TabIndex = 1;
            this.Username.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 35);
            this.label3.TabIndex = 0;
            this.label3.Text = "Password :";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Calibri", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 35);
            this.label2.TabIndex = 0;
            this.label2.Text = "User Name :";
            // 
            // TabRegister
            // 
            this.TabRegister.BackColor = System.Drawing.Color.White;
            this.TabRegister.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TabRegister.Controls.Add(this.NextFirst);
            this.TabRegister.Controls.Add(this.DateOfBirth);
            this.TabRegister.Controls.Add(this.EmailId);
            this.TabRegister.Controls.Add(this.ConfirmPassword);
            this.TabRegister.Controls.Add(this.RegisterPassword);
            this.TabRegister.Controls.Add(this.FullName);
            this.TabRegister.Controls.Add(this.label9);
            this.TabRegister.Controls.Add(this.label8);
            this.TabRegister.Controls.Add(this.label7);
            this.TabRegister.Controls.Add(this.label6);
            this.TabRegister.Controls.Add(this.label5);
            this.TabRegister.Controls.Add(this.ButtonClose2);
            this.TabRegister.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TabRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.TabRegister.Location = new System.Drawing.Point(4, 53);
            this.TabRegister.Margin = new System.Windows.Forms.Padding(0);
            this.TabRegister.Name = "TabRegister";
            this.TabRegister.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TabRegister.Size = new System.Drawing.Size(333, 454);
            this.TabRegister.TabIndex = 1;
            this.TabRegister.Text = "Register";
            this.TabRegister.ToolTipText = "Register with us";
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.CalendarFont = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateOfBirth.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateOfBirth.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DateOfBirth.Location = new System.Drawing.Point(8, 367);
            this.DateOfBirth.Name = "DateOfBirth";
            this.DateOfBirth.Size = new System.Drawing.Size(313, 32);
            this.DateOfBirth.TabIndex = 9;
            // 
            // EmailId
            // 
            this.EmailId.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.EmailId.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.EmailId.ForeColor = System.Drawing.Color.Black;
            this.EmailId.HintForeColor = System.Drawing.Color.Gray;
            this.EmailId.HintText = "Enter Email ID";
            this.EmailId.isPassword = false;
            this.EmailId.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.EmailId.LineIdleColor = System.Drawing.SystemColors.ControlLight;
            this.EmailId.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.EmailId.LineThickness = 3;
            this.EmailId.Location = new System.Drawing.Point(6, 291);
            this.EmailId.Margin = new System.Windows.Forms.Padding(4);
            this.EmailId.Name = "EmailId";
            this.EmailId.Size = new System.Drawing.Size(315, 33);
            this.EmailId.TabIndex = 8;
            this.EmailId.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // ConfirmPassword
            // 
            this.ConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ConfirmPassword.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.ConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ConfirmPassword.HintForeColor = System.Drawing.Color.Empty;
            this.ConfirmPassword.HintText = "";
            this.ConfirmPassword.isPassword = true;
            this.ConfirmPassword.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.ConfirmPassword.LineIdleColor = System.Drawing.SystemColors.ControlLight;
            this.ConfirmPassword.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.ConfirmPassword.LineThickness = 3;
            this.ConfirmPassword.Location = new System.Drawing.Point(8, 213);
            this.ConfirmPassword.Margin = new System.Windows.Forms.Padding(4);
            this.ConfirmPassword.Name = "ConfirmPassword";
            this.ConfirmPassword.Size = new System.Drawing.Size(315, 33);
            this.ConfirmPassword.TabIndex = 8;
            this.ConfirmPassword.Text = "Password";
            this.ConfirmPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.ConfirmPassword.Enter += new System.EventHandler(this.Password_Enter);
            this.ConfirmPassword.Leave += new System.EventHandler(this.Password_Leave);
            // 
            // RegisterPassword
            // 
            this.RegisterPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.RegisterPassword.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.RegisterPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.RegisterPassword.HintForeColor = System.Drawing.Color.Empty;
            this.RegisterPassword.HintText = "";
            this.RegisterPassword.isPassword = true;
            this.RegisterPassword.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.RegisterPassword.LineIdleColor = System.Drawing.SystemColors.ControlLight;
            this.RegisterPassword.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.RegisterPassword.LineThickness = 3;
            this.RegisterPassword.Location = new System.Drawing.Point(8, 139);
            this.RegisterPassword.Margin = new System.Windows.Forms.Padding(4);
            this.RegisterPassword.Name = "RegisterPassword";
            this.RegisterPassword.Size = new System.Drawing.Size(315, 33);
            this.RegisterPassword.TabIndex = 8;
            this.RegisterPassword.Text = "Password";
            this.RegisterPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.RegisterPassword.Enter += new System.EventHandler(this.Password_Enter);
            this.RegisterPassword.Leave += new System.EventHandler(this.Password_Leave);
            // 
            // FullName
            // 
            this.FullName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.FullName.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.FullName.ForeColor = System.Drawing.Color.Black;
            this.FullName.HintForeColor = System.Drawing.Color.Gray;
            this.FullName.HintText = "Enter Full Name";
            this.FullName.isPassword = false;
            this.FullName.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.FullName.LineIdleColor = System.Drawing.SystemColors.ControlLight;
            this.FullName.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(26)))), ((int)(((byte)(74)))));
            this.FullName.LineThickness = 3;
            this.FullName.Location = new System.Drawing.Point(8, 63);
            this.FullName.Margin = new System.Windows.Forms.Padding(4);
            this.FullName.Name = "FullName";
            this.FullName.Size = new System.Drawing.Size(315, 33);
            this.FullName.TabIndex = 8;
            this.FullName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 263);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(78, 24);
            this.label9.TabIndex = 7;
            this.label9.Text = "Email ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 339);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 24);
            this.label8.TabIndex = 7;
            this.label8.Text = "Date Of Birth";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(161, 24);
            this.label7.TabIndex = 7;
            this.label7.Text = "Confirm Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(4, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 24);
            this.label6.TabIndex = 7;
            this.label6.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(4, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "Full Name";
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 25;
            this.bunifuElipse1.TargetControl = this;
            // 
            // PictureBoxUser
            // 
            this.PictureBoxUser.Image = global::BussinessLogic.Properties.Resources.User_48px;
            this.PictureBoxUser.Location = new System.Drawing.Point(129, 17);
            this.PictureBoxUser.Name = "PictureBoxUser";
            this.PictureBoxUser.Size = new System.Drawing.Size(72, 63);
            this.PictureBoxUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxUser.TabIndex = 6;
            this.PictureBoxUser.TabStop = false;
            // 
            // ButtonClose
            // 
            this.ButtonClose.BackColor = System.Drawing.Color.Transparent;
            this.ButtonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonClose.FlatAppearance.BorderSize = 0;
            this.ButtonClose.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonClose.Image = global::BussinessLogic.Properties.Resources.Cancel_48px;
            this.ButtonClose.Location = new System.Drawing.Point(299, -1);
            this.ButtonClose.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonClose.Name = "ButtonClose";
            this.ButtonClose.Size = new System.Drawing.Size(33, 35);
            this.ButtonClose.TabIndex = 5;
            this.ButtonClose.UseVisualStyleBackColor = true;
            this.ButtonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // NextFirst
            // 
            this.NextFirst.BackColor = System.Drawing.Color.Transparent;
            this.NextFirst.FlatAppearance.BorderSize = 0;
            this.NextFirst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NextFirst.Image = global::BussinessLogic.Properties.Resources.Forward_48px;
            this.NextFirst.Location = new System.Drawing.Point(239, 401);
            this.NextFirst.Name = "NextFirst";
            this.NextFirst.Size = new System.Drawing.Size(85, 44);
            this.NextFirst.TabIndex = 10;
            this.NextFirst.UseVisualStyleBackColor = false;
            // 
            // ButtonClose2
            // 
            this.ButtonClose2.BackColor = System.Drawing.Color.Transparent;
            this.ButtonClose2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ButtonClose2.FlatAppearance.BorderSize = 0;
            this.ButtonClose2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonClose2.Image = global::BussinessLogic.Properties.Resources.Cancel_48px;
            this.ButtonClose2.Location = new System.Drawing.Point(299, -1);
            this.ButtonClose2.Margin = new System.Windows.Forms.Padding(0);
            this.ButtonClose2.Name = "ButtonClose2";
            this.ButtonClose2.Size = new System.Drawing.Size(33, 35);
            this.ButtonClose2.TabIndex = 6;
            this.ButtonClose2.UseVisualStyleBackColor = true;
            this.ButtonClose2.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // PictureBoxIRCTC
            // 
            this.PictureBoxIRCTC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PictureBoxIRCTC.Image = global::BussinessLogic.Properties.Resources.Indian_Railwaylogo;
            this.PictureBoxIRCTC.Location = new System.Drawing.Point(72, 89);
            this.PictureBoxIRCTC.Name = "PictureBoxIRCTC";
            this.PictureBoxIRCTC.Padding = new System.Windows.Forms.Padding(3);
            this.PictureBoxIRCTC.Size = new System.Drawing.Size(184, 160);
            this.PictureBoxIRCTC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBoxIRCTC.TabIndex = 0;
            this.PictureBoxIRCTC.TabStop = false;
            // 
            // LoginAndRegistrationForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(674, 511);
            this.Controls.Add(this.PanelRight);
            this.Controls.Add(this.PanelLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoginAndRegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.PanelLeft.ResumeLayout(false);
            this.PanelRight.ResumeLayout(false);
            this.LoginRegisterTabControl.ResumeLayout(false);
            this.TabLogin.ResumeLayout(false);
            this.TabRegister.ResumeLayout(false);
            this.TabRegister.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBoxIRCTC)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelLeft;
        private System.Windows.Forms.PictureBox PictureBoxIRCTC;
        private System.Windows.Forms.Panel PanelRight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl LoginRegisterTabControl;
        private System.Windows.Forms.TabPage TabLogin;
        private System.Windows.Forms.TabPage TabRegister;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private Bunifu.Framework.UI.BunifuCheckbox RememberMeCheckBox;
        private Bunifu.Framework.UI.BunifuMaterialTextbox Password;
        private Bunifu.Framework.UI.BunifuMaterialTextbox Username;
        private ToolBoxControls.RoundedButton LoginButton;
        private System.Windows.Forms.Button ButtonClose;
        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.PictureBox PictureBoxUser;
        private System.Windows.Forms.Button ButtonClose2;
        private Bunifu.Framework.UI.BunifuMaterialTextbox EmailId;
        private Bunifu.Framework.UI.BunifuMaterialTextbox ConfirmPassword;
        private Bunifu.Framework.UI.BunifuMaterialTextbox RegisterPassword;
        private Bunifu.Framework.UI.BunifuMaterialTextbox FullName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button NextFirst;
        private System.Windows.Forms.DateTimePicker DateOfBirth;
    }
}