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
    /// Aliens that chase the player
    /// </summary>
    internal class Enemy : GameObject
    {
        //Temporarily public
        private Vector2 velocity;
        private Vector2 acceleration;
        private Vector2 playerDirFromEnemy;

        private Vector2 playerPosition;

        //Constructor
        public Enemy(Texture2D objectTexture, Rectangle objectBounds) : base(objectTexture, objectBounds) 
        {
            velocity = new Vector2();
            acceleration = new Vector2();
        }

        public void GetPlayerPosition(Rectangle playerRectangle)
        {
            this.playerPosition = new Vector2(playerRectangle.X + playerRectangle.Width / 2, playerRectangle.Y + playerRectangle.Height / 2);
        }

        public void Update(GameTime gameTime)
        {
            X += (int)velocity.X;
            Y += (int)velocity.Y;

            velocity += acceleration;

            //Vector2 playerDirFromEnemy = Vector2.Normalize(new Vector2(playerPosition.X - CenterX, playerPosition.Y - CenterY));
            playerDirFromEnemy = Vector2.Normalize(new Vector2(playerPosition.X - X, playerPosition.Y - Y));

            acceleration = 0.15f * playerDirFromEnemy;
        }
    }
}
