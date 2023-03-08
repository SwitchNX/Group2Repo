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
    internal class Player : Actor
    {
        //Fields
        private GraphicsDeviceManager _graphics;
        private int lives;
        private MouseState ms;
        public Vector2 mouseDirFromPlayer; // TEMPORARILY PUBLIC FOR DEBUGGING
        private Vector2 playerMoving;

        //Properties
        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }

        // Constructor
        public Player (Texture2D objectTexture, Rectangle objectBounds, Vector2 actorVelocity, GraphicsDeviceManager _graphics) :
            base (objectTexture, objectBounds, actorVelocity)
        {
            this._graphics = _graphics;
            this.lives = 3;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Get mouse state
            ms = Mouse.GetState();

            // Get mouse position from the player and normalize it
            mouseDirFromPlayer = Vector2.Normalize(new Vector2(ms.X - CenterX, ms.Y - CenterY));

            // If mouse is clicked, move player in opposite direction from mouse
            if (ms.LeftButton == ButtonState.Pressed)
            {
                playerMoving.X -= (int)(5 * mouseDirFromPlayer.X);
                playerMoving.Y -= (int)(5 * mouseDirFromPlayer.Y);
            }

            // Add the new speeds
            X += (int)playerMoving.X;
            Y += (int)playerMoving.Y;

            // Dampen them. Change the number to change how fast the player slows down.
            playerMoving.X /= 1.2f;
            playerMoving.Y /= 1.2f;
        }
    }
}
