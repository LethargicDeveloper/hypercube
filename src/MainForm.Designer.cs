namespace Hypercube;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCubeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCubeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.expansionCardPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cubeNameLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.expansionNameLabel = new System.Windows.Forms.Label();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expansionCardPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(1228, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCubeToolStripMenuItem,
            this.openCubeToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newCubeToolStripMenuItem
            // 
            this.newCubeToolStripMenuItem.Name = "newCubeToolStripMenuItem";
            this.newCubeToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.newCubeToolStripMenuItem.Text = "&New Cube...";
            this.newCubeToolStripMenuItem.Click += new System.EventHandler(this.NewCubeToolStripMenuItem_Click);
            // 
            // openCubeToolStripMenuItem
            // 
            this.openCubeToolStripMenuItem.Name = "openCubeToolStripMenuItem";
            this.openCubeToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openCubeToolStripMenuItem.Text = "&Open Cube...";
            this.openCubeToolStripMenuItem.Click += new System.EventHandler(this.OpenCubeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(140, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // expansionCardPictureBox
            // 
            this.expansionCardPictureBox.Location = new System.Drawing.Point(12, 113);
            this.expansionCardPictureBox.Name = "expansionCardPictureBox";
            this.expansionCardPictureBox.Size = new System.Drawing.Size(336, 536);
            this.expansionCardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.expansionCardPictureBox.TabIndex = 1;
            this.expansionCardPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(52, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cube:";
            // 
            // cubeNameLabel
            // 
            this.cubeNameLabel.AutoSize = true;
            this.cubeNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cubeNameLabel.Location = new System.Drawing.Point(121, 50);
            this.cubeNameLabel.Name = "cubeNameLabel";
            this.cubeNameLabel.Size = new System.Drawing.Size(92, 21);
            this.cubeNameLabel.TabIndex = 3;
            this.cubeNameLabel.Text = "Cube Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Expansion:";
            // 
            // expansionNameLabel
            // 
            this.expansionNameLabel.AutoSize = true;
            this.expansionNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.expansionNameLabel.Location = new System.Drawing.Point(121, 71);
            this.expansionNameLabel.Name = "expansionNameLabel";
            this.expansionNameLabel.Size = new System.Drawing.Size(126, 21);
            this.expansionNameLabel.TabIndex = 5;
            this.expansionNameLabel.Text = "Expansion Name";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1228, 684);
            this.Controls.Add(this.expansionNameLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cubeNameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.expansionCardPictureBox);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magic The Gathering: Hypercube";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expansionCardPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private MenuStrip menuStrip;
    private ToolStripMenuItem fileToolStripMenuItem;
    private ToolStripMenuItem newCubeToolStripMenuItem;
    private ToolStripMenuItem openCubeToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripMenuItem exitToolStripMenuItem;
    private FolderBrowserDialog folderBrowserDialog;
    private PictureBox expansionCardPictureBox;
    private Label label1;
    private Label cubeNameLabel;
    private Label label2;
    private Label expansionNameLabel;
}
