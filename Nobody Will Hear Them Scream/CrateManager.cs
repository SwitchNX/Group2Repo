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
    internal class CrateManager : Crate
    {
        private List<Crate> crateList;

        public CrateManager(int crateNum, Texture2D objectTexture, Rectangle objectBounds) :
            base(objectTexture, objectBounds)
        {
            crateList = new List<Crate>(crateNum);

            for (int i = 0; i < crateNum; i++)
            {
                AddCrate(objectTexture, objectBounds);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="toRemove"></param>
        public void RemoveCrate(Crate toRemove)
        {
            crateList.Remove(toRemove);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="objectTexture"></param>
        /// <param name="objectBounds"></param>
        public void AddCrate(Texture2D objectTexture, Rectangle objectBounds)
        {
            Random rng = new Random();

            objectBounds = new Rectangle(rng.Next(40, 1560), rng.Next(40, 860), 50, 50);
            crateList.Add(new Crate(objectTexture, objectBounds));
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
            PlayerPos = new Rectangle(check.X, check.Y, check.Width, check.Height);

            if (Active)
            {
                return CratePos.Intersects(PlayerPos);
            }

            return false;
        }
    }
}
