﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// Anthony Curtis, Ryan Fogarty, & Hudson Ward

namespace Nobody_Will_Hear_Them_Scream
{
    /// <summary>
    /// Enum for types of enemies
    /// </summary>
    public enum EnemyType
    {
        basic, large, fast
    }

    /// <summary>
    /// Aliens that chase the player
    /// </summary>
    internal class Enemy : GameObject
    {
        // Fields

        private EnemyType enemyType;
        private int health;
        private Vector2 velocity;
        private Vector2 acceleration;
        private Vector2 playerPosition;
        private Vector2 playerDirFromEnemy;
        private float velocityDampener;
        private bool newIntersection;


        // Properties

        /// <summary>
        /// Get or set the velocity
        /// </summary>
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        /// <summary>
        /// Get the new intersection
        /// </summary>
        public bool NewIntersection
        {
            get { return newIntersection; }
        }

        /// <summary>
        /// Get or set the enemy health
        /// </summary>
        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        /// <summary>
        /// Get the velocity dampener
        /// </summary>
        public float VelocityDampener
        {
            get { return velocityDampener; }
        }


        // Constructor

        /// <summary>
        /// Create a new enemy object
        /// </summary>
        /// <param name="enemyType">The type of enemy</param>
        /// <param name="objectTexture">The texture of the enemy</param>
        /// <param name="objectBounds">The rectangle bounds of the enemy</param>
        public Enemy(EnemyType enemyType, Texture2D objectTexture, Rectangle objectBounds) : base(objectTexture, objectBounds) 
        {
            // Initialize the velocity, acceleration, velocity dampener, and new intersection
            velocity = new Vector2();
            acceleration = new Vector2();
            velocityDampener = .979f;
            newIntersection = true;

            // Change the dampener depending on the type of the enemy
            switch (enemyType)
            {
                case EnemyType.basic:
                    this.velocityDampener = .97f;
                    health = 1;
                    break;
                case EnemyType.large:
                    this.velocityDampener = .95f;
                    health = 2;
                    break;
                case EnemyType.fast:
                    this.velocityDampener = .985f;
                    health = 1;
                    break;
            }
        }


        // Methods

        /// <summary>
        /// Get the player rectangle
        /// </summary>
        /// <param name="playerRectangle">The player rectangle</param>
        public void GetPlayerPosition(Rectangle playerRectangle)
        {
            this.playerPosition = new Vector2(playerRectangle.X + playerRectangle.Width / 2, playerRectangle.Y + playerRectangle.Height / 2);
        }

        /// <summary>
        /// Update the enemy
        /// </summary>
        /// <param name="gameTime">The current game time</param>
        public override void Update(GameTime gameTime)
        {
            // Update the coordinates
            X += (int)velocity.X;
            Y += (int)velocity.Y;

            velocity *= velocityDampener;
            velocity += acceleration;

            // Get the player direction from the enemy
            playerDirFromEnemy = Vector2.Normalize(new Vector2(playerPosition.X - X, playerPosition.Y - Y));

            // Change acceleration so the enemy goes toward the player
            acceleration = 0.35f * playerDirFromEnemy;

            // If the enemy is a fast enemy, move faster
            if (this.enemyType == EnemyType.fast)
            {
                acceleration *= 1.1f;
            }
        }


        public void HandleScreenCollisions(int screenWidth, int screenHeight)
        {
            //Handles collisions with the boundaries of the screen
            if (X < 0)
            {
                X = 0;
                velocity.X *= -1;
            }
            else if (X + Width > screenWidth)
            {
                X = screenWidth - Width;
                velocity.X *= -1;
            }

            if (Y < 0)
            {
                Y = 0;
                velocity.Y *= -1;
            }
            else if (Y + Height > screenHeight)
            {
                Y = screenHeight - Height;
                velocity.Y *= -1;
            }
        }

        //Handles collisions with the player
        public void EnemyIntersection(Player astronaut)
        {
            if (astronaut.rect.Intersects(rect))
            {
                if(newIntersection == true)
                {
                    astronaut.Lives--;
                    newIntersection = false;

                    // Physics for collisions
                    Vector2 vnew = astronaut.PlayerVelocity + this.velocity;
                    if (vnew.X < 0)
                    {
                        vnew.X *= 1;
                    }
                    if (vnew.Y < 0)
                    {
                        vnew.Y *= 1;
                    }

                    astronaut.PlayerVelocity *= 1;
                    this.velocity *= 1;

                }
            } else
            {
                newIntersection = true;
            }
        }
        
		/// <summary>
        /// Makes enemies bounce off each other when they hit each other
        /// </summary>
        /// <param name="enemyList">the list of enemies</param>
        public void HandleEnemyCollisions(List<Enemy> enemyList)
        {
            foreach (Enemy e in enemyList)
            {
                //Handles collisions with other enemies
                if (rect.Intersects(e.rect) && e.rect != rect)
                {
                    velocity *= -1.2f;
                }
            }
        }

        public void DrawScore(SpriteBatch sb, SpriteFont font, EnemyManager e)
        {
            int typeScore = 0;
            switch (VelocityDampener)
            {
                case .97f:
                    typeScore = 2;
                    break;
                case .985f:
                    typeScore = 3;
                    break;
                case .95f:
                    typeScore = 4;
                    break;
            }
            //Prints score aquired by small enemy
            if (e.SmallPrint)
            {
                sb.DrawString(font, $"+{typeScore}pts",
                        new Vector2(X,
                        Y),
                        Color.Green);
            }
            

        }
    }
}

