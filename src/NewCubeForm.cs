using Hypercube.Scryfall;

namespace Hypercube;

public partial class NewCubeForm : Form
{
    readonly ScryfallClient client;

    List<Expansion> expansions;

    public NewCubeForm(ScryfallClient client)
    {
        InitializeComponent();

        this.client = client;
        this.expansions = new List<Expansion>();
    }

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
