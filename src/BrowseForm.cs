using Hypercube.Scryfall;

namespace Hypercube;

public partial class BrowseForm : Form
{
    const float SizeMultiplier = 0.85f;
    const int NumCards = 50;

    readonly Cube cube;
    readonly List<PictureBox> controls;
    List<Card> cards;
    int startIndex = 0;

    public event EventHandler<CardEventArgs>? SelectionChanged;

    public BrowseForm(Cube cube)
    {
        this.cube = cube;
        this.cards = new List<Card>();
        this.controls = new List<PictureBox>();

        InitializeComponent();
    }

    void BrowseForm_Load(object sender, EventArgs e)
    {
        this.cards = this.cube.Cards?
            .OrderBy(_ => _, new CardColorComparer())
            .ThenBy(_ => _.Name)
            .Where(_ => !string.IsNullOrEmpty(_.Name))
            .ToList() ?? new List<Card>();

        AddCardsToPanel();
    }

    private void FlowLayoutPanel_MouseWheel(object? sender, MouseEventArgs e)
    {
        var oldValue = this.flowLayoutPanel.VerticalScroll.Value;
        var newValue = oldValue + this.flowLayoutPanel.VerticalScroll.LargeChange;
        var eventArgs = new ScrollEventArgs(ScrollEventType.LargeIncrement, oldValue, newValue);

        FlowLayoutPanel_Scroll(sender ?? this.flowLayoutPanel, eventArgs);
    }

    void FlowLayoutPanel_Scroll(object sender, ScrollEventArgs e)
    {
        var vs = this.flowLayoutPanel.VerticalScroll;
        if (e.NewValue >= vs.Maximum - vs.LargeChange + 1)
        {
            AddCardsToPanel();
        }
    }

    void PictureBox_Click(object? sender, EventArgs e)
    {
        var pictureBox = sender as PictureBox;
        if (pictureBox == null) return;

        var card = (Card)pictureBox.Tag;
        OnSelectionChanged(new CardEventArgs(card));
    }

    void AddCardsToPanel()
    {
        this.flowLayoutPanel.SuspendLayout();
        for (int i = startIndex; i < startIndex + NumCards && i < this.cards.Count; ++i)
        {
            var card = cards[i];
            var pictureBox = new PictureBox
            {
                ImageLocation = this.cube.GetCardImagePath(card.ScryfallReference),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Width = (int)(315 * SizeMultiplier),
                Height = (int)(440 * SizeMultiplier),
                Margin = Padding.Empty,
                Cursor = Cursors.Hand,
                Tag = card
            };

            pictureBox.Click += PictureBox_Click;

            this.flowLayoutPanel.Controls.Add(pictureBox);
        }

        startIndex += NumCards;

        this.flowLayoutPanel.ResumeLayout();
    }

    protected virtual void OnSelectionChanged(CardEventArgs e)
    {
        var handler = SelectionChanged;
        handler?.Invoke(this, e);
    }
}

public class CardEventArgs : EventArgs
{
    public CardEventArgs(Card card)
    {
        Card = card;
    }

    public Card Card { get; init; }
}