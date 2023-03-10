using System;
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

        // Fields to set up astronaut character
        private Texture2D placeHolderSquare;
        private Rectangle astronautBounds;
        private Player astronaut;

        // Fields to set up HUD
        private int gameScore;
        private int levelScore;
        private int time;
        private int enemyNum;
        private int crateNum;
        private int levelNum;
        private int displayLevel;
        private int frames;

        // Lists to hold crates and enemies for levels
        private List<Enemy> enemyList = new List<Enemy>();
        private List<Crate> crateList = new List<Crate>();

        private Texture2D placeHolderPurpleSquare;
        private Enemy enemy;

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

            //_graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            //_graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Set up the placeholder astronaut
            placeHolderSquare = Content.Load<Texture2D>("square");
            placeHolderPurpleSquare = Content.Load<Texture2D>("purple-square");
            astronautBounds = new Rectangle(_graphics.PreferredBackBufferWidth / 2 - 50, _graphics.PreferredBackBufferHeight / 2 - 50, 100, 100);
            astronaut = new Player(placeHolderSquare, astronautBounds);

            enemy = new Enemy(placeHolderPurpleSquare, new Rectangle(200, 200, 40, 40));

            Arial14 = Content.Load<SpriteFont>("Arial14");
            Arial32 = Content.Load<SpriteFont>("Arial32");

            // Initializes the buttons present on the start screen.

            startGameButton = new Button(new Vector2(_graphics.PreferredBackBufferWidth/2 - Arial14.MeasureString("Start Game").X/2,
                _graphics.PreferredBackBufferHeight/4 + 100), "Start Game", Arial14);

            highScoresButton = new Button(new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString("High Scores").X / 2,
                _graphics.PreferredBackBufferHeight / 4 + 150), "High Scores", Arial14);

            closeGameButton = new Button(new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString("Close").X / 2,
                _graphics.PreferredBackBufferHeight / 4 + 200), "Close", Arial14);

            // Initializes the button used to get from high scores to title

            backToMainMenuButton = new Button(new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString("Back").X / 2,
                _graphics.PreferredBackBufferHeight / 4 + 100), "Back", Arial14);

            //Initializes buttons to resume or quit game from the pause screen

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
            levelNum = 0;
            astronaut.Lives = 3;
            gameScore = 0;
            levelScore = 0;
        }

        /// <summary>
        /// A method that sets the proper values for game elements when a game starts
        /// </summary>
        public void NewLevel()
        {
            levelNum++;
            displayLevel++;
            levelScore = 0;
            time = 60;
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

                    break;

                case GameState.highScores:
                    if (SingleLeftClick() && backToMainMenuButton.Rect.Contains(ms.Position))
                    {
                        gameState = GameState.mainMenu;
                    }
                    break;

                case GameState.instructions:
                    break;

                case GameState.gameplay:

                    astronaut.Update(gameTime);
                    astronaut.HandleScreenCollisions(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

                    enemy.GetPlayerPosition(astronaut.rect);
                    enemy.Update(gameTime);
                    enemy.HandleScreenCollisions(_graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);

                    if (SinglePress(Keys.Escape))
                    {
                        gameState = GameState.pauseScreen;
                    }

                    if (astronaut.Lives == 0)
                    {
                        gameState = GameState.gameOver;
                    }

                    // If there was a left click on this frame, move the player
                    if (SingleLeftClick())
                    {
                        // Move the player
                        astronaut.MovePlayer(ms);

                        // Create a projectile here
                        // Use astronaut.PlayerVelocity for the projectiles velocity
                    }

                    // Handles enemy collision with player
                    // Enemies should be stored in a list
                    enemy.EnemyIntersection(astronaut);

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
                    if (SinglePress(Keys.Escape) || (SingleLeftClick() && backToMainMenuButton.Rect.Contains(ms.Position)) )
                    {
                        gameState = GameState.mainMenu;
                    }
                    else if (SingleLeftClick() && highScoresButton.Rect.Contains(ms.Position))
                    {
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
            // Draw black background
            GraphicsDevice.Clear(Color.Black);

            // Start the sprite batch
            _spriteBatch.Begin();

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

                    closeGameButton.Draw(_spriteBatch, Color.White);
                    break;

                case GameState.highScores:
                    // Add the back button to return to the start screen

                    backToMainMenuButton.Draw(_spriteBatch, Color.White);

                    break;

                case GameState.instructions:
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

            // Draw the placeholder astronaut & placeholder enemy
            astronaut.Draw(_spriteBatch, colorToDrawSprites);
            enemy.Draw(_spriteBatch, colorToDrawSprites);

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
            _spriteBatch.DrawString(Arial14, $"Score: {levelScore}", new Vector2(30, 150), Color.White);
        }
    }
}