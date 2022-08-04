namespace Hypercube;

public partial class CardImageUserControl : UserControl
{
    public CardImageUserControl()
    {
        InitializeComponent();
    }

    public bool Checked
    {
        get => this.radioButton.Checked;
        set => this.radioButton.Checked = value;
    }

    private void CardImageUserControl_Click(object sender, EventArgs e)
    {
        this.radioButton.Checked = true;
    }

    private void PictureBox_Click(object sender, EventArgs e)
    {
        this.OnClick(e);
    }
}
