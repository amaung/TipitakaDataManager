namespace TipitakaDataManager
{
    partial class Form_UpdateHistory
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
            this.label_UpdateHistory = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button_Find = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Suttas = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_UserID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Pages = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_UpdateHistory
            // 
            this.label_UpdateHistory.AutoSize = true;
            this.label_UpdateHistory.BackColor = System.Drawing.Color.OldLace;
            this.label_UpdateHistory.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_UpdateHistory.Location = new System.Drawing.Point(244, 35);
            this.label_UpdateHistory.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label_UpdateHistory.Name = "label_UpdateHistory";
            this.label_UpdateHistory.Size = new System.Drawing.Size(231, 40);
            this.label_UpdateHistory.TabIndex = 14;
            this.label_UpdateHistory.Text = "Update History";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button_Find);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBox_Suttas);
            this.groupBox1.Location = new System.Drawing.Point(56, 92);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(612, 72);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Sutta";
            // 
            // button_Find
            // 
            this.button_Find.Location = new System.Drawing.Point(522, 27);
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
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Sutta :";
            // 
            // comboBox_Suttas
            // 
            this.comboBox_Suttas.FormattingEnabled = true;
            this.comboBox_Suttas.Location = new System.Drawing.Point(78, 26);
            this.comboBox_Suttas.Name = "comboBox_Suttas";
            this.comboBox_Suttas.Size = new System.Drawing.Size(393, 28);
            this.comboBox_Suttas.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(13, 77);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(586, 405);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_UserID);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.comboBox_Pages);
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(56, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(612, 501);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Update History";
            // 
            // textBox_UserID
            // 
            this.textBox_UserID.Location = new System.Drawing.Point(258, 30);
            this.textBox_UserID.Name = "textBox_UserID";
            this.textBox_UserID.ReadOnly = true;
            this.textBox_UserID.Size = new System.Drawing.Size(339, 27);
            this.textBox_UserID.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(188, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "User ID :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "Pages :";
            // 
            // comboBox_Pages
            // 
            this.comboBox_Pages.FormattingEnabled = true;
            this.comboBox_Pages.Location = new System.Drawing.Point(83, 30);
            this.comboBox_Pages.Name = "comboBox_Pages";
            this.comboBox_Pages.Size = new System.Drawing.Size(74, 28);
            this.comboBox_Pages.TabIndex = 22;
            this.comboBox_Pages.SelectedIndexChanged += new System.EventHandler(this.comboBox_Pages_SelectedIndexChanged);
            // 
            // Form_UpdateHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.OldLace;
            this.ClientSize = new System.Drawing.Size(720, 700);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label_UpdateHistory);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_UpdateHistory";
            this.Text = "Form_UpdateHistory";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label label_UpdateHistory;
        private GroupBox groupBox1;
        private Button button_Find;
        private Label label1;
        private ComboBox comboBox_Suttas;
        private DataGridView dataGridView1;
        private GroupBox groupBox2;
        private TextBox textBox_UserID;
        private Label label3;
        private Label label2;
        private ComboBox comboBox_Pages;
    }
}