using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public enum GameState
{
    mainMenu,
    highScores,
    gameOver,
    pauseScreen,
    instructions,
    gameplay
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
        private Button closeGameButton;
        private Button resumeGameButton;
        private Button quitGameButton;
        private Button instructionsButton;

        // Fields to set up astronaut character
        private Texture2D textureAstronautBody;
        private Rectangle astronautBounds;
        private Player astronaut;
        private Texture2D texturePlayerProjectile;

        // Fields to manage projectiles
        private List<Projectile> projectileList = new List<Projectile>();

        // Fields to set up HUD
        private int time;
        private int levelNum;
        private int displayLevel;
        private int frames;

        // Managers to hold crates and enemies for levels
        private EnemyManager enemyManager;
        private CrateManager crateList;

        // Textures for crates
        private Texture2D textureSquareCrate;
        private Texture2D textureWideCrate;
        private Texture2D textureTallCrate;

        // Texture for hearts
        private Texture2D textureHeart;

        // Texture for background
        private Texture2D textureSpaceBackground;

        // Texture for enemy
        private Texture2D textureEnemySprite;

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
            gameState = GameState.mainMenu;

            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 900;

            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.ApplyChanges();

            //Reads the top five scores from a text file if possible
            //Fills the list with 0s if no text file exits
            try
            {
                using(StreamReader scoreReader = new StreamReader("../../../HighScores.txt"))
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

            astronautBounds = new Rectangle(_graphics.PreferredBackBufferWidth / 2 - 50, _graphics.PreferredBackBufferHeight / 2 - 50, 42, 60);
            astronaut = new Player(textureAstronautBody, astronautBounds);

            // Set up the enemy
            textureEnemySprite = Content.Load<Texture2D>("enemy sprite");

            // Set up the boxes
            textureSquareCrate = Content.Load<Texture2D>("square box");
            textureWideCrate = Content.Load<Texture2D>("wide box");
            textureTallCrate = Content.Load<Texture2D>("tall box");

            // Set up the heart
            textureHeart = Content.Load<Texture2D>("heart");

            // Set up space background
            textureSpaceBackground = Content.Load<Texture2D>("SpaceWalk background");

            // Default items for the enemy and crate managers
            enemyManager = new EnemyManager(1, textureEnemySprite, new Rectangle(200, 200, 100, 100));
            crateList = new CrateManager(0, textureSquareCrate, new Rectangle(0, 0, 50, 50));

            // Set up fonts
            Arial14 = Content.Load<SpriteFont>("Arial14");
            Arial32 = Content.Load<SpriteFont>("Arial32");

            // Initializes the buttons present on the start screen.

            startGameButton = new Button(new Vector2(_graphics.PreferredBackBufferWidth/2 - Arial14.MeasureString("Start Game").X/2,
                _graphics.PreferredBackBufferHeight/4 + 100), "Start Game", Arial14);

            highScoresButton = new Button(new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString("High Scores").X / 2,
                _graphics.PreferredBackBufferHeight / 4 + 150), "High Scores", Arial14);

            instructionsButton = new Button(new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString("Instructions").X / 2,
                _graphics.PreferredBackBufferHeight / 4 + 200), "Instructions", Arial14);

            closeGameButton = new Button(new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString("Close").X / 2,
                _graphics.PreferredBackBufferHeight / 4 + 250), "Close", Arial14);

            // Initializes the button used to get from high scores to title

            backToMainMenuButton = new Button(new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString("Back").X / 2,
                _graphics.PreferredBackBufferHeight / 4 + 100), "Back", Arial14);

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
            crateList = new CrateManager(5, textureSquareCrate, new Rectangle(0, 0, 50, 50));
            enemyManager = new EnemyManager(1, textureEnemySprite, new Rectangle(200, 200, 50, 50));
        }

        /// <summary>
        /// A method that sets the proper values for game elements when a game starts
        /// </summary>
        public void NewLevel()
        {
            levelNum++;
            displayLevel++;
            astronaut.LevelScore = 0;
            time = 30;
            projectileList.Clear();
            crateList.ClearCrates();
            crateList = new CrateManager(5, textureSquareCrate, new Rectangle(300, 300, 50, 50));
            enemyManager = new EnemyManager(1, textureEnemySprite, new Rectangle(200, 200, 50, 50));
            //Remember to change this in post
            astronaut.rect = astronautBounds;
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
                    if (SingleLeftClick() && startGameButton.Rect.Contains(ms.Position))
                    {
                        Reset();
                        NewLevel();
                        gameState = GameState.gameplay;

                        //TEMPORARY adding an enemy
                        
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
                    if (SingleLeftClick() && backToMainMenuButton.Rect.Contains(ms.Position))
                    {
                        gameState = GameState.mainMenu;
                    }
                    break;

                case GameState.instructions:
                    if (SingleLeftClick() && backToMainMenuButton.Rect.Contains(ms.Position))
                    {
                        gameState = GameState.mainMenu;
                    }
                    break;

                case GameState.gameplay:

                    astronaut.Update(gameTime);
                    astronaut.HandleScreenCollisions(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

                    enemyManager.Update(gameTime, astronaut, projectileList, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
                    crateList.Update(gameTime, astronaut);

                    foreach(Projectile p in projectileList)
                    {
                        p.Update(gameTime);
                    }

                    if (SinglePress(Keys.Escape))
                    {
                        gameState = GameState.pauseScreen;
                    }

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
                            string path = new string("../../../HighScores.txt");
                            
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
                    if (SingleLeftClick())
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

                    }

                    // Works the timer
                    frames++;
                    if (frames % 60 == 0)
                    {
                        time--;
                    }

                    // Moves to the next level if time runs out
                    if(time == 0)
                    {
                        if(levelNum != 4)
                        {
                            NewLevel();
                        } else
                        {
                            levelNum = 0;
                            NewLevel();
                        }
                    }

                    break;

                case GameState.pauseScreen:
                    if (SingleLeftClick() && resumeGameButton.Rect.Contains(ms.Position))
                    {
                        gameState = GameState.gameplay;
                    }
                    else if (SingleLeftClick() && quitGameButton.Rect.Contains(ms.Position))
                    {
                        gameState = GameState.mainMenu;
                    }
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

                    // Measures the size of the string
                    Vector2 titleSize = Arial32.MeasureString("SPACEWALK");

                    // Draws the title
                    _spriteBatch.DrawString(Arial32, "SPACEWALK",
                        new Vector2(_graphics.PreferredBackBufferWidth / 2 - titleSize.X / 2, // Puts it in the middle of the screen
                        _graphics.PreferredBackBufferHeight / 4),
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
                    string stringFour = "Run into crates to build up a high score.";
                    string stringFive = "Each level has a set time, so act fast!";
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

                    //Make sure the player can get back to the Title Screen
                    backToMainMenuButton.Draw(_spriteBatch, Color.White);

                    break;

                case GameState.gameplay:

                    DrawGameplay(false);
                    break;

                case GameState.pauseScreen:

                    DrawGameplay(true);

                    // Draw resume and quit buttons
                    resumeGameButton.Draw(_spriteBatch, Color.White);
                    quitGameButton.Draw(_spriteBatch, Color.White);

                    break;

                case GameState.gameOver:

                    highScoresButton.Draw(_spriteBatch, Color.White);

                    break;
            }

            // Draw the state
            _spriteBatch.DrawString(Arial14, "State: " + gameState.ToString(), new Vector2(30, 30), Color.White);
            _spriteBatch.DrawString(Arial14, $"Screen size: {_graphics.PreferredBackBufferWidth}, {_graphics.PreferredBackBufferHeight}", new Vector2(30,10), Color.White);
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
            if (isPaused)
            {
                colorToDrawSprites = Color.DarkGray;
            }

            // Draw space background
            _spriteBatch.Draw(textureSpaceBackground,
                new Rectangle(0, 0, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight),
                colorToDrawSprites);

            //Makes sprites flash red when astronaut is damaged
            if (enemyManager.DetectPlayerIntersection(astronaut))
            {
                colorToDrawSprites = Color.Red;
            }

            // Draw the placeholder astronaut & placeholder enemy
            astronaut.Draw(_spriteBatch, colorToDrawSprites);

            // Draw the crates
            crateList.Draw(_spriteBatch, colorToDrawSprites);

            //Draw Enemies
            enemyManager.Draw(_spriteBatch, colorToDrawSprites);


            // Draw Projectiles
            foreach (Projectile p in projectileList)
            {
                p.Draw(_spriteBatch, Color.White);
            }

            // Draw debug stuff:

            // Center of astronaut
            _spriteBatch.DrawString(Arial14, $"Center of astronaut: {astronaut.CenterX}, {astronaut.CenterY}",
                new Vector2(30, 50),
                Color.White);

            // Mouse position
            _spriteBatch.DrawString(Arial14, $"Mouse pos: {ms.X}, {ms.Y}",
                new Vector2(30, 70),
                Color.White);

            // Time, lives, level, and level score
            _spriteBatch.DrawString(Arial14, $"Time: {time}", new Vector2(30, 90), Color.White);
            _spriteBatch.DrawString(Arial14, $"Lives: {astronaut.Lives}", new Vector2(30, 110), Color.White);
            _spriteBatch.DrawString(Arial14, $"Level: {displayLevel}", new Vector2(30, 130), Color.White);
            _spriteBatch.DrawString(Arial14, $"Score: {astronaut.LevelScore}", new Vector2(30, 150), Color.White);
        }
    }
}