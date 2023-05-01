using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// Kai & [names here]
// Class for projectile objects

namespace Nobody_Will_Hear_Them_Scream
{
    /// <summary>
    /// Projectiles fired from the player's weapon
    /// </summary>
    internal class Projectile : GameObject
    {
        // Fields

        private Vector2 velocity;

        private static Point projectileSize = new Point(20, 20);

        public static Point ProjectileSize
        {
            get { return projectileSize; }
        }


        // Constructor

        /// <summary>
        /// Creates a new projectile object
        /// </summary>
        /// <param name="objectTexture"></param>
        /// <param name="objectBounds"></param>
        /// <param name="velocity"></param>
        public Projectile(Texture2D objectTexture, Rectangle objectBounds, Vector2 velocity) : base(objectTexture, objectBounds)
        {
            this.velocity = velocity;
        }


        // Methods

        /// <summary>
        /// Update the projectlie
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Add the new speeds
            X += (int)velocity.X;
            Y += (int)velocity.Y;
        }
    }
}
