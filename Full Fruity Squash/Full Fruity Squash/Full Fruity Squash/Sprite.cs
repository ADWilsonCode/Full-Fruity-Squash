using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Full_Fruity_Squash
{
    public class Sprite
    {
        public Texture2D texture;

        public Vector2 position;
        public Vector2 velocity;

        public Vector2 center;
        public Vector2 origin;

        public float rotation;

        public Rectangle rectangle;

        public int ScreenWidth;
        public int ScreenHeight;

        public bool intersectWith(Sprite T)
        {
            return rectangle.Intersects(T.rectangle);
        }

        public Vector2 Position
        {
            get { return position; }
        }
        public Vector2 Center
        {
            get { return center; }
        }

        public Sprite(Texture2D tex, Vector2 pos, Rectangle rec, int inScreenWidth, int inScreenHeight)
        {
            texture = tex;

            position = pos;

            rectangle = rec;

            ScreenWidth = inScreenWidth;
            ScreenHeight = inScreenHeight;

            velocity = Vector2.Zero;

            center = new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2);
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        public virtual void Update(GameTime gameTime)
        {
            this.center = new Vector2(position.X + texture.Width / 2,
                position.Y + texture.Height / 2);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, center, null, Color.White,
            rotation, origin, 1.0f, SpriteEffects.None, 0);
        }

        public virtual void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(texture, center, null, color, rotation, origin, 1.0f, SpriteEffects.None, 0);
        }

        public float Distance(Sprite t)
        {
            Vector2 Object = t.position;
            Vector2 fruit = position;

            float a = fruit.X - Object.X;
            float b = fruit.X - Object.Y;


            return (float)Math.Sqrt((a * a) + (b * b));
        }
    }
}