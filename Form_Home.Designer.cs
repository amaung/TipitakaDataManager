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
            this.textBox_LoginStatus = new System.Windows.Forms.TextBox();
            this.button_Login = new System.Windows.Forms.Button();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_UserID = new System.Windows.Forms.TextBox();
            this.label_UserID = new System.Windows.Forms.Label();
            this.label_Date = new System.Windows.Forms.Label();
            this.label_MainTitle = new System.Windows.Forms.Label();
            this.button_ShowPswd = new System.Windows.Forms.Button();
            this.label_DhammaYaungchi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBox_LoginStatus
            // 
            this.textBox_LoginStatus.BackColor = System.Drawing.Color.OldLace;
            this.textBox_LoginStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_LoginStatus.Location = new System.Drawing.Point(138, 519);
            this.textBox_LoginStatus.Multiline = true;
            this.textBox_LoginStatus.Name = "textBox_LoginStatus";
            this.textBox_LoginStatus.ReadOnly = true;
            this.textBox_LoginStatus.Size = new System.Drawing.Size(436, 67);
            this.textBox_LoginStatus.TabIndex = 27;
            this.textBox_LoginStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button_Login
            // 
            this.button_Login.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_Login.Location = new System.Drawing.Point(304, 423);
            this.button_Login.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button_Login.Name = "button_Login";
            this.button_Login.Size = new System.Drawing.Size(101, 51);
            this.button_Login.TabIndex = 26;
            this.button_Login.Text = "Login";
            this.button_Login.UseVisualStyleBackColor = true;
            this.button_Login.Click += new System.EventHandler(this.button_Login_Click);
            // 
            // textBox_Password
            // 
            this.textBox_Password.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_Password.Location = new System.Drawing.Point(247, 337);
            this.textBox_Password.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.PasswordChar = '*';
            this.textBox_Password.Size = new System.Drawing.Size(306, 29);
            this.textBox_Password.TabIndex = 25;
            this.textBox_Password.TextChanged += new System.EventHandler(this.PasswordChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(127, 341);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 21);
            this.label1.TabIndex = 24;
            this.label1.Text = "Password:";
            // 
            // textBox_UserID
            // 
            this.textBox_UserID.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox_UserID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox_UserID.Location = new System.Drawing.Point(247, 265);
            this.textBox_UserID.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.textBox_UserID.Name = "textBox_UserID";
            this.textBox_UserID.PlaceholderText = "email";
            this.textBox_UserID.Size = new System.Drawing.Size(306, 29);
            this.textBox_UserID.TabIndex = 23;
            // 
            // label_UserID
            // 
            this.label_UserID.AutoSize = true;
            this.label_UserID.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_UserID.Location = new System.Drawing.Point(148, 271);
            this.label_UserID.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_UserID.Name = "label_UserID";
            this.label_UserID.Size = new System.Drawing.Size(73, 21);
            this.label_UserID.TabIndex = 22;
            this.label_UserID.Text = "User ID:";
            // 
            // label_Date
            // 
            this.label_Date.AutoSize = true;
            this.label_Date.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_Date.Location = new System.Drawing.Point(280, 162);
            this.label_Date.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_Date.Name = "label_Date";
            this.label_Date.Size = new System.Drawing.Size(127, 23);
            this.label_Date.TabIndex = 21;
            this.label_Date.Text = "Sept 30, 2022";
            // 
            // label_MainTitle
            // 
            this.label_MainTitle.AutoSize = true;
            this.label_MainTitle.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_MainTitle.Location = new System.Drawing.Point(179, 40);
            this.label_MainTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_MainTitle.Name = "label_MainTitle";
            this.label_MainTitle.Size = new System.Drawing.Size(343, 40);
            this.label_MainTitle.TabIndex = 20;
            this.label_MainTitle.Text = "Tipiṭaka Data Manager";
            // 
            // button_ShowPswd
            // 
            this.button_ShowPswd.BackgroundImage = global::TipitakaDataManager.Properties.Resources.showPasswordEye;
            this.button_ShowPswd.Location = new System.Drawing.Point(571, 342);
            this.button_ShowPswd.Name = "button_ShowPswd";
            this.button_ShowPswd.Size = new System.Drawing.Size(25, 23);
            this.button_ShowPswd.TabIndex = 28;
            this.button_ShowPswd.UseVisualStyleBackColor = true;
            this.button_ShowPswd.Click += new System.EventHandler(this.button_ShowPswd_Click);
            // 
            // label_DhammaYaungchi
            // 
            this.label_DhammaYaungchi.AutoSize = true;
            this.label_DhammaYaungchi.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_DhammaYaungchi.Location = new System.Drawing.Point(222, 113);
            this.label_DhammaYaungchi.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_DhammaYaungchi.Name = "label_DhammaYaungchi";
            this.label_DhammaYaungchi.Size = new System.Drawing.Size(247, 23);
            this.label_DhammaYaungchi.TabIndex = 29;
            this.label_DhammaYaungchi.Text = "Dhamma Yaungchi Software";
            // 
            // Form_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(720, 700);
            this.Controls.Add(this.label_DhammaYaungchi);
            this.Controls.Add(this.button_ShowPswd);
            this.Controls.Add(this.textBox_LoginStatus);
            this.Controls.Add(this.button_Login);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_UserID);
            this.Controls.Add(this.label_UserID);
            this.Controls.Add(this.label_Date);
            this.Controls.Add(this.label_MainTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Home";
            this.Text = "Home";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}