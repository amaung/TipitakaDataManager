namespace TipitakaDataManager
{
    partial class Form_Home
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
            textBox_LoginStatus = new TextBox();
            button_Login = new Button();
            textBox_Password = new TextBox();
            label1 = new Label();
            textBox_UserID = new TextBox();
            label_UserID = new Label();
            label_Date = new Label();
            label_MainTitle = new Label();
            button_ShowPswd = new Button();
            label_DhammaYaungchi = new Label();
            label_ServerName = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // textBox_LoginStatus
            // 
            textBox_LoginStatus.BackColor = Color.OldLace;
            textBox_LoginStatus.BorderStyle = BorderStyle.None;
            textBox_LoginStatus.Location = new Point(121, 418);
            textBox_LoginStatus.Margin = new Padding(3, 2, 3, 2);
            textBox_LoginStatus.Multiline = true;
            textBox_LoginStatus.Name = "textBox_LoginStatus";
            textBox_LoginStatus.ReadOnly = true;
            textBox_LoginStatus.Size = new Size(382, 50);
            textBox_LoginStatus.TabIndex = 27;
            textBox_LoginStatus.TextAlign = HorizontalAlignment.Center;
            // 
            // button_Login
            // 
            button_Login.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            button_Login.Location = new Point(266, 350);
            button_Login.Margin = new Padding(4, 3, 4, 3);
            button_Login.Name = "button_Login";
            button_Login.Size = new Size(88, 38);
            button_Login.TabIndex = 26;
            button_Login.Text = "Login";
            button_Login.UseVisualStyleBackColor = true;
            button_Login.Click += button_Login_Click;
            // 
            // textBox_Password
            // 
            textBox_Password.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_Password.Location = new Point(216, 249);
            textBox_Password.Margin = new Padding(4, 3, 4, 3);
            textBox_Password.Name = "textBox_Password";
            textBox_Password.PasswordChar = '*';
            textBox_Password.Size = new Size(268, 29);
            textBox_Password.TabIndex = 25;
            textBox_Password.TextChanged += PasswordChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(116, 252);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(88, 21);
            label1.TabIndex = 24;
            label1.Text = "Password:";
            // 
            // textBox_UserID
            // 
            textBox_UserID.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_UserID.ForeColor = SystemColors.ControlText;
            textBox_UserID.Location = new Point(216, 199);
            textBox_UserID.Margin = new Padding(4, 3, 4, 3);
            textBox_UserID.Name = "textBox_UserID";
            textBox_UserID.PlaceholderText = "email";
            textBox_UserID.Size = new Size(268, 29);
            textBox_UserID.TabIndex = 23;
            // 
            // label_UserID
            // 
            label_UserID.AutoSize = true;
            label_UserID.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_UserID.Location = new Point(130, 203);
            label_UserID.Margin = new Padding(4, 0, 4, 0);
            label_UserID.Name = "label_UserID";
            label_UserID.Size = new Size(73, 21);
            label_UserID.TabIndex = 22;
            label_UserID.Text = "User ID:";
            // 
            // label_Date
            // 
            label_Date.AutoSize = true;
            label_Date.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_Date.Location = new Point(245, 122);
            label_Date.Margin = new Padding(4, 0, 4, 0);
            label_Date.Name = "label_Date";
            label_Date.Size = new Size(127, 23);
            label_Date.TabIndex = 21;
            label_Date.Text = "Sept 30, 2022";
            // 
            // label_MainTitle
            // 
            label_MainTitle.AutoSize = true;
            label_MainTitle.Font = new Font("Times New Roman", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_MainTitle.Location = new Point(157, 30);
            label_MainTitle.Margin = new Padding(4, 0, 4, 0);
            label_MainTitle.Name = "label_MainTitle";
            label_MainTitle.Size = new Size(343, 40);
            label_MainTitle.TabIndex = 20;
            label_MainTitle.Text = "Tipiṭaka Data Manager";
            // 
            // button_ShowPswd
            // 
            button_ShowPswd.BackgroundImage = Properties.Resources.showPasswordEye;
            button_ShowPswd.Location = new Point(500, 252);
            button_ShowPswd.Margin = new Padding(3, 2, 3, 2);
            button_ShowPswd.Name = "button_ShowPswd";
            button_ShowPswd.Size = new Size(22, 25);
            button_ShowPswd.TabIndex = 28;
            button_ShowPswd.UseVisualStyleBackColor = true;
            button_ShowPswd.Click += button_ShowPswd_Click;
            // 
            // label_DhammaYaungchi
            // 
            label_DhammaYaungchi.AutoSize = true;
            label_DhammaYaungchi.Font = new Font("Times New Roman", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label_DhammaYaungchi.Location = new Point(194, 85);
            label_DhammaYaungchi.Margin = new Padding(4, 0, 4, 0);
            label_DhammaYaungchi.Name = "label_DhammaYaungchi";
            label_DhammaYaungchi.Size = new Size(247, 23);
            label_DhammaYaungchi.TabIndex = 29;
            label_DhammaYaungchi.Text = "Dhamma Yaungchi Software";
            // 
            // label_ServerName
            // 
            label_ServerName.AutoSize = true;
            label_ServerName.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_ServerName.Location = new Point(216, 301);
            label_ServerName.Name = "label_ServerName";
            label_ServerName.Size = new Size(101, 21);
            label_ServerName.TabIndex = 30;
            label_ServerName.Text = "Server Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(141, 301);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(62, 21);
            label3.TabIndex = 31;
            label3.Text = "Server:";
            // 
            // Form_Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(630, 525);
            Controls.Add(label3);
            Controls.Add(label_ServerName);
            Controls.Add(label_DhammaYaungchi);
            Controls.Add(button_ShowPswd);
            Controls.Add(textBox_LoginStatus);
            Controls.Add(button_Login);
            Controls.Add(textBox_Password);
            Controls.Add(label1);
            Controls.Add(textBox_UserID);
            Controls.Add(label_UserID);
            Controls.Add(label_Date);
            Controls.Add(label_MainTitle);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form_Home";
            Text = "Home";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_LoginStatus;
        private Button button_Login;
        private TextBox textBox_Password;
        private Label label1;
        private TextBox textBox_UserID;
        private Label label_UserID;
        private Label label_Date;
        private Label label_MainTitle;
        private Button button_ShowPswd;
        private Label label_DhammaYaungchi;
        private Label label_ServerName;
        private Label label3;
    }
}