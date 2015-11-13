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

namespace Full_Fruity_Squash
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class FruitSquashGame : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Sprite Background;

        Orange pickOrange;
        Apple pickApple;
        Banana pickBanna;

        Rotten_Apple dumpApple;
        Rotten_Banana dumpBanna;
        Rotten_Orange dumpOrange;

        Button BackButton;
        GraphicsDevice Device;

        public enum gamestate
        {
            startscreen,
            playingGame,
            highScore,
            gameover
        }
        
        gamestate currentgamestate = gamestate.highScore;
        public FruitSquashGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Device = graphics.GraphicsDevice;
            switch (currentgamestate)
            {
                case gamestate.startscreen:
                    break;
                case gamestate.playingGame:
                    break;
                case gamestate.highScore:
                    Texture2D HighScoreBackButton = Content.Load<Texture2D>("HighScoreBack");
                    BackButton = new Button(HighScoreBackButton, HighScoreBackButton, HighScoreBackButton, new Vector2(Device.PresentationParameters.BackBufferWidth / 2, Device.PresentationParameters.BackBufferHeight / 2));
                    BackButton.OnPress += new EventHandler(HighScoreBackButton_Clicked);
                    break;
                case gamestate.gameover:
                    break;
                default:
                    break;
            }

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

          Background = new Sprite (
                Content.Load<Texture2D>("Background"),
                Vector2.Zero);

          //pickOrange = new Orange(
          //    Content.Load<Texture2D>("OrangeBall"),
          //    Vector2.Zero);

          //pickBanna = new Banana(
          //    Content.Load<Texture2D>("YellowBall"),
          //    Vector2.Zero);

          //pickApple = new Apple(
          //    Content.Load<Texture2D>("GreenBall"),
          //    Vector2.Zero);

          dumpApple = new Rotten_Apple(
              Content.Load<Texture2D>("BlackBall"),
              Vector2.Zero);

          dumpBanna = new Rotten_Banana(
              Content.Load<Texture2D>("BlackBall"),
              Vector2.Zero);

          dumpOrange = new Rotten_Orange(
              Content.Load<Texture2D>("BlackBall"),
              Vector2.Zero);
        }

        private void HighScoreBackButton_Clicked(object sender, EventArgs e)
        {

            currentgamestate = gamestate.startscreen;

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            switch (currentgamestate)
            {
                case gamestate.startscreen:
                    break;
                case gamestate.playingGame:
                    break;
                case gamestate.highScore:
                    BackButton.Update(gameTime);
                    break;
                case gamestate.gameover:
                    break;
                default:
                    break;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();

            switch (currentgamestate)
            {
                case gamestate.startscreen:
                    break;
                case gamestate.playingGame:
                    break;
                case gamestate.highScore:
                    BackButton.Draw(spriteBatch);
                    break;
                case gamestate.gameover:
                    break;
                default:
                    break;
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
