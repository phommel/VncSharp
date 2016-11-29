using System;
using System.Collections.Generic;
using System.Text;

namespace VncSharp.PlatformIndependentDrawing
{
    public struct VncPoint
    {
        public bool IsEmpty
        {
            get
            {
                if (X == 0) return Y == 0;
                return false;
            }
        }

        public int X { get; set; }

        public int Y { get; set; }

        public VncPoint(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    public struct VncSize
    {
        public static readonly VncSize Empty;

        public bool IsEmpty
        {
            get
            {
                if (Width == 0) return Height == 0;
                return false;
            }
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public VncSize(VncPoint pt)
        {
            Width = pt.X;
            Height = pt.Y;
        }

        public VncSize(int width, int height)
        {
            Width = width;
            Height = height;
        }
    }

    public struct VncRectangle
    {
        public static readonly VncRectangle Empty;

        public VncPoint Location
        {
            get
            {
                return new VncPoint(X, Y);
            }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        public VncSize Size
        {
            get
            {
                return new VncSize(Width, Height);
            }
            set
            {
                Width = value.Width;
                Height = value.Height;
            }
        }

        public int X { get; set; }

        public int Y { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public int Left => X;

        public int Top => Y;
        public int Right => X + Width;
        public int Bottom => Y + Height;

        public bool IsEmpty
        {
            get
            {
                if (Height == 0 && Width == 0 && X == 0)
                    return Y == 0;
                return false;
            }
        }

        public VncRectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public VncRectangle(VncPoint location, VncSize size)
        {
            X = location.X;
            Y = location.Y;
            Width = size.Width;
            Height = size.Height;
        }

        public static bool operator == (VncRectangle left, VncRectangle right)
        {
            if (left.X == right.X && left.Y == right.Y && left.Width == right.Width)
                return left.Height == right.Height;
            return false;
        }

        public static bool operator != (VncRectangle left, VncRectangle right)
        {
            return !(left == right);
        }

        public void Inflate(int width, int height)
        {
            X = X - width;
            Y = Y - height;
            Width = Width + 2 * width;
            Height = Height + 2 * height;
        }

        public void Inflate(VncSize size)
        {
            Inflate(size.Width, size.Height);
        }

        public static VncRectangle Inflate(VncRectangle rect, int x, int y)
        {
            VncRectangle rectangle = rect;
            rectangle.Inflate(x, y);
            return rectangle;
        }

        public bool Contains(int x, int y)
        {
            if (this.X <= x && x < this.X + this.Width && this.Y <= y)
                return y < this.Y + this.Height;
            return false;
        }

        public bool Contains(VncPoint pt)
        {
            return this.Contains(pt.X, pt.Y);
        }

        public bool Contains(VncRectangle rect)
        {
            if (this.X <= rect.X && rect.X + rect.Width <= this.X + this.Width && this.Y <= rect.Y)
                return rect.Y + rect.Height <= this.Y + this.Height;
            return false;
        }
    }
}
