﻿/***************************************************************************
 *   GlobalQueuePacket.cs
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
    public class GlobalQueuePacket : RecvPacket
    {
        readonly byte _unk;
        readonly short _count;

        public byte Unknown
        {
            get { return _unk; }
        }

        public short Count
        {
            get { return _count; }
        }

        public GlobalQueuePacket(PacketReader reader)
            : base(0xCB, "Global Queue")
        {
            _unk = reader.ReadByte();
            _count = reader.ReadInt16();
        }
    }
}
