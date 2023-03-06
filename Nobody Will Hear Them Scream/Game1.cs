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

        private GameState gameState;

        private Button startGameButton;
        private Button highScoresButton;
        private Button backToMainMenuButton;
        private Button closeGameButton;
        private Button resumeGameButton;
        private Button quitGameButton;

        private Texture2D placeHolderSquare;
        private Rectangle astronautBounds;

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

            placeHolderSquare = Content.Load<Texture2D>("square");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

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
            }

            prevKB = kb;
            prevMS = ms;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            switch (gameState)
            {
                case GameState.mainMenu:
                    break;

                case GameState.highScores:
                    break;

                case GameState.instructions:
                    break;

                case GameState.gameplay:
                    break;

                case GameState.pauseScreen:
                    break;
            }

            base.Draw(gameTime);
        }
    }
}