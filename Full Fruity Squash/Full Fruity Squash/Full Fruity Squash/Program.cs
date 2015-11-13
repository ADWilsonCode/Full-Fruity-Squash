using System;

namespace Full_Fruity_Squash
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (FruitSquashGame game = new FruitSquashGame())
            {
                game.Run();
            }
        }
    }
#endif
}

