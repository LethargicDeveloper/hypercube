using Hypercube.Scryfall;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Hypercube;

public partial class MainForm : Form
{
    readonly FormFactory form;
    readonly CubeManager cubeManager;
    readonly ScryfallClient scryfallClient;
    readonly CardSymbolProvider cardSymbolProvider;
    readonly Panel panel = new()
    {
        Dock = DockStyle.Fill
    };

    public MainForm(
        FormFactory form,
        CubeManager cubeManager,
        ScryfallClient scryfallClient,
        CardSymbolProvider cardSymbolProvider)
    {
        InitializeComponent();

        this.form = form;
        this.cubeManager = cubeManager;
        this.scryfallClient = scryfallClient;
        this.cardSymbolProvider = cardSymbolProvider;
        this.Controls.Add(this.panel);
        this.panel.BringToFront();

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
        this.cardPictureBox.Load();
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
        this.cardPictureBox.Refresh();
    }

    void PowerTextBox_TextChanged(object sender, EventArgs e)
    {
        this.cardPictureBox.Refresh();
    }

    void ToughnessTextBox_TextChanged(object sender, EventArgs e)
    {
        this.cardPictureBox.Refresh();
    }

    void CardPictureBox_Paint(object sender, PaintEventArgs e)
    {
        var beleren = Fonts.GetFontFamily("Beleren");
        var relay = Fonts.GetFontFamily("Relay-Medium");

        using var belerenFont = new Font(beleren, 10);
        using var relayFont = new Font(relay, 8);

        e.Graphics.DrawString(this.cardNameTextBox.Text, belerenFont, Brushes.Black, new Point(25, 30));

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

        e.Graphics.DrawString(cardType, relayFont, Brushes.Black, new Point(28, 300));

        var rarity = Path.Combine(".\\img", "expansions",
            Rarities.GetIconPath(this.rarityComboBox.Text));

        var rarityImage = Image.FromFile(rarity);
        e.Graphics.DrawImage(rarityImage, 324, 298, 20, 20);

        var manaSymbolPaths = this.cardSymbolProvider
            .GetCardSymbolImagePaths(this.manaCostTextBox.Text)
            .Reverse();

        int i = 0;
        foreach (var manaSymbolPath in manaSymbolPaths)
        {
            var manaSymbol = Image.FromFile(manaSymbolPath);

            e.Graphics.DrawImage(manaSymbol, 325 - (20 * i++), 30);
        }

        if (this.hasPowerToughnessCheckBox.Checked)
        {
            var powerAndToughness = Image.FromFile(".\\img\\frames\\power_toughness.png");
            e.Graphics.DrawImage(powerAndToughness, 275, 460);

            var powerFontSize = this.powerTextBox.Text.Length <= 2 ? 14 : 10;
            var powerLeftOffset = (this.powerTextBox.Text.Length <= 2 ? 14 : 7) *
                (this.powerTextBox.Text.Length - 1);
            var powerTopOffset = this.powerTextBox.Text.Length <= 2 ? 0 : 5;
            using var powerFont = new Font(beleren, powerFontSize);
            e.Graphics.DrawString(this.powerTextBox.Text, powerFont, Brushes.Black,
                new Point(295 - powerLeftOffset, 465 + powerTopOffset));

            var toughnessTopOffset = this.toughnessTextBox.Text.Length <= 2 ? 0 : 5;
            using var toughnessFont = new Font(beleren, this.toughnessTextBox.Text.Length <= 2 ? 14 : 10);
            e.Graphics.DrawString(this.toughnessTextBox.Text, toughnessFont, Brushes.Black,
                new Point(320, 465 + toughnessTopOffset));
        }
    }

    void SetControlsEnabled(bool enabled)
    {
        foreach (Control control in this.Controls)
        {
            if (control is Label)
            {
                control.Enabled = enabled;
            }
        }
    }

    void LoadCube(Cube cube)
    {
        this.Cursor = Cursors.WaitCursor;
        var cards = this.scryfallClient.GetCardsForCube(cube)?.ToList();
        this.Cursor = Cursors.Default;

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
        this.hasPowerToughnessCheckBox.Checked = false;
        this.powerTextBox.Text = string.Empty;
        this.toughnessTextBox.Text = string.Empty;

        if (cards == null || cards.Count == 0)
        {
            return;
        }

        var card = cards[0];

        this.expansionCardPictureBox.ImageLocation = card.ImageUris.Normal;

        this.manaCostTextBox.Text = card.ManaCost;

        var frames = Frames.GetFrames();
        this.frameComboBox.BeginUpdate();
        this.frameComboBox.Items.Clear();
        this.frameComboBox.Items.AddRange(frames.ToArray());
        this.frameComboBox.EndUpdate();
        this.frameComboBox.Text = Frames.GetFrameForCard(card).Description;

        this.cardNameTextBox.Text = card.Name;

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
        this.hasPowerToughnessCheckBox.Checked =
            !string.IsNullOrEmpty(card.Power) ||
            !string.IsNullOrEmpty(card.Toughness);

        this.powerTextBox.Text = card.Power;
        this.toughnessTextBox.Text = card.Toughness;

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

    void ManaCostHelpButton_Click(object sender, EventArgs e)
    {
        Process proc = new Process();
        proc.StartInfo.UseShellExecute = true;
        proc.StartInfo.FileName = "https://www.scryfall.com/docs/api/colors";
        proc.Start();
    }
}