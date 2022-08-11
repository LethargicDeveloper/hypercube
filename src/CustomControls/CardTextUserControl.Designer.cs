namespace Hypercube
{
    partial class CardTextUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cardTextBox = new System.Windows.Forms.TextBox();
            this.powerTextBox = new System.Windows.Forms.TextBox();
            this.toughnessTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.hasPowerAndToughnessCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cardTextBox
            // 
            this.cardTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardTextBox.Location = new System.Drawing.Point(0, 0);
            this.cardTextBox.Multiline = true;
            this.cardTextBox.Name = "cardTextBox";
            this.cardTextBox.Size = new System.Drawing.Size(306, 242);
            this.cardTextBox.TabIndex = 28;
            this.cardTextBox.TextChanged += new System.EventHandler(this.CardTextBox_TextChanged);
            // 
            // powerTextBox
            // 
            this.powerTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.powerTextBox.Location = new System.Drawing.Point(81, 9);
            this.powerTextBox.MaxLength = 3;
            this.powerTextBox.Name = "powerTextBox";
            this.powerTextBox.Size = new System.Drawing.Size(100, 23);
            this.powerTextBox.TabIndex = 33;
            this.powerTextBox.TextChanged += new System.EventHandler(this.PowerTextBox_TextChanged);
            // 
            // toughnessTextBox
            // 
            this.toughnessTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toughnessTextBox.Location = new System.Drawing.Point(203, 9);
            this.toughnessTextBox.MaxLength = 3;
            this.toughnessTextBox.Name = "toughnessTextBox";
            this.toughnessTextBox.Size = new System.Drawing.Size(100, 23);
            this.toughnessTextBox.TabIndex = 34;
            this.toughnessTextBox.TextChanged += new System.EventHandler(this.ToughnessTextBox_TextChanged);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(187, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(12, 15);
            this.label11.TabIndex = 31;
            this.label11.Text = "/";
            // 
            // hasPowerAndToughnessCheckBox
            // 
            this.hasPowerAndToughnessCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.hasPowerAndToughnessCheckBox.AutoSize = true;
            this.hasPowerAndToughnessCheckBox.Location = new System.Drawing.Point(60, 13);
            this.hasPowerAndToughnessCheckBox.Name = "hasPowerAndToughnessCheckBox";
            this.hasPowerAndToughnessCheckBox.Size = new System.Drawing.Size(15, 14);
            this.hasPowerAndToughnessCheckBox.TabIndex = 32;
            this.hasPowerAndToughnessCheckBox.UseVisualStyleBackColor = true;
            this.hasPowerAndToughnessCheckBox.CheckedChanged += new System.EventHandler(this.HasPowerAndToughnessCheckBox_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toughnessTextBox);
            this.panel1.Controls.Add(this.powerTextBox);
            this.panel1.Controls.Add(this.hasPowerAndToughnessCheckBox);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 207);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 35);
            this.panel1.TabIndex = 35;
            // 
            // CardTextUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cardTextBox);
            this.Name = "CardTextUserControl";
            this.Size = new System.Drawing.Size(306, 242);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox cardTextBox;
        private TextBox powerTextBox;
        private TextBox toughnessTextBox;
        private Label label11;
        private CheckBox hasPowerAndToughnessCheckBox;
        private Panel panel1;
    }
}
