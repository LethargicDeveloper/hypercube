using Hypercube.Scryfall;

namespace Hypercube;

public partial class BrowseForm : Form
{
    const float SizeMultiplier = 0.85f;

    readonly Cube cube;

    public event EventHandler<CardEventArgs>? SelectionChanged;

    public BrowseForm(Cube cube)
    {
        this.cube = cube;
        InitializeComponent();
    }

    void BrowseForm_Load(object sender, EventArgs e)
    {
        // TODO: clicking card should load card in editor

        var cards = this.cube.Cards?
            .OrderBy(_ => _, new CardColorComparer())
            .ThenBy(_ => _.Name)
            .Where(_ => !string.IsNullOrEmpty(_.Name))
            .ToList() ?? new List<Card>();

        foreach (var card in cards)
        {
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
    }

    private void PictureBox_Click(object? sender, EventArgs e)
    {
        var pictureBox = sender as PictureBox;
        if (pictureBox == null) return;

        var card = (Card)pictureBox.Tag;
        OnSelectionChanged(new CardEventArgs(card));
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