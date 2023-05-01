using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// Ryan Fogarty, Anthony Curtis & Hudson Ward
// Class for managing crate objects

namespace Nobody_Will_Hear_Them_Scream
{
    /// <summary>
    /// Enum for types of crates
    /// </summary>
    public enum CrateTexutre
    {
        square, tall, wide
    }

    internal class CrateManager
    {
        // Fields

        private List<Crate> crateList;
        private Texture2D squareTexture;
        private Texture2D wideTexture;
        private Texture2D tallTexture;
        private Point crateSize;

        //Fields for printing scores when destroyed
        private bool smallPrint = false;
        private List<Crate> cratesToScore;
        int smallTimer = 5;


        // Properties

        /// <summary>
        /// Checks if an crate score needs to be printed
        /// </summary>
        public bool SmallPrint
        {
            get { return smallPrint; }
            set { smallPrint = value; }
        }

        // Constructor

        /// <summary>
        /// Creates a new crate manager object
        /// </summary>
        /// <param name="squareTexture">The texture of the square crates</param>
        /// <param name="wideTexture">The texture of the wide crates</param>
        /// <param name="tallTexture">The texture of the tall crates</param>
        public CrateManager(Texture2D squareTexture, Texture2D wideTexture, Texture2D tallTexture)
        {
            crateList = new List<Crate>();
            this.squareTexture = squareTexture;
            this.wideTexture = wideTexture;
            this.tallTexture = tallTexture;
            cratesToScore = new List<Crate>();

        }

        // Methods

        /// <summary>
        /// Creates a new crate object
        /// </summary>
        /// <param name="spawnPoint">The point the crate is located at</param>
        /// <param name="ct">The texture of the crate</param>
        public void CreateNewCrate(Point spawnPoint, CrateTexutre ct)
        {
            // Creates a new point for the point of the crate
            crateSize = new Point(50, 50);

            // Determines the crate's texture
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

            // Add the crate to the list
            crateList.Add(new Crate(objectTexture, new Rectangle(spawnPoint, crateSize)));
        }

        /// <summary>
        /// Updates GameObjects over time
        /// </summary>
        /// <param name="gameTime">The current game time</param>
        /// <param name="astronaut">The player</param>
        public void Update(GameTime gameTime, Player astronaut) 
        {
            // Update the timer for printing the pop up score
            smallTimer++;

            // Checks if pop up score should be removed yet
            if (smallTimer >= 30)
            {
                smallPrint = false;
                cratesToScore.Clear();
            }


            // Update the score if there is a collision with a crate
            for (int i = 0; i < crateList.Count; i++)
            {
                if (crateList[i].CheckCollision(astronaut))
                {
                    // Check the size of the crate to determine how much to add to the score
                    switch (crateList[i].Width * crateList[i].Height)
                    {
                        case 2500: // Square crate
                            astronaut.LevelScore += 10;
                            astronaut.GameScore += 10;
                            break;

                        case 5000: // Wide or tall crate
                            astronaut.LevelScore += 20;
                            astronaut.GameScore += 20;
                            break;
                    }

                    // Starts the pop up score timer
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
        /// <param name="C">The color to draw the crate</param>
        /// <param name="font">The sprite font for the pop up score</param>
        public void Draw(SpriteBatch sb, Color C, SpriteFont font)
        {
            // Loop through every crate
            for (int i = 0; i < crateList.Count; i++)
            {
                // If the crate is active, draw it
                if (crateList[i].Active)
                {
                    sb.Draw(squareTexture, crateList[i].CratePos, C);
                }
            }

            // Draw each pop up score
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
            // Make a new random
            Random rng = new Random();

            // Determine a random position for the crate
            objectBounds = new Rectangle(rng.Next(40, 1560), rng.Next(40, 860), 50, 50);

            // Add the crate to the list
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
