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

        Texture2D Background;
        Rectangle BackgroundRect;

        Texture2D TitleScreen;
        Rectangle TitleScreenRec;

        Texture2D pickOrange;
        Texture2D pickApple;
        Texture2D pickBanna;

        Texture2D dumpApple;
        Texture2D dumpBanna;
        Texture2D dumpOrange;

        BananaBlender bananaBlender;
        AppleBlender appleBlender;
        OrangeBlender orangeBlender;

        Player BatPl;

        Bin bin1;
        Bin bin2;
        int ScreenWidth, ScreenHeight;

        //high score Stuff
        Button BackButton;
        GraphicsDevice Device;
        SpriteFont HighScoreFont;
        SpriteFont HighScoreTitle;
        List<PersonDetails> PeopleList;

        // Score Entry
        HighScore HighScoreList = new HighScore();
        KeyboardDispatcher KeyBoardDispatcher;
        TextBoxClass.TextBox TextEntry;
        Button SubmitButton;
        SpriteFont SubmitText;
        SpriteFont HighScore;

        //Start Screen
        Button Start;
        Button ViewHighScore;

        // Game Play
        //ElapsTime
        float elapsed = 0f;
        float WaveLengthOne = 10000f;
        List<Fruit> WaveOneList;
        Random XPosition = new Random();
        Random YPosition = new Random();
        Random FruitNumber = new Random();
        Random TimeGeneration = new Random();
        Player player;

        List<Blender> DrawBlender = new List<Blender>();
        List<Bad_Fruit> DrawRottenFruit = new List<Bad_Fruit>();
        List<Fruit> DrawFruit = new List<Fruit>();
        List<Bin> DrawBins = new List<Bin>();

         public enum gamestate
         {
             startscreen,
             playingGame,
             highScore,
             ScoreEntry
         }

        gamestate currentgamestate = gamestate.startscreen;
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
            ScreenWidth = GraphicsDevice.Viewport.Width;
            ScreenHeight = GraphicsDevice.Viewport.Height;

            Device = graphics.GraphicsDevice;
            switch (currentgamestate)
            {
                case gamestate.startscreen:
                    Texture2D start = Content.Load<Texture2D>("buttonStart");
                    Start = new Button(start, start, start, new Vector2(Device.PresentationParameters.BackBufferWidth / 30, Device.PresentationParameters.BackBufferHeight / 2),new Rectangle(0,0,0,0),ScreenWidth,ScreenHeight);
                    Start.OnPress += new EventHandler(StartButton_Clicked);

                    Texture2D ViewHighScores = Content.Load<Texture2D>("buttonHighScores");
                    ViewHighScore = new Button(ViewHighScores, ViewHighScores, ViewHighScores, new Vector2(Device.PresentationParameters.BackBufferWidth -300, Device.PresentationParameters.BackBufferHeight /30), new Rectangle(0, 0, 0, 0), ScreenWidth, ScreenHeight);
                    ViewHighScore.OnPress += new EventHandler(ViewHighScoresButton_Clicked);

                    TitleScreen = Content.Load<Texture2D>("assests for fruity full squash/Title");
                    TitleScreenRec = new Rectangle(0, 0, ScreenWidth, ScreenHeight);

                    break;
                case gamestate.playingGame:
                    WaveOneList = WaveOne();
                    break;
                case gamestate.highScore:
                    Texture2D HighScoreBackButton = Content.Load<Texture2D>("HighScoreBack");
                    BackButton = new Button(HighScoreBackButton, HighScoreBackButton, HighScoreBackButton, new Vector2(Device.PresentationParameters.BackBufferWidth / 3 + 10, Device.PresentationParameters.BackBufferHeight / 2), new Rectangle(0, 0, 0, 0), ScreenWidth, ScreenHeight);
                    BackButton.OnPress += new EventHandler(HighScoreBackButton_Clicked);

                    HighScoreTitle = Content.Load<SpriteFont>("Title");
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
                    SubmitButton = new Button(SubmitScore, SubmitScore, SubmitScore, new Vector2(Device.PresentationParameters.BackBufferWidth / 3 + 10, Device.PresentationParameters.BackBufferHeight / 2), new Rectangle(0, 0, 0, 0), ScreenWidth, ScreenHeight);
                    SubmitButton.OnPress += new EventHandler(SubmitButton_Clicked);

                    SubmitText = Content.Load<SpriteFont>("HighScoreText");
                    HighScore = Content.Load<SpriteFont>("HighScoreText");
                    break;
                default:
                   break;
            }


            
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

          Background = Content.Load<Texture2D>("BackGround");
          BackgroundRect = new Rectangle(0, 0, ScreenWidth, ScreenHeight);

          pickOrange = Content.Load<Texture2D>("assests for fruity full squash/orange");

          pickBanna = Content.Load<Texture2D>("assests for fruity full squash/bananas-03");

          pickApple = Content.Load<Texture2D>("assests for fruity full squash/apple");

          dumpApple = Content.Load<Texture2D>("assests for fruity full squash/rottenApple");

          dumpBanna = Content.Load<Texture2D>("assests for fruity full squash/rottenbanana");

          dumpOrange = Content.Load<Texture2D>("assests for fruity full squash/rottenOrange");

          appleBlender = new AppleBlender(
              Content.Load<Texture2D>("assests for fruity full squash/AppleBlender"),
             new Vector2(170, 410),
              new Rectangle(0, 0, 40, 40),
              ScreenWidth, ScreenHeight);

          BatPl = new Player(
            Content.Load<Texture2D>("assests for fruity full squash/paddle"),
           new Vector2(170, 310),
            new Rectangle(0, 0, 40, 40),
            ScreenWidth, ScreenHeight);

          bananaBlender = new BananaBlender(
              Content.Load<Texture2D>("assests for fruity full squash/BananaBlender"),
             new Vector2(400, 410),
              new Rectangle(0, 0, 100, 40),
              ScreenWidth, ScreenHeight);

          orangeBlender = new OrangeBlender(
              Content.Load<Texture2D>("assests for fruity full squash/OrangeBlender"),
             new Vector2(600, 410),
              new Rectangle(0, 0, 40, 40),
              ScreenWidth, ScreenHeight);

          bin1 = new Bin(
              Content.Load<Texture2D>("assests for fruity full squash/bin2"),
             new Vector2(0, 400),
              new Rectangle(0, 0, 40, 40),
              ScreenWidth, ScreenHeight);

          bin2 = new Bin(
         Content.Load<Texture2D>("assests for fruity full squash/bin2"),
        new Vector2(740, 400),
         new Rectangle(0, 0, 40, 40),
         ScreenWidth, ScreenHeight);

          DrawBlender.Add(orangeBlender);
          DrawBlender.Add(appleBlender);
          DrawBlender.Add(bananaBlender);

          DrawBins.Add(bin1);
          DrawBins.Add(bin2);
        }


        private void HighScoreBackButton_Clicked(object sender, EventArgs e)
        {

            currentgamestate = gamestate.startscreen;
            LoadContent();
        }

        private void StartButton_Clicked(object sender, EventArgs e)
        {

            currentgamestate = gamestate.playingGame;
            LoadContent();
        }

        private void ViewHighScoresButton_Clicked(object sender, EventArgs e)
        {

            currentgamestate = gamestate.highScore;
            LoadContent();

        }

        private void SubmitButton_Clicked(object sender, EventArgs e)
        {
            string PersonName = TextEntry.Text;
            int Score = 300;
            PeopleList.Add(new PersonDetails(PersonName, Score));

            PersonDetails temp = null;

            for (int write = 0; write < PeopleList.Count; write++)
            {
                for (int sort = 0; sort < PeopleList.Count - 1; sort++)
                {
                    if (PeopleList[sort].ScoreGetSet < PeopleList[sort + 1].ScoreGetSet)
                    {
                        temp = PeopleList[sort + 1];
                        PeopleList[sort + 1] = PeopleList[sort];
                        PeopleList[sort] = temp;
                    }
                }
            }

            PeopleList.Remove(PeopleList[5]);
            HighScoreList.GetSetTopFivePeople = PeopleList;
            HighScoreList.SavePeople();
            HighScoreList.LoadPeople();
            currentgamestate = gamestate.startscreen;

        }

        private void DrawHighScores()
        {
            int Yaxis = 80;
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


        public int XPositionGenerator()
        {
            Device = graphics.GraphicsDevice;
            int Position = XPosition.Next(1, Device.PresentationParameters.BackBufferWidth - 1);

            return Position;
        }

        public int YPositionGenerator()
        {
            Device = graphics.GraphicsDevice;
            int Position = YPosition.Next(-200,-100);

            return Position;
        }

        public float TimeGenerator(float EndTime)
        {

            Device = graphics.GraphicsDevice;
            float TimeGen = TimeGeneration.Next(0, (int)EndTime);

            return TimeGen;
        }

        public int FruitType()
        {
            Device = graphics.GraphicsDevice;
            int FruitNum = FruitNumber.Next(0, 5);

            return FruitNum;
        }

        public List<Fruit> WaveOne()
        {
            List<Fruit> Fruit = new List<Fruit>();
            int NumOfFruitDrop = 5;
            int FType = 0;
            int XPos = 0;
            int Ypos = 0;
            float TimeDrop = 0f;

            for (int x = 0; x < NumOfFruitDrop; ++x)
            {
                FType = FruitType();
                XPos = XPositionGenerator();
                TimeDrop = TimeGenerator(WaveLengthOne);

                switch (FType)
                {
                    case 0:
                        Apple apple = new Apple(pickApple, new Vector2(XPos, Ypos), new Rectangle(0, 0, 0, 0), ScreenWidth, ScreenHeight, TimeDrop);
                        Fruit.Add(apple);
                        break;
                    case 1:
                        Banana banana = new Banana(pickBanna, new Vector2(XPos, Ypos), new Rectangle(0, 0, 0, 0), ScreenWidth, ScreenHeight, TimeDrop);
                        Fruit.Add(banana);
                        break;
                    case 2:
                        Orange orange = new Orange(pickOrange, new Vector2(XPos, Ypos), new Rectangle(0, 0, 0, 0), ScreenWidth, ScreenHeight, TimeDrop);
                        Fruit.Add(orange);
                        break;
                    case 3:
                        Rotten_Apple Rottenapple = new Rotten_Apple(dumpApple, new Vector2(XPos, 0), new Rectangle(0, 0, 0, 0), ScreenWidth, ScreenHeight, TimeDrop);
                        Fruit.Add(Rottenapple);
                        break;
                    case 4:
                        Rotten_Banana Rottenbanana = new Rotten_Banana(dumpBanna, new Vector2(XPos, 0), new Rectangle(0, 0, 0, 0), ScreenWidth, ScreenHeight, TimeDrop);
                        Fruit.Add(Rottenbanana);
                        break;
                    case 5:
                        Rotten_Orange Rottenorange = new Rotten_Orange(dumpOrange, new Vector2(XPos, 0), new Rectangle(0, 0, 0, 0), ScreenWidth, ScreenHeight, TimeDrop);
                        Fruit.Add(Rottenorange);
                        break;
                    default:
                        break;
                }

            }

            return Fruit;
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
                    Start.Update(gameTime);
                    ViewHighScore.Update(gameTime);
                    break;
                case gamestate.playingGame:
                    BatPl.Update(gameTime);
                   elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                   if (elapsed >= WaveLengthOne)
                    {
                        elapsed = 0f;
                        currentgamestate = gamestate.startscreen;
                    }
                    foreach (Fruit Fruit in WaveOneList)
                    {
                            Fruit.Update(gameTime);
                    }

                    break;
                case gamestate.highScore:
                    BackButton.Update(gameTime);
                    break;
                case gamestate.ScoreEntry:
                    TextEntry.Update(gameTime);
                    SubmitButton.Update(gameTime);
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
                    spriteBatch.Draw(TitleScreen, TitleScreenRec, Color.White);
                    Start.Draw(spriteBatch);
                    ViewHighScore.Draw(spriteBatch);
                    
                    break;
                case gamestate.playingGame:
                    spriteBatch.Draw(Background, BackgroundRect, Color.White);
                    foreach (Blender c in DrawBlender)
                        c.Draw(spriteBatch);
                    foreach (Bin a in DrawBins)
                        a.Draw(spriteBatch);
                    foreach (Fruit F in WaveOneList)
                        F.Draw(spriteBatch);
                         BatPl.Draw(spriteBatch);
                        
                    break;
                case gamestate.highScore:
                    BackButton.Draw(spriteBatch);
                    DrawHighScores();
                    spriteBatch.DrawString(HighScoreTitle, "High Score", new Vector2(Device.PresentationParameters.BackBufferWidth / 3 +20, Device.PresentationParameters.BackBufferHeight / 30), Color.Black);
                    break;
                case gamestate.ScoreEntry:
                    TextEntry.Draw(spriteBatch,gameTime);
                    SubmitButton.Draw(spriteBatch);
                    spriteBatch.DrawString(HighScoreFont, "Enter Name : ", new Vector2(Device.PresentationParameters.BackBufferWidth/3 -5, Device.PresentationParameters.BackBufferHeight / 2 - 50), Color.Black);
                    spriteBatch.DrawString(HighScore, "Score : ", new Vector2(Device.PresentationParameters.BackBufferWidth / 3 +10, Device.PresentationParameters.BackBufferHeight/4 - 50), Color.Black);
                    break;
                default:
                    break;
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
