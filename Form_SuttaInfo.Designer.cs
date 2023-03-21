namespace TipitakaDataManager
{
    partial class Form_SuttaInfo
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
            label_SuttaInfo = new Label();
            groupBox1 = new GroupBox();
            textBox_SelVerified = new TextBox();
            textBox_SelSubmitted = new TextBox();
            textBox_SelAssigned = new TextBox();
            textBox_SelPages = new TextBox();
            textBox_SelSuttaNo = new TextBox();
            label6 = new Label();
            label3 = new Label();
            textBox_TotalVerified = new TextBox();
            textBox_TotalSubmitted = new TextBox();
            textBox_TotalAssigned = new TextBox();
            textBox_TotalPages = new TextBox();
            textBox_TotalSutta = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label_Assigned = new Label();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            button_Download = new Button();
            button_View = new Button();
            button_ViewSource = new Button();
            button_Refresh = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label_SuttaInfo
            // 
            label_SuttaInfo.AutoSize = true;
            label_SuttaInfo.BackColor = Color.OldLace;
            label_SuttaInfo.Font = new Font("Times New Roman", 26.25F, FontStyle.Regular, GraphicsUnit.Point);
            label_SuttaInfo.Location = new Point(194, 22);
            label_SuttaInfo.Margin = new Padding(4, 0, 4, 0);
            label_SuttaInfo.Name = "label_SuttaInfo";
            label_SuttaInfo.Size = new Size(243, 40);
            label_SuttaInfo.TabIndex = 11;
            label_SuttaInfo.Text = "Sutta Page Data";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox_SelVerified);
            groupBox1.Controls.Add(textBox_SelSubmitted);
            groupBox1.Controls.Add(textBox_SelAssigned);
            groupBox1.Controls.Add(textBox_SelPages);
            groupBox1.Controls.Add(textBox_SelSuttaNo);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBox_TotalVerified);
            groupBox1.Controls.Add(textBox_TotalSubmitted);
            groupBox1.Controls.Add(textBox_TotalAssigned);
            groupBox1.Controls.Add(textBox_TotalPages);
            groupBox1.Controls.Add(textBox_TotalSutta);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label_Assigned);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Location = new Point(20, 61);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(582, 88);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "General Stats";
            // 
            // textBox_SelVerified
            // 
            textBox_SelVerified.BackColor = SystemColors.GradientInactiveCaption;
            textBox_SelVerified.Enabled = false;
            textBox_SelVerified.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_SelVerified.Location = new Point(482, 57);
            textBox_SelVerified.Margin = new Padding(3, 2, 3, 2);
            textBox_SelVerified.Name = "textBox_SelVerified";
            textBox_SelVerified.ReadOnly = true;
            textBox_SelVerified.Size = new Size(79, 27);
            textBox_SelVerified.TabIndex = 16;
            textBox_SelVerified.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox_SelSubmitted
            // 
            textBox_SelSubmitted.BackColor = SystemColors.GradientInactiveCaption;
            textBox_SelSubmitted.Enabled = false;
            textBox_SelSubmitted.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_SelSubmitted.Location = new Point(386, 57);
            textBox_SelSubmitted.Margin = new Padding(3, 2, 3, 2);
            textBox_SelSubmitted.Name = "textBox_SelSubmitted";
            textBox_SelSubmitted.ReadOnly = true;
            textBox_SelSubmitted.Size = new Size(79, 27);
            textBox_SelSubmitted.TabIndex = 15;
            textBox_SelSubmitted.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox_SelAssigned
            // 
            textBox_SelAssigned.BackColor = SystemColors.GradientInactiveCaption;
            textBox_SelAssigned.Enabled = false;
            textBox_SelAssigned.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_SelAssigned.Location = new Point(287, 57);
            textBox_SelAssigned.Margin = new Padding(3, 2, 3, 2);
            textBox_SelAssigned.Name = "textBox_SelAssigned";
            textBox_SelAssigned.ReadOnly = true;
            textBox_SelAssigned.Size = new Size(79, 27);
            textBox_SelAssigned.TabIndex = 14;
            textBox_SelAssigned.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox_SelPages
            // 
            textBox_SelPages.BackColor = SystemColors.GradientInactiveCaption;
            textBox_SelPages.Enabled = false;
            textBox_SelPages.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_SelPages.Location = new Point(189, 57);
            textBox_SelPages.Margin = new Padding(3, 2, 3, 2);
            textBox_SelPages.Name = "textBox_SelPages";
            textBox_SelPages.ReadOnly = true;
            textBox_SelPages.Size = new Size(79, 27);
            textBox_SelPages.TabIndex = 13;
            textBox_SelPages.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox_SelSuttaNo
            // 
            textBox_SelSuttaNo.BackColor = SystemColors.GradientInactiveCaption;
            textBox_SelSuttaNo.Enabled = false;
            textBox_SelSuttaNo.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_SelSuttaNo.Location = new Point(90, 56);
            textBox_SelSuttaNo.Margin = new Padding(3, 2, 3, 2);
            textBox_SelSuttaNo.Name = "textBox_SelSuttaNo";
            textBox_SelSuttaNo.ReadOnly = true;
            textBox_SelSuttaNo.Size = new Size(79, 27);
            textBox_SelSuttaNo.TabIndex = 12;
            textBox_SelSuttaNo.TextAlign = HorizontalAlignment.Center;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 59);
            label6.Name = "label6";
            label6.Size = new Size(57, 15);
            label6.TabIndex = 11;
            label6.Text = "Selected :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 35);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 10;
            label3.Text = "Total :";
            // 
            // textBox_TotalVerified
            // 
            textBox_TotalVerified.BackColor = SystemColors.GradientInactiveCaption;
            textBox_TotalVerified.Enabled = false;
            textBox_TotalVerified.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_TotalVerified.Location = new Point(482, 32);
            textBox_TotalVerified.Margin = new Padding(3, 2, 3, 2);
            textBox_TotalVerified.Name = "textBox_TotalVerified";
            textBox_TotalVerified.ReadOnly = true;
            textBox_TotalVerified.Size = new Size(79, 27);
            textBox_TotalVerified.TabIndex = 9;
            textBox_TotalVerified.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox_TotalSubmitted
            // 
            textBox_TotalSubmitted.BackColor = SystemColors.GradientInactiveCaption;
            textBox_TotalSubmitted.Enabled = false;
            textBox_TotalSubmitted.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_TotalSubmitted.Location = new Point(386, 32);
            textBox_TotalSubmitted.Margin = new Padding(3, 2, 3, 2);
            textBox_TotalSubmitted.Name = "textBox_TotalSubmitted";
            textBox_TotalSubmitted.ReadOnly = true;
            textBox_TotalSubmitted.Size = new Size(79, 27);
            textBox_TotalSubmitted.TabIndex = 8;
            textBox_TotalSubmitted.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox_TotalAssigned
            // 
            textBox_TotalAssigned.BackColor = SystemColors.GradientInactiveCaption;
            textBox_TotalAssigned.Enabled = false;
            textBox_TotalAssigned.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_TotalAssigned.Location = new Point(287, 32);
            textBox_TotalAssigned.Margin = new Padding(3, 2, 3, 2);
            textBox_TotalAssigned.Name = "textBox_TotalAssigned";
            textBox_TotalAssigned.ReadOnly = true;
            textBox_TotalAssigned.Size = new Size(79, 27);
            textBox_TotalAssigned.TabIndex = 7;
            textBox_TotalAssigned.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox_TotalPages
            // 
            textBox_TotalPages.BackColor = SystemColors.GradientInactiveCaption;
            textBox_TotalPages.Enabled = false;
            textBox_TotalPages.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_TotalPages.Location = new Point(189, 32);
            textBox_TotalPages.Margin = new Padding(3, 2, 3, 2);
            textBox_TotalPages.Name = "textBox_TotalPages";
            textBox_TotalPages.ReadOnly = true;
            textBox_TotalPages.Size = new Size(79, 27);
            textBox_TotalPages.TabIndex = 6;
            textBox_TotalPages.TextAlign = HorizontalAlignment.Center;
            // 
            // textBox_TotalSutta
            // 
            textBox_TotalSutta.BackColor = SystemColors.GradientInactiveCaption;
            textBox_TotalSutta.Enabled = false;
            textBox_TotalSutta.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            textBox_TotalSutta.Location = new Point(90, 32);
            textBox_TotalSutta.Margin = new Padding(3, 2, 3, 2);
            textBox_TotalSutta.Name = "textBox_TotalSutta";
            textBox_TotalSutta.ReadOnly = true;
            textBox_TotalSutta.Size = new Size(79, 27);
            textBox_TotalSutta.TabIndex = 5;
            textBox_TotalSutta.TextAlign = HorizontalAlignment.Center;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(495, 15);
            label5.Name = "label5";
            label5.Size = new Size(46, 15);
            label5.TabIndex = 4;
            label5.Text = "Verified";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(391, 16);
            label4.Name = "label4";
            label4.Size = new Size(62, 15);
            label4.TabIndex = 3;
            label4.Text = "Submitted";
            // 
            // label_Assigned
            // 
            label_Assigned.AutoSize = true;
            label_Assigned.Location = new Point(295, 15);
            label_Assigned.Name = "label_Assigned";
            label_Assigned.Size = new Size(55, 15);
            label_Assigned.TabIndex = 2;
            label_Assigned.Text = "Assigned";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(206, 15);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 1;
            label2.Text = "Pages";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(106, 15);
            label1.Name = "label1";
            label1.Size = new Size(41, 15);
            label1.TabIndex = 0;
            label1.Text = "Sutta#";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(20, 154);
            groupBox2.Margin = new Padding(3, 2, 3, 2);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 2, 3, 2);
            groupBox2.Size = new Size(582, 328);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            groupBox2.Text = "Sutta Info";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(18, 26);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(542, 286);
            dataGridView1.TabIndex = 0;
            // 
            // button_Download
            // 
            button_Download.Location = new Point(192, 490);
            button_Download.Margin = new Padding(3, 2, 3, 2);
            button_Download.Name = "button_Download";
            button_Download.Size = new Size(88, 24);
            button_Download.TabIndex = 14;
            button_Download.Text = "Download";
            button_Download.UseVisualStyleBackColor = true;
            button_Download.Click += button_Download_Click;
            // 
            // button_View
            // 
            button_View.Location = new Point(481, 490);
            button_View.Margin = new Padding(3, 2, 3, 2);
            button_View.Name = "button_View";
            button_View.Size = new Size(88, 24);
            button_View.TabIndex = 15;
            button_View.Text = "View";
            button_View.UseVisualStyleBackColor = true;
            button_View.Click += button_View_Click;
            // 
            // button_ViewSource
            // 
            button_ViewSource.Location = new Point(337, 490);
            button_ViewSource.Margin = new Padding(3, 2, 3, 2);
            button_ViewSource.Name = "button_ViewSource";
            button_ViewSource.Size = new Size(88, 24);
            button_ViewSource.TabIndex = 16;
            button_ViewSource.Text = "View Source";
            button_ViewSource.UseVisualStyleBackColor = true;
            button_ViewSource.Click += button_ViewSource_Click;
            // 
            // button_Refresh
            // 
            button_Refresh.Location = new Point(49, 490);
            button_Refresh.Margin = new Padding(3, 2, 3, 2);
            button_Refresh.Name = "button_Refresh";
            button_Refresh.Size = new Size(88, 24);
            button_Refresh.TabIndex = 17;
            button_Refresh.Text = "Refresh";
            button_Refresh.UseVisualStyleBackColor = true;
            button_Refresh.Click += button_Refresh_Click;
            // 
            // Form_SuttaInfo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.OldLace;
            ClientSize = new Size(630, 525);
            Controls.Add(button_Refresh);
            Controls.Add(button_ViewSource);
            Controls.Add(button_View);
            Controls.Add(button_Download);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(label_SuttaInfo);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form_SuttaInfo";
            Text = "Form_SuttaInfo";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_SuttaInfo;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private TextBox textBox_TotalAssigned;
        private TextBox textBox_TotalPages;
        private TextBox textBox_TotalSutta;
        private Label label5;
        private Label label4;
        private Label label_Assigned;
        private Label label2;
        private Label label1;
        private TextBox textBox_TotalSubmitted;
        private TextBox textBox_TotalVerified;
        private Label label6;
        private Label label3;
        private TextBox textBox_SelSuttaNo;
        private TextBox textBox_SelVerified;
        private TextBox textBox_SelSubmitted;
        private TextBox textBox_SelAssigned;
        private TextBox textBox_SelPages;
        private Button button_Download;
        private Button button_View;
        private Button button_ViewSource;
        private Button button_Refresh;
    }
}