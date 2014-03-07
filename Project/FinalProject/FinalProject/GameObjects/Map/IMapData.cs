﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject
{
    public interface IMapData
    {
        List<MapEntity[][]> Contents { get; }
        Vector2 Spawn { get; }
        Vector2 End { get; }
    }
}
