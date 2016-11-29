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
	/// Base class for desktop clipping/scaling policies.  Used by RemoteDesktop.
	/// </summary>
	public abstract class VncDesktopTransformPolicy
	{
        protected VncClient vnc;
        protected IRemoteDesktop remoteDesktop;

        public VncDesktopTransformPolicy(VncClient vnc, IRemoteDesktop remoteDesktop)
        {
            this.vnc = vnc;
            this.remoteDesktop = remoteDesktop;
        }

        public virtual bool AutoScroll
        {
            get
            {
                return false;
            }
        }

        public abstract VncSize AutoScrollMinSize { get; }

        public abstract VncRectangle AdjustUpdateRectangle(VncRectangle updateRectangle);

        public abstract VncRectangle RepositionImage(IVncImage desktopImage);

        public abstract VncRectangle GetMouseMoveRectangle();

        public abstract VncPoint GetMouseMovePoint(VncPoint current);

        public abstract VncPoint UpdateRemotePointer(VncPoint current);
    }
}
