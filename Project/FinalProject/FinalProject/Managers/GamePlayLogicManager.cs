﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FinalProject
{
    class GamePlayLogicManager
    {
        private static GamePlayLogicManager instance;

        public static GamePlayLogicManager GetInstance()
        {
            if (instance == null)
                instance = new GamePlayLogicManager();
            return instance;
        }

        private List<Movable> updateList;
        private QuadTree<Collidable> collidableEntities;
        private QuadTree<DroppedItem> droppedItems;

        private List<Updatable> updatableEntities;

        private Rectangle mapRect;

        public QuadTree<Collidable> CollisionTree
        {
            get
            {
                return this.collidableEntities;
            }
        }

        public QuadTree<DroppedItem> DroppedItems
        {
            get
            {
                return this.droppedItems;
            }
        }

        public Rectangle MapRect
        {
            get
            {
                return mapRect;
            }
            set
            {
                mapRect = value;
            }
        }

        private GamePlayLogicManager()
        {
            updateList = new List<Movable>();
            updatableEntities = new List<Updatable>();
            collidableEntities = null;
        }

        public void CreateCollisionTree(Rectangle r)
        {
            mapRect = r;
            collidableEntities = new QuadTree<Collidable>((x => x.BoundingBox), r);
            droppedItems = new QuadTree<DroppedItem>((x => x.BoundingBox), r);
        }

        public void Update()
        {
            foreach(Movable m in updateList)
            {
                m.Logic();
            }

            foreach (Movable m in updateList)
            {
                m.Move();
            }

            for (int i = 0; i < updatableEntities.Count; i++ ) //because we may be removing entities from the list and foreach loops don't like that
            {
                updatableEntities[i].CheckStatus();
            }
        }

        public void AddMovable(Movable m)
        {
            updateList.Add(m);
        }

        public void AddCollidable(Collidable c)
        {
            collidableEntities.Add(c);
        }

        public void Remove(Movable m)
        {
            if(updateList.Contains(m))
                updateList.Remove(m);
        }

        public void RemoveCollidable(Collidable c)
        {
            collidableEntities.Remove(c);
        }

        public void AddUpdatable(Updatable m)
        {
            updatableEntities.Add(m);
        }

        public void RemoveUpdatable(Updatable m)
        {
            if (updatableEntities.Contains(m))
                updatableEntities.Remove(m);
        }

        public void AddDroppedItem(DroppedItem d)
        {
            droppedItems.Add(d);
        }

        public void RemoveDroppedItem(DroppedItem d)
        {
            droppedItems.Remove(d);
        }
    }
}
