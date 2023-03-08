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
        private Vector2 playerMoving;
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

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            
            // Add the new speeds
            X += (int)playerMoving.X;
            Y += (int)playerMoving.Y;

            // Dampen them. Change the number to change how fast the player slows down.
            playerMoving.X /= dampenAmount;
            playerMoving.Y /= dampenAmount;
        }

        /// <summary>
        /// Move the player according to the mouse direction from the player
        /// </summary>
        /// <param name="ms">The current mouse state</param>
        public void MovePlayer(MouseState ms)
        {
            // Get mouse position from the player and normalize it
            mouseDirFromPlayer = Vector2.Normalize(new Vector2(ms.X - CenterX, ms.Y - CenterY));

            playerMoving.X -= (int)(boostAmount * mouseDirFromPlayer.X);
            playerMoving.Y -= (int)(boostAmount * mouseDirFromPlayer.Y);
        }
    }
}
