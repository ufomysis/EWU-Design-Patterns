﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalProject
{
    class CollidableMapEntity : MapEntity, Collidable
    {
        protected int health = 30;
        protected Rectangle boundingBox;

        private MapEntityData mapEntityData;

        public Rectangle BoundingBox
        {
            get
            {
                return this.boundingBox;
            }
        }


        public CollidableMapEntity(MapEntityData mapEntityData, Vector2 position) : base(mapEntityData, position)
        {
            if (mapEntityData.Sprite != null)
            {
                this.boundingBox = mapEntityData.Sprite.Bounds;                         //the bounding box can be set to (temporarily, at least) the sprite bounding rectangle
                this.boundingBox.Location = new Point((int)position.X, (int)position.Y);//then need to move to the actual position, since the sprite is technically at (0, 0)
            }
            else
            {
                this.boundingBox = new Rectangle();
            }
        }

        public virtual void Hit(int amount, int type)
        {
            health -= amount;

            if (health <= 0)
            {
                GamePlayLogicManager.GetInstance().RemoveCollidable(this);
            }
            //DebugText.GetInstance().WriteLinePerm("Amount: " + amount + " type: " + type);

            GamePlayDrawManager.GetInstance().UI.AddElementA(new GameUIElement(GamePlayDrawManager.GetInstance().UI, "*THUNK*", position, 10));
        }
    }
}
