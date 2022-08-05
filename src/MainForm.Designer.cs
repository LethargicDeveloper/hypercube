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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cardNameTextBox = new System.Windows.Forms.TextBox();
            this.manaCostTextBox = new System.Windows.Forms.TextBox();
            this.manaCostHelpButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.frameComboBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.type1ComboBox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.rarityComboBox = new System.Windows.Forms.ComboBox();
            this.generateButton = new System.Windows.Forms.Button();
            this.supertype1ComboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cardPictureBox = new System.Windows.Forms.PictureBox();
            this.cardTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.hasPowerToughnessCheckBox = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.newCardTabPage = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.supertype2ComboBox = new System.Windows.Forms.ComboBox();
            this.type2ComboBox = new System.Windows.Forms.ComboBox();
            this.type3ComboBox = new System.Windows.Forms.ComboBox();
            this.subtype3ComboBox = new System.Windows.Forms.ComboBox();
            this.subtype2ComboBox = new System.Windows.Forms.ComboBox();
            this.subtype1ComboBox = new System.Windows.Forms.ComboBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expansionCardPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.newCardTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(6, 3, 0, 3);
            this.menuStrip.Size = new System.Drawing.Size(1394, 30);
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
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newCubeToolStripMenuItem
            // 
            this.newCubeToolStripMenuItem.Name = "newCubeToolStripMenuItem";
            this.newCubeToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.newCubeToolStripMenuItem.Text = "&New Cube...";
            this.newCubeToolStripMenuItem.Click += new System.EventHandler(this.NewCubeToolStripMenuItem_Click);
            // 
            // openCubeToolStripMenuItem
            // 
            this.openCubeToolStripMenuItem.Name = "openCubeToolStripMenuItem";
            this.openCubeToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.openCubeToolStripMenuItem.Text = "&Open Cube...";
            this.openCubeToolStripMenuItem.Click += new System.EventHandler(this.OpenCubeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(172, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(175, 26);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // expansionCardPictureBox
            // 
            this.expansionCardPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.expansionCardPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.expansionCardPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.expansionCardPictureBox.Location = new System.Drawing.Point(138, 147);
            this.expansionCardPictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.expansionCardPictureBox.Name = "expansionCardPictureBox";
            this.expansionCardPictureBox.Size = new System.Drawing.Size(293, 476);
            this.expansionCardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.expansionCardPictureBox.TabIndex = 1;
            this.expansionCardPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(528, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cube:";
            // 
            // cubeNameLabel
            // 
            this.cubeNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cubeNameLabel.AutoSize = true;
            this.cubeNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cubeNameLabel.Location = new System.Drawing.Point(607, 52);
            this.cubeNameLabel.Name = "cubeNameLabel";
            this.cubeNameLabel.Size = new System.Drawing.Size(114, 28);
            this.cubeNameLabel.TabIndex = 3;
            this.cubeNameLabel.Text = "Cube Name";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(482, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Expansion:";
            // 
            // expansionNameLabel
            // 
            this.expansionNameLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.expansionNameLabel.AutoSize = true;
            this.expansionNameLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.expansionNameLabel.Location = new System.Drawing.Point(607, 80);
            this.expansionNameLabel.Name = "expansionNameLabel";
            this.expansionNameLabel.Size = new System.Drawing.Size(157, 28);
            this.expansionNameLabel.TabIndex = 5;
            this.expansionNameLabel.Text = "Expansion Name";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(479, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 28);
            this.label3.TabIndex = 6;
            this.label3.Text = "Card &Name:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(485, 196);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 28);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mana &Cost:";
            // 
            // cardNameTextBox
            // 
            this.cardNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cardNameTextBox.Location = new System.Drawing.Point(607, 147);
            this.cardNameTextBox.Name = "cardNameTextBox";
            this.cardNameTextBox.Size = new System.Drawing.Size(363, 27);
            this.cardNameTextBox.TabIndex = 7;
            this.cardNameTextBox.TextChanged += new System.EventHandler(this.CardNameTextBox_TextChanged);
            // 
            // manaCostTextBox
            // 
            this.manaCostTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.manaCostTextBox.Location = new System.Drawing.Point(607, 192);
            this.manaCostTextBox.Name = "manaCostTextBox";
            this.manaCostTextBox.Size = new System.Drawing.Size(329, 27);
            this.manaCostTextBox.TabIndex = 9;
            this.manaCostTextBox.TextChanged += new System.EventHandler(this.ManaCostTextBox_TextChanged);
            // 
            // manaCostHelpButton
            // 
            this.manaCostHelpButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.manaCostHelpButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.manaCostHelpButton.Location = new System.Drawing.Point(942, 185);
            this.manaCostHelpButton.Name = "manaCostHelpButton";
            this.manaCostHelpButton.Size = new System.Drawing.Size(27, 39);
            this.manaCostHelpButton.TabIndex = 0;
            this.manaCostHelpButton.TabStop = false;
            this.manaCostHelpButton.Text = "?";
            this.manaCostHelpButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.manaCostHelpButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(522, 245);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 28);
            this.label5.TabIndex = 10;
            this.label5.Text = "Fra&me:";
            // 
            // frameComboBox
            // 
            this.frameComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.frameComboBox.DisplayMember = "Description";
            this.frameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.frameComboBox.FormattingEnabled = true;
            this.frameComboBox.Location = new System.Drawing.Point(606, 245);
            this.frameComboBox.Name = "frameComboBox";
            this.frameComboBox.Size = new System.Drawing.Size(363, 28);
            this.frameComboBox.TabIndex = 11;
            this.frameComboBox.ValueMember = "Key";
            this.frameComboBox.SelectedIndexChanged += new System.EventHandler(this.FrameComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(535, 344);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 28);
            this.label6.TabIndex = 15;
            this.label6.Text = "&Type:";
            // 
            // type1ComboBox
            // 
            this.type1ComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.type1ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.type1ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.type1ComboBox.FormattingEnabled = true;
            this.type1ComboBox.Location = new System.Drawing.Point(608, 344);
            this.type1ComboBox.Name = "type1ComboBox";
            this.type1ComboBox.Size = new System.Drawing.Size(120, 28);
            this.type1ComboBox.TabIndex = 16;
            this.type1ComboBox.SelectedIndexChanged += new System.EventHandler(this.Type1ComboBox_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(504, 393);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 28);
            this.label7.TabIndex = 19;
            this.label7.Text = "Su&btype:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(525, 443);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 28);
            this.label8.TabIndex = 23;
            this.label8.Text = "&Rarity:";
            // 
            // rarityComboBox
            // 
            this.rarityComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rarityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.rarityComboBox.FormattingEnabled = true;
            this.rarityComboBox.Items.AddRange(new object[] {
            "Common",
            "Uncommon",
            "Rare",
            "Mythic"});
            this.rarityComboBox.Location = new System.Drawing.Point(607, 443);
            this.rarityComboBox.Name = "rarityComboBox";
            this.rarityComboBox.Size = new System.Drawing.Size(363, 28);
            this.rarityComboBox.TabIndex = 24;
            this.rarityComboBox.SelectedIndexChanged += new System.EventHandler(this.RarityComboBox_SelectedIndexChanged);
            // 
            // generateButton
            // 
            this.generateButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.generateButton.Enabled = false;
            this.generateButton.Location = new System.Drawing.Point(607, 874);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(363, 103);
            this.generateButton.TabIndex = 100;
            this.generateButton.Text = "&Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            // 
            // supertype1ComboBox
            // 
            this.supertype1ComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.supertype1ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.supertype1ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.supertype1ComboBox.FormattingEnabled = true;
            this.supertype1ComboBox.Location = new System.Drawing.Point(607, 295);
            this.supertype1ComboBox.Name = "supertype1ComboBox";
            this.supertype1ComboBox.Size = new System.Drawing.Size(178, 28);
            this.supertype1ComboBox.TabIndex = 13;
            this.supertype1ComboBox.SelectedIndexChanged += new System.EventHandler(this.Supertype1ComboBox_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(487, 295);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 28);
            this.label9.TabIndex = 12;
            this.label9.Text = "&Supertype:";
            // 
            // cardPictureBox
            // 
            this.cardPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cardPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.cardPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardPictureBox.Location = new System.Drawing.Point(1014, 147);
            this.cardPictureBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cardPictureBox.Name = "cardPictureBox";
            this.cardPictureBox.Size = new System.Drawing.Size(293, 476);
            this.cardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cardPictureBox.TabIndex = 21;
            this.cardPictureBox.TabStop = false;
            this.cardPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.CardPictureBox_Paint);
            // 
            // cardTextBox
            // 
            this.cardTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardTextBox.Location = new System.Drawing.Point(0, 0);
            this.cardTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cardTextBox.Multiline = true;
            this.cardTextBox.Name = "cardTextBox";
            this.cardTextBox.Size = new System.Drawing.Size(355, 303);
            this.cardTextBox.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(495, 497);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 28);
            this.label10.TabIndex = 25;
            this.label10.Text = "Card Te&xt:";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Location = new System.Drawing.Point(717, 840);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(114, 27);
            this.textBox1.TabIndex = 29;
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox2.Location = new System.Drawing.Point(856, 840);
            this.textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(114, 27);
            this.textBox2.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(838, 844);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(15, 20);
            this.label11.TabIndex = 25;
            this.label11.Text = "/";
            // 
            // hasPowerToughnessCheckBox
            // 
            this.hasPowerToughnessCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hasPowerToughnessCheckBox.AutoSize = true;
            this.hasPowerToughnessCheckBox.Location = new System.Drawing.Point(693, 845);
            this.hasPowerToughnessCheckBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.hasPowerToughnessCheckBox.Name = "hasPowerToughnessCheckBox";
            this.hasPowerToughnessCheckBox.Size = new System.Drawing.Size(18, 17);
            this.hasPowerToughnessCheckBox.TabIndex = 28;
            this.hasPowerToughnessCheckBox.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabControl1.Controls.Add(this.newCardTabPage);
            this.tabControl1.Location = new System.Drawing.Point(607, 497);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(363, 336);
            this.tabControl1.TabIndex = 26;
            // 
            // newCardTabPage
            // 
            this.newCardTabPage.Controls.Add(this.cardTextBox);
            this.newCardTabPage.Location = new System.Drawing.Point(4, 29);
            this.newCardTabPage.Name = "newCardTabPage";
            this.newCardTabPage.Size = new System.Drawing.Size(355, 303);
            this.newCardTabPage.TabIndex = 4;
            this.newCardTabPage.Text = "New Card";
            this.newCardTabPage.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1014, 630);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(293, 347);
            this.flowLayoutPanel1.TabIndex = 31;
            // 
            // supertype2ComboBox
            // 
            this.supertype2ComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.supertype2ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.supertype2ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.supertype2ComboBox.Enabled = false;
            this.supertype2ComboBox.FormattingEnabled = true;
            this.supertype2ComboBox.Location = new System.Drawing.Point(792, 295);
            this.supertype2ComboBox.Name = "supertype2ComboBox";
            this.supertype2ComboBox.Size = new System.Drawing.Size(178, 28);
            this.supertype2ComboBox.TabIndex = 14;
            // 
            // type2ComboBox
            // 
            this.type2ComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.type2ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.type2ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.type2ComboBox.Enabled = false;
            this.type2ComboBox.FormattingEnabled = true;
            this.type2ComboBox.Location = new System.Drawing.Point(729, 344);
            this.type2ComboBox.Name = "type2ComboBox";
            this.type2ComboBox.Size = new System.Drawing.Size(120, 28);
            this.type2ComboBox.TabIndex = 17;
            // 
            // type3ComboBox
            // 
            this.type3ComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.type3ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.type3ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.type3ComboBox.Enabled = false;
            this.type3ComboBox.FormattingEnabled = true;
            this.type3ComboBox.Location = new System.Drawing.Point(850, 344);
            this.type3ComboBox.Name = "type3ComboBox";
            this.type3ComboBox.Size = new System.Drawing.Size(120, 28);
            this.type3ComboBox.TabIndex = 18;
            // 
            // subtype3ComboBox
            // 
            this.subtype3ComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.subtype3ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.subtype3ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.subtype3ComboBox.Enabled = false;
            this.subtype3ComboBox.FormattingEnabled = true;
            this.subtype3ComboBox.Location = new System.Drawing.Point(850, 393);
            this.subtype3ComboBox.Name = "subtype3ComboBox";
            this.subtype3ComboBox.Size = new System.Drawing.Size(120, 28);
            this.subtype3ComboBox.TabIndex = 22;
            // 
            // subtype2ComboBox
            // 
            this.subtype2ComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.subtype2ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.subtype2ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.subtype2ComboBox.Enabled = false;
            this.subtype2ComboBox.FormattingEnabled = true;
            this.subtype2ComboBox.Location = new System.Drawing.Point(729, 393);
            this.subtype2ComboBox.Name = "subtype2ComboBox";
            this.subtype2ComboBox.Size = new System.Drawing.Size(120, 28);
            this.subtype2ComboBox.TabIndex = 21;
            // 
            // subtype1ComboBox
            // 
            this.subtype1ComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.subtype1ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.subtype1ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.subtype1ComboBox.FormattingEnabled = true;
            this.subtype1ComboBox.Location = new System.Drawing.Point(608, 393);
            this.subtype1ComboBox.Name = "subtype1ComboBox";
            this.subtype1ComboBox.Size = new System.Drawing.Size(120, 28);
            this.subtype1ComboBox.TabIndex = 20;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1394, 993);
            this.Controls.Add(this.subtype3ComboBox);
            this.Controls.Add(this.subtype2ComboBox);
            this.Controls.Add(this.subtype1ComboBox);
            this.Controls.Add(this.type3ComboBox);
            this.Controls.Add(this.type2ComboBox);
            this.Controls.Add(this.supertype2ComboBox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.hasPowerToughnessCheckBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cardPictureBox);
            this.Controls.Add(this.supertype1ComboBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.rarityComboBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.type1ComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.frameComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.manaCostHelpButton);
            this.Controls.Add(this.manaCostTextBox);
            this.Controls.Add(this.cardNameTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.expansionNameLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cubeNameLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.expansionCardPictureBox);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Magic The Gathering: Hypercube";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expansionCardPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.newCardTabPage.ResumeLayout(false);
            this.newCardTabPage.PerformLayout();
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
    private Label label3;
    private Label label4;
    private TextBox cardNameTextBox;
    private TextBox manaCostTextBox;
    private Button manaCostHelpButton;
    private Label label5;
    private ComboBox frameComboBox;
    private Label label6;
    private ComboBox type1ComboBox;
    private Label label7;
    private Label label8;
    private ComboBox rarityComboBox;
    private Button generateButton;
    private ComboBox supertype1ComboBox;
    private Label label9;
    private PictureBox cardPictureBox;
    private TextBox cardTextBox;
    private Label label10;
    private TextBox textBox1;
    private TextBox textBox2;
    private Label label11;
    private CheckBox hasPowerToughnessCheckBox;
    private TabControl tabControl1;
    private TabPage newCardTabPage;
    private FlowLayoutPanel flowLayoutPanel1;
    private ComboBox supertype2ComboBox;
    private ComboBox type2ComboBox;
    private ComboBox type3ComboBox;
    private ComboBox subtype3ComboBox;
    private ComboBox subtype2ComboBox;
    private ComboBox subtype1ComboBox;
}
