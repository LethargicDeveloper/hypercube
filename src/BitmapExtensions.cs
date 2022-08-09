using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Text;

namespace Hypercube;

public static class BitmapExtensions
{
    [Flags]
    private enum EmfToWmfBitsFlags
    {
        EmfToWmfBitsFlagsDefault = 0x00000000,
        EmfToWmfBitsFlagsEmbedEmf = 0x00000001,
        EmfToWmfBitsFlagsIncludePlaceable = 0x00000002,
        EmfToWmfBitsFlagsNoXORClip = 0x00000004
    }

    [DllImport("gdiplus.dll")]
    private static extern uint GdipEmfToWmfBits(IntPtr _hEmf, uint _bufferSize, byte[] _buffer, int _mappingMode, EmfToWmfBitsFlags _flags);
    [DllImport("gdi32.dll")]
    private static extern IntPtr SetMetaFileBitsEx(uint _bufferSize, byte[] _buffer);
    [DllImport("gdi32.dll")]
    private static extern IntPtr CopyMetaFile(IntPtr hWmf, string filename);
    [DllImport("gdi32.dll")]
    private static extern bool DeleteMetaFile(IntPtr hWmf);
    [DllImport("gdi32.dll")]
    private static extern bool DeleteEnhMetaFile(IntPtr hEmf);

    public static string ToMetafileHexString(this Bitmap image)
    {
        const int MM_ANISOTROPIC = 8;

        Metafile metafile = null!;
        using (Graphics g = Graphics.FromImage(image))
        {
            IntPtr hDC = g.GetHdc();
            metafile = new Metafile(hDC, EmfType.EmfOnly);
            g.ReleaseHdc(hDC);
        }

        using (Graphics g = Graphics.FromImage(metafile))
        {
            g.DrawImage(image, 0, 0);
        }

        IntPtr _hEmf = metafile.GetHenhmetafile();
        uint _bufferSize = GdipEmfToWmfBits(_hEmf, 0, null!, MM_ANISOTROPIC, EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);
        byte[] _buffer = new byte[_bufferSize];
        GdipEmfToWmfBits(_hEmf, _bufferSize, _buffer, MM_ANISOTROPIC, EmfToWmfBitsFlags.EmfToWmfBitsFlagsDefault);
        DeleteEnhMetaFile(_hEmf);

        using var stream = new MemoryStream();
        stream.Write(_buffer, 0, (int)_bufferSize);
        stream.Seek(0, 0);

        var bytes = stream.ToArray();
        var hex = BitConverter.ToString(bytes).Replace("-", string.Empty);

        return hex;
    }
}
