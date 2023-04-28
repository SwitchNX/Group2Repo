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
        private int levelScore;
        private int gameScore;
        private Vector2 mouseDirFromPlayer;
        private Vector2 playerVelocity;
        private float dampenAmount;
        private float boostAmount;
        private Texture2D body;
        private Texture2D arm;
        private float armAngle;
        private SpriteEffects effectArm;
        private SpriteEffects effectBody;
        private Vector2 armPosition;


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
        /// Gets or sets the score on the current level
        /// </summary>
        public int LevelScore { get { return levelScore; } set { levelScore = value; } }

        /// <summary>
        /// Gets or sets the total score
        /// </summary>
        public int GameScore { get { return gameScore; } set { gameScore = value; } }

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
            set { playerVelocity = value; }
        }

        /// <summary>
        /// Gets or sets the arm's position
        /// </summary>
        public Vector2 ArmPosition
        {
            get { return armPosition; }
            set { armPosition = value; }
        }

        // Constructor

        /// <summary>
        /// Creates a new Player object
        /// </summary>
        /// <param name="objectTexture">The texture of the player</param>
        /// <param name="objectBounds">The rectangle of the player</param>
        public Player (Texture2D objectTexture1, Texture2D objectTexture2, Rectangle objectBounds) :
            base (objectTexture1, objectBounds)
        {
            this.lives = 3;

            body = objectTexture1;
            arm = objectTexture2;

            // For default weapon
            dampenAmount = 1.03f;
            boostAmount = 15f;
        }


        // Methods

        /// <summary>
        /// Update the player
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime, MouseState direction)
        {
            // Get mouse position from the player and normalize it
            mouseDirFromPlayer = Vector2.Normalize(new Vector2(direction.X - CenterX, direction.Y - CenterY));

            // update the angle of the arm based on the mouse position
            if (mouseDirFromPlayer.Y > 0)
            {
                armAngle = (float)Math.Acos(mouseDirFromPlayer.X);
            }
            else
            {
                armAngle = -(float)Math.Acos(mouseDirFromPlayer.X);
            }

            // flip player
            if (mouseDirFromPlayer.X > 0)
            {
                armPosition.X = X + 15;
                armPosition.Y = Y + 37;
                effectArm = SpriteEffects.FlipVertically;
                effectBody = SpriteEffects.FlipHorizontally;
            }
            else
            {
                armPosition.X = X + 30;
                armPosition.Y = Y + 37;
                effectArm = SpriteEffects.None;
                effectBody = SpriteEffects.None;
            }

            // Add the new speeds
            X += (int)playerVelocity.X;
            Y += (int)playerVelocity.Y;

            // Dampen the player's velocity
            playerVelocity.X /= dampenAmount;
            playerVelocity.Y /= dampenAmount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="c"></param>
        public void Draw(SpriteBatch sb, Color c, Rectangle playerbounds)
        {
            //base.Draw(sb, c);

            sb.Draw(body, new Vector2(X, Y), null, c, 0f, new Vector2(0, 0), 0.16f, effectBody, 0f);

            sb.Draw(arm, armPosition, null, c, armAngle, new Vector2(0, arm.Height / 2), 0.25f, effectArm, 0f);
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
