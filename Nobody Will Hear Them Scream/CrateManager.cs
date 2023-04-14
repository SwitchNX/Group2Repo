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

        public CrateManager(int crateNum, Texture2D objectTexture1, Texture2D objectTexture2, Texture2D objectTexture3, Rectangle objectBounds) :
            base(objectTexture1, objectBounds)
        {
            crateList = new List<Crate>(crateNum);

            Random rng = new Random();
            Random rand = new Random();

            for (int i = 0; i < crateNum; i++)
            {
                int randTextureNum = rng.Next(3);

                switch (randTextureNum)
                {
                    case 0:
                        objectBounds = new Rectangle(rand.Next(40, 1560), rand.Next(40, 860), 50, 50);
                        crateList.Add(new Crate(objectTexture1, objectBounds));
                        break;
                    case 1:
                        objectBounds = new Rectangle(rand.Next(40, 1560), rand.Next(40, 860), 50, 100);
                        crateList.Add(new Crate(objectTexture2, objectBounds));
                        break;
                    case 2:
                        objectBounds = new Rectangle(rand.Next(40, 1560), rand.Next(40, 860), 100, 50);
                        crateList.Add(new Crate(objectTexture3, objectBounds));
                        break;
                }

            }
        }

        /// <summary>
        /// Updates GameObjects over time
        /// </summary>
        public void Update(GameTime gameTime, Player astronaut) 
        {
            // Update the score if there is a collision with a crate
            for (int i = 0; i < crateList.Count; i++)
            {
                if (crateList[i].CheckCollision(astronaut))
                {
                    astronaut.LevelScore += 10;
                    astronaut.GameScore += 10;
                }
            }
        }

        /// <summary>
        /// Draws a Crate to the screen if it is active
        /// </summary>
        /// <param name="sb">allows for the call of the Draw method</param>
        public override void Draw(SpriteBatch sb, Color C)
        {
            for (int i = 0; i < crateList.Count; i++)
            {
                if (crateList[i].Active)
                {
                    sb.Draw(Texture, crateList[i].CratePos, C);
                }
            }
        }

        /// <summary>
        /// Removes the intended Crate from the list of Crates
        /// </summary>
        /// <param name="toRemove">the crate to be removed</param>
        public void RemoveCrate(Crate toRemove)
        {
            crateList.Remove(toRemove);
        }

        /// <summary>
        /// Clears the list of crates
        /// </summary>
        public void ClearCrates()
        {
            crateList.Clear();
        }
        
    }
}
