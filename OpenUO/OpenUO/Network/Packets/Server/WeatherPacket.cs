﻿/***************************************************************************
 *   WeatherPacket.cs
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
    public class WeatherPacket : RecvPacket
    {
        readonly byte _weatherType;
        readonly byte _effectId;
        readonly byte _temperature;

        public byte WeatherType
        {
            get { return _weatherType; }
        }

        public byte NumberOfWeatherEffectsOnScreen
        {
            get { return _effectId; }        
        }

        public byte Temperature 
        {
            get { return _temperature; }
        }

        public WeatherPacket(PacketReader reader)
            : base(0x65, "Set Weather")
        {
            _weatherType = reader.ReadByte();
            _effectId = reader.ReadByte();
            _temperature = reader.ReadByte();
        }
    }
}
