﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace FinalProject
{
    public abstract class Menu : Drawable
    {
        protected ContentManager cm;
        private bool buttonPressed = false;
        private bool buttonReleased = false;
        private List<MenuButton> buttons;


        protected Menu(ContentManager cm)
        {
            this.buttons = new List<MenuButton>();
            this.cm = cm;
        }

        public List<MenuButton> Buttons
        {
            get { return this.buttons; }
        }

        protected abstract bool doInput(MenuButton buttonClicked);

        public bool HandleInput()
        {
            DebugText dt = DebugText.GetInstance();
            MouseState ms = Mouse.GetState();

            if (ms.LeftButton == ButtonState.Pressed)
            {
                this.buttonPressed = true;
            }
            else if (ms.LeftButton == ButtonState.Released && this.buttonPressed)
            {
                this.buttonReleased = true;
            }
            if (this.buttonPressed && this.buttonReleased)
            {
                foreach (MenuButton b in buttons)
                {
                    //If the mouse is within the bounds of the rectangle of the button
                    if (b.Bounds.Contains(ms.X, ms.Y))
                    {
                        dt.WriteLine("Clicked button " + b.Text + " at " + b.Bounds.X.ToString() + "," + b.Bounds.Y.ToString());
                        this.buttonPressed = false;
                        this.buttonReleased = false;
                        return doInput(b);
                    }
                }
            }
            return false;
        }

        public void Update()
        {
            DebugText dt = DebugText.GetInstance();
            MouseState ms = Mouse.GetState();
            

            foreach (MenuButton b in buttons)
            {
                //If the mouse is within the bounds of the rectangle of the button
                if (b.Bounds.Contains(ms.X, ms.Y))
                {
                    dt.WriteLine("Mouse over button at " + b.Bounds.X.ToString() + "," + b.Bounds.Y.ToString());
                }
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (MenuButton b in buttons)
            {
                spriteBatch.Draw(b.Sprite, b.Bounds, Color.White);
            }
        }

        public Vector2 Position
        {
            get { return new Vector2(0,0); }
            set { }
        }
    }
}
