using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Full_Fruity_Squash
{
    class Player : Sprite
    {

        public enum HandState
        {
            full,
            empty,

        }
        List<Fruit> fruits;
        HandState handState = HandState.empty;

        public List<Fruit> Fruits
        {
            get { return fruits; }
            set { fruits = value; }
        }

        public Player(Texture2D tex, Vector2 pos, Rectangle rec,int inScreenWidth, int inScreenHeight) 
            :base (tex, pos,rec,inScreenWidth,inScreenHeight)
        {
            texture = tex;

            position = pos;
            velocity = Vector2.Zero;

            center = new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2);
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
            
            fruits = new List<Fruit>();
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Left))
            {
                velocity = new Vector2(-10, 0);
                position += velocity;
                if (position.X < 0)
                {
                    position.X = 800;
                }
                
            }

            if (keyState.IsKeyDown(Keys.Right))
            {
                velocity = new Vector2(10, 0);
                position += velocity;
                if (position.X + rectangle.Width > ScreenWidth)
                {
                    position.X = 0;
                }
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {

            }

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
