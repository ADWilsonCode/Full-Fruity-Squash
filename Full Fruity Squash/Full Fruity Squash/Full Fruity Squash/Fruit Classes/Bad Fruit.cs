﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Full_Fruity_Squash
{
    public class Bad_Fruit : Sprite
    {
        public enum badFruitState
        {
            badFalling,
            badCaught,
            badBinned,
        }


        badFruitState currentBadFruitState = badFruitState.badFalling;
        public Bad_Fruit(Texture2D tex, Vector2 pos) 
            : base (tex, pos)
        {
            texture = tex;
            position = pos;

            center = new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2);
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        public bool isAlive
        {
            get { return isAlive;}
            set {isAlive =  value;}
        }

        protected virtual void falling()
        {
            velocity = new Vector2(0, 5);
            position += velocity;
            //toDo add falling code heer
        }

        protected virtual void caught()
        {
            
            //toDo add caught code here
        }

        protected virtual void binned()
        {
            isAlive = false;
           //toDo add binned code here
        }

        public override void Update(GameTime gameTime)
        {
            switch (currentBadFruitState)
            {
                case badFruitState.badFalling :
                    falling();
                    break;

                case badFruitState.badCaught :
                    caught();
                    break;

                case badFruitState.badBinned :
                    binned();
                    break;
            }
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
