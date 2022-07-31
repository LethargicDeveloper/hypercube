namespace Hypercube;

public partial class MainForm : Form
{
    readonly FormNavigation navigation;

    public MainForm(FormNavigation navigation)
    {
        InitializeComponent();

        this.navigation = navigation;
    }

    void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    void NewCubeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.navigation.ShowDialog<NewCubeForm>();
    }

    void OpenCubeToolStripMenuItem_Click(object sender, EventArgs e)
    {

    }
}
