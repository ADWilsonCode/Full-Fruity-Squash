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

        public float TimeDrop;


        public Fruit(Texture2D tex, Vector2 pos, Rectangle rec, int inScreenWidth, int inScreenHeight, float inTimeDrop)
            : base(tex, pos, rec, inScreenWidth, inScreenHeight)
        {
            texture = tex;
            position = pos;
            velocity = Vector2.Zero;
            center = new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2);
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
           
            TimeDrop = inTimeDrop;
        }

        public bool Stop;

        public override void Update(GameTime gameTime)
       {
           if (Stop)
           {
               velocity = new Vector2(0, 0);
           }
           else
           {
               velocity = new Vector2(0, 2);
               position += velocity;
           }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}

