﻿/***************************************************************************
 *   MiniMap.cs
 *   Part of OpenUO: http://code.google.com/p/OpenUO
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
using Microsoft.Xna.Framework.Graphics;
#endregion

namespace OpenUO.TileEngine
{
    // N.B.
    // This code is currently not used by the engine and may well be nonfunctional.
    public class MiniMap
    {

    }

    class WorldTexture
    {
        Texture2D _texture;
        bool _loaded = false;
        Map _map;
        int _x, _y;

        public WorldTexture(GraphicsDevice graphics, Map map, int x, int y)
        {
            _texture = new Texture2D(graphics, 64, 64);
            _map = map;
            _x = x;
            _y = y;
        }

        public Texture2D Texture()
        {
            if (!_loaded)
            {
                _loaded = true;
                uint[] buffer = new uint[64 * 64];

                _map.LoadEverything_Override = true;

                for (int i = 0; i < 64; i++)
                {
                    int ix = _x + i % 8;
                    int iy = _y + i / 8;
                    // MapCell c = _map.GetMapCell(ix << 3, iy << 3, true);
                    // c.WriteRadarColors(buffer, i % 8 << 3, i / 8 << 3);
                }

                _map.LoadEverything_Override = false;

                _texture.SetData<uint>(buffer);
            }
            return _texture;
        }
    }

    public class MiniMap_DEPRECIATED
    {
        private Texture2D _texture;
        private GraphicsDevice _graphics;
        private int _lastUpdateTicker;

        public Texture2D Texture(Map map, int renderBeginX, int renderBeginY)
        {
            update(map, renderBeginX, renderBeginY);
            return _texture;
        }

        public MiniMap_DEPRECIATED(GraphicsDevice graphics)
        {
            _graphics = graphics;
        }

        private unsafe void update(Map map, int renderBeginX, int renderBeginY)
        {
            if ((map.UpdateTicker != _lastUpdateTicker) || (_texture == null))
            {
                int size = UltimaVars.EngineVars.RenderSize * 2;
                _lastUpdateTicker = map.UpdateTicker;
                _texture = new Texture2D(_graphics, size, size, false, SurfaceFormat.Bgra5551);
                ushort[] data = new ushort[size * size];
                fixed (ushort* pData = data)
                {
                    for (int y = 0; y < UltimaVars.EngineVars.RenderSize; y++)
                    {
                        ushort* cur = pData + ((size /2 - 1) + (size - 1) * y);
                        for (int x = 0; x < UltimaVars.EngineVars.RenderSize; x++)
                        {
                            MapTile m = map.GetMapTile(renderBeginX + x, renderBeginY + y, true);
                            List<MapObject> o = m.Items;
                            int i;
                            for (i = o.Count - 1; i > 0; i--)
                            {
                                if (o[i] is MapObjectStatic)
                                {
                                    *cur++ = (ushort)(UltimaData.Radarcol.Colors[o[i].ItemID] | 0x8000);
                                    *cur = (ushort)(UltimaData.Radarcol.Colors[o[i].ItemID] | 0x8000);
                                    cur += size;
                                    break;
                                }
                            }
                            if (i == 0)
                            {
                                *cur++ = (ushort)(UltimaData.Radarcol.Colors[m.GroundTile.ItemID] | 0x8000);
                                *cur = (ushort)(UltimaData.Radarcol.Colors[o[i].ItemID] | 0x8000);
                                cur += size;
                            }
                        }
                    }
                }
                _texture.SetData<ushort>(data);
            }
        }
    }
}
