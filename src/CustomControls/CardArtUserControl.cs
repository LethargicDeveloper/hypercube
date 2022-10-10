using Hypercube.UrzasAI;

namespace Hypercube;

public partial class CardArtUserControl : UserControl
{
    CardArt? cardArt;

    public event EventHandler? SelectedChanged;
    public event EventHandler? LoadCompleted;

    public CardArtUserControl()
    {
        InitializeComponent();
    }

    public bool Selected
    {
        get => this.radioButton.Checked;
        set => this.radioButton.Checked = value;
    }

    public CardArt? CardArt
    {
        get => this.cardArt;
        set
        {   if (value != this.cardArt)
            {
                if (this.cardArt != null)
                {
                    this.cardArt.PropertyChanged -= CardArt_PropertyChanged;
                }

                this.cardArt = value;
                
                if (this.cardArt != null)
                {
                    this.pictureBox.ImageLocation = this.cardArt.ArtUrl;
                    this.cardArt.PropertyChanged += CardArt_PropertyChanged;
                }
            }
        }
    }

    public Image RenderedImage
    {
        get => this.pictureBox.Image;
    }

    protected virtual void OnSelectedChanged(EventArgs e)
    {
        var handler = SelectedChanged;
        handler?.Invoke(this, e);
    }

    protected virtual void OnLoadCompleted(EventArgs e)
    {
        var handler = LoadCompleted;
        handler?.Invoke(this, e);
    }

    void CardArt_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(CardArt.ArtUrl))
        {
            this.pictureBox.ImageLocation = this.cardArt?.ArtUrl;
        }
    }

    void CardArtUserControl_Click(object sender, EventArgs e)
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

    void RadioButton_CheckedChanged(object sender, EventArgs e)
    {
        OnSelectedChanged(e);
    }

    void PictureBox_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
    {
        OnLoadCompleted(e);
    }
}
