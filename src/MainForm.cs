using Hypercube.Scryfall;

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

    void Supertype1ComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        CanGenerateCard();
        this.supertype2ComboBox.Enabled = !string.IsNullOrEmpty(this.supertype1ComboBox.Text);
    }

    void Type1ComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        CanGenerateCard();
    }

    void SubtypeTextBox_TextChanged(object sender, EventArgs e)
    {
        CanGenerateCard();
    }

    void RarityComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        CanGenerateCard();
    }

    void CardPictureBox_Paint(object sender, PaintEventArgs e)
    {
        var fontFamily = Fonts.GetFontFamily("Beleren");
        using var font = new Font(fontFamily, 10);
        
        e.Graphics.DrawString(this.cardNameTextBox.Text, font, Brushes.Black, new Point(23, 26));
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

        this.cubeNameLabel.Text = cube.CubeName;
        this.expansionNameLabel.Text = cube.Expansion;
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

        var allCardTypes = card.TypeLine.Split(" — ");
        var cardTypes = allCardTypes[0].Split(" ", StringSplitOptions.RemoveEmptyEntries);
        var subtypes = allCardTypes.Length > 1
            ? allCardTypes[1].Split(" ", StringSplitOptions.RemoveEmptyEntries)
            : Array.Empty<string>();

        for (int i = 0; i < cardTypes.Length; ++i)
        {
            var cardType = cardTypes[i];
            if (CardTypes.Supertypes.Contains(cardType))
            {
                if (i == 0)
                {
                    this.supertype1ComboBox.Text = cardType;
                }
                else if (i == 1)
                {
                    this.supertype2ComboBox.Text = cardType;
                }
                else break;
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
