using System;
using System.Collections.Generic;
using System.Text;

namespace VncSharp.PlatformIndependentDrawing
{
    public interface IRemoteDesktop
    {
        int Width { get; }
        int Height { get; }
        VncSize ClientSize { get; }
        VncRectangle ClientRectangle { get; }
        VncRectangle DisplayRectangle { get; }
        IVncImage Desktop { get; }
        VncPoint AutoScrollPosition { get; }
    }
}
