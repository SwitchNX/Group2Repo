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
    /// Crates that the player can collide with to get points
    /// </summary>
    internal class Crate : GameObject
    {
        private bool active;
        private Rectangle playerPos;

        private Rectangle cratePos;
        private Texture2D crateTexutre;

        /// <summary>
        /// returns or changes the value of active
        /// </summary>
        public bool Active { get { return active; } set { active = value; } }

        /// <summary>
        /// Initializes the fields of the Crate class
        /// </summary>
        public Crate(Texture2D objectTexture, Rectangle objectBounds) : base(objectTexture, objectBounds) 
        {
            cratePos = new Rectangle(X, Y, Width, Height);
        }

        /// <summary>
        /// Determines if there is a collision between the
        /// GameObject and an active Crate
        /// </summary>
        /// <param name="check">the GameObject being checked</param>
        /// <returns> whether or not the provided GameObject parameter 
        /// is intersecting with this Crate</returns>
        public bool CheckCollision(GameObject check)
        {
            playerPos = new Rectangle(check.X, check.Y, check.Width, check.Height);

            if (active)
            {
                return cratePos.Intersects(playerPos);
            }

            return false;
        }

        /// <summary>
        /// Draws the Collectible to the screen
        /// if it is active
        /// </summary>
        public override void Draw(SpriteBatch sb, Color c)
        {
            if (active) { sb.Draw(Texture, cratePos, c); }
        }
    }
}
