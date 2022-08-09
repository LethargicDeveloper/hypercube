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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCubeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCubeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.expansionCardPictureBox = new System.Windows.Forms.PictureBox();
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
            this.label10 = new System.Windows.Forms.Label();
            this.powerTextBox = new System.Windows.Forms.TextBox();
            this.toughnessTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.hasPowerToughnessCheckBox = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.newCardTabPage = new System.Windows.Forms.TabPage();
            this.cardTextBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.supertype2ComboBox = new System.Windows.Forms.ComboBox();
            this.type2ComboBox = new System.Windows.Forms.ComboBox();
            this.type3ComboBox = new System.Windows.Forms.ComboBox();
            this.subtype1TextBox = new System.Windows.Forms.TextBox();
            this.subtype2TextBox = new System.Windows.Forms.TextBox();
            this.subtype3TextBox = new System.Windows.Forms.TextBox();
            this.cardTextRichTextBox = new System.Windows.Forms.RichTextBox();
            this.powerAndToughnessPictureBox = new System.Windows.Forms.PictureBox();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expansionCardPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.newCardTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.powerAndToughnessPictureBox)).BeginInit();
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
            this.menuStrip.Size = new System.Drawing.Size(1208, 24);
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
            this.expansionCardPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.expansionCardPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.expansionCardPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.expansionCardPictureBox.Location = new System.Drawing.Point(23, 53);
            this.expansionCardPictureBox.Name = "expansionCardPictureBox";
            this.expansionCardPictureBox.Size = new System.Drawing.Size(328, 394);
            this.expansionCardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.expansionCardPictureBox.TabIndex = 1;
            this.expansionCardPictureBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(374, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 21);
            this.label3.TabIndex = 6;
            this.label3.Text = "Card &Name:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(379, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mana &Cost:";
            // 
            // cardNameTextBox
            // 
            this.cardNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cardNameTextBox.Location = new System.Drawing.Point(486, 70);
            this.cardNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cardNameTextBox.Name = "cardNameTextBox";
            this.cardNameTextBox.Size = new System.Drawing.Size(318, 23);
            this.cardNameTextBox.TabIndex = 7;
            this.cardNameTextBox.TextChanged += new System.EventHandler(this.CardNameTextBox_TextChanged);
            // 
            // manaCostTextBox
            // 
            this.manaCostTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.manaCostTextBox.Location = new System.Drawing.Point(486, 104);
            this.manaCostTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.manaCostTextBox.Name = "manaCostTextBox";
            this.manaCostTextBox.Size = new System.Drawing.Size(288, 23);
            this.manaCostTextBox.TabIndex = 9;
            this.manaCostTextBox.TextChanged += new System.EventHandler(this.ManaCostTextBox_TextChanged);
            // 
            // manaCostHelpButton
            // 
            this.manaCostHelpButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.manaCostHelpButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.manaCostHelpButton.Location = new System.Drawing.Point(779, 99);
            this.manaCostHelpButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.manaCostHelpButton.Name = "manaCostHelpButton";
            this.manaCostHelpButton.Size = new System.Drawing.Size(24, 29);
            this.manaCostHelpButton.TabIndex = 0;
            this.manaCostHelpButton.TabStop = false;
            this.manaCostHelpButton.Text = "?";
            this.manaCostHelpButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.manaCostHelpButton.UseVisualStyleBackColor = true;
            this.manaCostHelpButton.Click += new System.EventHandler(this.ManaCostHelpButton_Click);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(411, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 21);
            this.label5.TabIndex = 10;
            this.label5.Text = "Fra&me:";
            // 
            // frameComboBox
            // 
            this.frameComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.frameComboBox.DisplayMember = "Description";
            this.frameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.frameComboBox.FormattingEnabled = true;
            this.frameComboBox.Location = new System.Drawing.Point(485, 144);
            this.frameComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.frameComboBox.Name = "frameComboBox";
            this.frameComboBox.Size = new System.Drawing.Size(318, 23);
            this.frameComboBox.TabIndex = 11;
            this.frameComboBox.ValueMember = "Key";
            this.frameComboBox.SelectedIndexChanged += new System.EventHandler(this.FrameComboBox_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(423, 218);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 21);
            this.label6.TabIndex = 15;
            this.label6.Text = "&Type:";
            // 
            // type1ComboBox
            // 
            this.type1ComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.type1ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.type1ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.type1ComboBox.FormattingEnabled = true;
            this.type1ComboBox.Location = new System.Drawing.Point(486, 218);
            this.type1ComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.type1ComboBox.Name = "type1ComboBox";
            this.type1ComboBox.Size = new System.Drawing.Size(106, 23);
            this.type1ComboBox.TabIndex = 16;
            this.type1ComboBox.TextChanged += new System.EventHandler(this.Type1ComboBox_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(396, 255);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 21);
            this.label7.TabIndex = 19;
            this.label7.Text = "Su&btype:";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(414, 292);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 21);
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
            this.rarityComboBox.Location = new System.Drawing.Point(486, 292);
            this.rarityComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rarityComboBox.Name = "rarityComboBox";
            this.rarityComboBox.Size = new System.Drawing.Size(318, 23);
            this.rarityComboBox.TabIndex = 24;
            this.rarityComboBox.SelectedIndexChanged += new System.EventHandler(this.RarityComboBox_SelectedIndexChanged);
            // 
            // generateButton
            // 
            this.generateButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.generateButton.Enabled = false;
            this.generateButton.Location = new System.Drawing.Point(488, 628);
            this.generateButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(318, 77);
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
            this.supertype1ComboBox.Location = new System.Drawing.Point(486, 182);
            this.supertype1ComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.supertype1ComboBox.Name = "supertype1ComboBox";
            this.supertype1ComboBox.Size = new System.Drawing.Size(156, 23);
            this.supertype1ComboBox.TabIndex = 13;
            this.supertype1ComboBox.TextChanged += new System.EventHandler(this.Supertype1ComboBox_TextChanged);
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label9.Location = new System.Drawing.Point(381, 182);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 21);
            this.label9.TabIndex = 12;
            this.label9.Text = "&Supertype:";
            // 
            // cardPictureBox
            // 
            this.cardPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cardPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.cardPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardPictureBox.Location = new System.Drawing.Point(842, 53);
            this.cardPictureBox.Name = "cardPictureBox";
            this.cardPictureBox.Size = new System.Drawing.Size(328, 394);
            this.cardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cardPictureBox.TabIndex = 21;
            this.cardPictureBox.TabStop = false;
            this.cardPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.CardPictureBox_Paint);
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label10.Location = new System.Drawing.Point(387, 334);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 21);
            this.label10.TabIndex = 25;
            this.label10.Text = "Card Te&xt:";
            // 
            // powerTextBox
            // 
            this.powerTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.powerTextBox.Location = new System.Drawing.Point(581, 592);
            this.powerTextBox.MaxLength = 3;
            this.powerTextBox.Name = "powerTextBox";
            this.powerTextBox.Size = new System.Drawing.Size(100, 23);
            this.powerTextBox.TabIndex = 29;
            this.powerTextBox.TextChanged += new System.EventHandler(this.PowerTextBox_TextChanged);
            // 
            // toughnessTextBox
            // 
            this.toughnessTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.toughnessTextBox.Location = new System.Drawing.Point(703, 592);
            this.toughnessTextBox.MaxLength = 3;
            this.toughnessTextBox.Name = "toughnessTextBox";
            this.toughnessTextBox.Size = new System.Drawing.Size(100, 23);
            this.toughnessTextBox.TabIndex = 30;
            this.toughnessTextBox.TextChanged += new System.EventHandler(this.ToughnessTextBox_TextChanged);
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(687, 595);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(12, 15);
            this.label11.TabIndex = 25;
            this.label11.Text = "/";
            // 
            // hasPowerToughnessCheckBox
            // 
            this.hasPowerToughnessCheckBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hasPowerToughnessCheckBox.AutoSize = true;
            this.hasPowerToughnessCheckBox.Location = new System.Drawing.Point(560, 596);
            this.hasPowerToughnessCheckBox.Name = "hasPowerToughnessCheckBox";
            this.hasPowerToughnessCheckBox.Size = new System.Drawing.Size(15, 14);
            this.hasPowerToughnessCheckBox.TabIndex = 28;
            this.hasPowerToughnessCheckBox.UseVisualStyleBackColor = true;
            this.hasPowerToughnessCheckBox.CheckedChanged += new System.EventHandler(this.HasPowerToughnessCheckBox_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tabControl1.Controls.Add(this.newCardTabPage);
            this.tabControl1.Location = new System.Drawing.Point(485, 334);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(318, 252);
            this.tabControl1.TabIndex = 26;
            // 
            // newCardTabPage
            // 
            this.newCardTabPage.Controls.Add(this.cardTextBox);
            this.newCardTabPage.Location = new System.Drawing.Point(4, 24);
            this.newCardTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.newCardTabPage.Name = "newCardTabPage";
            this.newCardTabPage.Size = new System.Drawing.Size(310, 224);
            this.newCardTabPage.TabIndex = 4;
            this.newCardTabPage.Text = "New Card";
            this.newCardTabPage.UseVisualStyleBackColor = true;
            // 
            // cardTextBox
            // 
            this.cardTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardTextBox.Location = new System.Drawing.Point(0, 0);
            this.cardTextBox.Multiline = true;
            this.cardTextBox.Name = "cardTextBox";
            this.cardTextBox.Size = new System.Drawing.Size(310, 224);
            this.cardTextBox.TabIndex = 27;
            this.cardTextBox.TextChanged += new System.EventHandler(this.CardTextBox_TextChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(842, 473);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(328, 260);
            this.flowLayoutPanel1.TabIndex = 31;
            // 
            // supertype2ComboBox
            // 
            this.supertype2ComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.supertype2ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.supertype2ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.supertype2ComboBox.Enabled = false;
            this.supertype2ComboBox.FormattingEnabled = true;
            this.supertype2ComboBox.Location = new System.Drawing.Point(648, 182);
            this.supertype2ComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.supertype2ComboBox.Name = "supertype2ComboBox";
            this.supertype2ComboBox.Size = new System.Drawing.Size(156, 23);
            this.supertype2ComboBox.TabIndex = 14;
            this.supertype2ComboBox.TextChanged += new System.EventHandler(this.Supertype2ComboBox_TextChanged);
            // 
            // type2ComboBox
            // 
            this.type2ComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.type2ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.type2ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.type2ComboBox.Enabled = false;
            this.type2ComboBox.FormattingEnabled = true;
            this.type2ComboBox.Location = new System.Drawing.Point(592, 218);
            this.type2ComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.type2ComboBox.Name = "type2ComboBox";
            this.type2ComboBox.Size = new System.Drawing.Size(106, 23);
            this.type2ComboBox.TabIndex = 17;
            this.type2ComboBox.TextChanged += new System.EventHandler(this.Type2ComboBox_TextChanged);
            // 
            // type3ComboBox
            // 
            this.type3ComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.type3ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.type3ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.type3ComboBox.Enabled = false;
            this.type3ComboBox.FormattingEnabled = true;
            this.type3ComboBox.Location = new System.Drawing.Point(698, 218);
            this.type3ComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.type3ComboBox.Name = "type3ComboBox";
            this.type3ComboBox.Size = new System.Drawing.Size(106, 23);
            this.type3ComboBox.TabIndex = 18;
            this.type3ComboBox.TextChanged += new System.EventHandler(this.Type3ComboBox_TextChanged);
            // 
            // subtype1TextBox
            // 
            this.subtype1TextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.subtype1TextBox.Location = new System.Drawing.Point(486, 258);
            this.subtype1TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.subtype1TextBox.Name = "subtype1TextBox";
            this.subtype1TextBox.Size = new System.Drawing.Size(106, 23);
            this.subtype1TextBox.TabIndex = 20;
            this.subtype1TextBox.TextChanged += new System.EventHandler(this.Subtype1TextBox_TextChanged);
            // 
            // subtype2TextBox
            // 
            this.subtype2TextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.subtype2TextBox.Enabled = false;
            this.subtype2TextBox.Location = new System.Drawing.Point(592, 258);
            this.subtype2TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.subtype2TextBox.Name = "subtype2TextBox";
            this.subtype2TextBox.Size = new System.Drawing.Size(106, 23);
            this.subtype2TextBox.TabIndex = 21;
            this.subtype2TextBox.TextChanged += new System.EventHandler(this.Subtype2TextBox_TextChanged);
            // 
            // subtype3TextBox
            // 
            this.subtype3TextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.subtype3TextBox.Enabled = false;
            this.subtype3TextBox.Location = new System.Drawing.Point(698, 258);
            this.subtype3TextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.subtype3TextBox.Name = "subtype3TextBox";
            this.subtype3TextBox.Size = new System.Drawing.Size(106, 23);
            this.subtype3TextBox.TabIndex = 22;
            this.subtype3TextBox.TextChanged += new System.EventHandler(this.Subtype3TextBox_TextChanged);
            // 
            // cardTextRichTextBox
            // 
            this.cardTextRichTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cardTextRichTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(237)))), ((int)(((byte)(235)))));
            this.cardTextRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cardTextRichTextBox.Location = new System.Drawing.Point(869, 301);
            this.cardTextRichTextBox.Name = "cardTextRichTextBox";
            this.cardTextRichTextBox.ReadOnly = true;
            this.cardTextRichTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.cardTextRichTextBox.Size = new System.Drawing.Size(271, 114);
            this.cardTextRichTextBox.TabIndex = 101;
            this.cardTextRichTextBox.Text = "";
            // 
            // powerAndToughnessPictureBox
            // 
            this.powerAndToughnessPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.powerAndToughnessPictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.powerAndToughnessPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.powerAndToughnessPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("powerAndToughnessPictureBox.Image")));
            this.powerAndToughnessPictureBox.Location = new System.Drawing.Point(1090, 397);
            this.powerAndToughnessPictureBox.Name = "powerAndToughnessPictureBox";
            this.powerAndToughnessPictureBox.Size = new System.Drawing.Size(65, 31);
            this.powerAndToughnessPictureBox.TabIndex = 102;
            this.powerAndToughnessPictureBox.TabStop = false;
            this.powerAndToughnessPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PowerAndToughnessPictureBox_Paint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 745);
            this.Controls.Add(this.powerAndToughnessPictureBox);
            this.Controls.Add(this.cardTextRichTextBox);
            this.Controls.Add(this.subtype3TextBox);
            this.Controls.Add(this.subtype2TextBox);
            this.Controls.Add(this.subtype1TextBox);
            this.Controls.Add(this.type3ComboBox);
            this.Controls.Add(this.type2ComboBox);
            this.Controls.Add(this.supertype2ComboBox);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.hasPowerToughnessCheckBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.toughnessTextBox);
            this.Controls.Add(this.powerTextBox);
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
            this.Controls.Add(this.expansionCardPictureBox);
            this.Controls.Add(this.menuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
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
            ((System.ComponentModel.ISupportInitialize)(this.powerAndToughnessPictureBox)).EndInit();
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
    private Label label10;
    private TextBox powerTextBox;
    private TextBox toughnessTextBox;
    private Label label11;
    private CheckBox hasPowerToughnessCheckBox;
    private TabControl tabControl1;
    private TabPage newCardTabPage;
    private FlowLayoutPanel flowLayoutPanel1;
    private ComboBox supertype2ComboBox;
    private ComboBox type2ComboBox;
    private ComboBox type3ComboBox;
    private TextBox subtype1TextBox;
    private TextBox subtype2TextBox;
    private TextBox subtype3TextBox;
    private RichTextBox cardTextRichTextBox;
    private PictureBox powerAndToughnessPictureBox;
    private TextBox cardTextBox;
}
