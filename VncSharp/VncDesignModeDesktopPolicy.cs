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
	/// A Design Mode version of VncDesktopTransformPolicy.
	/// </summary>
	public sealed class VncDesignModeDesktopPolicy : VncDesktopTransformPolicy
	{
        public VncDesignModeDesktopPolicy(IRemoteDesktop remoteDesktop) 
            : base(null, remoteDesktop)
        {
        }

        public override bool AutoScroll {
            get {
                return true;
            }
        }

        public override VncSize AutoScrollMinSize {
            get {
                return new VncSize(608, 427); // just a default for Design graphic. Will get changed once connected.
            }
        }

        public override VncPoint UpdateRemotePointer(VncPoint current)
        {
            throw new NotImplementedException();
        }

        public override VncRectangle AdjustUpdateRectangle(VncRectangle updateRectangle)
        {
            throw new NotImplementedException();			
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

            return new VncRectangle(x, y, remoteDesktop.ClientSize.Width, remoteDesktop.ClientSize.Height);
        }

        public override VncRectangle GetMouseMoveRectangle()
        {
            throw new NotImplementedException();
        }

        public override VncPoint GetMouseMovePoint(VncPoint current)
        {
            throw new NotImplementedException();
        }
    }
}