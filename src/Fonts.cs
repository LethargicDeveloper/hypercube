using System.Drawing.Text;

namespace Hypercube;

public static class Fonts
{
    static readonly PrivateFontCollection fonts = new();

    static Fonts()
    {
        LoadFonts();
    }

    static void LoadFonts()
    {
        var files = Directory.GetFiles("fonts");

        foreach (var file in files)
        {
            fonts.AddFontFile(file);
        }
    }

    public static FontFamily GetFontFamily(string name)
    {
        return fonts.Families.FirstOrDefault(_ => _.Name == name) ?? new FontFamily("Arial");
    }
}
