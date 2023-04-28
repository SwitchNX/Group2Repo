using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// Anthony Curtis & Hudson Ward
// Class for crate objects

namespace Nobody_Will_Hear_Them_Scream
{
    /// <summary>
    /// Crates that the player can collide with to get points
    /// </summary>
    internal class Crate : GameObject
    {
        // Fields

        private bool active;
        private Rectangle cratePos;


        // Properties

        /// <summary>
        /// returns or changes the value of active
        /// </summary>
        public bool Active { get { return active; } set { active = value; } }

        /// <summary>
        /// returns or changes the value of the crate's position
        /// </summary>
        public Rectangle CratePos { get { return cratePos; } set { cratePos = value; } }


        // Constructor

        /// <summary>
        /// Initializes the fields of the Crate class
        /// </summary>
        /// <param name="objectTexture">The texture of the object</param>
        /// <param name="objectBounds">The rectuangle bounds of the object</param>
        public Crate(Texture2D objectTexture, Rectangle objectBounds) : base(objectTexture, objectBounds)
        {
            cratePos = new Rectangle(X, Y, Width, Height);
            active = true;
        }


        // Methods

        /// <summary>
        /// Determines if there is a collision between the
        /// GameObject and an active Crate
        /// </summary>
        /// <param name="check">the GameObject being checked</param>
        /// <returns> whether or not the provided GameObject parameter 
        /// is intersecting with this Crate</returns>
        public bool CheckCollision(GameObject check)
        {
            Rectangle playerPos = new Rectangle(check.X, check.Y, check.Width, check.Height);

            // only checks for intersection if the crate is still
            // visible on screen
            if (active)
            {
                if (cratePos.Intersects(playerPos))
                {
                    active = false;
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Draws the score on the screen after collision
        /// </summary>
        /// <param name="sb">The sprite batch</param>
        /// <param name="font">The sprite font</param>
        /// <param name="crateManger">The crate manager</param>
        public void DrawScore(SpriteBatch sb, SpriteFont font, CrateManager crateManger)
        {
            // The score depending on the type of crate
            int typeScore = 0;
            switch (Width * Height) // Determines the size of the crate using the area
            {
                case 2500: // Box crate
                    typeScore = 10;
                    break;
                case 5000: // Tall or wide crate
                    typeScore = 20;
                    break;
            }

            // Prints score aquired
            if (crateManger.SmallPrint)
            {
                sb.DrawString(font, $"+{typeScore}pts",
                        new Vector2(X,
                        Y),
                        Color.Green);
            }
        }
    }
}
