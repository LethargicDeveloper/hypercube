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
            this.cardTextTabControl = new System.Windows.Forms.TabControl();
            this.newCardTabPage = new System.Windows.Forms.TabPage();
            this.cardTextUserControl = new Hypercube.CardTextUserControl();
            this.cardArtFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.supertype2ComboBox = new System.Windows.Forms.ComboBox();
            this.type2ComboBox = new System.Windows.Forms.ComboBox();
            this.type3ComboBox = new System.Windows.Forms.ComboBox();
            this.subtype1TextBox = new System.Windows.Forms.TextBox();
            this.subtype2TextBox = new System.Windows.Forms.TextBox();
            this.subtype3TextBox = new System.Windows.Forms.TextBox();
            this.cardTextRichTextBox = new System.Windows.Forms.RichTextBox();
            this.powerAndToughnessPictureBox = new System.Windows.Forms.PictureBox();
            this.fontSizeTrackBar = new System.Windows.Forms.TrackBar();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.expansionCardPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox)).BeginInit();
            this.cardTextTabControl.SuspendLayout();
            this.newCardTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.powerAndToughnessPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeTrackBar)).BeginInit();
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
            this.expansionCardPictureBox.Location = new System.Drawing.Point(23, 94);
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
            this.label3.Location = new System.Drawing.Point(374, 111);
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
            this.label4.Location = new System.Drawing.Point(379, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 21);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mana &Cost:";
            // 
            // cardNameTextBox
            // 
            this.cardNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cardNameTextBox.Location = new System.Drawing.Point(486, 111);
            this.cardNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cardNameTextBox.Name = "cardNameTextBox";
            this.cardNameTextBox.Size = new System.Drawing.Size(318, 23);
            this.cardNameTextBox.TabIndex = 7;
            this.cardNameTextBox.TextChanged += new System.EventHandler(this.CardNameTextBox_TextChanged);
            // 
            // manaCostTextBox
            // 
            this.manaCostTextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.manaCostTextBox.Location = new System.Drawing.Point(486, 145);
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
            this.manaCostHelpButton.Location = new System.Drawing.Point(779, 140);
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
            this.label5.Location = new System.Drawing.Point(411, 185);
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
            this.frameComboBox.Location = new System.Drawing.Point(485, 185);
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
            this.label6.Location = new System.Drawing.Point(423, 259);
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
            this.type1ComboBox.Location = new System.Drawing.Point(486, 259);
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
            this.label7.Location = new System.Drawing.Point(396, 296);
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
            this.label8.Location = new System.Drawing.Point(414, 333);
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
            this.rarityComboBox.Location = new System.Drawing.Point(486, 333);
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
            this.generateButton.Location = new System.Drawing.Point(489, 739);
            this.generateButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(318, 77);
            this.generateButton.TabIndex = 100;
            this.generateButton.Text = "&Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // supertype1ComboBox
            // 
            this.supertype1ComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.supertype1ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.supertype1ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.supertype1ComboBox.FormattingEnabled = true;
            this.supertype1ComboBox.Location = new System.Drawing.Point(486, 223);
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
            this.label9.Location = new System.Drawing.Point(381, 223);
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
            this.cardPictureBox.Location = new System.Drawing.Point(842, 94);
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
            this.label10.Location = new System.Drawing.Point(388, 420);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 21);
            this.label10.TabIndex = 25;
            this.label10.Text = "Card Te&xt:";
            // 
            // cardTextTabControl
            // 
            this.cardTextTabControl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cardTextTabControl.Controls.Add(this.newCardTabPage);
            this.cardTextTabControl.Location = new System.Drawing.Point(486, 420);
            this.cardTextTabControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cardTextTabControl.Name = "cardTextTabControl";
            this.cardTextTabControl.SelectedIndex = 0;
            this.cardTextTabControl.Size = new System.Drawing.Size(318, 315);
            this.cardTextTabControl.TabIndex = 26;
            // 
            // newCardTabPage
            // 
            this.newCardTabPage.Controls.Add(this.cardTextUserControl);
            this.newCardTabPage.Location = new System.Drawing.Point(4, 24);
            this.newCardTabPage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.newCardTabPage.Name = "newCardTabPage";
            this.newCardTabPage.Size = new System.Drawing.Size(310, 287);
            this.newCardTabPage.TabIndex = 4;
            this.newCardTabPage.Text = "New Card";
            this.newCardTabPage.UseVisualStyleBackColor = true;
            // 
            // cardTextUserControl
            // 
            this.cardTextUserControl.CardText = "";
            this.cardTextUserControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cardTextUserControl.HasPowerAndToughness = false;
            this.cardTextUserControl.Location = new System.Drawing.Point(0, 0);
            this.cardTextUserControl.Name = "cardTextUserControl";
            this.cardTextUserControl.Power = "";
            this.cardTextUserControl.Readonly = false;
            this.cardTextUserControl.Size = new System.Drawing.Size(310, 287);
            this.cardTextUserControl.TabIndex = 104;
            this.cardTextUserControl.Toughness = "";
            this.cardTextUserControl.CardTextChanged += new System.EventHandler(this.CardTextBox_TextChanged);
            this.cardTextUserControl.HasPowerAndToughnessCheckChanged += new System.EventHandler(this.HasPowerToughnessCheckBox_CheckedChanged);
            this.cardTextUserControl.PowerTextChanged += new System.EventHandler(this.PowerTextBox_TextChanged);
            this.cardTextUserControl.ToughnessTextChanged += new System.EventHandler(this.ToughnessTextBox_TextChanged);
            // 
            // cardArtFlowLayoutPanel
            // 
            this.cardArtFlowLayoutPanel.AllowDrop = true;
            this.cardArtFlowLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cardArtFlowLayoutPanel.AutoScroll = true;
            this.cardArtFlowLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.cardArtFlowLayoutPanel.Location = new System.Drawing.Point(842, 493);
            this.cardArtFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cardArtFlowLayoutPanel.Name = "cardArtFlowLayoutPanel";
            this.cardArtFlowLayoutPanel.Size = new System.Drawing.Size(328, 328);
            this.cardArtFlowLayoutPanel.TabIndex = 31;
            this.cardArtFlowLayoutPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.CardArtFlowLayoutPanel_DragDrop);
            this.cardArtFlowLayoutPanel.DragOver += new System.Windows.Forms.DragEventHandler(this.CardArtFlowLayoutPanel_DragOver);
            // 
            // supertype2ComboBox
            // 
            this.supertype2ComboBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.supertype2ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.supertype2ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.supertype2ComboBox.Enabled = false;
            this.supertype2ComboBox.FormattingEnabled = true;
            this.supertype2ComboBox.Location = new System.Drawing.Point(648, 223);
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
            this.type2ComboBox.Location = new System.Drawing.Point(592, 259);
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
            this.type3ComboBox.Location = new System.Drawing.Point(698, 259);
            this.type3ComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.type3ComboBox.Name = "type3ComboBox";
            this.type3ComboBox.Size = new System.Drawing.Size(106, 23);
            this.type3ComboBox.TabIndex = 18;
            this.type3ComboBox.TextChanged += new System.EventHandler(this.Type3ComboBox_TextChanged);
            // 
            // subtype1TextBox
            // 
            this.subtype1TextBox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.subtype1TextBox.Location = new System.Drawing.Point(486, 299);
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
            this.subtype2TextBox.Location = new System.Drawing.Point(592, 299);
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
            this.subtype3TextBox.Location = new System.Drawing.Point(698, 299);
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
            this.cardTextRichTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cardTextRichTextBox.Location = new System.Drawing.Point(869, 342);
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
            this.powerAndToughnessPictureBox.Location = new System.Drawing.Point(1090, 438);
            this.powerAndToughnessPictureBox.Name = "powerAndToughnessPictureBox";
            this.powerAndToughnessPictureBox.Size = new System.Drawing.Size(65, 31);
            this.powerAndToughnessPictureBox.TabIndex = 102;
            this.powerAndToughnessPictureBox.TabStop = false;
            this.powerAndToughnessPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.PowerAndToughnessPictureBox_Paint);
            // 
            // fontSizeTrackBar
            // 
            this.fontSizeTrackBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fontSizeTrackBar.LargeChange = 1;
            this.fontSizeTrackBar.Location = new System.Drawing.Point(485, 370);
            this.fontSizeTrackBar.Maximum = 15;
            this.fontSizeTrackBar.Minimum = 8;
            this.fontSizeTrackBar.Name = "fontSizeTrackBar";
            this.fontSizeTrackBar.Size = new System.Drawing.Size(318, 45);
            this.fontSizeTrackBar.TabIndex = 103;
            this.fontSizeTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.fontSizeTrackBar.Value = 11;
            this.fontSizeTrackBar.Scroll += new System.EventHandler(this.FontSizeTrackBar_Scroll);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1208, 827);
            this.Controls.Add(this.fontSizeTrackBar);
            this.Controls.Add(this.powerAndToughnessPictureBox);
            this.Controls.Add(this.cardTextRichTextBox);
            this.Controls.Add(this.subtype3TextBox);
            this.Controls.Add(this.subtype2TextBox);
            this.Controls.Add(this.subtype1TextBox);
            this.Controls.Add(this.type3ComboBox);
            this.Controls.Add(this.type2ComboBox);
            this.Controls.Add(this.supertype2ComboBox);
            this.Controls.Add(this.cardArtFlowLayoutPanel);
            this.Controls.Add(this.cardTextTabControl);
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
            this.cardTextTabControl.ResumeLayout(false);
            this.newCardTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.powerAndToughnessPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fontSizeTrackBar)).EndInit();
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
    private TabControl cardTextTabControl;
    private TabPage newCardTabPage;
    private FlowLayoutPanel cardArtFlowLayoutPanel;
    private ComboBox supertype2ComboBox;
    private ComboBox type2ComboBox;
    private ComboBox type3ComboBox;
    private TextBox subtype1TextBox;
    private TextBox subtype2TextBox;
    private TextBox subtype3TextBox;
    private RichTextBox cardTextRichTextBox;
    private PictureBox powerAndToughnessPictureBox;
    private TrackBar fontSizeTrackBar;
    private CardTextUserControl cardTextUserControl;
}
