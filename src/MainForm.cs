namespace Hypercube;

public partial class MainForm : Form
{
    readonly FormFactory form;
    readonly CubeManager cubeManager;

    public MainForm(FormFactory form, CubeManager cubeManager)
    {
        InitializeComponent();

        this.form = form;
        this.cubeManager = cubeManager;
    }

    void ExitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }

    void NewCubeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var newCubeForm = this.form.Create<NewCubeForm>();
        if (newCubeForm.ShowDialog() == DialogResult.OK)
        {
        }
    }

    void OpenCubeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        this.folderBrowserDialog.InitialDirectory = Path.GetFullPath(".\\Cubes");
        if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
        {
            var cubeName = Path.GetFileName(this.folderBrowserDialog.SelectedPath);
            var cube = this.cubeManager.LoadCube(cubeName);
        }
    }
}
