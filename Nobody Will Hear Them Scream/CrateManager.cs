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
        private bool smallPrint = false;
        private List<Crate> cratesToScore;
        int smallTimer = 5;

        /// <summary>
        /// Checks if an crate score needs to be printed
        /// </summary>
        public bool SmallPrint
        {
            get { return smallPrint; }
            set { smallPrint = value; }
        }

        public CrateManager(Texture2D squareTexture, Texture2D wideTexture, Texture2D tallTexture)
        {
            crateList = new List<Crate>();
            this.squareTexture = squareTexture;
            this.wideTexture = wideTexture;
            this.tallTexture = tallTexture;
            cratesToScore = new List<Crate>();

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
            smallTimer++;
            if (smallTimer >= 10)
            {
                smallPrint = false;
                cratesToScore.Clear();
            }
            // Update the score if there is a collision with a crate
            for (int i = 0; i < crateList.Count; i++)
            {
                if (crateList[i].CheckCollision(astronaut))
                {
                    //Check the size of the crate to determine how much to add to the score
                    switch (crateList[i].Width * crateList[i].Height)
                    {
                        case 2500:
                            astronaut.LevelScore += 10;
                            astronaut.GameScore += 10;
                            break;
                        case 5000:
                            astronaut.LevelScore += 20;
                            astronaut.GameScore += 20;
                            break;
                    }
                    smallTimer = 0;
                    smallPrint = true;
                    cratesToScore.Add(crateList[i]);
                }
            }
        }

        /// <summary>
        /// Draws a Crate to the screen if it is active
        /// </summary>
        /// <param name="sb">allows for the call of the Draw method</param>
        public void Draw(SpriteBatch sb, Color C, SpriteFont font)
        {
            for (int i = 0; i < crateList.Count; i++)
            {
                if (crateList[i].Active)
                {
                    sb.Draw(squareTexture, crateList[i].CratePos, C);
                    //crateList[i].Draw(sb, C);
                }
            }
            foreach (Crate c in cratesToScore)
            {
                c.DrawScore(sb, font, this);
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
