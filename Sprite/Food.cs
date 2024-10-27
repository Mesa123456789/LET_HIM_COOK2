﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

using MonoGame.Extended.Collisions;
using MonoGame.Extended.Tiled.Renderers;
using MonoGame.Extended.Tiled;
using MonoGame.Extended;
using MonoGame.Extended.Timers;
using MonoGame.Extended.ViewportAdapters;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input;
using LET_HIM_COOK.Screen;

namespace LET_HIM_COOK.Sprite
{
    public class Food : Sprite
    {
        public Vector2 foodPosition;
        public RectangleF foodBox;
        public Rectangle foodRec;
        public Texture2D foodTexture, foodTexBag2;
        public Texture2D foodTexBag;
        public int getFood;
        public static bool OntableAble;
        public Player player;
        Game1 game;
        public RectangleF Bounds;
        AnimatedTexture SpriteTexture;
        Vector2 playerPos;
        public string name;
        public bool istrue;
        public bool Two;
        public int id;
        public Food(int id, string name, bool Istrue)
        {
            this.id = id;
            this.name = name;
            istrue = Istrue;
        }
        public Food(Texture2D foodTexBag, Rectangle foodRec)
        {
            
            this.foodTexBag = foodTexBag;
            this.foodRec = foodRec;
        }
        public Food(string name, Texture2D foodTexBag, Vector2 foodPosition)
        {
            this.name = name;
            this.foodTexBag = foodTexBag;
            this.foodPosition = foodPosition;
        }
        public Food(string name, Texture2D foodTexBag, Rectangle foodRec,bool Two)
        {
            this.name = name;
            this.Two = Two;
            this.foodTexBag = foodTexBag;
            this.foodRec = foodRec;
        }
        public Food(string name, Texture2D foodTexBag, bool Istrue , Vector2 foodPosition , Rectangle foodRec)
        {
            this.name = name;
            this.foodTexBag = foodTexBag;
            istrue = Istrue;
            this.foodPosition = foodPosition;
            this.foodRec = foodRec;
        }
        public Food(string name, Texture2D foodTexture, Texture2D foodTexBag, Vector2 foodPosition)
        {
            this.name = name;
            this.foodTexture = foodTexture;
            this.foodTexBag = foodTexBag;
            this.foodPosition = foodPosition;
            foodBox = new RectangleF((int)foodPosition.X, (int)foodPosition.Y, 50, 50);
            OntableAble = false;
            player = new Player(SpriteTexture, new Vector2(1500, 400), game, Bounds);
        }


        public override void Update(GameTime gameTime)
        {
            MouseState ms = Mouse.GetState();
            if (foodBox.Intersects(GameplayScreen.player.Bounds) && !OntableAble)
            {
                if (ms.LeftButton == ButtonState.Pressed)
                {
                    OnCollision();
                }
            }
            foodBox = new RectangleF((int)foodPosition.X, (int)foodPosition.Y, 50, 50);
        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(foodTexture, foodPosition, Color.White);
        }
        public override void DrawBag(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(foodTexBag, foodPosition, Color.White);
        }
        public virtual void OnCollision()
        {
            OntableAble = true;
            Game1.BagList.Add(this);
            Game1.IsPopUp = true;
            foreach (Food food in Game1.foodList)
            {
                Game1.foodList.Remove(this);
                break;
            }
        }


    }
}
