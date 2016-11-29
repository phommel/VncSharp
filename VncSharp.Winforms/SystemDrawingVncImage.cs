using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using VncSharp.PlatformIndependentDrawing;

namespace VncSharp.Winforms
{
    public class SystemDrawingIVncImage : IVncImage
    {
        private readonly Image Img;

        public int Width => Img.Width;

        public int Height => Img.Height;

        public VncSize Size => Img.Size.ToVncSize();

        public SystemDrawingIVncImage(Image img)
        {
            Img = img;
        }
    }

    public static class ImageExtensions
    {
        public static SystemDrawingIVncImage ToVncImage(this Image img) => new SystemDrawingIVncImage(img);
    }

    public class SystemDrawingIVncBitmap : IVncBitmap
    {
        private readonly Bitmap Bmp;

        public int Width => Bmp.Width;
        public int Height => Bmp.Height;
        public VncSize Size => Bmp.Size.ToVncSize();

        public IVncBitmapData LockBits(VncRectangle rectangle) => 
            Bmp.LockBits(rectangle.ToRectangle(), ImageLockMode.ReadWrite, Bmp.PixelFormat)
                .ToVncBitmapData();

        public void UnlockBits(IVncBitmapData bmpdata)
        {
            Bmp.UnlockBits((bmpdata as SystemDrawingIVncBitmapData).BmpData);
        }

        public SystemDrawingIVncBitmap(Bitmap bmp)
        {
            Bmp = bmp;
        }
    }

    public class SystemDrawingIVncBitmapData : IVncBitmapData
    {
        public readonly BitmapData BmpData;

        public IntPtr Scan0 => BmpData.Scan0;

        public SystemDrawingIVncBitmapData(BitmapData bmpdata)
        {
            BmpData = bmpdata;
        }
    }

    public static class BitmapExtensions
    {
        public static SystemDrawingIVncBitmap ToVncBitmap(this Bitmap bmp) => 
            new SystemDrawingIVncBitmap(bmp);
        public static SystemDrawingIVncBitmapData ToVncBitmapData(this BitmapData bmpdata) =>
            new SystemDrawingIVncBitmapData(bmpdata);
    }


}
