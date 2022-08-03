namespace Hypercube;

public partial class CardImageUserControl : UserControl
{
    public CardImageUserControl()
    {
        InitializeComponent();
    }

    private void CardImageUserControl_Click(object sender, EventArgs e)
    {
        this.radioButton.Checked = true;
    }
}
