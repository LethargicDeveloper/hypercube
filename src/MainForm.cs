using Hypercube.Scryfall;
using Hypercube.UrzasAI;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;

namespace Hypercube;

public partial class MainForm : Form
{
    readonly FormFactory form;
    readonly CubeManager cubeManager;
    readonly ScryfallClient scryfallClient;
    readonly UrzasAIClient urzasClient;
    readonly CardSymbolProvider cardSymbolProvider;
    readonly Panel panel = new()
    {
        Dock = DockStyle.Fill
    };

    readonly float dpiX;
    readonly float dpiY;

    CardImageUserControl? selectedImage;

    public MainForm(
        FormFactory form,
        CubeManager cubeManager,
        ScryfallClient scryfallClient,
        UrzasAIClient urzasClient,
        CardSymbolProvider cardSymbolProvider)
    {
        InitializeComponent();

        this.form = form;
        this.cubeManager = cubeManager;
        this.scryfallClient = scryfallClient;
        this.urzasClient = urzasClient;
        this.cardSymbolProvider = cardSymbolProvider;
        this.Controls.Add(this.panel);
        this.panel.BringToFront();

        using var graphics = this.CreateGraphics();
        this.dpiX = graphics.DpiX;
        this.dpiY = graphics.DpiY;

        SetControlsEnabled(false);
    }

