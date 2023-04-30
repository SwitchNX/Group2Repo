using System;
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

        /// <summary>
        /// Handles collisions with the screen borders
        /// </summary>
        /// <param name="screenWidth">The width of the screen</param>
        /// <param name="screenHeight">The height of the screen</param>
        public void HandleScreenCollisions(int screenWidth, int screenHeight)
        {
            // Handles collisions with the boundaries of the screen

            
            if (X < 0) // Left edge
            {
                X = 0;
                velocity.X *= -1;
            }
            else if (X + Width > screenWidth) // Right edge
            {
                X = screenWidth - Width;
                velocity.X *= -1;
            }

            if (Y < 0) // Top edge
            {
                Y = 0;
                velocity.Y *= -1;
            }
            else if (Y + Height > screenHeight) // Bottom edge
            {
                Y = screenHeight - Height;
                velocity.Y *= -1;
            }
        }

        /// <summary>
        /// Handles collisions with the player
        /// </summary>
        /// <param name="astronaut">The player</param>
        public void EnemyIntersection(Player astronaut)
        {
            // If the enemy and the player are intersecting
            if (astronaut.rect.Intersects(rect))
            {
                // Makes sure not to double ding a collision
                if(newIntersection == true)
                {
                    // Lower the player's health
                    astronaut.Lives--;
                    newIntersection = false;

                    // Draws the player red for 10 frames
                    astronaut.FramesLeftToDrawRed = 10;

                    // Avergages the players and enemys velocities
                    Vector2 avgV = new Vector2();
                    avgV.X = (Math.Abs(astronaut.PlayerVelocity.X) + Math.Abs(this.velocity.X)) / 2;
                    avgV.Y = (Math.Abs(astronaut.PlayerVelocity.Y) + Math.Abs(this.velocity.Y)) / 2;

                    astronaut.PlayerVelocity = avgV;
                    this.velocity = avgV;

                    // Changes the direction of the players or enemys velocity depending on their relative position 
                    if (astronaut.X < this.X)
                    {
                        astronaut.PlayerVelocity = new Vector2(-astronaut.PlayerVelocity.X, astronaut.PlayerVelocity.Y);
                    }
                    else
                    {
                        this.velocity = new Vector2(-velocity.X, velocity.Y);
                    }

                    if (astronaut.Y < this.Y)
                    {
                        astronaut.PlayerVelocity = new Vector2(astronaut.PlayerVelocity.X, -astronaut.PlayerVelocity.Y);
                    }
                    else
                    {
                        this.velocity = new Vector2(velocity.X, -velocity.Y);
                    }

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

        /// <summary>
        /// Draws the pop up score for killing an enemy
        /// </summary>
        /// <param name="sb">The sprite batch</param>
        /// <param name="font">The sprite font</param>
        /// <param name="e">The enemy manager</param>
        public void DrawScore(SpriteBatch sb, SpriteFont font, EnemyManager e)
        {
            int typeScore = 0;
            switch (VelocityDampener) // Determines which enemy is which using their respective velocity dampeners
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

