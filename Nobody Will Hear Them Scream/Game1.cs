using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.ConstrainedExecution;

public enum GameState
{
    mainMenu,
    highScores,
    gameOver,
    pauseScreen,
    instructions,
    gameplay,
    levelTransitions
}

namespace Nobody_Will_Hear_Them_Scream
{
    public class Game1 : Game
    {
        // Fields to set up player interaction
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private KeyboardState kb;
        private KeyboardState prevKB;
        private MouseState ms;
        private MouseState prevMS;

        // Fields to set up text fonts
        private SpriteFont Arial14;
        private SpriteFont Arial32;

        // Fields to set up FSM and buttons
        private GameState gameState;

        private Button startGameButton;
        private Button highScoresButton;
        private Button backToMainMenuButton;
        private Button backToMainMenuButtonTwo;
        private Button closeGameButton;
        private Button resumeGameButton;
        private Button quitGameButton;
        private Button instructionsButton;

        // Fields to set up astronaut character
        private Texture2D textureAstronautBody;
        private Texture2D texturePlayerProjectile;
        private Texture2D textureAstronautArm;
        private Rectangle astronautBounds;
        private Player astronaut;

        // Fields to manage projectiles
        private List<Projectile> projectileList = new List<Projectile>();

        // Fields to set up HUD
        private int time;
        private int levelNum;
        private int displayLevel;
        private int frames;

        // Managers to hold crates, enemies, and health pickups for levels
        private EnemyManager enemyManager;
        private CrateManager crateList;
        private HealthPickupManager healthPickupManager;

        // Textures for crates
        private Texture2D textureSquareCrate;
        private Texture2D textureWideCrate;
        private Texture2D textureTallCrate;

        // Texture for health pickup
        private Texture2D textureHealthPickup;

        // Texture for hearts
        private Texture2D textureHeart;

        // Texture for background
        private Texture2D textureSpaceBackground;

        // Texture for title
        private Texture2D textureLogo;

        // Texture for enemies
        private Texture2D textureBaseEnemySprite;
        private Texture2D textureSlowEnemySprite;
        private Texture2D textureFastEnemySprite;

        private int levelCount;

        private int framesSinceLevelEnd;

        private bool firstTimePlaying;
        private bool exitTutorial;

        private List<int> scoreList = new List<int>();

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            //Window.IsBorderless = true;
        }

        protected override void Initialize()
        {
            levelCount = 8;

            gameState = GameState.mainMenu;

            firstTimePlaying = true;
            exitTutorial = false;

            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            //_graphics.ToggleFullScreen();
            _graphics.ApplyChanges();

            //Reads the top five scores from a text file if possible
            //Fills the list with 0s if no text file exits
            try
            {
                using(StreamReader scoreReader = new StreamReader("HighScores.txt"))
                {
                    int score;
                    while ((score = int.Parse(scoreReader.ReadLine())) != null)
                    {
                        scoreList.Add(score);
                    }
                }
            } catch
            {
                for(int i = 0; i < 5; i++)
                {
                    scoreList.Add(0);
                }
            }

            //Makes sure no extra 0s are added to the score.
            if(scoreList.Count > 5)
            {
                while (scoreList.Count > 5)
                {
                    scoreList.RemoveAt(scoreList.Count - 1);
                }
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Set up the astronaut
            textureAstronautBody = Content.Load<Texture2D>("astronaut body");
            texturePlayerProjectile = Content.Load<Texture2D>("projectile");
            textureAstronautArm = Content.Load<Texture2D>("astronaut arm");

            astronautBounds = new Rectangle(_graphics.PreferredBackBufferWidth / 2 - 50, _graphics.PreferredBackBufferHeight / 2 - 50, 42, 60);
            astronaut = new Player(textureAstronautBody, textureAstronautArm, astronautBounds);

            // Set up the enemies
            textureBaseEnemySprite = Content.Load<Texture2D>("enemy sprite");
            textureSlowEnemySprite = Content.Load<Texture2D>("Big Enemy sprite");
            textureFastEnemySprite = Content.Load<Texture2D>("Fast Enemy sprite");

            // Set up the boxes
            textureSquareCrate = Content.Load<Texture2D>("square box");
            textureWideCrate = Content.Load<Texture2D>("wide box");
            textureTallCrate = Content.Load<Texture2D>("tall box");

            // Set up the health pickup
            textureHealthPickup = Content.Load<Texture2D>("health box");

            // Set up the heart
            textureHeart = Content.Load<Texture2D>("heart");

            // Set up space background
            textureSpaceBackground = Content.Load<Texture2D>("SpaceWalk background");

            // Set up title
            textureLogo = Content.Load<Texture2D>("SpaceWalk logo");

            // Default items for the enemy and crate managers
            enemyManager = new EnemyManager(textureBaseEnemySprite, textureSlowEnemySprite, textureFastEnemySprite);
            crateList = new CrateManager(textureSquareCrate, textureWideCrate, textureTallCrate);
            healthPickupManager = new HealthPickupManager(textureHealthPickup);

            // Set up fonts
            Arial14 = Content.Load<SpriteFont>("Arial14");
            Arial32 = Content.Load<SpriteFont>("Arial32");

            // Initializes the buttons present on the start screen.

            startGameButton = new Button(new Vector2(_graphics.PreferredBackBufferWidth/2 - Arial14.MeasureString("Start Game").X/2,
                _graphics.PreferredBackBufferHeight/4 + 175), "Start Game", Arial14);

            highScoresButton = new Button(new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString("High Scores").X / 2,
                _graphics.PreferredBackBufferHeight / 4 + 225), "High Scores", Arial14);

            instructionsButton = new Button(new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString("Instructions").X / 2,
                _graphics.PreferredBackBufferHeight / 4 + 275), "Instructions", Arial14);

