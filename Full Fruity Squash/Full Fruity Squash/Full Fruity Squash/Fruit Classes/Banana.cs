using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Full_Fruity_Squash
{
    public class Banana : Fruit
    {
        public Banana(Texture2D tex, Vector2 pos, Rectangle rec, int inScreenWidth, int inScreenHeight, float inTimeDrop)
            : base(tex, pos, rec, inScreenWidth, inScreenHeight,inTimeDrop)
        {
            texture = tex;
            position = pos;
            velocity = Vector2.Zero;
            center = new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2);
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
           
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
