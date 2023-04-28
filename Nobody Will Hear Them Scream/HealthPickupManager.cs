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
    internal class HealthPickupManager
    {
        private static Point HealthPickupSize = new Point(40, 40);
        private static List<Rectangle> healthPickupList = new List<Rectangle>();
        private static Texture2D healthPickupTexture;

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
        public void CheckPlayerCollisions(Player astronaut)
        {
            for (int i = 0; i < healthPickupList.Count; i++)
            {
                if (astronaut.rect.Intersects(healthPickupList[i]))
                {
                    astronaut.Lives++;
                    healthPickupList.RemoveAt(i);
                    i--;
                }
            }
        }

        /// <summary>
        /// Draws every health pickup onto the screen
        /// </summary>
        /// <param name="sb">The spritebatch to draw with</param>
        public void Draw(SpriteBatch sb, Color c)
        {
            foreach(Rectangle r in healthPickupList)
            {
                sb.Draw(healthPickupTexture, r, c);
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
