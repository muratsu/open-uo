﻿/***************************************************************************
 *   RequestNameResponsePacket.cs
 *   Part of OpenUO: http://code.google.com/p/OpenUO
 *   
 *   begin                : May 31, 2009
 *   email                : poplicola@OpenUO.com
 *
 ***************************************************************************/

/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 3 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/
#region usings
using OpenUO.Network;
#endregion

namespace OpenUO.Network.Packets.Server
{
    public class RequestNameResponsePacket : RecvPacket
    {
        readonly Serial _serial;
        readonly string _mobileName;

        public Serial Serial
        { 
            get { return _serial; } 
        }

        public string MobileName
        {
            get { return _mobileName; }
        }

        public RequestNameResponsePacket(PacketReader reader)
            : base(0x98, "Request Name Response")
        {
            _serial = reader.ReadInt32();
            _mobileName = reader.ReadString(30);
        }
    }
}
