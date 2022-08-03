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

    void LoadCube(Cube cube)
    {
        this.Cursor = Cursors.WaitCursor;
        var cards = this.scryfallClient.GetCardsForCube(cube)?.ToList();
        this.Cursor = Cursors.Default;

        if (cards == null || cards.Count == 0)
        {
            return;
        }

        this.cubeNameLabel.Text = cube.CubeName;
        this.expansionNameLabel.Text = cube.Expansion;
        this.expansionCardPictureBox.ImageLocation = cards.First().ImageUris.Normal;

        this.panel.Hide();
    }
}
