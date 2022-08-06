using Hypercube.Scryfall;
using System.Text.RegularExpressions;

namespace Hypercube;

public partial class MainForm : Form
{
    readonly FormFactory form;
    readonly CubeManager cubeManager;
    readonly ScryfallClient scryfallClient;
    readonly Panel panel = new()
    {
        Dock = DockStyle.Fill
    };

    public MainForm(FormFactory form, CubeManager cubeManager, ScryfallClient scryfallClient)
    {
        InitializeComponent();

        this.form = form;
        this.cubeManager = cubeManager;
        this.scryfallClient = scryfallClient;
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

        //cardType = "Legendary Enchantment - Background";

        e.Graphics.DrawString(cardType, relayFont, Brushes.Black, new Point(28, 300));
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

        if (cards == null || cards.Count == 0)
        {
            return;
        }

        var card = cards[0];

        this.expansionCardPictureBox.ImageLocation = card.ImageUris.Normal;

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
}
