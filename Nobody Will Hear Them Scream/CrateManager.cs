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
    public enum CrateTexutre
    {
        square, tall, wide
    }

    internal class CrateManager
    {
        private List<Crate> crateList;
        private Texture2D squareTexture;
        private Texture2D wideTexture;
        private Texture2D tallTexture;
        private Point crateSize; 

        public CrateManager(Texture2D squareTexture, Texture2D wideTexture, Texture2D tallTexture)
        {
            crateList = new List<Crate>();
            this.squareTexture = squareTexture;
            this.wideTexture = wideTexture;
            this.tallTexture = tallTexture;

        }

        public void CreateNewCrate(Point spawnPoint, CrateTexutre ct)
        {
            crateSize = new Point(50, 50);

            Texture2D objectTexture;
            switch(ct)
            {
                case CrateTexutre.square:
                    objectTexture = squareTexture;
                    break;
                case CrateTexutre.wide:
                    crateSize.X *= 2;
                    objectTexture = wideTexture;
                    break;
                default:
                    crateSize.Y *= 2;
                    objectTexture = tallTexture;
                    break;
            }

            crateList.Add(new Crate(objectTexture, new Rectangle(spawnPoint, crateSize)));
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
        public void Draw(SpriteBatch sb, Color C)
        {
            for (int i = 0; i < crateList.Count; i++)
            {
                if (crateList[i].Active)
                {
                    sb.Draw(squareTexture, crateList[i].CratePos, C);
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
        /// Adds a crate ot the list at a random position on screen
        /// </summary>
        /// <param name="objectTexture">crate's texture</param>
        /// <param name="objectBounds">size and location of the crate</param>
        public void AddCrateAtRandomPos(Texture2D objectTexture, Rectangle objectBounds)
        {
            Random rng = new Random();

            objectBounds = new Rectangle(rng.Next(40, 1560), rng.Next(40, 860), 50, 50);
            crateList.Add(new Crate(objectTexture, objectBounds));
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