            closeGameButton = new Button(new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString("Close").X / 2,
                _graphics.PreferredBackBufferHeight / 4 + 325), "Close", Arial14);

            // Initializes the button used to get from high scores to title

            backToMainMenuButton = new Button(new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString("Back").X / 2,
                _graphics.PreferredBackBufferHeight / 4 + 100), "Back", Arial14);

            backToMainMenuButtonTwo = new Button(new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString("Back").X / 2,
                _graphics.PreferredBackBufferHeight / 4 + 500), "Back", Arial14);

            // Initializes buttons to resume or quit game from the pause screen

            resumeGameButton = new Button(new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString("Resume").X / 2,
                _graphics.PreferredBackBufferHeight / 4 + 100), "Resume", Arial14);

            quitGameButton = new Button(new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString("Quit").X / 2,
                _graphics.PreferredBackBufferHeight / 4 + 150), "Quit", Arial14);
        }

        /// <summary>
        /// A method that resets game values at the start of a new game
        /// </summary>
        public void Reset()
        {
            displayLevel = 0;
            levelNum = 0;
            astronaut.Lives = 3;
            astronaut.GameScore = 0;
            astronaut.LevelScore = 0;
            crateList.ClearCrates();
            crateList = new CrateManager(textureSquareCrate, textureWideCrate, textureTallCrate);
            enemyManager = new EnemyManager(textureBaseEnemySprite, textureSlowEnemySprite, textureFastEnemySprite);
            framesSinceLevelEnd = 0;
        }

        /// <summary>
        /// A method that sets the proper values for game elements when a game starts
        /// </summary>
        public void NewLevel()
        {
            framesSinceLevelEnd = 0;
            levelNum++;
            displayLevel++;
            astronaut.LevelScore = 0;
            astronaut.PlayerVelocity = new Vector2(0,0);
            projectileList.Clear();
            crateList.ClearCrates();
            healthPickupManager.Clear();
            LoadLevel();
            astronaut.rect = astronautBounds;
        }

        /// <summary>
        /// Loads the data from a .level file and sets up the new level
        /// </summary>
        /// <param name="level">Which level number is being loaded (level 1, etc)</param>
        private void LoadLevel()
        {
            string filename = $"Content/level{levelNum}.level";
            if (!File.Exists(filename))
            {
                //Do whatever happens when you run out of levels
                return;
            }

            FileStream inputStream = File.OpenRead(filename);
            BinaryReader input = new BinaryReader(inputStream);

            int w = input.ReadInt32();
            int h = input.ReadInt32();

            //enemyManager.SmallPrint = false;

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    int id = input.ReadInt32();

                    if (id != 0)
                    {
                        int x = (int)((double)i / w * _graphics.PreferredBackBufferWidth);
                        int y = (int)((double)j / h * _graphics.PreferredBackBufferHeight);
                        Point spawnPoint = new Point(x, y);

                        if (id == 1)
                        {
                            astronaut.X = x;
                            astronaut.Y = y;
                        }
                        else if (id == 2)
                        {
                            healthPickupManager.AddHealthPickup(spawnPoint);
                        }
                        else if (id == 10)
                        {
                            enemyManager.CreateBasicEnemy(spawnPoint);
                        }
                        else if (id == 11)
                        {
                            enemyManager.CreateLargeEnemy(spawnPoint);
                        }
                        else if (id == 12)
                        {
                            enemyManager.CreateFastEnemy(spawnPoint);
                        }
                        else if (id == 20)
                        {
                            crateList.CreateNewCrate(spawnPoint, CrateTexutre.square);
                        }
                        
                        else if (id == 21)
                        {
                            crateList.CreateNewCrate(spawnPoint, CrateTexutre.wide);
                        }
                        else if (id == 22)
                        {
                            crateList.CreateNewCrate(spawnPoint, CrateTexutre.tall);
                        }

                    }
                }
            }

            time = input.ReadInt32();
        }

        /// <summary>
        /// Checks if the leftmouse button has been clicked this frame and not last frame
        /// </summary>
        /// <returns></returns>
        private bool SingleLeftClick()
        {
            if (ms.LeftButton == ButtonState.Pressed && prevMS.LeftButton != ButtonState.Pressed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if a key was pressed this frame and not last frame
        /// </summary>
        /// <param name="key">The key to check for</param>
        /// <returns></returns>
        private bool SinglePress(Keys key)
        {
            if (kb.IsKeyDown(key) && !prevKB.IsKeyDown(key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected override void Update(GameTime gameTime)
        {
            // Get Keyboard and Mouse states
            kb = Keyboard.GetState();
            ms = Mouse.GetState();

            // State machine
            switch (gameState)
            {
                case GameState.mainMenu:
                    // Brings user to a screen when pressing it's respective button
                    if (SingleLeftClick() && startGameButton.Rect.Contains(ms.Position))
                    {
                        Reset();
                        NewLevel();
                        gameState = GameState.gameplay;
                    }
                    else if (SingleLeftClick() && highScoresButton.Rect.Contains(ms.Position))
                    {
                        gameState = GameState.highScores;
                    }
                    else if (SingleLeftClick() && closeGameButton.Rect.Contains(ms.Position))
                    {
                        //Closes the application
                        Exit();
                    }
                    else if (SingleLeftClick() && instructionsButton.Rect.Contains(ms.Position))
                    {
                        gameState = GameState.instructions;
                    }

                    break;

                case GameState.highScores:
                    // Brings player to main menu if they press the button or if they press escape
                    if (SingleLeftClick() && backToMainMenuButton.Rect.Contains(ms.Position) || SinglePress(Keys.Escape))
                    {
                        gameState = GameState.mainMenu;
                    }
                    break;

                case GameState.instructions:
                    // Brings player to main menu if they press the button or if they press escape
                    if (SingleLeftClick() && backToMainMenuButtonTwo.Rect.Contains(ms.Position) || SinglePress(Keys.Escape))
                    {
                        gameState = GameState.mainMenu;
                    }
                    break;

                case GameState.gameplay:

                    astronaut.Update(gameTime, ms);
                    astronaut.HandleScreenCollisions(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

                    // Update the score
                    int scoreToAdd = enemyManager.Update(gameTime, astronaut, projectileList, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
                    astronaut.GameScore += scoreToAdd;
                    astronaut.LevelScore += scoreToAdd;

                    crateList.Update(gameTime, astronaut);
                    healthPickupManager.Update(astronaut);

                    //For initial tutorial
                    if(firstTimePlaying == true)
                    {
                        gameState = GameState.pauseScreen;
                    }

                    // Update projectiles
                    foreach(Projectile p in projectileList)
                    {
                        p.Update(gameTime);
                    }

                    // Transfer to pause screen
                    if (SinglePress(Keys.Escape))
                    {
                        gameState = GameState.pauseScreen;
                    }

                    // Game over
                    if (astronaut.Lives == 0)
                    {
                        //Updates the high scores if necessary
                        for (int i = 0; i < 5; i++)
                        {
                            if (astronaut.GameScore >= scoreList[i])
                            {
                                scoreList.Insert(i, astronaut.GameScore);
                                scoreList.RemoveAt(5);
                                break;
                            }
                        }
                        
                        //Records the high scores to a text file, creating a new one if necessary
                        try
                        {
                            string path = new string("HighScores.txt");
                            
                            if (!File.Exists(path))
                            {
                                using (StreamWriter scoreWriter = File.CreateText(path))
                                {
                                    for (int i = 0; i < 5; i++)
                                    {
                                        scoreWriter.WriteLine(scoreList[i]);
                                    }
                                }
                                
                            } else
                            {
                                StreamWriter scoreWriter = new StreamWriter(path);
                                for (int i = 0; i < 5; i++)
                                {
                                    scoreWriter.WriteLine(scoreList[i]);
                                }
                                scoreWriter.Close();
                            }
                        } catch
                        {
                            Console.WriteLine("Path creation unsuccessful");
                        }
                        

                        //Brings the player to the game over screen
                        gameState = GameState.gameOver;
                    }

                    // If there was a left click on this frame, move the player
                    if (SingleLeftClick() || exitTutorial == true)
                    {
                        // Move the player
                        astronaut.MovePlayer(ms);

                        //Determine projectile's velocity
                        Vector2 v = new Vector2(ms.X - astronaut.CenterX, ms.Y - astronaut.CenterY);
                        v.Normalize();
                        v *= 15;
                        // Create a projectile
                        Projectile p = new Projectile(texturePlayerProjectile, new Rectangle(astronaut.rect.Center, Projectile.ProjectileSize), v);
                        projectileList.Add(p);

                        exitTutorial = false;
                    }

                    // Works the timer
                    frames++;
                    if (frames % 60 == 0)
                    {
                        time--;
                    }

                    // Moves to the next level if time runs out
                    if(enemyManager.EnemyCount == 0)
                    {
                        framesSinceLevelEnd = 0;
                        gameState = GameState.levelTransitions;
                    }
                    else if (time == 0)
                    {
                        gameState = GameState.gameOver;
                    }

                    break;

                case GameState.pauseScreen:
                    // Brings the player back to the game if they press the button or if they press escape
                    if(firstTimePlaying == true && SingleLeftClick())
                    {
                        firstTimePlaying = false;
                        exitTutorial = true;
                        gameState = GameState.gameplay;
                    }
                    if (SingleLeftClick() && resumeGameButton.Rect.Contains(ms.Position) || SinglePress(Keys.Escape))
                    {
                        gameState = GameState.gameplay;
                    }
                    else if (SingleLeftClick() && quitGameButton.Rect.Contains(ms.Position))
                    {
                        gameState = GameState.mainMenu;
                    }
                    break;
                case GameState.levelTransitions:
                    if (framesSinceLevelEnd == 0)
                    {
                        if (levelNum != levelCount)
                        {
                            NewLevel();
                        }
                        else
                        {
                            levelNum = 0;
                            NewLevel();
                        }
                    }
                    else if (framesSinceLevelEnd == 20)
                    {
                        gameState = GameState.gameplay;
                    }
                    framesSinceLevelEnd++;
                    break;
                case GameState.gameOver:

                    //Handles Button Presses
                    if (SinglePress(Keys.Escape) || (SingleLeftClick() && backToMainMenuButton.Rect.Contains(ms.Position)) )
                    {
                        //Brings the player back to the Main Menu
                        gameState = GameState.mainMenu;
                    }
                    else if (SingleLeftClick() && highScoresButton.Rect.Contains(ms.Position))
                    {
                        //Brings the player to the High Scores Screen
                        gameState = GameState.highScores;
                    }
                    break;
            }

            // Set current keyboard and mouse states to be
            // used as previous ones for next cycle
            prevKB = kb;
            prevMS = ms;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Start the sprite batch
            _spriteBatch.Begin();

            // Draw space background
            _spriteBatch.Draw(textureSpaceBackground,
                new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight),
                Color.White);

            // State machine
            switch (gameState)
            {
                case GameState.mainMenu:
                    //Draw the title and buttons


                    // Draws the title
                    _spriteBatch.Draw(textureLogo,
                        new Rectangle(_graphics.PreferredBackBufferWidth / 2 - textureLogo.Width / 2 / 2,
                        _graphics.PreferredBackBufferHeight / 6,
                        (int)(textureLogo.Width / 2.5f), (int)(textureLogo.Height / 2.5f)),
                        Color.White);


                    // Draws the buttons

                    startGameButton.Draw(_spriteBatch, Color.White);

                    highScoresButton.Draw(_spriteBatch, Color.White);

                    instructionsButton.Draw(_spriteBatch, Color.White);

                    closeGameButton.Draw(_spriteBatch, Color.White);
                    break;

                case GameState.highScores:
                    // Add the back button to return to the start screen

                    backToMainMenuButton.Draw(_spriteBatch, Color.White);

                    //Draws in each high score in the list
                    int height = 175;
                    int i = 0;
                    foreach(int score in scoreList)
                    {
                        _spriteBatch.DrawString(Arial14, $"{score}",
                        new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString($"{score}").X / 2,
                        // Puts it in the middle of the screen
                        height),
                        Color.White);
                        height += 25;
                    }

                    break;

                case GameState.instructions:
                    //Write in the instructions
                    string stringOne = "How to play:";
                    string stringTwo = "Click the screen to blast the astronaut in the opposite direction.";
                    string stringThree = "Avoid enemies, and blast them with projectiles.";
                    string stringFour = "Run into crates to build up a high score, and grab health pickups to stay alive.";
                    string stringFive = "Each level has a set time, so act fast!";
                    string stringSix = "Enemies will home in on you. (2pts)";
                    string stringSeven = "Pointy enemies move faster. (3 pts)";
                    string stringEight = "Flat enemies move slower, but take 2 hits. (4 pts)";
                    string stringNine = "(10 pts)               (20 pts)                (20 pts)               (1 HP)";
                    _spriteBatch.DrawString(Arial14, stringOne,
                        new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString(stringOne).X / 2,
                        175),
                        Color.White);
                    _spriteBatch.DrawString(Arial14, stringTwo,
                        new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString(stringTwo).X / 2,
                        200),
                        Color.White);
                    _spriteBatch.DrawString(Arial14, stringThree,
                        new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString(stringThree).X / 2,
                        225),
                        Color.White);
                    _spriteBatch.DrawString(Arial14, stringFour,
                        new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString(stringFour).X / 2,
                        250),
                        Color.White);
                    _spriteBatch.DrawString(Arial14, stringFive,
                        new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString(stringFive).X / 2,
                        275),
                        Color.White);
                    _spriteBatch.DrawString(Arial14, stringSix,
                        new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString(stringSix).X / 2,
                        362),
                        Color.White);
                    _spriteBatch.DrawString(Arial14, stringSeven,
                        new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString(stringSeven).X / 2,
                        412),
                        Color.White);
                    _spriteBatch.DrawString(Arial14, stringEight,
                        new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString(stringEight).X / 2,
                        462),
                        Color.White);
                    
                    _spriteBatch.DrawString(Arial14, stringNine,
                        new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString(stringNine).X / 2,
                        600),
                        Color.White);
                    

                    //Draw the enemies and crates to show what they look like
                    _spriteBatch.Draw(textureBaseEnemySprite, new Rectangle(710, 350, 30, 30), Color.White);
                    _spriteBatch.Draw(textureFastEnemySprite, new Rectangle(710, 400, 30, 30), Color.White);
                    _spriteBatch.Draw(textureSlowEnemySprite, new Rectangle(700, 450, 50, 50), Color.White);
                    _spriteBatch.Draw(textureSquareCrate, new Rectangle(740, 550, 30, 30), Color.White);
                    _spriteBatch.Draw(textureWideCrate, new Rectangle(880, 525, 30, 60), Color.White);
                    _spriteBatch.Draw(textureTallCrate, new Rectangle(1010, 550, 60, 30), Color.White);
                    _spriteBatch.Draw(textureHealthPickup, new Rectangle(1160, 550, 30, 30), Color.White);

                    //Make sure the player can get back to the Title Screen
                    backToMainMenuButtonTwo.Draw(_spriteBatch, Color.White);

                    break;

                case GameState.gameplay:

                    DrawGameplay(false);
                    break;

                case GameState.pauseScreen:

                    DrawGameplay(true);

                    //Provide Tutorial
                    if(firstTimePlaying == true)
                    {
                        _spriteBatch.DrawString(Arial32, "Click at the alien to shoot it, and",
                        new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial32.MeasureString("Click at the alien to shoot it, and").X / 2,
                        250),
                        Color.White);
                        _spriteBatch.DrawString(Arial32, "you'll blast off in the opposite direction!",
                        new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial32.MeasureString("you'll blast off in the opposite direction!").X / 2,
                        300),
                        Color.White);
                    } else
                    {
                        // Draw resume and quit buttons
                        resumeGameButton.Draw(_spriteBatch, Color.White);
                        quitGameButton.Draw(_spriteBatch, Color.White);
                    }

                    break;
                case GameState.levelTransitions:
                    DrawGameplay(false);
                    break;

                case GameState.gameOver:
                    //Game Over Title
                    _spriteBatch.DrawString(Arial32, "GAME OVER",
                        new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial32.MeasureString("GAME OVER").X / 2, // Puts it in the middle of the screen
                        _graphics.PreferredBackBufferHeight / 4),
                        Color.White);

                    //Presents access to the High Scores
                    highScoresButton.Draw(_spriteBatch, Color.White);

                    break;
            }

            // End the sprite batch
            _spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Draws everything on the screen when the game is being played
        /// </summary>
        /// <param name="isPaused">True if the game is paused, false if it isn't</param>
        public void DrawGameplay(bool isPaused)
        {
            Color colorToDrawSprites = Color.White;
            Color colorToDrawIntSprites = Color.White;
            Color colorToDrawTime = Color.White;
            Color colorToDrawPlayer = colorToDrawIntSprites;

            // Change sprites to gray when paused
            if (isPaused)
            {
                colorToDrawTime = Color.DarkGray;
                colorToDrawSprites = Color.DarkGray;
                colorToDrawIntSprites = Color.DarkGray;
            }

            // Make timer red at 10 seconds left and dark red if its paused
            if (time <= 10 && isPaused)
            {
                colorToDrawTime = Color.DarkRed;
            }
            else if (time <= 10)
            {
                colorToDrawTime = Color.Red;
            }

            // Draw space background
            _spriteBatch.Draw(textureSpaceBackground,
                new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight),
                colorToDrawSprites);

            //Makes sprites flash red when astronaut is damaged
            if (enemyManager.DetectPlayerIntersection(astronaut))
            {
                if (isPaused)
                {
                    colorToDrawPlayer = Color.DarkRed;
                } else
                {
                    colorToDrawPlayer = Color.Red;
                }
            } else
            {
                colorToDrawPlayer = colorToDrawIntSprites;
            }

            // Draw the player
            astronaut.Draw(_spriteBatch, colorToDrawPlayer);

            //Draw Enemies
            enemyManager.Draw(_spriteBatch, colorToDrawIntSprites, Arial32);

            // Draw the crates
            crateList.Draw(_spriteBatch, colorToDrawSprites, Arial32);

            // Draw the health pickups
            healthPickupManager.Draw(_spriteBatch, colorToDrawSprites, Arial32);

            // Draw Projectiles
            foreach (Projectile p in projectileList)
            {
                p.Draw(_spriteBatch, Color.White);
            }

            // === PRINT UI ===

            int heartSize = 96;

            // Draw as many hearts as the player has lives
            for (int i = 0; i < astronaut.Lives; i++)
            {
                _spriteBatch.Draw(textureHeart,
                    new Rectangle(30 + i * (heartSize + 20), 30,
                        heartSize, heartSize),
                    colorToDrawSprites);
            }

            // Print the time
            _spriteBatch.DrawString(Arial32, $"Time Left: {time}", new Vector2(30, 140), colorToDrawTime);

            // Print the current level
            _spriteBatch.DrawString(Arial32, $"Level: {displayLevel}", new Vector2(30, 180), colorToDrawSprites);

            // Print the current score
            _spriteBatch.DrawString(Arial32, $"Score: {astronaut.GameScore}", new Vector2(30, 220), colorToDrawSprites);



            // WHETHER TO PRINT DEBUG STUFF OR NOT
            bool printDebugStuff = false;

            if (printDebugStuff)
            {// Draw debug stuff:

                // Center of astronaut
                _spriteBatch.DrawString(Arial14, $"Center of astronaut: {astronaut.CenterX}, {astronaut.CenterY}",
                    new Vector2(30, 50),
                    Color.White);

                // Mouse position
                _spriteBatch.DrawString(Arial14, $"Mouse pos: {ms.X}, {ms.Y}",
                    new Vector2(30, 70),
                    Color.White);

                // State, Screen size, lives, level, and level score
                _spriteBatch.DrawString(Arial14, "State: " + gameState.ToString(), new Vector2(30, 30), Color.White);
                _spriteBatch.DrawString(Arial14, $"Screen size: {_graphics.PreferredBackBufferWidth}, {_graphics.PreferredBackBufferHeight}", new Vector2(30, 10), Color.White);
                _spriteBatch.DrawString(Arial14, $"Lives: {astronaut.Lives}", new Vector2(30, 110), Color.White);
            }
        }
    }
}