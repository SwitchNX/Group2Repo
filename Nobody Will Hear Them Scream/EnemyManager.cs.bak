using Microsoft.Xna.Framework.Graphics;
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
    internal class EnemyManager
    {
        private List<Enemy> enemyList;
        private Texture2D objectTexture;
        public static Point enemySize = new Point(30, 30);

        /// <summary>
        /// How many enenies there are
        /// </summary>
        public int EnemyCount { get { return enemyList.Count; } }

        public EnemyManager (Texture2D objectTexture)
        {
            this.objectTexture = objectTexture;
            enemyList = new List<Enemy>();
        }

        /// <summary>
        /// Creates a new enemy to the enemy manager
        /// </summary>
        /// <param name="spawnPoint">The point at which the enemy (top left corner) will spawn at</param>
        public void CreateEnemy(Point spawnPoint)
        {
            enemyList.Add(new Enemy(objectTexture, new Rectangle(spawnPoint, enemySize)));
        }

        /// <summary>
        /// Updates all of the enemies postions, handles screen, player, and projectile collisions
        /// </summary>
        /// <param name="gametime"></param>
        /// <param name="astronaut"></param>
        /// <param name="projectileList"></param>
        /// <param name="screenWidth"></param>
        /// <param name="screenHeight"></param>
        public void Update(GameTime gametime, Player astronaut, List<Projectile> projectileList, int screenWidth, int screenHeight) 
        {
            List<Enemy> enemiesToBeRemoved = new List<Enemy>();
            List<Projectile> projectilesToBeRemoved = new List<Projectile>();


            foreach (Enemy e in enemyList)
            {
                e.GetPlayerPosition(astronaut.rect);
                e.Update(gametime);
                e.HandleScreenCollisions(screenWidth, screenHeight);
                e.EnemyIntersection(astronaut);
                foreach (Projectile p in projectileList)
                {
                    if (e.rect.Intersects(p.rect))
                    {
                        enemiesToBeRemoved.Add(e);
                        projectilesToBeRemoved.Add(p);
                    }
                }
            }

            // Removes all of the enemies and projectiles that need to be removed
            for (int i = 0; i < enemiesToBeRemoved.Count; i++)
            {
                Remove(enemiesToBeRemoved[i]);
                projectileList.Remove(projectilesToBeRemoved[i]);
            }
        }

        /// <summary>
        /// Draws in objects from other classes
        /// </summary>
        /// <param name="sb">allows for the call of the Draw method</param>
        public void Draw(SpriteBatch sb, Color C)
        {
            foreach(Enemy enemy in enemyList)
            {
                sb.Draw(objectTexture, enemy.rect, C);
            }
        }

        /// <summary>
        /// Removes an enemy from the enemy list
        /// </summary>
        /// <param name="enemy"></param>
        public void Remove(Enemy enemy)
        {
            enemyList.Remove(enemy);
        }

        /// <summary>
        /// Checks whether any of the enemies intersect with the astronaut
        /// </summary>
        /// <param name="astronaut">The player</param>
        /// <returns>True if any intersection is found, false if otherwise</returns>
        public bool DetectPlayerIntersection(Player astronaut)
        {
            foreach(Enemy e in enemyList)
            {
                if (e.rect.Intersects(astronaut.rect))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
