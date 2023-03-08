﻿using System;
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
        //Fields to set up player interaction
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private KeyboardState kb;
        private KeyboardState prevKB;
        private MouseState ms;
        private MouseState prevMS;

        //Fields to set up text fonts
        private SpriteFont Arial14;
        private SpriteFont Arial32;

        //Fields to set up FSM and buttons
        private GameState gameState;

        private Button startGameButton;
        private Button highScoresButton;
        private Button backToMainMenuButton;
        private Button closeGameButton;
        private Button resumeGameButton;
        private Button quitGameButton;

        //Fields to set up astronaut character
        private Texture2D placeHolderSquare;
        private Rectangle astronautBounds;
        private Player astronaut;

        //Fields to set up HUD
        private int gameScore;
        private int levelScore;
        private int time;
        private int enemyNum;
        private int crateNum;
        private int levelNum;

        //Lists to hold crates and enemies for levels
        private List<Enemy> enemyList = new List<Enemy>();
        private List<Crate> crateList = new List<Crate>();

        private Texture2D placeHolderPurpleSquare;
        private Enemy enemy;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            gameState = GameState.mainMenu;

            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 1600;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //Set up the placeholder astronaut
            placeHolderSquare = Content.Load<Texture2D>("square");
            placeHolderPurpleSquare = Content.Load<Texture2D>("purple-square");
            astronautBounds = new Rectangle(_graphics.PreferredBackBufferWidth / 2 - 50, _graphics.PreferredBackBufferHeight / 2 - 50, 100, 100);
            astronaut = new Player(placeHolderSquare, astronautBounds);

            enemy = new Enemy(placeHolderPurpleSquare, new Rectangle(250, 100, 40, 40));

            Arial14 = Content.Load<SpriteFont>("Arial14");
            Arial32 = Content.Load<SpriteFont>("Arial32");

            //Initializes the buttons present on the start screen.

            startGameButton = new Button(new Vector2(_graphics.PreferredBackBufferWidth/2 - Arial14.MeasureString("Start Game").X/2,
                _graphics.PreferredBackBufferHeight/4 + 100), "Start Game", Arial14);

            highScoresButton = new Button(new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString("High Scores").X / 2,
                _graphics.PreferredBackBufferHeight / 4 + 150), "High Scores", Arial14);

            closeGameButton = new Button(new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString("Close").X / 2,
                _graphics.PreferredBackBufferHeight / 4 + 200), "Close", Arial14);

            //Initializes the button used to get from high scores to title

            backToMainMenuButton = new Button(new Vector2(_graphics.PreferredBackBufferWidth / 2 - Arial14.MeasureString("Back").X / 2,
                _graphics.PreferredBackBufferHeight / 4 * 3), "Back", Arial14);

            // TODO: use this.Content to load your game content here
        }

        //A method that resets game values at the start of a new game
        public void Reset()
        {
            levelNum = 0;
        }

        //A method that sets the proper values for game elements when a game starts
        public void NewLevel()
        {
            levelNum++;
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

                    enemy.GetPlayerPosition(astronaut.rect);
                    enemy.Update(gameTime);

                    if (SinglePress(Keys.Escape))
                    {
                        gameState = GameState.pauseScreen;
                    }


                    if (astronaut.Lives == 0)
                    {
                        gameState = GameState.gameOver;
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
                    //Add the back button to return to the start screen

                    backToMainMenuButton.Draw(_spriteBatch, Color.White);

                    break;

                case GameState.instructions:
                    break;

                case GameState.gameplay:

                    //Draw the placeholder astronaut & placeholder enemy
                    astronaut.Draw(_spriteBatch);
                    enemy.Draw(_spriteBatch);

                    // Draw debug stuff:

                    // Alien direction from enemy
                    _spriteBatch.DrawString(Arial14, $"Player Direction from enemy: {enemy.playerDirFromEnemy.X}, {enemy.playerDirFromEnemy.Y}",
                        new Vector2(30, 50),
                        Color.White);

                    // Player position
                    _spriteBatch.DrawString(Arial14, $"Alien's player position: {enemy.playerPosition.X}, {enemy.playerPosition.Y}",
                        new Vector2(30, 70),
                        Color.White);

                    // Alien velocity
                    _spriteBatch.DrawString(Arial14, $"Alien velocity: {enemy.velocity.X}, {enemy.velocity.Y}",
                        new Vector2(30, 900),
                        Color.White);

                    // Alien acceleration
                    _spriteBatch.DrawString(Arial14, $"Alien acceleration: {enemy.acceleration.X}, {enemy.acceleration.Y}",
                        new Vector2(30, 110),
                        Color.White);


                    break;

                case GameState.pauseScreen:
                    break;

                case GameState.gameOver:
                    break;
            }

            // Draw the state
            _spriteBatch.DrawString(Arial14, "State: " + gameState.ToString(), new Vector2(30, 30), Color.White);
            _spriteBatch.DrawString(Arial14, $"Screen size: {_graphics.PreferredBackBufferWidth}, {_graphics.PreferredBackBufferHeight}", new Vector2(30,10), Color.White);
            // End the sprite batch
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}