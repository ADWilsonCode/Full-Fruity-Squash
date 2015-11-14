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

        BananaBlender bananaBlender;
        AppleBlender appleBlender;
        OrangeBlender orangeBlender;

        Bin bin1;
        Bin bin2;

        //high score Stuff
        Button BackButton;
        GraphicsDevice Device;
        SpriteFont HighScoreFont;
        List<PersonDetails> PeopleList;

        // Score Entry
        KeyboardDispatcher KeyBoardDispatcher;
        TextBoxClass.TextBox TextEntry;
        Button SubmitButton;
        SpriteFont SubmitText;
        SpriteFont HighScore;

         public enum gamestate
         {
             startscreen,
             playingGame,
             highScore,
             ScoreEntry,
             gameover
         }

        gamestate currentgamestate = gamestate.ScoreEntry;
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
            HighScore HighScoreList = new HighScore();

            if (!HighScoreList.LoadPeople())
            {
                PeopleList = HighScoreList.GetSetTopFivePeople;
                for (int x = 0; x < 5; ++x)
                {
                    PeopleList.Add(new PersonDetails("To Be Filled", 0));
                }

                HighScoreList.SavePeople();
            }
            PeopleList = HighScoreList.GetSetTopFivePeople;

            KeyBoardDispatcher = new KeyboardDispatcher(Window);

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
                    BackButton = new Button(HighScoreBackButton, HighScoreBackButton, HighScoreBackButton, new Vector2(Device.PresentationParameters.BackBufferWidth / 3+10, Device.PresentationParameters.BackBufferHeight / 2));
                    BackButton.OnPress += new EventHandler(HighScoreBackButton_Clicked);

                    HighScoreFont = Content.Load<SpriteFont>("HighScoreText");
                    break;
                case gamestate.ScoreEntry:
                    Texture2D EntryPoint = Content.Load<Texture2D>("button");
                    HighScoreFont = Content.Load<SpriteFont>("HighScoreText");
                    TextEntry = new TextBoxClass.TextBox(EntryPoint, EntryPoint, HighScoreFont);
                    TextEntry.X = Device.PresentationParameters.BackBufferWidth / 2;
                    TextEntry.Y = Device.PresentationParameters.BackBufferHeight/2 - 50;
                    TextEntry.Width = 200;
                    KeyBoardDispatcher.Subscriber = TextEntry;

                    Texture2D SubmitScore = Content.Load<Texture2D>("buttonSubmitText");
                    SubmitButton = new Button(SubmitScore, SubmitScore, SubmitScore, new Vector2(Device.PresentationParameters.BackBufferWidth / 3 + 10, Device.PresentationParameters.BackBufferHeight / 2));
                    SubmitButton.OnPress += new EventHandler(SubmitButton_Clicked);

                    SubmitText = Content.Load<SpriteFont>("HighScoreText");
                    HighScore = Content.Load<SpriteFont>("HighScoreText");
                    break;
                case gamestate.gameover:
                    break;
                default:
                   break;
            }


            
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

          Background = new Sprite (
                Content.Load<Texture2D>("BackGround"),
                Vector2.Zero);

          pickOrange = new Orange(
              Content.Load<Texture2D>("orange"),
              Vector2.Zero);

          pickBanna = new Banana(
              Content.Load<Texture2D>("bananas-03"),
              Vector2.Zero);

          pickApple = new Apple(
              Content.Load<Texture2D>("apple"),
              Vector2.Zero);

          dumpApple = new Rotten_Apple(
              Content.Load<Texture2D>("rottenApple"),
              Vector2.Zero);

          dumpBanna = new Rotten_Banana(
              Content.Load<Texture2D>("rottenbanana"),
              Vector2.Zero);

          dumpOrange = new Rotten_Orange(
              Content.Load<Texture2D>("rottenOrange"),
              Vector2.Zero);

          appleBlender = new AppleBlender(
              Content.Load<Texture2D>("AppleBlender"),
              Vector2.Zero);

          bananaBlender = new BananaBlender(
              Content.Load<Texture2D>("BananaBlender"),
              Vector2.Zero);

          orangeBlender = new OrangeBlender(
              Content.Load<Texture2D>("OrangeBlender"),
              Vector2.Zero);

          bin1 = new Bin(
              Content.Load<Texture2D>("bin2"),
              Vector2.Zero);

         bin2 = new Bin(
        Content.Load<Texture2D>("bin2"),
        Vector2.Zero);
        }


        private void HighScoreBackButton_Clicked(object sender, EventArgs e)
        {

            currentgamestate = gamestate.startscreen;

        }

        private void SubmitButton_Clicked(object sender, EventArgs e)
        {

            currentgamestate = gamestate.startscreen;

        }

        private void DrawHighScores()
        {
            int Yaxis = 60;
            for(int x = 0; x<PeopleList.Count;++x)
            {
                spriteBatch.DrawString(HighScoreFont, PeopleList[x].NameGetSet + " --> " + PeopleList[x].ScoreGetSet, new Vector2(Device.PresentationParameters.BackBufferWidth / 3 +30, Yaxis), Color.Black);
                Yaxis += 45;
            }
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
                case gamestate.ScoreEntry:
                    TextEntry.Update(gameTime);
                    SubmitButton.Update(gameTime);
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
                    DrawHighScores();
                    break;
                case gamestate.ScoreEntry:
                    TextEntry.Draw(spriteBatch,gameTime);
                    SubmitButton.Draw(spriteBatch);
                    spriteBatch.DrawString(HighScoreFont, "Enter Name : ", new Vector2(Device.PresentationParameters.BackBufferWidth/3 -5, Device.PresentationParameters.BackBufferHeight / 2 - 50), Color.Black);
                    spriteBatch.DrawString(HighScore, "Score : ", new Vector2(Device.PresentationParameters.BackBufferWidth / 3 +10, Device.PresentationParameters.BackBufferHeight/4 - 50), Color.Black);
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
