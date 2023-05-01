using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// Ryan
// Manages the health pickup crate objects

namespace Nobody_Will_Hear_Them_Scream
{
    internal class HealthPickupManager
    {
        private static Point HealthPickupSize = new Point(40, 40);
        private static List<Rectangle> healthPickupList = new List<Rectangle>();
        private static Texture2D healthPickupTexture;
        
        private static List<Vector2> positionsOfStringsToDraw = new List<Vector2>();
        private static List<int> framesStringsHaveBeenOnFrame = new List<int>();

        public HealthPickupManager(Texture2D texture)
        {
            healthPickupTexture = texture;
        }

        /// <summary>
        /// Adds a new health pickup onto the manager
        /// </summary>
        /// <param name="spawnPoint">The point where the health pickup will be spawned</param>
        public void AddHealthPickup(Point spawnPoint)
        {
            healthPickupList.Add(new Rectangle(spawnPoint, HealthPickupSize));
        }


        /// <summary>
        /// Checks if the player collides with any health pickup. If they do, increases the player's health and removes that pickup
        /// </summary>
        /// <param name="astronaut"></param>
        public void Update(Player astronaut)
        {
            for (int i = 0; i < healthPickupList.Count; i++)
            {
                if (astronaut.rect.Intersects(healthPickupList[i]))
                {
                    astronaut.Lives++;

                    positionsOfStringsToDraw.Add(new Vector2(healthPickupList[i].X, healthPickupList[i].Y));
                    framesStringsHaveBeenOnFrame.Add(0);

                    healthPickupList.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < framesStringsHaveBeenOnFrame.Count; i++)
            {
                framesStringsHaveBeenOnFrame[i]++;
                if (framesStringsHaveBeenOnFrame[i] > 30)
                {
                    framesStringsHaveBeenOnFrame.RemoveAt(0);
                    positionsOfStringsToDraw.RemoveAt(0);
                }
            }
        }

        /// <summary>
        /// Draws every health pickup onto the screen
        /// </summary>
        /// <param name="sb">The spritebatch to draw with</param>
        public void Draw(SpriteBatch sb, Color c, SpriteFont font)
        {
            foreach(Rectangle r in healthPickupList)
            {
                sb.Draw(healthPickupTexture, r, c);
            }

            foreach(Vector2 v in positionsOfStringsToDraw)
            {
                sb.DrawString(font, "+1 hp", v, Color.Green);
            }
        }

        /// <summary>
        /// Clears all the health pickups from the manager
        /// </summary>
        public void Clear()
        {
            healthPickupList.Clear();
        }
    }
}
