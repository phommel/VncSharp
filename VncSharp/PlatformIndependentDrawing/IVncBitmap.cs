using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace VncSharp.PlatformIndependentDrawing
{
    public interface IVncBitmap
    {
        int Width { get; }
        int Height { get; }
        VncSize Size { get; }
        IVncBitmapData LockBits(VncRectangle rectangle);
        void UnlockBits(IVncBitmapData bmpdata);
    }

    public interface IVncBitmapData
    {
        IntPtr Scan0 { get; }
    }
}
