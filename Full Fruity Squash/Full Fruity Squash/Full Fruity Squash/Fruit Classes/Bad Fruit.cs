using System;
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
        {

        }

        public void Update()
        {

        }

        public void Draw()
        {

        }
    }
}
