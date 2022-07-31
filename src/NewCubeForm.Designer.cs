namespace Hypercube
{
    partial class NewCubeForm
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
            this.components = new System.ComponentModel.Container();
            this.cubeNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.setListBox = new System.Windows.Forms.ListBox();
            this.expansionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.setFilterTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.expansionBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cubeNameTextBox
            // 
            this.cubeNameTextBox.Location = new System.Drawing.Point(108, 6);
            this.cubeNameTextBox.Name = "cubeNameTextBox";
            this.cubeNameTextBox.Size = new System.Drawing.Size(290, 27);
            this.cubeNameTextBox.TabIndex = 1;
            this.cubeNameTextBox.TextChanged += new System.EventHandler(this.CubeNameTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cube &Name:";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Enabled = false;
            this.okButton.Location = new System.Drawing.Point(307, 393);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(94, 29);
            this.okButton.TabIndex = 10;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.BackColor = System.Drawing.SystemColors.Control;
            this.cancelButton.Location = new System.Drawing.Point(207, 393);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(94, 29);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "&Template:";
            // 
            // setListBox
            // 
            this.setListBox.DisplayMember = "Name";
            this.setListBox.FormattingEnabled = true;
            this.setListBox.ItemHeight = 20;
            this.setListBox.Location = new System.Drawing.Point(12, 119);
            this.setListBox.Name = "setListBox";
            this.setListBox.Size = new System.Drawing.Size(386, 264);
            this.setListBox.TabIndex = 4;
            this.setListBox.ValueMember = "Code";
            this.setListBox.SelectedIndexChanged += new System.EventHandler(this.SetListBox_SelectedIndexChanged);
            // 
            // expansionBindingSource
            // 
            this.expansionBindingSource.DataSource = typeof(Hypercube.Scryfall.Expansion);
            // 
            // setFilterTextBox
            // 
            this.setFilterTextBox.Location = new System.Drawing.Point(12, 84);
            this.setFilterTextBox.Name = "setFilterTextBox";
            this.setFilterTextBox.Size = new System.Drawing.Size(389, 27);
            this.setFilterTextBox.TabIndex = 3;
            this.setFilterTextBox.TextChanged += new System.EventHandler(this.SetFilterTextBox_TextChanged);
            // 
            // NewCubeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 434);
            this.Controls.Add(this.setFilterTextBox);
            this.Controls.Add(this.setListBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cubeNameTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NewCubeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Cube";
            this.Load += new System.EventHandler(this.NewCubeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.expansionBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox cubeNameTextBox;
        private Label label1;
        private Button okButton;
        private Button cancelButton;
        private Label label2;
        private ListBox setListBox;
        private BindingSource expansionBindingSource;
        private TextBox setFilterTextBox;
    }
}