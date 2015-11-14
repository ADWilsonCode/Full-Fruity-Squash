using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Full_Fruity_Squash
{
    public class Bad_Fruit : Fruit
    {
        public enum badFruitState
        {
            badFalling,
            badCaught,
            badBinned,
        }

        badFruitState currentBadFruitState = badFruitState.badFalling;
        public Bad_Fruit(Texture2D tex, Vector2 pos, Rectangle rec, int inScreenWidth, int inScreenHeight, float inTimeDrop)
            : base( tex,  pos,  rec,  inScreenWidth,  inScreenHeight,  inTimeDrop)
        {
            texture = tex;
            position = pos;

            center = new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2);
            origin = new Vector2(texture.Width / 2, texture.Height / 2);
            TimeDrop = inTimeDrop;
        }

        public bool isAlive
        {
            get { return isAlive; }
            set { isAlive = value; }
        }


        public virtual void caught()
        {

            //toDo add caught code here
        }

        public virtual void binned()
        {
            isAlive = false;
            //toDo add binned code here
        }

        public override void Update(GameTime gameTime)
        {
            switch (currentBadFruitState)
            {
                case badFruitState.badCaught:
                    caught();
                    break;

                case badFruitState.badBinned:
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
