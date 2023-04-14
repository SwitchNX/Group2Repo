using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Nobody_Will_Hear_Them_Scream
{
    /// <summary>
    /// player-controlled lil guy
    /// </summary>
    internal class Player : GameObject
    {
        // Fields

        private int lives;
        private Vector2 mouseDirFromPlayer;
        private Vector2 playerVelocity;
        private float dampenAmount;
        private float boostAmount;


        // Properties

        /// <summary>
        /// Gets or sets the amount of lives
        /// </summary>
        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }

        /// <summary>
        /// Gets or sets the amount to dampen
        /// </summary>
        public float DampenAmount
        {
            get { return dampenAmount; }
            set { dampenAmount = value; }
        }

        /// <summary>
        /// Gets or sets the amount to boost
        /// </summary>
        public float BoostAmount
        {
            get { return boostAmount; }
            set { boostAmount = value; }
        }

        /// <summary>
        /// Gets the player's current velocity
        /// </summary>
        public Vector2 PlayerVelocity
        {
            get { return playerVelocity; }
        }


        // Constructor

        /// <summary>
        /// Creates a new Player object
        /// </summary>
        /// <param name="objectTexture">The texture of the player</param>
        /// <param name="objectBounds">The rectangle of the player</param>
        public Player (Texture2D objectTexture, Rectangle objectBounds) :
            base (objectTexture, objectBounds)
        {
            this.lives = 3;

            // For default weapon
            dampenAmount = 1.05f;
            boostAmount = 15f;
        }


        // Methods

        /// <summary>
        /// Update the player
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
            // Add the new speeds
            X += (int)playerVelocity.X;
            Y += (int)playerVelocity.Y;

            // Dampen the player's velocity
            playerVelocity.X /= dampenAmount;
            playerVelocity.Y /= dampenAmount;
        }

        /// <summary>
        /// Move the player according to the mouse direction from the player
        /// </summary>
        /// <param name="ms">The current mouse state</param>
        public void MovePlayer(MouseState ms)
        {
            // Get mouse position from the player and normalize it
            mouseDirFromPlayer = Vector2.Normalize(new Vector2(ms.X - CenterX, ms.Y - CenterY));

            // Increase the players velocity
            playerVelocity.X -= (int)(boostAmount * mouseDirFromPlayer.X);
            playerVelocity.Y -= (int)(boostAmount * mouseDirFromPlayer.Y);
        }

        public void HandleScreenCollisions(int screenWidth, int screenHeight)
        {
            //Handles collisions with the boundaries of the screen
            if (X < 0)
            {
                X = 0;
                playerVelocity.X *= -1;
            }
            else if (X + Width > screenWidth)
            {
                X = screenWidth - Width;
                playerVelocity.X *= -1;
            }

            if (Y < 0)
            {
                Y = 0;
                playerVelocity.Y *= -1;
            }
            else if (Y + Height > screenHeight)
            {
                Y = screenHeight - Height;
                playerVelocity.Y *= -1;
            }
        }


        /// <summary>
        /// Gets the point on the astronaut where the projectile will spawn
        /// </summary>
        /// <returns></returns>
        public Point GetProjectileSpawnPoint()
        {
            Point spawnpoint = new Point();

            spawnpoint.X = CenterX;
            spawnpoint.Y = CenterY;

            return spawnpoint;
        }
    }
}
