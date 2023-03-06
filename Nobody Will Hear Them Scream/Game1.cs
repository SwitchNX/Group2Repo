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
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private KeyboardState kb;
        private KeyboardState prevKB;
        private MouseState ms;
        private MouseState prevMS;

        private SpriteFont Arial14;
        private SpriteFont Arial32;

        private GameState gameState;

        private Button startGameButton;
        private Button highScoresButton;
        private Button backToMainMenuButton;
        private Button closeGameButton;
        private Button resumeGameButton;
        private Button quitGameButton;

        private Texture2D placeHolderSquare;
        private Rectangle astronautBounds;
        private Player astronaut;

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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //Set up the placeholder astronaut
            placeHolderSquare = Content.Load<Texture2D>("square");
            astronautBounds = new Rectangle(0, 0, 100, 100);
            astronaut = new Player(placeHolderSquare, astronautBounds, _graphics);

            Arial14 = Content.Load<SpriteFont>("Arial14");
            Arial32 = Content.Load<SpriteFont>("Arial32");

            startGameButton = new Button(new Vector2(_graphics.PreferredBackBufferWidth/2 - Arial14.MeasureString("Start Game").X/2,
                _graphics.PreferredBackBufferHeight/4 + 100), "Start Game", Arial14);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here
            kb = Keyboard.GetState();
            ms = Mouse.GetState();

            switch (gameState)
            {
                case GameState.mainMenu:
                    if (startGameButton.IsClicked(ms))
                    {
                        gameState = GameState.gameplay;
                    }
                    else if (highScoresButton.IsClicked(ms))
                    {
                        gameState = GameState.highScores;
                    }
                    else if (closeGameButton.IsClicked(ms))
                    {
                        //Closes the application
                        Exit();
                    }

                    break;

                case GameState.highScores:
                    if (backToMainMenuButton.IsClicked(ms))
                    {
                        gameState = GameState.mainMenu;
                    }
                    break;

                case GameState.instructions:
                    break;

                case GameState.gameplay:
                    if (kb.IsKeyDown(Keys.Escape))
                    {
                        gameState = GameState.pauseScreen;
                    }


                    if (astronaut.Lives == 0)
                    {
                        gameState = GameState.gameOver;
                    }

                    break;

                case GameState.pauseScreen:
                    if (resumeGameButton.IsClicked(ms))
                    {
                        gameState = GameState.gameplay;
                    }
                    else if (quitGameButton.IsClicked(ms))
                    {
                        gameState = GameState.mainMenu;
                    }
                    break;

                case GameState.gameOver:
                    if (kb.IsKeyDown(Keys.Escape) || backToMainMenuButton.IsClicked(ms))
                    {
                        gameState = GameState.mainMenu;
                    }
                    else if (highScoresButton.IsClicked(ms))
                    {
                        gameState = GameState.highScores;
                    }
                    break;
            }

            prevKB = kb;
            prevMS = ms;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            Vector2 stateTextPosition = new Vector2(30, 30);

            _spriteBatch.Begin();

            switch (gameState)
            {
                case GameState.mainMenu:
                    Vector2 titleSize = Arial32.MeasureString("SPACEWALK");
                    _spriteBatch.DrawString(Arial32, "SPACEWALK", new Vector2(_graphics.PreferredBackBufferWidth / 2 - titleSize.X / 2,
                        _graphics.PreferredBackBufferHeight / 4), Color.White);

                    startGameButton.Draw(_spriteBatch, Color.White);
                    break;

                case GameState.highScores:
                    break;

                case GameState.instructions:
                    break;

                case GameState.gameplay:

                    //Draw the placeholder astronaut
                    _spriteBatch.Draw(astronaut.ObjectTexture, astronaut.rect, Color.White);
                    break;

                case GameState.pauseScreen:
                    break;

                case GameState.gameOver:
                    break;
            }

            _spriteBatch.DrawString(Arial14, "State: " + gameState.ToString(), stateTextPosition, Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}