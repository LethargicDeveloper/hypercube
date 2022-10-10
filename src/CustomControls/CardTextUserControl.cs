namespace Hypercube;

public partial class CardTextUserControl : UserControl
{
    bool @readonly;

    public event EventHandler? CardTextChanged;
    public event EventHandler? HasPowerAndToughnessCheckChanged;
    public event EventHandler? PowerTextChanged;
    public event EventHandler? ToughnessTextChanged;

    public CardTextUserControl()
    {
        InitializeComponent();
    }

    public string CardText
    {
        get => this.cardTextBox.Text;
        set => this.cardTextBox.Text = value;
    }

    public bool HasPowerAndToughness
    {
        get => this.hasPowerAndToughnessCheckBox.Checked;
        set => this.hasPowerAndToughnessCheckBox.Checked = value;
    }

    public string Power
    {
        get => this.powerTextBox.Text;
        set => this.powerTextBox.Text = value;
    }

    public string Toughness
    {
        get => this.toughnessTextBox.Text;
        set => this.toughnessTextBox.Text = value;
    }

    public bool Readonly
    {
        get => this.@readonly;
        set
        {
            this.@readonly = value;
            UpdateReadonly();
        }
    }

    protected virtual void OnCardTextChanged(EventArgs e)
    {
        var handler = CardTextChanged;
        handler?.Invoke(this, e);
    }

    protected virtual void OnHasPowerAndToughnessCheckChanged(EventArgs e)
    {
        var handler = HasPowerAndToughnessCheckChanged;
        handler?.Invoke(this, e);
    }

    protected virtual void OnPowerTextChanged(EventArgs e)
    {
        var handler = PowerTextChanged;
        handler?.Invoke(this, e);
    }

    protected virtual void OnToughnessTextChanged(EventArgs e)
    {
        var handler = ToughnessTextChanged;
        handler?.Invoke(this, e);
    }

    void CardTextBox_TextChanged(object sender, EventArgs e)
    {
        this.OnCardTextChanged(e);
    }

    void HasPowerAndToughnessCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        this.OnHasPowerAndToughnessCheckChanged(e);
    }

    void PowerTextBox_TextChanged(object sender, EventArgs e)
    {
        this.OnPowerTextChanged(e);
    }

    void ToughnessTextBox_TextChanged(object sender, EventArgs e)
    {
        this.OnToughnessTextChanged(e);
    }

    void UpdateReadonly()
    {
        this.cardTextBox.ReadOnly = this.@readonly;
        this.powerTextBox.ReadOnly = this.@readonly;
        this.toughnessTextBox.ReadOnly = this.Readonly;
        this.hasPowerAndToughnessCheckBox.Visible = !this.Readonly;
        
        this.powerTextBox.DeselectAll();
        this.toughnessTextBox.DeselectAll();
        this.cardTextBox.DeselectAll();
    }
}
