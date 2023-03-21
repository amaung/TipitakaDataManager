namespace TipitakaDataManager
{
    partial class Form_UserProfiles
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
            label_UserProfiles = new Label();
            dataGridView_Users = new DataGridView();
            label1 = new Label();
            textBox_UserID = new TextBox();
            textBox_NameE = new TextBox();
            label_NameE = new Label();
            textBox_NameM = new TextBox();
            label_NameM = new Label();
            textBox_Password = new TextBox();
            label_Password = new Label();
            label_UserClass = new Label();
            label_UserStatus = new Label();
            comboBox_UserClass = new ComboBox();
            comboBox_UserStatus = new ComboBox();
            label_Remarks = new Label();
            textBox_Remarks = new TextBox();
            button_New = new Button();
            button_Update = new Button();
            button_Remove = new Button();
            button_Add = new Button();
            button_GenPassword = new Button();
            textBox_NewPswd = new TextBox();
            textBox_RetypePswd = new TextBox();
            label2 = new Label();
            label3 = new Label();
            button_ShowPswd = new Button();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView_Users).BeginInit();
            SuspendLayout();
            // 
            // label_UserProfiles
            // 
            label_UserProfiles.AutoSize = true;
            label_UserProfiles.Font = new Font("Times New Roman", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_UserProfiles.Location = new Point(225, 30);
            label_UserProfiles.Margin = new Padding(4, 0, 4, 0);
            label_UserProfiles.Name = "label_UserProfiles";
            label_UserProfiles.Size = new Size(184, 40);
            label_UserProfiles.TabIndex = 10;
            label_UserProfiles.Text = "User Profile";
            // 
            // dataGridView_Users
            // 
            dataGridView_Users.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView_Users.Location = new Point(24, 99);
            dataGridView_Users.Margin = new Padding(3, 2, 3, 2);
            dataGridView_Users.Name = "dataGridView_Users";
            dataGridView_Users.RowTemplate.Height = 29;
            dataGridView_Users.Size = new Size(245, 350);
            dataGridView_Users.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(301, 101);
            label1.Name = "label1";
            label1.Size = new Size(78, 21);
            label1.TabIndex = 12;
            label1.Text = "User ID :";
            // 
            // textBox_UserID
            // 
            textBox_UserID.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_UserID.Location = new Point(421, 99);
            textBox_UserID.Margin = new Padding(3, 2, 3, 2);
            textBox_UserID.Name = "textBox_UserID";
            textBox_UserID.Size = new Size(192, 25);
            textBox_UserID.TabIndex = 13;
            textBox_UserID.Leave += textBox_UserID_Leave;
            // 
            // textBox_NameE
            // 
            textBox_NameE.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_NameE.Location = new Point(421, 133);
            textBox_NameE.Margin = new Padding(3, 2, 3, 2);
            textBox_NameE.Name = "textBox_NameE";
            textBox_NameE.Size = new Size(192, 25);
            textBox_NameE.TabIndex = 15;
            // 
            // label_NameE
            // 
            label_NameE.AutoSize = true;
            label_NameE.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_NameE.Location = new Point(301, 135);
            label_NameE.Name = "label_NameE";
            label_NameE.Size = new Size(117, 21);
            label_NameE.TabIndex = 14;
            label_NameE.Text = "Name (ENG) :";
            // 
            // textBox_NameM
            // 
            textBox_NameM.Font = new Font("Myanmar Text", 12F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_NameM.Location = new Point(421, 166);
            textBox_NameM.Margin = new Padding(3, 2, 3, 2);
            textBox_NameM.Name = "textBox_NameM";
            textBox_NameM.Size = new Size(192, 37);
            textBox_NameM.TabIndex = 17;
            // 
            // label_NameM
            // 
            label_NameM.AutoSize = true;
            label_NameM.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_NameM.Location = new Point(301, 168);
            label_NameM.Name = "label_NameM";
            label_NameM.Size = new Size(119, 21);
            label_NameM.TabIndex = 16;
            label_NameM.Text = "Name (MYA) :";
            // 
            // textBox_Password
            // 
            textBox_Password.Location = new Point(421, 206);
            textBox_Password.Margin = new Padding(3, 2, 3, 2);
            textBox_Password.Name = "textBox_Password";
            textBox_Password.PasswordChar = '*';
            textBox_Password.Size = new Size(192, 23);
            textBox_Password.TabIndex = 19;
            // 
            // label_Password
            // 
            label_Password.AutoSize = true;
            label_Password.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_Password.Location = new Point(301, 208);
            label_Password.Name = "label_Password";
            label_Password.Size = new Size(93, 21);
            label_Password.TabIndex = 18;
            label_Password.Text = "Password :";
            // 
            // label_UserClass
            // 
            label_UserClass.AutoSize = true;
            label_UserClass.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_UserClass.Location = new Point(301, 320);
            label_UserClass.Name = "label_UserClass";
            label_UserClass.Size = new Size(100, 21);
            label_UserClass.TabIndex = 20;
            label_UserClass.Text = "User Class :";
            // 
            // label_UserStatus
            // 
            label_UserStatus.AutoSize = true;
            label_UserStatus.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_UserStatus.Location = new Point(301, 356);
            label_UserStatus.Name = "label_UserStatus";
            label_UserStatus.Size = new Size(105, 21);
            label_UserStatus.TabIndex = 22;
            label_UserStatus.Text = "User Status :";
            // 
            // comboBox_UserClass
            // 
            comboBox_UserClass.FormattingEnabled = true;
            comboBox_UserClass.Items.AddRange(new object[] { "Administrator", "Data Entry User", "Proof Reader" });
            comboBox_UserClass.Location = new Point(421, 320);
            comboBox_UserClass.Margin = new Padding(3, 2, 3, 2);
            comboBox_UserClass.Name = "comboBox_UserClass";
            comboBox_UserClass.Size = new Size(192, 23);
            comboBox_UserClass.TabIndex = 24;
            // 
            // comboBox_UserStatus
            // 
            comboBox_UserStatus.FormattingEnabled = true;
            comboBox_UserStatus.Items.AddRange(new object[] { "Active", "Suspended", "Blocked" });
            comboBox_UserStatus.Location = new Point(421, 356);
            comboBox_UserStatus.Margin = new Padding(3, 2, 3, 2);
            comboBox_UserStatus.Name = "comboBox_UserStatus";
            comboBox_UserStatus.Size = new Size(192, 23);
            comboBox_UserStatus.TabIndex = 25;
            // 
            // label_Remarks
            // 
            label_Remarks.AutoSize = true;
            label_Remarks.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_Remarks.Location = new Point(301, 388);
            label_Remarks.Name = "label_Remarks";
            label_Remarks.Size = new Size(85, 21);
            label_Remarks.TabIndex = 26;
            label_Remarks.Text = "Remarks :";
            // 
            // textBox_Remarks
            // 
            textBox_Remarks.Location = new Point(421, 388);
            textBox_Remarks.Margin = new Padding(3, 2, 3, 2);
            textBox_Remarks.Multiline = true;
            textBox_Remarks.Name = "textBox_Remarks";
            textBox_Remarks.Size = new Size(192, 56);
            textBox_Remarks.TabIndex = 27;
            // 
            // button_New
            // 
            button_New.BackColor = SystemColors.Control;
            button_New.Location = new Point(340, 470);
            button_New.Margin = new Padding(3, 2, 3, 2);
            button_New.Name = "button_New";
            button_New.Size = new Size(88, 30);
            button_New.TabIndex = 28;
            button_New.Text = "New";
            button_New.UseVisualStyleBackColor = false;
            button_New.Click += button_New_Click;
            // 
            // button_Update
            // 
            button_Update.BackColor = SystemColors.Control;
            button_Update.Location = new Point(186, 470);
            button_Update.Margin = new Padding(3, 2, 3, 2);
            button_Update.Name = "button_Update";
            button_Update.Size = new Size(88, 30);
            button_Update.TabIndex = 29;
            button_Update.Text = "Update";
            button_Update.UseVisualStyleBackColor = false;
            button_Update.Click += button_Update_Click;
            // 
            // button_Remove
            // 
            button_Remove.BackColor = SystemColors.Control;
            button_Remove.Location = new Point(29, 470);
            button_Remove.Margin = new Padding(3, 2, 3, 2);
            button_Remove.Name = "button_Remove";
            button_Remove.Size = new Size(88, 30);
            button_Remove.TabIndex = 30;
            button_Remove.Text = "Remove";
            button_Remove.UseVisualStyleBackColor = false;
            button_Remove.Click += button_Remove_Click;
            // 
            // button_Add
            // 
            button_Add.BackColor = SystemColors.Control;
            button_Add.Location = new Point(508, 470);
            button_Add.Margin = new Padding(3, 2, 3, 2);
            button_Add.Name = "button_Add";
            button_Add.Size = new Size(88, 30);
            button_Add.TabIndex = 31;
            button_Add.Text = "Add";
            button_Add.UseVisualStyleBackColor = false;
            button_Add.Click += button_Add_Click;
            // 
            // button_GenPassword
            // 
            button_GenPassword.BackColor = SystemColors.Control;
            button_GenPassword.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            button_GenPassword.Location = new Point(421, 229);
            button_GenPassword.Margin = new Padding(3, 2, 3, 2);
            button_GenPassword.Name = "button_GenPassword";
            button_GenPassword.Size = new Size(192, 25);
            button_GenPassword.TabIndex = 32;
            button_GenPassword.Text = "Generate Password";
            button_GenPassword.UseVisualStyleBackColor = false;
            button_GenPassword.Click += button_GenPassword_Click;
            // 
            // textBox_NewPswd
            // 
            textBox_NewPswd.Location = new Point(421, 257);
            textBox_NewPswd.Margin = new Padding(3, 2, 3, 2);
            textBox_NewPswd.Name = "textBox_NewPswd";
            textBox_NewPswd.PasswordChar = '*';
            textBox_NewPswd.Size = new Size(192, 23);
            textBox_NewPswd.TabIndex = 33;
            // 
            // textBox_RetypePswd
            // 
            textBox_RetypePswd.Location = new Point(421, 286);
            textBox_RetypePswd.Margin = new Padding(3, 2, 3, 2);
            textBox_RetypePswd.Name = "textBox_RetypePswd";
            textBox_RetypePswd.PasswordChar = '*';
            textBox_RetypePswd.Size = new Size(192, 23);
            textBox_RetypePswd.TabIndex = 35;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(301, 288);
            label2.Name = "label2";
            label2.Size = new Size(119, 21);
            label2.TabIndex = 34;
            label2.Text = "Retype Pswd :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(301, 260);
            label3.Name = "label3";
            label3.Size = new Size(100, 21);
            label3.TabIndex = 36;
            label3.Text = "New Pswd :";
            // 
            // button_ShowPswd
            // 
            button_ShowPswd.Location = new Point(359, 230);
            button_ShowPswd.Margin = new Padding(3, 2, 3, 2);
            button_ShowPswd.Name = "button_ShowPswd";
            button_ShowPswd.Size = new Size(22, 17);
            button_ShowPswd.TabIndex = 37;
            button_ShowPswd.UseVisualStyleBackColor = true;
            button_ShowPswd.Click += button_ShowPswd_Click;
            // 
            // groupBox1
            // 
            groupBox1.Location = new Point(289, 77);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(336, 379);
            groupBox1.TabIndex = 38;
            groupBox1.TabStop = false;
            groupBox1.Text = "Profile";
            // 
            // groupBox2
            // 
            groupBox2.Location = new Point(10, 78);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(273, 378);
            groupBox2.TabIndex = 39;
            groupBox2.TabStop = false;
            groupBox2.Text = "Users";
            // 
            // Form_UserProfiles
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(635, 525);
            Controls.Add(button_ShowPswd);
            Controls.Add(label3);
            Controls.Add(textBox_RetypePswd);
            Controls.Add(label2);
            Controls.Add(textBox_NewPswd);
            Controls.Add(button_GenPassword);
            Controls.Add(button_Add);
            Controls.Add(button_Remove);
            Controls.Add(button_Update);
            Controls.Add(button_New);
            Controls.Add(textBox_Remarks);
            Controls.Add(label_Remarks);
            Controls.Add(comboBox_UserStatus);
            Controls.Add(comboBox_UserClass);
            Controls.Add(label_UserStatus);
            Controls.Add(label_UserClass);
            Controls.Add(textBox_Password);
            Controls.Add(label_Password);
            Controls.Add(textBox_NameM);
            Controls.Add(label_NameM);
            Controls.Add(textBox_NameE);
            Controls.Add(label_NameE);
            Controls.Add(textBox_UserID);
            Controls.Add(label1);
            Controls.Add(dataGridView_Users);
            Controls.Add(label_UserProfiles);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form_UserProfiles";
            Text = "User Profiles";
            ((System.ComponentModel.ISupportInitialize)dataGridView_Users).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_UserProfiles;
        private DataGridView dataGridView_Users;
        private Label label1;
        private TextBox textBox_UserID;
        private TextBox textBox_NameE;
        private Label label_NameE;
        private TextBox textBox_NameM;
        private Label label_NameM;
        private TextBox textBox_Password;
        private Label label_Password;
        private Label label_UserClass;
        private Label label_UserStatus;
        private ComboBox comboBox_UserClass;
        private ComboBox comboBox_UserStatus;
        private Label label_Remarks;
        private TextBox textBox_Remarks;
        private Button button_New;
        private Button button_Update;
        private Button button_Remove;
        private Button button_Add;
        private Button button_GenPassword;
        private TextBox textBox_NewPswd;
        private TextBox textBox_RetypePswd;
        private Label label2;
        private Label label3;
        private Button button_ShowPswd;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
    }
}