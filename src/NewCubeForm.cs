using Hypercube.Scryfall;

namespace Hypercube;

public partial class NewCubeForm : Form
{
    readonly ScryfallClient client;
    readonly CubeManager cubeManager;

    List<Expansion> expansions;

    public NewCubeForm(ScryfallClient client, CubeManager cubeManager)
    {
        InitializeComponent();

        this.client = client;
        this.cubeManager = cubeManager;
        this.expansions = new List<Expansion>();
    }

    public Cube Cube { get; private set; } = null!;

    void CancelButton_Click(object sender, EventArgs e)
    {
        this.DialogResult = DialogResult.Cancel;
        this.Close();
    }

    void NewCubeForm_Load(object sender, EventArgs e)
    {
        expansions = this.client.GetExpansions().ToList();
        this.setListBox.Items.AddRange(expansions.ToArray());
    }

    void SetFilterTextBox_TextChanged(object sender, EventArgs e)
    {
        var filteredExpansion = this
            .expansions
            .Where(_ => _.Name.Contains(this.setFilterTextBox.Text, StringComparison.OrdinalIgnoreCase));

        this.setListBox.BeginUpdate();
        this.setListBox.Items.Clear();
        this.setListBox.Items.AddRange(filteredExpansion.ToArray());
        this.setListBox.EndUpdate();
    }

    void OkButton_Click(object sender, EventArgs e)
    {
        var expansion = (Expansion)this.setListBox.SelectedItem;

        this.Cube = new Cube()
        {
            CubeName = this.cubeNameTextBox.Text,
            Expansion = expansion.Name,
            ExpansionCode = expansion.Code,
            ScryfallUri = expansion.SearchUri
        };

        this.Cursor = Cursors.WaitCursor;
        if (this.cubeManager.CreateCube(this.Cube))
        {
            this.Cursor = Cursors.Default;
            DialogResult = DialogResult.OK;
            this.Close();
            return;
        }

        this.Cursor = Cursors.Default;
        MessageBox.Show($"The cube \"{this.Cube.CubeName}\" already exists.", "Error");
    }

    void CubeNameTextBox_TextChanged(object sender, EventArgs e)
    {
        ValidateForm();
    }

    void SetListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        ValidateForm();
    }

    void ValidateForm()
    {
        this.okButton.Enabled =
            !string.IsNullOrEmpty(this.cubeNameTextBox.Text) &&
            this.setListBox.SelectedIndex > -1;
    }
}
