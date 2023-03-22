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
    internal class CrateManager : GameObject
    {
        private List<Crate> crateList;

        public CrateManager(int crateNum, Texture2D objectTexture, Rectangle objectBounds) :
            base(objectTexture, objectBounds)
        {
            crateList = new List<Crate>(crateNum);

            for (int i = 0; i < crateNum; i++)
            {

            }
        }

        /// <summary>
        /// Updates GameObjects over time
        /// </summary>
        public override void Update(GameTime gameTime) { }

        /// <summary>
        /// Draws in objects from other classes
        /// </summary>
        /// <param name="sb">allows for the call of the Draw method</param>
        public override void Draw(SpriteBatch sb, Color C)
        {
            sb.Draw(Texture, rect, C);
        }

        // Remove

        // Add
    }
}
