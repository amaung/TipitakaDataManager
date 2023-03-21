namespace TipitakaDataManager
{
    partial class Form_ViewSource
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_ViewSource));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_SuttaNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_PageNos = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Left = new System.Windows.Forms.Button();
            this.button_Right = new System.Windows.Forms.Button();
            this.button_Done = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sutta# : ";
            // 
            // textBox_SuttaNo
            // 
            this.textBox_SuttaNo.Location = new System.Drawing.Point(75, 10);
            this.textBox_SuttaNo.Name = "textBox_SuttaNo";
            this.textBox_SuttaNo.Size = new System.Drawing.Size(75, 27);
            this.textBox_SuttaNo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Page# :";
            // 
            // comboBox_PageNos
            // 
            this.comboBox_PageNos.FormattingEnabled = true;
            this.comboBox_PageNos.Location = new System.Drawing.Point(221, 10);
            this.comboBox_PageNos.Name = "comboBox_PageNos";
            this.comboBox_PageNos.Size = new System.Drawing.Size(65, 28);
            this.comboBox_PageNos.TabIndex = 3;
            this.comboBox_PageNos.SelectedIndexChanged += new System.EventHandler(this.comboBox_PageNos_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Location = new System.Drawing.Point(1, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(533, 755);
            this.panel1.TabIndex = 4;
            // 
            // button_Left
            // 
            this.button_Left.Image = global::TipitakaDataManager.Properties.Resources.Left_Arrow20x20;
            this.button_Left.Location = new System.Drawing.Point(337, 10);
            this.button_Left.Name = "button_Left";
            this.button_Left.Size = new System.Drawing.Size(30, 30);
            this.button_Left.TabIndex = 5;
            this.button_Left.UseVisualStyleBackColor = true;
            this.button_Left.Click += new System.EventHandler(this.button_Left_Click);
            // 
            // button_Right
            // 
            this.button_Right.Image = global::TipitakaDataManager.Properties.Resources.Right_Arrow20x20;
            this.button_Right.Location = new System.Drawing.Point(379, 10);
            this.button_Right.Name = "button_Right";
            this.button_Right.Size = new System.Drawing.Size(30, 30);
            this.button_Right.TabIndex = 6;
            this.button_Right.UseVisualStyleBackColor = true;
            this.button_Right.Click += new System.EventHandler(this.button_Right_Click);
            // 
            // button_Done
            // 
            this.button_Done.Location = new System.Drawing.Point(427, 10);
            this.button_Done.Name = "button_Done";
            this.button_Done.Size = new System.Drawing.Size(55, 30);
            this.button_Done.TabIndex = 7;
            this.button_Done.Text = "Done";
            this.button_Done.UseVisualStyleBackColor = true;
            this.button_Done.Click += new System.EventHandler(this.button_Done_Click);
            // 
            // Form_ViewSource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 691);
            this.Controls.Add(this.button_Done);
            this.Controls.Add(this.button_Right);
            this.Controls.Add(this.button_Left);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.comboBox_PageNos);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_SuttaNo);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_ViewSource";
            this.Text = "Source Page Viewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textBox_SuttaNo;
        private Label label2;
        private ComboBox comboBox_PageNos;
        private Panel panel1;
        private Button button_Left;
        private Button button_Right;
        private Button button_Done;
    }
}