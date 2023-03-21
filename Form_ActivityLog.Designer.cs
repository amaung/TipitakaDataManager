namespace TipitakaDataManager
{
    partial class Form_ActivityLog
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
            this.label_MainTitle = new System.Windows.Forms.Label();
            this.groupBox_Filter = new System.Windows.Forms.GroupBox();
            this.button_Find = new System.Windows.Forms.Button();
            this.comboBox_Users = new System.Windows.Forms.ComboBox();
            this.label_User = new System.Windows.Forms.Label();
            this.checkBox_All = new System.Windows.Forms.CheckBox();
            this.dateTimePicker_End = new System.Windows.Forms.DateTimePicker();
            this.label_End = new System.Windows.Forms.Label();
            this.dateTimePicker_Start = new System.Windows.Forms.DateTimePicker();
            this.label_Start = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_ActivityCount = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox_Filter.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_MainTitle
            // 
            this.label_MainTitle.AutoSize = true;
            this.label_MainTitle.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_MainTitle.Location = new System.Drawing.Point(249, 40);
            this.label_MainTitle.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_MainTitle.Name = "label_MainTitle";
            this.label_MainTitle.Size = new System.Drawing.Size(191, 40);
            this.label_MainTitle.TabIndex = 21;
            this.label_MainTitle.Text = "Activity Log";
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
            this.groupBox_Filter.TabIndex = 22;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label_ActivityCount);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(40, 247);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(646, 418);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Activities";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total Found :";
            // 
            // label_ActivityCount
            // 
            this.label_ActivityCount.AutoSize = true;
            this.label_ActivityCount.Location = new System.Drawing.Point(322, 20);
            this.label_ActivityCount.Name = "label_ActivityCount";
            this.label_ActivityCount.Size = new System.Drawing.Size(17, 20);
            this.label_ActivityCount.TabIndex = 1;
            this.label_ActivityCount.Text = "0";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 53);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(615, 342);
            this.dataGridView1.TabIndex = 0;
            // 
            // Form_ActivityLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(726, 700);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox_Filter);
            this.Controls.Add(this.label_MainTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_ActivityLog";
            this.Text = "Form_ActivityLog";
            this.groupBox_Filter.ResumeLayout(false);
            this.groupBox_Filter.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_MainTitle;
        private GroupBox groupBox_Filter;
        private Button button_Find;
        private ComboBox comboBox_Users;
        private Label label_User;
        private CheckBox checkBox_All;
        private DateTimePicker dateTimePicker_End;
        private Label label_End;
        private DateTimePicker dateTimePicker_Start;
        private Label label_Start;
        private GroupBox groupBox1;
        private DataGridView dataGridView1;
        private Label label_ActivityCount;
        private Label label1;
    }
}