    void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    void NewCubeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var newCubeForm = this.form.Create<NewCubeForm>();
        if (newCubeForm.ShowDialog() == DialogResult.OK)
        {
            LoadCube(newCubeForm.Cube);
        }
    }

    void OpenCubeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.folderBrowserDialog.InitialDirectory = Path.GetFullPath(".\\Cubes");
        if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            var cubeName = Path.GetFileName(this.folderBrowserDialog.SelectedPath);
            var cube = this.cubeManager.LoadCube(cubeName);
            if (cube == null)
            {
                MessageBox.Show("Error loading cube.", "Error!");
                return;
            }

            LoadCube(cube);
        }
    }

    void CardNameTextBox_TextChanged(object sender, EventArgs e)
    {
        CanGenerateCard();

        this.cardPictureBox.Refresh();
        CardTextBox_TextChanged(sender, e);
    }

    void ManaCostTextBox_TextChanged(object sender, EventArgs e)
    {
        CanGenerateCard();
        this.cardPictureBox.Refresh();
    }

    void FrameComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        CanGenerateCard();
        
        var path = Path.Combine(".\\img", "frames",
            ((Frame)this.frameComboBox.SelectedItem).Path);

        this.cardPictureBox.ImageLocation = path;
        this.cardPictureBox.LoadAsync();
    }

    void Supertype1ComboBox_TextChanged(object sender, EventArgs e)
    {
        CanGenerateCard();

        this.supertype2ComboBox.Enabled = !string.IsNullOrEmpty(this.supertype1ComboBox.Text);
        this.cardPictureBox.Refresh();
    }

    void Supertype2ComboBox_TextChanged(object sender, EventArgs e)
    {
        this.cardPictureBox.Refresh();
    }

    void Type1ComboBox_TextChanged(object sender, EventArgs e)
    {
        CanGenerateCard();

        this.type2ComboBox.Enabled = !string.IsNullOrEmpty(this.type1ComboBox.Text);
        this.cardPictureBox.Refresh();
    }

    void Type2ComboBox_TextChanged(object sender, EventArgs e)
    {
        this.type3ComboBox.Enabled = !string.IsNullOrEmpty(this.type2ComboBox.Text);
        this.cardPictureBox.Refresh();
    }

    void Type3ComboBox_TextChanged(object sender, EventArgs e)
    {
        this.cardPictureBox.Refresh();
    }

    void Subtype1TextBox_TextChanged(object sender, EventArgs e)
    {
        CanGenerateCard();

        this.subtype2TextBox.Enabled = !string.IsNullOrEmpty(this.subtype1TextBox.Text);
        this.cardPictureBox.Refresh();
    }

    void Subtype2TextBox_TextChanged(object sender, EventArgs e)
    {
        this.subtype3TextBox.Enabled = !string.IsNullOrEmpty(this.subtype2TextBox.Text);
        this.cardPictureBox.Refresh();
    }

    void Subtype3TextBox_TextChanged(object sender, EventArgs e)
    {
        this.cardPictureBox.Refresh();
    }

    void RarityComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        CanGenerateCard();
        this.cardPictureBox.Refresh();
    }

    void HasPowerToughnessCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        this.powerAndToughnessPictureBox.Visible = this.cardTextUserControl.HasPowerAndToughness;
    }

    void PowerTextBox_TextChanged(object sender, EventArgs e)
    {
        this.powerAndToughnessPictureBox.Refresh();
    }

    void ToughnessTextBox_TextChanged(object sender, EventArgs e)
    {
        this.powerAndToughnessPictureBox.Refresh();
    }

    void CardPictureBox_Paint(object sender, PaintEventArgs e)
    {
        var beleren = Fonts.GetFontFamily("Beleren");
        var relay = Fonts.GetFontFamily("Relay-Medium");

        using var belerenFont = new Font(beleren, 10);
        using var relayFont = new Font(relay, 8);

        e.Graphics.DrawString(this.cardNameTextBox.Text, belerenFont, Brushes.Black, new Point(25, 23));

        var manaSymbolPaths = this.cardSymbolProvider
            .GetCardSymbolImagePaths(this.manaCostTextBox.Text)
            .Reverse();

        int i = 0;
        foreach (var manaSymbolPath in manaSymbolPaths)
        {
            var manaSymbol = Image.FromFile(manaSymbolPath);
            e.Graphics.DrawImage(manaSymbol, 285 - (16 * i++), 22);
        }

        var cardType = string.Format("{0} {1} {2} {3} {4}",
            this.supertype1ComboBox.Text,
            this.supertype2ComboBox.Text,
            this.type1ComboBox.Text,
            this.type2ComboBox.Text,
            this.type3ComboBox.Text);

        if (!string.IsNullOrEmpty(subtype1TextBox.Text))
        {
            cardType += string.Format(" — {0} {1} {2}",
                this.subtype1TextBox.Text,
                this.subtype2TextBox.Text,
                this.subtype3TextBox.Text);
        }

        RegexOptions options = RegexOptions.None;
        var regex = new Regex("[ ]{2,}", options);
        cardType = regex.Replace(cardType, " ").Trim();

        e.Graphics.DrawString(cardType, relayFont, Brushes.Black, new Point(25, 223));

        var rarity = Path.Combine(".\\img", "expansions",
            Rarities.GetIconPath(this.rarityComboBox.Text));

        var rarityImage = Image.FromFile(rarity);
        e.Graphics.DrawImage(rarityImage, 285, 222, 17, 17);

        if (this.selectedImage?.RenderedImage != null)
            e.Graphics.DrawImage(this.selectedImage.RenderedImage, 25, 45, 275, 173);
    }

    void PowerAndToughnessPictureBox_Paint(object sender, PaintEventArgs e)
    {
        var beleren = Fonts.GetFontFamily("Beleren");
        using var belerenFont = new Font(beleren, 10);

        if (this.cardTextUserControl.HasPowerAndToughness)
        {
            var power = this.cardTextUserControl.Power;
            var powerTopOffset = power.Length <= 2 ? 0 : 2;
            var powerLeftOffset = (power.Length <= 2 ? 11 : 5) *
                (power.Length - 1);
            var powerFontSize = power.Length <= 2 ? 14 : 10;
            using var powerFont = new Font(beleren, powerFontSize);
            e.Graphics.DrawString(power, powerFont, Brushes.Black,
                new Point(16 - powerLeftOffset, 6 + powerTopOffset));

            var toughness = this.cardTextUserControl.Toughness;
            var toughnessTopOffset = toughness.Length <= 2 ? 0 : 2;
            using var toughnessFont = new Font(beleren, toughness.Length <= 2 ? 14 : 10);
            e.Graphics.DrawString(toughness, toughnessFont, Brushes.Black,
                new Point(36, 6 + toughnessTopOffset));
        }
    }

    void CardTextBox_TextChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(this.cardTextRichTextBox.Text))
            this.cardTextRichTextBox.Clear();

        var text = this.cardTextUserControl.CardText
            .Replace("~", this.cardNameTextBox.Text);

        var sb = new StringBuilder();
        sb.Append(@"{\rtf1\ansi\deff0");

        bool italic = false;
        bool bold = false;
        bool symbol = false;
        string symbolChars = string.Empty;
        for (int i = 0; i < text.Length; ++i)
        {
            var @char = text[i];

            if (@char == '{' && text.IndexOf('}', i) > -1)
            {
                symbol = text.IndexOf('}', i) > -1;
            }
            else if (symbol && @char == '}')
            {
                symbol = false;
                var filename = this.cardSymbolProvider.GetCardSymbolImagePath($"{{{symbolChars}}}");
                if (string.IsNullOrEmpty(filename)) continue;
                Bitmap original = (Bitmap)Bitmap.FromFile(filename);
                Bitmap bmp = original.RemoveTransparency();
                var hex = bmp.ToMetafileHexString();

                var picw = (int)Math.Round((bmp.Width / this.dpiX) * 2540);
                var pich = (int)Math.Round((bmp.Height / this.dpiY) * 2540);
                var picwgoal = (int)Math.Round((bmp.Width / this.dpiX) * 1440);
                var pichgoal = (int)Math.Round((bmp.Height / this.dpiY) * 1440);

                sb.Append($@"\pvpg{{\pict\wmetafile8\picw{picw}\pich{pich}\picwgoal{picwgoal}\pichgoal{pichgoal} {hex}}}");
                symbolChars = string.Empty;
            }
            else if (symbol)
            {
                symbolChars += @char;
            }
            else if (@char == '_')
            {
                sb.Append(@"\i");
                if (italic) sb.Append(@"0");
                sb.Append(" ");
                italic = !italic;
            }
            else if (@char == '*')
            {
                sb.Append(@"\b");
                if (bold) sb.Append(@"0");
                sb.Append(" ");
                bold = !bold;
            }
            else if (@char == '\n')
            {
                sb.Append(@"\par ");
            }
            else if (@char == '\r') { }
            else if ("\\{}".Contains(@char))
            {
                sb.Append($@"\{@char}");
            }
            else
            {
                sb.Append(@char);
            }
        }

        sb.Append("}");

        this.cardTextRichTextBox.Rtf = sb.ToString();
    }

    void FontSizeTrackBar_Scroll(object sender, EventArgs e)
    {
        this.cardTextRichTextBox.SelectionStart = 0;
        this.cardTextRichTextBox.SelectionLength = this.cardTextRichTextBox.Text.Length;
        this.cardTextRichTextBox.SelectionFont = new Font(
            this.cardTextRichTextBox.Font.FontFamily,
            this.fontSizeTrackBar.Value);

        this.cardTextRichTextBox.DeselectAll();
    }

    void ManaCostHelpButton_Click(object sender, EventArgs e)
    {
        Process proc = new Process();
        proc.StartInfo.UseShellExecute = true;
        proc.StartInfo.FileName = "https://www.scryfall.com/docs/api/colors";
        proc.Start();
    }

    async void GenerateButton_Click(object sender, EventArgs e)
    {
        (CardText, CardImage)[]? results;

        try
        {
            SetControlsEnabled(false);
            Application.UseWaitCursor = true;

            var tasks = Enumerable
                .Range(0, this.cardTextTabControl.TabCount == 1 ? 4 : 1)
                .Select(_ => GenerateCard());

            results = await Task.WhenAll(tasks);
        }
        finally
        {
            Application.UseWaitCursor = false;
            SetControlsEnabled(true);
        }

        for (int i = 0; i < results.Length; ++i)
        {
            var (cardText, cardImage) = results[i];

            var cardTextUserControl = new CardTextUserControl
            {
                CardText = $"{cardText.Text.ReplaceLineEndings()}\r\n\r\n_{cardText.FlavorText}_",
                HasPowerAndToughness = !string.IsNullOrEmpty(cardText.Power) || !string.IsNullOrEmpty(cardText.Toughness),
                Power = cardText.Power,
                Toughness = cardText.Toughness,
                Readonly = true
            };

            var tabPage = new TabPage($"Card {this.cardTextTabControl.TabCount}");
            tabPage.Controls.Add(cardTextUserControl);

            this.cardTextTabControl.TabPages.Add(tabPage);

            var cardImageUserControl = new CardImageUserControl
            {
                CardImage = cardImage,
                Width = 150,
                Height = 150
            };

            cardImageUserControl.SelectedChanged += CardImageUserControl_SelectedChanged;
            cardImageUserControl.LoadCompleted += CardImageUserControl_LoadCompleted;
            
            if (this.selectedImage == null)
            {
                this.selectedImage = cardImageUserControl;
                cardImageUserControl.Selected = true;
            }

            this.cardImageFlowLayoutPanel.Controls.Add(cardImageUserControl);
        }
    }

    void CardImageFlowLayoutPanel_DragOver(object sender, DragEventArgs e)
    {
        if (e.Data!.GetDataPresent(DataFormats.FileDrop))
        {
            e.Effect = DragDropEffects.Link;
        }
        else
        {
            e.Effect = DragDropEffects.None;
        }
    }

    void CardImageFlowLayoutPanel_DragDrop(object sender, DragEventArgs e)
    {
        var files = (e.Data!.GetData(DataFormats.FileDrop) as string[]) ?? Array.Empty<string>();
        foreach (var file in files)
        {
            var cardImageUserControl = new CardImageUserControl
            {
                CardImage = new CardImage
                {
                    ArtUrl = file,
                    State = "completed"
                },
                Width = 150,
                Height = 150
            };

            cardImageUserControl.SelectedChanged += CardImageUserControl_SelectedChanged;
            cardImageUserControl.LoadCompleted += CardImageUserControl_LoadCompleted;

            if (this.selectedImage == null)
            {
                this.selectedImage = cardImageUserControl;
                cardImageUserControl.Selected = true;
            }

            this.cardImageFlowLayoutPanel.Controls.Add(cardImageUserControl);
        }
    }

    void CardImageUserControl_SelectedChanged(object? sender, EventArgs e)
    {
        var control = sender as CardImageUserControl;
        if (control == null) return;

        foreach (CardImageUserControl cardImageUserControl in this.cardImageFlowLayoutPanel.Controls)
        {
            if (cardImageUserControl != control)
            {
                cardImageUserControl.SelectedChanged -= CardImageUserControl_SelectedChanged;
                cardImageUserControl.Selected = false;
                cardImageUserControl.SelectedChanged += CardImageUserControl_SelectedChanged;
            }
        }

        if (control.Selected)
        {
            this.selectedImage = control;
            this.cardPictureBox.Refresh();
        }
    }

    void CardImageUserControl_LoadCompleted(object? sender, EventArgs e)
    {
        var control = sender as CardImageUserControl;
        if (control == null) return;

        if (control.Selected)
        {
            this.cardPictureBox.Refresh();
        }
    }

    async Task<(CardText, CardImage)> GenerateCard()
    {
        var types = new List<string>
        {
            this.supertype1ComboBox.Text,
            this.supertype2ComboBox.Text,
            this.type1ComboBox.Text,
            this.type2ComboBox.Text,
            this.type3ComboBox.Text
        };

        var typesString = string.Join(" ", types.Where(_ => !string.IsNullOrEmpty(_))).Trim();

        var subtypes = new List<string>
        {
            this.subtype1TextBox.Text,
            this.subtype2TextBox.Text,
            this.subtype3TextBox.Text
        };

        var subtypesString = string.Join(" ", subtypes.Where(_ => !string.IsNullOrEmpty(_))).Trim();

        CardText cardText = new CardText();
        CardImage cardImage = new CardImage();

        cardText = await this.urzasClient.GenerateCardTextAsync(new UrzasAIRequest
        {
            Presets = new CardText
            {
                Name = this.cardNameTextBox.Text,
                ManaCost = this.manaCostTextBox.Text,
                Types = typesString,
                Subtypes = subtypesString,
            }
        });

        cardImage = await this.urzasClient.GenerateImageAsync(cardText);

        return (cardText, cardImage);
    }

    void LoadCube(Cube cube)
    {
        this.Cursor = Cursors.WaitCursor;
        var cards = this.scryfallClient.GetCardsForCube(cube)?.ToList();
        this.Cursor = Cursors.Default;

        var cardTextFontFamily = Fonts.GetFontFamily("MPlantin");
        using var cardTextFont = new Font(cardTextFontFamily, 11, FontStyle.Regular);
        this.cardTextRichTextBox.Font = cardTextFont;

        this.cardNameTextBox.Text = string.Empty;
        this.manaCostTextBox.Text = string.Empty;
        this.frameComboBox.Text = string.Empty;
        this.supertype1ComboBox.Text = string.Empty;
        this.supertype2ComboBox.Text = string.Empty;
        this.type1ComboBox.Text = string.Empty;
        this.type2ComboBox.Text = string.Empty;
        this.type3ComboBox.Text = string.Empty;
        this.subtype1TextBox.Text = string.Empty;
        this.subtype2TextBox.Text = string.Empty;
        this.subtype3TextBox.Text = string.Empty;
        this.rarityComboBox.Text = string.Empty;
        this.cardNameTextBox.Text = string.Empty;
        this.cardTextTabControl.SelectedIndex = 0;
        this.cardTextUserControl.CardText = string.Empty;
        this.cardTextUserControl.HasPowerAndToughness = false;
        this.cardTextUserControl.Power = string.Empty;
        this.cardTextUserControl.Toughness = string.Empty;
        ClearTabs();

        if (cards == null || cards.Count == 0)
        {
            return;
        }

        var card = cards[0];

        this.manaCostTextBox.Text = card.ManaCost;

        var frames = Frames.GetFrames();
        this.frameComboBox.BeginUpdate();
        this.frameComboBox.Items.Clear();
        this.frameComboBox.Items.AddRange(frames.ToArray());
        this.frameComboBox.EndUpdate();
        this.frameComboBox.Text = Frames.GetFrameForCard(card).Description;

        var supertypes = new[] { "" }.Concat(CardTypes.Supertypes).ToArray();
        this.supertype1ComboBox.BeginUpdate();
        this.supertype1ComboBox.Items.Clear();
        this.supertype1ComboBox.Items.AddRange(supertypes);
        this.supertype1ComboBox.EndUpdate();

        this.supertype2ComboBox.BeginUpdate();
        this.supertype2ComboBox.Items.Clear();
        this.supertype2ComboBox.Items.AddRange(supertypes);
        this.supertype2ComboBox.EndUpdate();

        var cardtypes = new[] { "" }.Concat(CardTypes.Types).ToArray();
        this.type1ComboBox.BeginUpdate();
        this.type1ComboBox.Items.Clear();
        this.type1ComboBox.Items.AddRange(cardtypes);
        this.type1ComboBox.EndUpdate();

        this.type2ComboBox.BeginUpdate();
        this.type2ComboBox.Items.Clear();
        this.type2ComboBox.Items.AddRange(cardtypes);
        this.type2ComboBox.EndUpdate();

        this.type3ComboBox.BeginUpdate();
        this.type3ComboBox.Items.Clear();
        this.type3ComboBox.Items.AddRange(cardtypes);
        this.type3ComboBox.EndUpdate();

        this.expansionCardPictureBox.ImageLocation = card.ImageUris.Normal;

        var allCardTypes = card.TypeLine
            .Replace(" — ", " ")
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        int supertypeCount = 0;
        int typeCount = 0;
        int subtypeCount = 0;

        for (int i = 0; i < allCardTypes.Length; ++i)
        {
            var cardType = allCardTypes[i];
            if (CardTypes.Supertypes.Contains(cardType))
            {
                supertypeCount++;
                if (supertypeCount == 1) this.supertype1ComboBox.Text = cardType;
                else if (supertypeCount == 2) this.supertype2ComboBox.Text = cardType;

            }
            else if (CardTypes.Types.Contains(cardType))
            {
                typeCount++;
                if (typeCount == 1) this.type1ComboBox.Text = cardType;
                else if (typeCount == 2) this.type2ComboBox.Text = cardType;
                else if (typeCount == 3) this.type3ComboBox.Text = cardType;
            }
            else
            {
                subtypeCount++;
                if (subtypeCount == 1) this.subtype1TextBox.Text = cardType;
                else if (subtypeCount == 2) this.subtype2TextBox.Text = cardType;
                else if (subtypeCount == 3) this.subtype3TextBox.Text = cardType;
            }
        }

        this.rarityComboBox.Text = Rarities.GetRarity(card.Rarity);
        this.cardTextUserControl.HasPowerAndToughness =
            !string.IsNullOrEmpty(card.Power) ||
            !string.IsNullOrEmpty(card.Toughness);

        this.cardTextUserControl.Power = card.Power;
        this.cardTextUserControl.Toughness = card.Power;

        SetControlsEnabled(true);
        this.panel.Hide();
    }

    void CanGenerateCard()
    {
        this.generateButton.Enabled =
            !string.IsNullOrEmpty(this.cardNameTextBox.Text) &&
            !string.IsNullOrEmpty(this.frameComboBox.Text) &&
            !string.IsNullOrEmpty(this.type1ComboBox.Text) &&
            !string.IsNullOrEmpty(this.rarityComboBox.Text);
    }

    void ClearTabs()
    {
        for (int i = 1; i < this.cardTextTabControl.TabPages.Count - 1; ++i)
        {
            this.cardTextTabControl.TabPages.RemoveAt(1);
        }
    }

    void SetControlsEnabled(bool enabled)
    {
        foreach (Control control in this.Controls)
        {
            if (control is not MenuStrip)
            {
                control.Enabled = enabled;
            }
        }
    }
}