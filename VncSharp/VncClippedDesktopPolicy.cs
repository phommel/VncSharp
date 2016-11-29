// VncSharp - .NET VNC Client Library
// Copyright (C) 2008 David Humphrey
//
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA

using System;
using VncSharp.PlatformIndependentDrawing;

namespace VncSharp
{
	/// <summary>
	/// A clipped version of VncDesktopTransformPolicy.
	/// </summary>
	public sealed class VncClippedDesktopPolicy : VncDesktopTransformPolicy
	{
        public VncClippedDesktopPolicy(VncClient vnc, IRemoteDesktop remoteDesktop) 
            : base(vnc, remoteDesktop)
        {
        }

        public override bool AutoScroll {
            get {
                return true;
            }
        }

        public override VncSize AutoScrollMinSize {
            get {
                if (vnc != null && vnc.Framebuffer != null) {
                    return new VncSize(vnc.Framebuffer.Width, vnc.Framebuffer.Height);
                } else {
                    return new VncSize(100, 100);
                }
            }
        }

        public override VncPoint UpdateRemotePointer(VncPoint current)
        {
            VncPoint adjusted = new VncPoint();
			if (remoteDesktop.ClientSize.Width > remoteDesktop.Desktop.Size.Width) {
			    adjusted.X = current.X - ((remoteDesktop.ClientRectangle.Width - remoteDesktop.Desktop.Width) / 2);
			} else {
				adjusted.X = current.X - remoteDesktop.AutoScrollPosition.X;
			}
 
			if (remoteDesktop.ClientSize.Height > remoteDesktop.Desktop.Size.Height ) {
				adjusted.Y = current.Y - ((remoteDesktop.ClientRectangle.Height - remoteDesktop.Desktop.Height) / 2);
			} else {
				adjusted.Y = current.Y - remoteDesktop.AutoScrollPosition.Y;
			}

			return adjusted;
        }

        public override VncRectangle AdjustUpdateRectangle(VncRectangle updateRectangle)
        {
			int x, y;
			
			if (remoteDesktop.ClientSize.Width > remoteDesktop.Desktop.Size.Width) {
				x = updateRectangle.X + (remoteDesktop.ClientRectangle.Width - remoteDesktop.Desktop.Width) / 2;
			} else {
				x = updateRectangle.X + remoteDesktop.AutoScrollPosition.X;
			}

			if (remoteDesktop.ClientSize.Height > remoteDesktop.Desktop.Size.Height ) {
				y = updateRectangle.Y + (remoteDesktop.ClientRectangle.Height - remoteDesktop.Desktop.Height) / 2;
			} else {
				y = updateRectangle.Y + remoteDesktop.AutoScrollPosition.Y;
			}

			return new VncRectangle(x, y, updateRectangle.Width, updateRectangle.Height);
        }

        public override VncRectangle RepositionImage(IVncImage desktopImage)
        {
            // See if the image needs to be clipped (i.e., it is too big for the 
 			// available space) or centered (i.e., it is too small)
			int x, y;
			
			if (remoteDesktop.ClientSize.Width > desktopImage.Width) {
				x = (remoteDesktop.ClientRectangle.Width - desktopImage.Width) / 2;
			} else {
				x = remoteDesktop.DisplayRectangle.X;
			}

			if (remoteDesktop.ClientSize.Height > desktopImage.Height ) {
				y = (remoteDesktop.ClientRectangle.Height - desktopImage.Height) / 2;
			} else {
				y = remoteDesktop.DisplayRectangle.Y;
			}

            return new VncRectangle(x, y, desktopImage.Width, desktopImage.Height);
        }

        public override VncRectangle GetMouseMoveRectangle()
        {
			VncRectangle desktopRect = vnc.Framebuffer.Rectangle;

			if (remoteDesktop.ClientSize.Width > remoteDesktop.Desktop.Size.Width) {
				desktopRect.X = (remoteDesktop.ClientRectangle.Width - remoteDesktop.Desktop.Width) / 2;
			}

            if (remoteDesktop.ClientSize.Height > remoteDesktop.Desktop.Size.Height) {
                desktopRect.Y = (remoteDesktop.ClientRectangle.Height - remoteDesktop.Desktop.Height) / 2;
            }

            return desktopRect;
        }

        public override VncPoint GetMouseMovePoint(VncPoint current)
        {
            return current;
        }
    }
}