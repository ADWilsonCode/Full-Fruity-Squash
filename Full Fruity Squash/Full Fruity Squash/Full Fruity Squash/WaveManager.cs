using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Windows.Input;

namespace Full_Fruity_Squash
{
    public class WaveManager
    {
        GraphicsDeviceManager graphics;
        GraphicsDevice Device;
     
        public int XPositionGenerator()
        {
            Device = graphics.GraphicsDevice;
            Random XPosition = new Random();
            int Position = XPosition.Next(1, Device.PresentationParameters.BackBufferWidth -1);

            return Position;
        }

        public int TimeGenerator(int EndTime)
        {

            Device = graphics.GraphicsDevice;
            Random TimeGeneration = new Random();
            int TimeGen = TimeGeneration.Next(0, EndTime);

            return TimeGen;
        }

        public int FruitType()
        {
            Device = graphics.GraphicsDevice;
            Random FruitNumber = new Random();
            int FruitNum = FruitNumber.Next(0, 5);

            return FruitNum;
        }

        public List<Sprite> WaveOne()
        {
            List<Sprite> Fruit = new List<Sprite>();
            int NumOfFruitDrop = 5;
            int WaveLength = 10;
            int FType = 0;

            for (int x = 0; x < NumOfFruitDrop; ++x)
            {
                FType = FruitType();
                switch (FType)
                {
                    case 0:
                        break;
                    case 1:
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    default:
                        break;
                }

            }

            return Fruit;
        }

        //public void Update(GameTime gameTime)
        //{

            

        //}
    }
}
