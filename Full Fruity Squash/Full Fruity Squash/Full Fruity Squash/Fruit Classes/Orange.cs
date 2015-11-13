using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Full_Fruity_Squash
{
    public class Orange : Fruit
    {
        public Orange(Texture2D tex, Vector2 pos)
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

        public override void Fall(GameTime gameTime)
        {
            base.Fall(gameTime);
        }

        public override void Caught(GameTime gameTime)
        {
            base.Caught(gameTime);
        }

        public override void Dropped(GameTime gameTime)
        {
            base.Dropped(gameTime);
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
