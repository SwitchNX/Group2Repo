using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Nobody_Will_Hear_Them_Scream
{

    public enum EnemyType
    {
        basic, large, fast
    }

    /// <summary>
    /// Aliens that chase the player
    /// </summary>
    internal class Enemy : GameObject
    {
        //Fields
        private EnemyType enemyType;
        private int health;

        private Vector2 velocity;
        private Vector2 acceleration;

        private Vector2 playerPosition;
        private Vector2 playerDirFromEnemy;

        private float velocityDampener;

        private static Rectangle screenBounds;

        private bool newIntersection;

        private bool isDamaged;

        //Properties
        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public bool NewIntersection
        {
            get { return newIntersection; }
        }

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

        public float VelocityDampener
        {
            get { return velocityDampener; }
        }

        //Constructor
        public Enemy(EnemyType enemyType, Texture2D objectTexture, Rectangle objectBounds) : base(objectTexture, objectBounds) 
        {
            velocity = new Vector2();
            acceleration = new Vector2();
            velocityDampener = .979f;
            newIntersection = true;

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

        public void GetPlayerPosition(Rectangle playerRectangle)
        {
            this.playerPosition = new Vector2(playerRectangle.X + playerRectangle.Width / 2, playerRectangle.Y + playerRectangle.Height / 2);
        }

        public void Update(GameTime gameTime)
        {
            X += (int)velocity.X;
            Y += (int)velocity.Y;

            velocity *= velocityDampener;
            velocity += acceleration;

            //Vector2 playerDirFromEnemy = Vector2.Normalize(new Vector2(playerPosition.X - CenterX, playerPosition.Y - CenterY));
            playerDirFromEnemy = Vector2.Normalize(new Vector2(playerPosition.X - X, playerPosition.Y - Y));

            acceleration = 0.35f * playerDirFromEnemy;

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

