﻿using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace FinalProject
{

    /*
     * 128 x 128
     * 
     * 
     * 
     */
    class GameMapSimple : GameMap
    {
        public GameMapSimple()
        {
            this.Height = 128;
            this.Width = 128;
        }

        public override void LoadContent()
        {
            MapEntityFactory factory = MapEntityFactory.GetInstance();

            AddToDrawList(factory.CreateDirtMapEntity(new Vector2(0, 0)));
            AddToDrawList(factory.CreateGrassMapEntity(new Vector2(0, 32)));
            AddToDrawList(factory.CreateGrassMapEntity(new Vector2(0, 64)));
            AddToDrawList(factory.CreateGrassMapEntity(new Vector2(0, 96)));

            AddToDrawList(factory.CreateGrassMapEntity(new Vector2(32, 0)));
            AddToDrawList(factory.CreateGrassMapEntity(new Vector2(32, 32)));
            AddToDrawList(factory.CreateGrassMapEntity(new Vector2(32, 64)));
            AddToDrawList(factory.CreateGrassMapEntity(new Vector2(32, 96)));

            AddToDrawList(factory.CreateGrassMapEntity(new Vector2(64, 0)));
            AddToDrawList(factory.CreateGrassMapEntity(new Vector2(64, 32)));
            AddToDrawList(factory.CreateGrassMapEntity(new Vector2(64, 64)));
            AddToDrawList(factory.CreateGrassMapEntity(new Vector2(64, 96)));

            AddToDrawList(factory.CreateTreeMapEntity(new Vector2(96, 0)));
            AddToDrawList(factory.CreateTreeMapEntity(new Vector2(96, 128)));
        }

        private void AddToDrawList(Drawable d)
        {
            GamePlayDrawManager.GetInstance().Add(d);
        }
    }
}