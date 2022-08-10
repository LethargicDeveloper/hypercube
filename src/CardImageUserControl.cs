using Hypercube.UrzasAI;

namespace Hypercube;

public partial class CardImageUserControl : UserControl
{
    CardImage? cardImage;

    public CardImageUserControl()
    {
        InitializeComponent();
    }

    public event EventHandler? SelectedChanged;

    public bool Selected
    {
        get => this.radioButton.Checked;
        set => this.radioButton.Checked = value;
    }

    public CardImage? CardImage
    {
        get => this.cardImage;
        set
        {   if (value != this.cardImage)
            {
                if (this.cardImage != null)
                {
                    this.cardImage.PropertyChanged -= CardImage_PropertyChanged;
                }

                this.cardImage = value;
                
                if (this.cardImage != null)
                {
                    this.pictureBox.ImageLocation = this.cardImage.ArtUrl;
                    this.cardImage.PropertyChanged += CardImage_PropertyChanged;
                }
            }
        }
    }

    private void CardImage_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(CardImage.ArtUrl))
        {
            this.pictureBox.ImageLocation = this.cardImage?.ArtUrl;
            //this.pictureBox.Refresh();
        }
    }

    protected virtual void OnSelectedChanged(EventArgs e)
    {
        var handler = SelectedChanged;
        handler?.Invoke(this, e);
    }

    void CardImageUserControl_Click(object sender, EventArgs e)
    {
        if (!this.radioButton.Checked)
        {
            this.radioButton.Checked = true;
            OnSelectedChanged(e);
        }
    }

    void PictureBox_Click(object sender, EventArgs e)
    {
        this.OnClick(e);
    }
}
