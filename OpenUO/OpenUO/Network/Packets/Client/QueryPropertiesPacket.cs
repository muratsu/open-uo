﻿/***************************************************************************
 *   QueryPropertiesPacket.cs
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#endregion

namespace OpenUO.Network.Packets.Client
{
    public class QueryPropertiesPacket : SendPacket
    {
        public QueryPropertiesPacket(Serial serial)
            : base(0xD6, "Query Properties", 7)
        {
            Stream.Write((short)7);
            Stream.Write((int)serial);
        }
    }
}
