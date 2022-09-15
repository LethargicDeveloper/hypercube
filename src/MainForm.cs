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

    bool loading = false;
    Cube cube;
    int currentCard = 0;
    CardArtUserControl? selectedCardArtUserControl;
    List<Scryfall.Card> scryfallCards = new();

    public MainForm(
        FormFactory form,
        CubeManager cubeManager,
        ScryfallClient scryfallClient,
        UrzasAIClient urzasClient,
        CardSymbolProvider cardSymbolProvider)
    {
        this.cube = new();

        this.loading = true;

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

        var frames = Frames.GetFrames();
        this.frameComboBox.BeginUpdate();
        this.frameComboBox.Items.Clear();
        this.frameComboBox.Items.AddRange(frames.ToArray());
        this.frameComboBox.EndUpdate();

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

        this.colorNavigationComboBox.DisplayMember = "Name";
        this.colorNavigationComboBox.ValueMember = "Value";
        this.colorNavigationComboBox.BeginUpdate();
        this.colorNavigationComboBox.Items.Clear();
        this.colorNavigationComboBox.Items.AddRange(CardColors.Colors.ToArray());
        this.colorNavigationComboBox.EndUpdate();

        this.loading = false;
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
            this.cube = newCubeForm.Cube;
            LoadCube();
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

            this.cube = cube;
            LoadCube();
        }
    }

    void CardNameTextBox_TextChanged(object sender, EventArgs e)
    {
        if (this.loading) return;

        this.cardPictureBox.Refresh();
        CardTextBox_TextChanged(sender, e);
    }

    void ManaCostTextBox_TextChanged(object sender, EventArgs e)
    {
        if (this.loading) return;

        this.cardPictureBox.Refresh();
    }

    void FrameComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        var path = Path.Combine(".\\img", "frames",
            ((Frame)this.frameComboBox.SelectedItem).Path);

        this.cardPictureBox.ImageLocation = path;
        
        if (this.loading) return;
        this.cardPictureBox.LoadAsync();
    }

    void Supertype1ComboBox_TextChanged(object sender, EventArgs e)
    {
        if (this.loading) return;

        this.cardPictureBox.Refresh();
    }

    void Supertype2ComboBox_TextChanged(object sender, EventArgs e)
    {
        if (this.loading) return;

        this.cardPictureBox.Refresh();
    }

    void Type1ComboBox_TextChanged(object sender, EventArgs e)
    {
        if (this.loading) return;

        this.cardPictureBox.Refresh();
    }

    void Type2ComboBox_TextChanged(object sender, EventArgs e)
    {
        if (this.loading) return;

        this.cardPictureBox.Refresh();
    }

    void Type3ComboBox_TextChanged(object sender, EventArgs e)
    {
        if (this.loading) return;

        this.cardPictureBox.Refresh();
    }

    void Subtype1TextBox_TextChanged(object sender, EventArgs e)
    {
        if (this.loading) return;

        this.cardPictureBox.Refresh();
    }

    void Subtype2TextBox_TextChanged(object sender, EventArgs e)
    {
        if (this.loading) return;

        this.cardPictureBox.Refresh();
    }

    void Subtype3TextBox_TextChanged(object sender, EventArgs e)
    {
        if (this.loading) return;

        this.cardPictureBox.Refresh();
    }

    void RarityComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.loading) return;

        this.cardPictureBox.Refresh();
    }

    void HasPowerToughnessCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        if (this.loading) return;

        this.powerAndToughnessPictureBox.Visible = this.cardTextUserControl.HasPowerAndToughness;
    }

    void PowerTextBox_TextChanged(object sender, EventArgs e)
    {
        if (this.loading) return;

        this.powerAndToughnessPictureBox.Refresh();
    }

    void ToughnessTextBox_TextChanged(object sender, EventArgs e)
    {
        if (this.loading) return;

        this.powerAndToughnessPictureBox.Refresh();
    }

    void CardPictureBox_Paint(object sender, PaintEventArgs e)
    {
        var beleren = Fonts.GetFontFamily("Beleren");
        var relay = Fonts.GetFontFamily("Relay-Medium");

        using var belerenFont = new Font(beleren, 12);
        using var relayFont = new Font(relay, 8);

        e.Graphics.DrawString(this.cardNameTextBox.Text, belerenFont, Brushes.Black, new Point(25, 24));

        var manaSymbolPaths = this.cardSymbolProvider
            .GetCardSymbolImagePaths(this.manaCostTextBox.Text)
            .Reverse();

        int i = 0;
        foreach (var manaSymbolPath in manaSymbolPaths)
        {
            var manaSymbol = Image.FromFile(manaSymbolPath);
            e.Graphics.DrawImage(manaSymbol, 275 - (16 * i++), 26);
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

        e.Graphics.DrawString(cardType, relayFont, Brushes.Black, new Point(25, 251));

        var rarity = Path.Combine(".\\img", "expansions",
            Rarities.GetIconPath(this.rarityComboBox.Text));

        var rarityImage = Image.FromFile(rarity);
        e.Graphics.DrawImage(rarityImage, 275, 250, 17, 17);

        if (this.selectedCardArtUserControl?.RenderedImage != null)
            e.Graphics.DrawImage(this.selectedCardArtUserControl.RenderedImage, 24, 50, 267, 195);
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
                new Point(17 - powerLeftOffset, 6 + powerTopOffset));

            var toughness = this.cardTextUserControl.Toughness;
            var toughnessTopOffset = toughness.Length <= 2 ? 0 : 2;
            using var toughnessFont = new Font(beleren, toughness.Length <= 2 ? 14 : 10);
            e.Graphics.DrawString(toughness, toughnessFont, Brushes.Black,
                new Point(35, 6 + toughnessTopOffset));
        }
    }

    void CardTextBox_TextChanged(object sender, EventArgs e)
    {
        if (this.loading) return;

        if (string.IsNullOrEmpty(this.cardTextRichTextBox.Text))
            this.cardTextRichTextBox.Clear();

        var text = this.cardTextUserControl.CardText
            .Replace("~", this.cardNameTextBox.Text);

        var sb = new StringBuilder();
        // http://www.arcdev.hu/manuals/standard/rtf/rtfspeci.pdf
        // rtf renders fonts in half points so we multiply our font size by 2.
        sb.Append($@"{{\rtf1\ansi\deff0\fs{this.fontSizeTrackBar.Value * 2}");

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
                int scalex = Math.Clamp((int)(100 * (this.fontSizeTrackBar.Value / 11.0f)), 0, 100);
                int scaley = Math.Clamp((int)(100 * (this.fontSizeTrackBar.Value / 11.0f)), 0, 100);

                sb.Append($@"\pvpg{{\pict\wmetafile8\picw{picw}\pich{pich}\picwgoal{picwgoal}\pichgoal{pichgoal}\picscalex{scalex}\picscaley{scaley} {hex}}}");
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
            else if (@char == '@')
            {
                sb.Append(@"\bullet ");
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

        if (this.loading) return;

        CardTextBox_TextChanged(sender, e);
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
        (CardText, CardArt)[]? results;

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
            var (cardText, cardArt) = results[i];

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

            var cardArtUserControl = new CardArtUserControl
            {
                CardArt = cardArt,
                Width = 150,
                Height = 150
            };

            cardArtUserControl.SelectedChanged += CardArtUserControl_SelectedChanged;
            cardArtUserControl.LoadCompleted += CardArtUserControl_LoadCompleted;
            
            if (this.selectedCardArtUserControl == null)
            {
                this.selectedCardArtUserControl = cardArtUserControl;
                cardArtUserControl.Selected = true;
            }

            this.cardArtFlowLayoutPanel.Controls.Add(cardArtUserControl);
        }
    }

    void CardArtFlowLayoutPanel_DragOver(object sender, DragEventArgs e)
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

    void CardArtFlowLayoutPanel_DragDrop(object sender, DragEventArgs e)
    {
        var files = (e.Data!.GetData(DataFormats.FileDrop) as string[]) ?? Array.Empty<string>();
        foreach (var file in files)
        {
            var cardArtUserControl = new CardArtUserControl
            {
                CardArt = new CardArt
                {
                    ArtUrl = file,
                    State = "completed"
                },
                Width = 150,
                Height = 150
            };

            cardArtUserControl.SelectedChanged += CardArtUserControl_SelectedChanged;
            cardArtUserControl.LoadCompleted += CardArtUserControl_LoadCompleted;

            if (this.selectedCardArtUserControl == null)
            {
                this.selectedCardArtUserControl = cardArtUserControl;
                cardArtUserControl.Selected = true;
            }

            this.cardArtFlowLayoutPanel.Controls.Add(cardArtUserControl);
        }
    }

    void CardArtUserControl_SelectedChanged(object? sender, EventArgs e)
    {
        if (this.loading) return;

        var control = sender as CardArtUserControl;
        if (control == null) return;

        foreach (CardArtUserControl cardArtUserControl in this.cardArtFlowLayoutPanel.Controls)
        {
            if (cardArtUserControl != control)
            {
                cardArtUserControl.SelectedChanged -= CardArtUserControl_SelectedChanged;
                cardArtUserControl.Selected = false;
                cardArtUserControl.SelectedChanged += CardArtUserControl_SelectedChanged;
            }
        }

        if (control.Selected)
        {
            this.selectedCardArtUserControl = control;
            this.cardPictureBox.Refresh();
        }
    }

    void CardArtUserControl_LoadCompleted(object? sender, EventArgs e)
    {
        var control = sender as CardArtUserControl;
        if (control == null) return;

        if (control.Selected)
        {
            this.cardPictureBox.Refresh();
        }
    }

    void SaveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (this.loading) return;

        var cardText = ((CardTextUserControl)this.cardTextTabControl.TabPages[0].Controls[0]);
        var card = new Card
        {
            ScryfallReference = this.expansionCardPictureBox.ImageLocation,
            CardText = cardText.CardText,
            FontSize = this.fontSizeTrackBar.Value,
            Frame = this.frameComboBox.Text,
            ManaCost = this.manaCostTextBox.Text,
            Name = this.cardNameTextBox.Text,
            Power = cardText.HasPowerAndToughness ? cardText.Power : string.Empty,
            Rarity = this.rarityComboBox.Text,
            Toughness = cardText.HasPowerAndToughness ? cardText.Toughness : string.Empty,
            Subtypes = new List<string>
            {
                this.subtype1TextBox.Text,
                this.subtype2TextBox.Text,
                this.subtype3TextBox.Text
            },
            Supertypes = new List<string>
            {
                this.supertype1ComboBox.Text,
                this.supertype2ComboBox.Text,
            },
            Types = new List<string>
            {
                this.type1ComboBox.Text,
                this.type2ComboBox.Text,
                this.type3ComboBox.Text,
            }
        };

        this.cube.AddOrUpdate(card);
        this.cube.Save();

        var artImage = this.selectedCardArtUserControl?.RenderedImage;
        if (artImage != null)
        {
            this.cube.SaveArtImage(card.ScryfallReference, artImage);
        }

        using var cardImage = RenderCardImage(card);
        if (cardImage != null)
        {
            this.cube.SaveCardImage(card.ScryfallReference, cardImage);
        }
    }

    void NextButton_Click(object sender, EventArgs e)
    {
        SaveToolStripMenuItem_Click(sender, e);

        this.currentCard++;
        if (this.currentCard >= this.scryfallCards.Count)
        {
            this.currentCard = 0;
        }

        this.loading = true;
        ClearControls();
        SetControlsToCurrentCard();
        SetControlsEnabled(true);
        this.loading = false;

        CardTextBox_TextChanged(this, new EventArgs());
        this.cardPictureBox.Refresh();
    }

    void PreviousButton_Click(object sender, EventArgs e)
    {
        SaveToolStripMenuItem_Click(sender, e);

        this.currentCard--;
        if (this.currentCard < 0)
        {
            this.currentCard = this.scryfallCards.Count - 1;
        }

        this.loading = true;
        ClearControls();
        SetControlsToCurrentCard();
        SetControlsEnabled(true);
        this.loading = false;

        CardTextBox_TextChanged(this, new EventArgs());
        this.cardPictureBox.Refresh();
    }

    void ColorNavigationComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (this.loading) return;

        var selectedColor = ((CardColorItem)this.colorNavigationComboBox.SelectedItem).Value;
        var prevCard = this.currentCard;

        SaveToolStripMenuItem_Click(sender, e);

        this.currentCard = FindSelectedCardByColor(selectedColor, this.currentCard, this.scryfallCards.Count - 1);
        if (prevCard == currentCard)
        {
            this.currentCard = FindSelectedCardByColor(selectedColor, 0, this.currentCard + 1);
        }

        ClearControls();
        SetControlsToCurrentCard();
        SetControlsEnabled(true);

        CardTextBox_TextChanged(this, new EventArgs());
        this.cardPictureBox.Refresh();
    }

    void NextColorToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var index = this.colorNavigationComboBox.SelectedIndex + 1;
        this.colorNavigationComboBox.SelectedIndex =
            index > this.colorNavigationComboBox.Items.Count - 1 ? 0 : index;
    }

    void PreviousColorToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var index = this.colorNavigationComboBox.SelectedIndex - 1;
        this.colorNavigationComboBox.SelectedIndex =
            index < 0 ? this.colorNavigationComboBox.Items.Count - 1 : index;
    }

    int FindSelectedCardByColor(string selectedColor, int startIndex, int endIndex)
    {
        for (int i = startIndex; i < endIndex; ++i)
        {
            var card = this.scryfallCards[i];
            
            var isMonoColored = card.Colors.Count == 1 && "WUBRG".Contains(selectedColor) && selectedColor == card.Colors[0];
            var isMultiColored = card.Colors.Count > 1 && selectedColor == "M";
            var isColorless = card.Colors.Count == 0 && selectedColor == "0" && !card.TypeLine.Contains("Land");
            var isLand = card.Colors.Count == 0 && selectedColor == "L" && card.TypeLine.Contains("Land");

            if (isMonoColored || isMultiColored || isColorless || isLand)
            {
                return i;
            }
        }

        return startIndex;
    }

    Image RenderCardImage(Card card)
    {
        using var cardImage = new Bitmap(this.cardPictureBox.Width, this.cardPictureBox.Height);
        this.cardPictureBox.DrawToBitmap(cardImage, new Rectangle(0, 0, this.cardPictureBox.Width, this.cardPictureBox.Height));

        using var powerAndToughnessImage = new Bitmap(this.powerAndToughnessPictureBox.Width, this.powerAndToughnessPictureBox.Height);
        this.powerAndToughnessPictureBox.DrawToBitmap(powerAndToughnessImage, new Rectangle(0, 0, this.powerAndToughnessPictureBox.Width, this.powerAndToughnessPictureBox.Height));

        using var cardText = new Bitmap(this.cardTextRichTextBox.Width, this.cardTextRichTextBox.Height);
        this.cardTextRichTextBox.DrawToBitmap(cardText, new Rectangle(0, 0, this.cardTextRichTextBox.Width, this.cardTextRichTextBox.Height));

        using var control = new PictureBox();
        control.Width = this.cardPictureBox.Width;
        control.Height = this.cardPictureBox.Height;
        control.Paint += (sender, e) =>
        {
            e.Graphics.FillRectangle(Brushes.Black, new Rectangle(0, 0, control.Width, control.Height));

            e.Graphics.DrawImage(cardImage, 0, 0);

            if (!string.IsNullOrEmpty(card.CardText))
            {
                e.Graphics.DrawImage(cardText, 26, 277);
            }

            if (card.HasPowerAndToughness)
            {
                e.Graphics.DrawImage(powerAndToughnessImage, 235, 385);
            }
        };
        control.Refresh();

        var bmp = new Bitmap(control.Width, control.Height);
        control.DrawToBitmap(bmp, new Rectangle(0, 0, control.Width, control.Height));

        return bmp;
    }

    Image ScaleImage(Image image, int scale)
    {
        int width = 63 * scale;
        int height = 88 * scale;

        var bmp = new Bitmap(width, height);
        using var g = Graphics.FromImage(bmp);
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        
        g.FillRectangle(Brushes.Black, new Rectangle(0, 0, width, height));
        g.DrawImage(image, new Rectangle(0, 0, width, height));

        return bmp;
    }

    async Task<(CardText, CardArt)> GenerateCard()
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
        CardArt cardArt = new CardArt();

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

        cardArt = await this.urzasClient.GenerateImageAsync(cardText);

        return (cardText, cardArt);
    }

    void LoadCube()
    {
        this.loading = true;
        Application.UseWaitCursor = true;
        this.scryfallCards = this.scryfallClient.GetCardsForCube(this.cube)?.ToList() ?? new();

        ClearControls();

        if (this.scryfallCards.Count == 0)
        {
            return;
        }

        SetControlsToCurrentCard();
        
        SetControlsEnabled(true);
        this.panel.Hide();
        Application.UseWaitCursor = false;
        this.loading = false;

        CardTextBox_TextChanged(this, new EventArgs());
        this.cardPictureBox.Refresh();
    }

    Card GetCurrentCard()
    {
        var scryfallCard = this.scryfallCards[this.currentCard];
        var cubeCard = this.cube.Cards.FirstOrDefault(_ => _.ScryfallReference == scryfallCard.ImageUris.Normal);

        var allCardTypes = scryfallCard.TypeLine
             .Replace(" — ", " ")
             .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        var supertypes = new List<string>();
        var types = new List<string>();
        var subtypes = new List<string>();

        for (int i = 0; i < allCardTypes.Length; ++i)
        {
            var cardType = allCardTypes[i];
            if (CardTypes.Supertypes.Contains(cardType))
            {
                supertypes.Add(cardType);

            }
            else if (CardTypes.Types.Contains(cardType))
            {
                types.Add(cardType);
            }
            else
            {
                subtypes.Add(cardType);
            }
        }

        return cubeCard ?? new Card
        {
            CardText = string.Empty,
            FontSize = 11,
            Frame = Frames.GetFrameForCard(scryfallCard).Description,
            ManaCost = scryfallCard.ManaCost,
            Name = string.Empty,
            Power = scryfallCard.Power,
            Rarity = Rarities.GetRarity(scryfallCard.Rarity),
            ScryfallReference = scryfallCard.ImageUris.Normal,
            Subtypes = subtypes,
            Supertypes = supertypes,
            Types = types,
            Toughness = scryfallCard.Toughness
        };
    }

    void SetControlsToCurrentCard()
    {
        var card = this.GetCurrentCard();

        this.expansionCardPictureBox.ImageLocation = card.ScryfallReference;
        
        this.cardNameTextBox.Text = card.Name;
        this.manaCostTextBox.Text = card.ManaCost;
        this.frameComboBox.Text = card.Frame;
        this.supertype1ComboBox.Text = card.Supertypes.Count > 0 ? card.Supertypes[0] : string.Empty;
        this.supertype2ComboBox.Text = card.Supertypes.Count > 1 ? card.Supertypes[1] : string.Empty;
        this.type1ComboBox.Text = card.Types.Count > 0 ? card.Types[0] : string.Empty;
        this.type2ComboBox.Text = card.Types.Count > 1 ? card.Types[1] : string.Empty;
        this.type3ComboBox.Text = card.Types.Count > 2 ? card.Types[2] : string.Empty;
        this.subtype1TextBox.Text = card.Subtypes.Count > 0 ? card.Subtypes[0] : string.Empty;
        this.subtype2TextBox.Text = card.Subtypes.Count > 1 ? card.Subtypes[1] : string.Empty;
        this.subtype3TextBox.Text = card.Subtypes.Count > 2 ? card.Subtypes[2] : string.Empty;
        this.rarityComboBox.Text = card.Rarity;
        this.fontSizeTrackBar.Value = card.FontSize;
        this.cardTextUserControl.CardText = card.CardText;

        var cardTextFontFamily = Fonts.GetFontFamily("MPlantin");
        using var cardTextFont = new Font(cardTextFontFamily, this.fontSizeTrackBar.Value, FontStyle.Regular);
        this.cardTextRichTextBox.Font = cardTextFont;

        var selectedColor = new CardColorComparer().GetColorIndex(this.scryfallCards[this.currentCard]);
        foreach (CardColorItem item in this.colorNavigationComboBox.Items)
        {
            if (item.Value == selectedColor)
            {
                this.colorNavigationComboBox.Text = item.Name;
                break;
            }
        }

        this.cardTextUserControl.HasPowerAndToughness =
            !string.IsNullOrEmpty(card.Power) ||
            !string.IsNullOrEmpty(card.Toughness);

        this.cardTextUserControl.Power = card.Power;
        this.cardTextUserControl.Toughness = card.Toughness;

        var art = this.cube.GetArtImagePath(card.ScryfallReference);
        if (!string.IsNullOrEmpty(art))
        {
            AddArtControl(new CardArt
            {
                ArtUrl = art,
                State = "completed"
            }, selected: true);
        }
    }

    void AddArtControl(CardArt art, bool selected = false)
    {
        var cardArtUserControl = new CardArtUserControl
        {
            CardArt = art,
            Width = 150,
            Height = 150
        };

        cardArtUserControl.SelectedChanged += CardArtUserControl_SelectedChanged;
        cardArtUserControl.LoadCompleted += CardArtUserControl_LoadCompleted;

        if (this.selectedCardArtUserControl == null || selected)
        {
            this.selectedCardArtUserControl = cardArtUserControl;
            cardArtUserControl.Selected = true;
        }

        this.cardArtFlowLayoutPanel.Controls.Add(cardArtUserControl);
    }
    
    void ClearControls()
    {
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
        this.cardTextTabControl.SelectedIndex = 0;
        this.cardTextUserControl.CardText = string.Empty;
        this.cardTextUserControl.HasPowerAndToughness = false;
        this.cardTextUserControl.Power = string.Empty;
        this.cardTextUserControl.Toughness = string.Empty;
        this.saveToolStripMenuItem.Enabled = false;
        this.navigationToolStripMenuItem.Visible = false;

        ClearArt();
        ClearTabs();
    }

    void ClearArt()
    {
        foreach (CardArtUserControl artControl in this.cardArtFlowLayoutPanel.Controls)
        {
            artControl.SelectedChanged -= CardArtUserControl_SelectedChanged;
        }

        this.cardArtFlowLayoutPanel.Controls.Clear();
        this.selectedCardArtUserControl = null;
    }

    void ClearTabs()
    {
        var tab = this.cardTextTabControl.TabPages[0];
        this.cardTextTabControl.TabPages.Clear();
        this.cardTextTabControl.TabPages.Add(tab);
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

        if (!string.IsNullOrEmpty(this.cube.CubeName))
        {
            this.saveToolStripMenuItem.Enabled = true;
            this.navigationToolStripMenuItem.Visible = true;
        }
    }
}