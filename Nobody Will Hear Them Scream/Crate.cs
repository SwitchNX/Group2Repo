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

        /// <summary>
        /// returns or changes the value of active
        /// </summary>
        public bool Active { get { return active; } set { active = value; } }

        public Rectangle PlayerPos { get { return playerPos; } set { playerPos = value; } }

        public Rectangle CratePos { get { return cratePos; } set { cratePos = value; } }

        /// <summary>
        /// Initializes the fields of the Crate class
        /// </summary>
        public Crate(Texture2D objectTexture, Rectangle objectBounds) : base(objectTexture, objectBounds) 
        {
            cratePos = new Rectangle(X, Y, Width, Height);
            active = true;
        }

        ///// <summary>
        ///// Draws the Collectible to the screen
        ///// if it is active
        ///// </summary>
        //public override void Draw(SpriteBatch sb, Color c)
        //{
        //    if (active) { sb.Draw(Texture, cratePos, c); }
        //}
    }
}
