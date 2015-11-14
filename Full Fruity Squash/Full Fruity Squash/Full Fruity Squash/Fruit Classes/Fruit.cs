using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Full_Fruity_Squash
{
    public class Fruit : Sprite
    {
        public enum fruitState
        {
            falling,
            caught,
            dropped,
        };

        protected fruitState currentState;
        protected bool isAlive;

        public bool IsAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }

         public Fruit(Texture2D tex, Vector2 pos) 
             : base(tex, pos)
        {
            texture = tex;
            position = pos;
            velocity = Vector2.Zero;
            center = new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2);
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
            currentState = fruitState.falling;
            isAlive = true;
        }

        public virtual void Fall(GameTime gameTime)
         {
             velocity = new Vector2(0, 5);
             position += velocity;
         }

        public virtual void Caught(GameTime gameTime)
        {
            //TODO: add code to follow the position of the player
        }

        public virtual void Dropped(GameTime gameTime)
        {
            velocity = new Vector2(0, 5);
            position += velocity;
        }

        public virtual void Kill()
        {
            isAlive = false;
        }

        public override void Update(GameTime gameTime)
         {
             switch(currentState)
             {
                 case fruitState.falling:
                     Fall(gameTime);
                     break;
                 case fruitState.caught:
                     Caught(gameTime);
                     break;
                 case fruitState.dropped:
                     Dropped(gameTime);
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
