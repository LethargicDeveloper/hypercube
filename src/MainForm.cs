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

    int currentCard = 0;

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
    }

    void ManaCostTextBox_TextChanged(object sender, EventArgs e)
    {
        CanGenerateCard();
    }

    void FrameComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        CanGenerateCard();
    }

    void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
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
        var cardTypes = card.TypeLine.Split(" — ");

        this.cubeNameLabel.Text = cube.CubeName;
        this.expansionNameLabel.Text = cube.Expansion;
        this.expansionCardPictureBox.ImageLocation = card.ImageUris.Normal;

        //this.cardNameTextBox.Text = card.Name;
        //this.manaCostTextBox.Text = card.ManaCost;
        //this.typeComboBox.Text = cardTypes[0];
        //this.subtypeTextBox.Text = cardTypes.Length == 2 ? cardTypes[1] : string.Empty;

        //this.rarityComboBox.SelectedIndex = this.rarityComboBox.FindStringExact(card.Rarity);
        //if (this.rarityComboBox.SelectedIndex == -1)
        //{
        //    this.rarityComboBox.SelectedIndex = 0;
        //}

        SetControlsEnabled(true);
        this.panel.Hide();
    }

    void CanGenerateCard()
    {
        this.generateButton.Enabled =
            !string.IsNullOrEmpty(this.cardNameTextBox.Text) &&
            !string.IsNullOrEmpty(this.frameComboBox.Text) &&
            !string.IsNullOrEmpty(this.typeComboBox.Text) &&
            !string.IsNullOrEmpty(this.rarityComboBox.Text);
    }

    private void CardImage1_Click(object sender, EventArgs e)
    {
        this.cardImage2.Checked = false;
        this.cardImage3.Checked = false;
        this.cardImage4.Checked = false;
    }

    private void CardImage2_Click(object sender, EventArgs e)
    {
        this.cardImage1.Checked = false;
        this.cardImage3.Checked = false;
        this.cardImage4.Checked = false;
    }

    private void CardImage3_Click(object sender, EventArgs e)
    {
        this.cardImage1.Checked = false;
        this.cardImage2.Checked = false;
        this.cardImage4.Checked = false;
    }

    private void CardImage4_Click(object sender, EventArgs e)
    {
        this.cardImage1.Checked = false;
        this.cardImage2.Checked = false;
        this.cardImage3.Checked = false;
    }
}
