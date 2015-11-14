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

        list<Fruit> fruits;

        public list<Fruit> Fruits
        {
            get { return fruits; }
            set { fruits = value; }
        }

        public Player(Texture2D tex, Vector2 pos) 
            :base (tex, pos)
        {
            texture = tex;

            position = pos;
            velocity = Vector2.Zero;

            center = new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2);
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
            HandState handState = Handstate.empty;
            fruits = new list<Fruit>();
        }

        private void Movement(Gametime gametime)
        {
            KeyboardState keybState = Keyboard.GetState();

            if (keybState.IsKeyDown(Keys.Left) || keybState.IsKeyDown(Keys.A))
            { 
                velocity = new vector2(-10, 0);
                position += velocity;
            }

            if (keybState.IsKeyDown(Keys.Right) || keybState.IsKeyDown(Keys.D))
            {
                velocity = new vector2(10, 0);
                position += velocity;
            }
        }

        private void CatchFruit(Gametime gameTime)
        {
            if(handState == HandState.full)
            {
                if (keybState.IsKeyDown(Keys.Spacebar))
                {
                   
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            CatchFruit(gameTime);
            Movement(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
