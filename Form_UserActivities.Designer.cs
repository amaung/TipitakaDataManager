namespace TipitakaDataManager
{
    partial class Form_UserActivities
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
            this.label_UserActivities = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_Find = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_AllUsers = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_VerifiedPercent = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_Verified = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_SubmittedPercent = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Updated = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Submitted = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Downloaded = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_Assigned = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Total = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_UserActivities
            // 
            this.label_UserActivities.AutoSize = true;
            this.label_UserActivities.BackColor = System.Drawing.Color.OldLace;
            this.label_UserActivities.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_UserActivities.Location = new System.Drawing.Point(244, 35);
            this.label_UserActivities.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_UserActivities.Name = "label_UserActivities";
            this.label_UserActivities.Size = new System.Drawing.Size(220, 40);
            this.label_UserActivities.TabIndex = 12;
            this.label_UserActivities.Text = "User Activities";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_Find);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox_AllUsers);
            this.groupBox1.Location = new System.Drawing.Point(55, 91);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(612, 78);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select User";
            // 
            // button_Find
            // 
            this.button_Find.Location = new System.Drawing.Point(512, 28);
            this.button_Find.Name = "button_Find";
            this.button_Find.Size = new System.Drawing.Size(75, 28);
            this.button_Find.TabIndex = 19;
            this.button_Find.Text = "Find";
            this.button_Find.UseVisualStyleBackColor = true;
            this.button_Find.Click += new System.EventHandler(this.button_Find_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "User ID :";
            // 
            // comboBox_AllUsers
            // 
            this.comboBox_AllUsers.FormattingEnabled = true;
            this.comboBox_AllUsers.Location = new System.Drawing.Point(78, 26);
            this.comboBox_AllUsers.Name = "comboBox_AllUsers";
            this.comboBox_AllUsers.Size = new System.Drawing.Size(409, 28);
            this.comboBox_AllUsers.TabIndex = 5;
            this.comboBox_AllUsers.SelectedIndexChanged += new System.EventHandler(this.comboBox_AllUsers_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(55, 284);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(612, 396);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "User Activities";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(586, 342);
            this.dataGridView1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_VerifiedPercent);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.textBox_Verified);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.textBox_SubmittedPercent);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textBox_Updated);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBox_Submitted);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.textBox_Downloaded);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBox_Assigned);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBox_Total);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Location = new System.Drawing.Point(55, 175);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(612, 101);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Statistics";
            // 
            // textBox_VerifiedPercent
            // 
            this.textBox_VerifiedPercent.Location = new System.Drawing.Point(546, 56);
            this.textBox_VerifiedPercent.Name = "textBox_VerifiedPercent";
            this.textBox_VerifiedPercent.Size = new System.Drawing.Size(50, 27);
            this.textBox_VerifiedPercent.TabIndex = 34;
            this.textBox_VerifiedPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(468, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 20);
            this.label9.TabIndex = 33;
            this.label9.Text = "Verified%";
            // 
            // textBox_Verified
            // 
            this.textBox_Verified.Location = new System.Drawing.Point(388, 56);
            this.textBox_Verified.Name = "textBox_Verified";
            this.textBox_Verified.Size = new System.Drawing.Size(50, 27);
            this.textBox_Verified.TabIndex = 32;
            this.textBox_Verified.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(322, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 20);
            this.label8.TabIndex = 31;
            this.label8.Text = "Verified";
            // 
            // textBox_SubmittedPercent
            // 
            this.textBox_SubmittedPercent.Location = new System.Drawing.Point(546, 24);
            this.textBox_SubmittedPercent.Name = "textBox_SubmittedPercent";
            this.textBox_SubmittedPercent.Size = new System.Drawing.Size(50, 27);
            this.textBox_SubmittedPercent.TabIndex = 30;
            this.textBox_SubmittedPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(450, 29);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 20);
            this.label7.TabIndex = 29;
            this.label7.Text = "Submitted%";
            // 
            // textBox_Updated
            // 
            this.textBox_Updated.Location = new System.Drawing.Point(240, 56);
            this.textBox_Updated.Name = "textBox_Updated";
            this.textBox_Updated.Size = new System.Drawing.Size(50, 27);
            this.textBox_Updated.TabIndex = 28;
            this.textBox_Updated.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(167, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 20);
            this.label6.TabIndex = 27;
            this.label6.Text = "Updated";
            // 
            // textBox_Submitted
            // 
            this.textBox_Submitted.Location = new System.Drawing.Point(388, 24);
            this.textBox_Submitted.Name = "textBox_Submitted";
            this.textBox_Submitted.Size = new System.Drawing.Size(50, 27);
            this.textBox_Submitted.TabIndex = 26;
            this.textBox_Submitted.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(304, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.TabIndex = 25;
            this.label5.Text = "Submitted";
            // 
            // textBox_Downloaded
            // 
            this.textBox_Downloaded.Location = new System.Drawing.Point(240, 24);
            this.textBox_Downloaded.Name = "textBox_Downloaded";
            this.textBox_Downloaded.Size = new System.Drawing.Size(50, 27);
            this.textBox_Downloaded.TabIndex = 24;
            this.textBox_Downloaded.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(141, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 20);
            this.label4.TabIndex = 23;
            this.label4.Text = "Downloaded";
            // 
            // textBox_Assigned
            // 
            this.textBox_Assigned.Location = new System.Drawing.Point(83, 56);
            this.textBox_Assigned.Name = "textBox_Assigned";
            this.textBox_Assigned.Size = new System.Drawing.Size(50, 27);
            this.textBox_Assigned.TabIndex = 22;
            this.textBox_Assigned.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 21;
            this.label3.Text = "Assigned";
            // 
            // textBox_Total
            // 
            this.textBox_Total.Location = new System.Drawing.Point(83, 24);
            this.textBox_Total.Name = "textBox_Total";
            this.textBox_Total.Size = new System.Drawing.Size(50, 27);
            this.textBox_Total.TabIndex = 20;
            this.textBox_Total.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Total";
            // 
            // Form_UserActivities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(720, 700);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_UserActivities);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_UserActivities";
            this.Text = "Form_UserActivities";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label_UserActivities;
        private GroupBox groupBox1;
        private Label label1;
        private ComboBox comboBox_AllUsers;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private Button button_Find;
        private GroupBox groupBox3;
        private TextBox textBox_VerifiedPercent;
        private Label label9;
        private TextBox textBox_Verified;
        private Label label8;
        private TextBox textBox_SubmittedPercent;
        private Label label7;
        private TextBox textBox_Updated;
        private Label label6;
        private TextBox textBox_Submitted;
        private Label label5;
        private TextBox textBox_Downloaded;
        private Label label4;
        private TextBox textBox_Assigned;
        private Label label3;
        private TextBox textBox_Total;
        private Label label2;
    }
}