/***************************************************************************
 *   PlayMusicPacket.cs
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
    public class PlayMusicPacket : RecvPacket
    {
        readonly short _id;

        public short MusicID
        {
            get { return _id; }
        }

        public PlayMusicPacket(PacketReader reader)
            : base(0x6D, "Play Music")
        {
            _id = reader.ReadInt16();
        }
    }
}
