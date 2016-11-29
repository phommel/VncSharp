using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using VncSharp.PlatformIndependentDrawing;

namespace VncSharp.Winforms
{
    public static class SystemDrawingExtensions
    {
        public static VncSize ToVncSize(this Size size) => new VncSize(size.Width,size.Height);
        public static Size ToSize(this VncSize size) => new Size(size.Width, size.Height);

        public static VncPoint ToVncPoint(this Point point) => new VncPoint(point.X, point.Y);

        public static VncRectangle ToVncRectangle(this Rectangle rect) => 
            new VncRectangle(rect.X,rect.Y,rect.Width,rect.Height);
        public static Rectangle ToRectangle(this VncRectangle rect) =>
            new Rectangle(rect.X, rect.Y, rect.Width, rect.Height);
    }
}
