using System;
using System.Collections.Generic;
using System.Text;

namespace VncSharp.PlatformIndependentDrawing
{
    public interface IVncImage
    {
        int Width { get; }
        int Height { get; }
        VncSize Size { get; }
    }
}
