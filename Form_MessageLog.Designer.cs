namespace TipitakaDataManager
{
    partial class Form_MessageLog
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
            this.label_MessageLog = new System.Windows.Forms.Label();
            this.groupBox_Filter = new System.Windows.Forms.GroupBox();
            this.button_Find = new System.Windows.Forms.Button();
            this.comboBox_Users = new System.Windows.Forms.ComboBox();
            this.label_User = new System.Windows.Forms.Label();
            this.checkBox_All = new System.Windows.Forms.CheckBox();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.label_End = new System.Windows.Forms.Label();
            this.dateTimePicker_Start = new System.Windows.Forms.DateTimePicker();
            this.label_Start = new System.Windows.Forms.Label();
            this.groupBox_Messages = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox_Details = new System.Windows.Forms.GroupBox();
            this.textBox_Seen = new System.Windows.Forms.TextBox();
            this.textBox_Type = new System.Windows.Forms.TextBox();
            this.label_Seen = new System.Windows.Forms.Label();
            this.label_Type = new System.Windows.Forms.Label();
            this.textBox_Message = new System.Windows.Forms.TextBox();
            this.label_Message = new System.Windows.Forms.Label();
            this.textBox_From = new System.Windows.Forms.TextBox();
            this.label_From = new System.Windows.Forms.Label();
            this.textBox_DateTime = new System.Windows.Forms.TextBox();
            this.label_DateTime = new System.Windows.Forms.Label();
            this.groupBox_Filter.SuspendLayout();
            this.groupBox_Messages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox_Details.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_MessageLog
            // 
            this.label_MessageLog.AutoSize = true;
            this.label_MessageLog.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_MessageLog.Location = new System.Drawing.Point(251, 40);
            this.label_MessageLog.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_MessageLog.Name = "label_MessageLog";
            this.label_MessageLog.Size = new System.Drawing.Size(203, 40);
            this.label_MessageLog.TabIndex = 11;
            this.label_MessageLog.Text = "Message Log";
            // 
            // groupBox_Filter
            // 
            this.groupBox_Filter.Controls.Add(this.button_Find);
            this.groupBox_Filter.Controls.Add(this.comboBox_Users);
            this.groupBox_Filter.Controls.Add(this.label_User);
            this.groupBox_Filter.Controls.Add(this.checkBox_All);
            this.groupBox_Filter.Controls.Add(this.dateTimePicker_End);
            this.groupBox_Filter.Controls.Add(this.label_End);
            this.groupBox_Filter.Controls.Add(this.dateTimePicker_Start);
            this.groupBox_Filter.Controls.Add(this.label_Start);
            this.groupBox_Filter.Location = new System.Drawing.Point(40, 100);
            this.groupBox_Filter.Name = "groupBox_Filter";
            this.groupBox_Filter.Size = new System.Drawing.Size(646, 129);
            this.groupBox_Filter.TabIndex = 12;
            this.groupBox_Filter.TabStop = false;
            this.groupBox_Filter.Text = "Filter";
            // 
            // button_Find
            // 
            this.button_Find.Location = new System.Drawing.Point(557, 79);
            this.button_Find.Name = "button_Find";
            this.button_Find.Size = new System.Drawing.Size(75, 28);
            this.button_Find.TabIndex = 7;
            this.button_Find.Text = "Find";
            this.button_Find.UseVisualStyleBackColor = true;
            this.button_Find.Click += new System.EventHandler(this.button_Find_Click);
            // 
            // comboBox_Users
            // 
            this.comboBox_Users.FormattingEnabled = true;
            this.comboBox_Users.Location = new System.Drawing.Point(68, 74);
            this.comboBox_Users.Name = "comboBox_Users";
            this.comboBox_Users.Size = new System.Drawing.Size(200, 28);
            this.comboBox_Users.TabIndex = 6;
            // 
            // label_User
            // 
            this.label_User.AutoSize = true;
            this.label_User.Location = new System.Drawing.Point(15, 77);
            this.label_User.Name = "label_User";
            this.label_User.Size = new System.Drawing.Size(45, 20);
            this.label_User.TabIndex = 5;
            this.label_User.Text = "User :";
            // 
            // checkBox_All
            // 
            this.checkBox_All.AutoSize = true;
            this.checkBox_All.Location = new System.Drawing.Point(581, 35);
            this.checkBox_All.Name = "checkBox_All";
            this.checkBox_All.Size = new System.Drawing.Size(46, 24);
            this.checkBox_All.TabIndex = 4;
            this.checkBox_All.Text = "All";
            this.checkBox_All.UseVisualStyleBackColor = true;
            this.checkBox_All.CheckedChanged += new System.EventHandler(this.checkBox_All_CheckedChanged);
            // 
            // dateTimePicker_End
            // 
            this.dateTimePicker_End.Location = new System.Drawing.Point(351, 34);
            this.dateTimePicker_End.Name = "dateTimePicker_End";
            this.dateTimePicker_End.Size = new System.Drawing.Size(200, 27);
            this.dateTimePicker_End.TabIndex = 3;
            // 
            // label_End
            // 
            this.label_End.AutoSize = true;
            this.label_End.Location = new System.Drawing.Point(298, 35);
            this.label_End.Name = "label_End";
            this.label_End.Size = new System.Drawing.Size(41, 20);
            this.label_End.TabIndex = 2;
            this.label_End.Text = "End :";
            // 
            // dateTimePicker_Start
            // 
            this.dateTimePicker_Start.Location = new System.Drawing.Point(68, 33);
            this.dateTimePicker_Start.Name = "dateTimePicker_Start";
            this.dateTimePicker_Start.Size = new System.Drawing.Size(200, 27);
            this.dateTimePicker_Start.TabIndex = 1;
            // 
            // label_Start
            // 
            this.label_Start.AutoSize = true;
            this.label_Start.Location = new System.Drawing.Point(15, 34);
            this.label_Start.Name = "label_Start";
            this.label_Start.Size = new System.Drawing.Size(47, 20);
            this.label_Start.TabIndex = 0;
            this.label_Start.Text = "Start :";
            // 
            // groupBox_Messages
            // 
            this.groupBox_Messages.Controls.Add(this.dataGridView1);
            this.groupBox_Messages.Location = new System.Drawing.Point(40, 247);
            this.groupBox_Messages.Name = "groupBox_Messages";
            this.groupBox_Messages.Size = new System.Drawing.Size(331, 414);
            this.groupBox_Messages.TabIndex = 13;
            this.groupBox_Messages.TabStop = false;
            this.groupBox_Messages.Text = "Messages";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 37);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(300, 360);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox_Details
            // 
            this.groupBox_Details.Controls.Add(this.textBox_Seen);
            this.groupBox_Details.Controls.Add(this.textBox_Type);
            this.groupBox_Details.Controls.Add(this.label_Seen);
            this.groupBox_Details.Controls.Add(this.label_Type);
            this.groupBox_Details.Controls.Add(this.textBox_Message);
            this.groupBox_Details.Controls.Add(this.label_Message);
            this.groupBox_Details.Controls.Add(this.textBox_From);
            this.groupBox_Details.Controls.Add(this.label_From);
            this.groupBox_Details.Controls.Add(this.textBox_DateTime);
            this.groupBox_Details.Controls.Add(this.label_DateTime);
            this.groupBox_Details.Location = new System.Drawing.Point(395, 247);
            this.groupBox_Details.Name = "groupBox_Details";
            this.groupBox_Details.Size = new System.Drawing.Size(291, 414);
            this.groupBox_Details.TabIndex = 14;
            this.groupBox_Details.TabStop = false;
            this.groupBox_Details.Text = "Detail";
            // 
            // textBox_Seen
            // 
            this.textBox_Seen.Location = new System.Drawing.Point(246, 377);
            this.textBox_Seen.Name = "textBox_Seen";
            this.textBox_Seen.ReadOnly = true;
            this.textBox_Seen.Size = new System.Drawing.Size(37, 27);
            this.textBox_Seen.TabIndex = 11;
            // 
            // textBox_Type
            // 
            this.textBox_Type.Location = new System.Drawing.Point(55, 377);
            this.textBox_Type.Name = "textBox_Type";
            this.textBox_Type.ReadOnly = true;
            this.textBox_Type.Size = new System.Drawing.Size(130, 27);
            this.textBox_Type.TabIndex = 10;
            // 
            // label_Seen
            // 
            this.label_Seen.AutoSize = true;
            this.label_Seen.Location = new System.Drawing.Point(198, 379);
            this.label_Seen.Name = "label_Seen";
            this.label_Seen.Size = new System.Drawing.Size(48, 20);
            this.label_Seen.TabIndex = 9;
            this.label_Seen.Text = "Seen :";
            // 
            // label_Type
            // 
            this.label_Type.AutoSize = true;
            this.label_Type.Location = new System.Drawing.Point(5, 379);
            this.label_Type.Name = "label_Type";
            this.label_Type.Size = new System.Drawing.Size(47, 20);
            this.label_Type.TabIndex = 8;
            this.label_Type.Text = "Type :";
            // 
            // textBox_Message
            // 
            this.textBox_Message.Location = new System.Drawing.Point(6, 163);
            this.textBox_Message.Multiline = true;
            this.textBox_Message.Name = "textBox_Message";
            this.textBox_Message.ReadOnly = true;
            this.textBox_Message.Size = new System.Drawing.Size(279, 200);
            this.textBox_Message.TabIndex = 7;
            // 
            // label_Message
            // 
            this.label_Message.AutoSize = true;
            this.label_Message.Location = new System.Drawing.Point(6, 139);
            this.label_Message.Name = "label_Message";
            this.label_Message.Size = new System.Drawing.Size(74, 20);
            this.label_Message.TabIndex = 6;
            this.label_Message.Text = "Message :";
            // 
            // textBox_From
            // 
            this.textBox_From.Location = new System.Drawing.Point(6, 106);
            this.textBox_From.Name = "textBox_From";
            this.textBox_From.ReadOnly = true;
            this.textBox_From.Size = new System.Drawing.Size(279, 27);
            this.textBox_From.TabIndex = 3;
            // 
            // label_From
            // 
            this.label_From.AutoSize = true;
            this.label_From.Location = new System.Drawing.Point(6, 83);
            this.label_From.Name = "label_From";
            this.label_From.Size = new System.Drawing.Size(64, 20);
            this.label_From.TabIndex = 2;
            this.label_From.Text = "User ID :";
            // 
            // textBox_DateTime
            // 
            this.textBox_DateTime.Location = new System.Drawing.Point(6, 51);
            this.textBox_DateTime.Name = "textBox_DateTime";
            this.textBox_DateTime.ReadOnly = true;
            this.textBox_DateTime.Size = new System.Drawing.Size(279, 27);
            this.textBox_DateTime.TabIndex = 1;
            // 
            // label_DateTime
            // 
            this.label_DateTime.AutoSize = true;
            this.label_DateTime.Location = new System.Drawing.Point(6, 28);
            this.label_DateTime.Name = "label_DateTime";
            this.label_DateTime.Size = new System.Drawing.Size(127, 20);
            this.label_DateTime.TabIndex = 0;
            this.label_DateTime.Text = "DateTime (local) :";
            // 
            // Form_MessageLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(720, 700);
            this.Controls.Add(this.groupBox_Details);
            this.Controls.Add(this.groupBox_Messages);
            this.Controls.Add(this.groupBox_Filter);
            this.Controls.Add(this.label_MessageLog);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_MessageLog";
            this.Text = "Form_MessageLog";
            this.groupBox_Filter.ResumeLayout(false);
            this.groupBox_Filter.PerformLayout();
            this.groupBox_Messages.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox_Details.ResumeLayout(false);
            this.groupBox_Details.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_MessageLog;
        private GroupBox groupBox_Filter;
        private DateTimePicker dateTimePicker_Start;
        private Label label_Start;
        private ComboBox comboBox_Users;
        private Label label_User;
        private CheckBox checkBox_All;
        private DateTimePicker dateTimePicker_End;
        private Label label_End;
        private Button button_Find;
        private GroupBox groupBox_Messages;
        private DataGridView dataGridView1;
        private GroupBox groupBox_Details;
        private TextBox textBox_From;
        private Label label_From;
        private TextBox textBox_DateTime;
        private Label label_DateTime;
        private Label label_Seen;
        private Label label_Type;
        private TextBox textBox_Message;
        private Label label_Message;
        private TextBox textBox_Type;
        private TextBox textBox_Seen;
    }
}