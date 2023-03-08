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
        Vector2 velocity;
        Vector2 acceleration;

        Vector2 playerPosition;

        //Constructor
        public Enemy(Texture2D objectTexture, Rectangle objectBounds) : base(objectTexture, objectBounds) 
        {
            velocity = new Vector2();
            acceleration = new Vector2();
        }

        public void GetPlayerPosition(Vector2 playerPosition)
        {
            this.playerPosition = playerPosition;
        }

        public void Update(GameTime gameTime, Vector2 playerPosition)
        {
            X += (int)velocity.X;
            Y += (int)velocity.Y;
            velocity += acceleration;

            Vector2 playerDirFromEnemy = Vector2.Normalize(new Vector2(playerPosition.X - CenterX, playerPosition.Y - CenterY));
            acceleration = 3 * playerDirFromEnemy;
        }
    }
}
