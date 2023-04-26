using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Nobody_Will_Hear_Them_Scream
{
    internal class EnemyManager
    {
        private List<Enemy> enemyList;
        private Texture2D basicTexture;
        private Texture2D largeTexture;
        private Texture2D fastTexture;
        private static Point enemyNormalSize = new Point(30, 30);
        private static Point enemyLargeSize = new Point(50, 50);
        private bool greenFlash = false;
        private bool smallPrint = false;
        private bool fastPrint = false;
        private bool bigPrint = false;
        int smallTimer = 5;

        /// <summary>
        /// How many enenies there are
        /// </summary>
        public int EnemyCount { get { return enemyList.Count; } }

        public EnemyManager (Texture2D basicTexture, Texture2D largeTexture, Texture2D fastTexture)
        {
            this.basicTexture = basicTexture;
            this.largeTexture = largeTexture;
            this.fastTexture = fastTexture;
            enemyList = new List<Enemy>();
        }

        /// <summary>
        /// Creates a new basic enemy to the enemy manager
        /// </summary>
        /// <param name="spawnPoint">The point at which the enemy (top left corner) will spawn at</param>
        public void CreateBasicEnemy(Point spawnPoint)
        {
            enemyList.Add(new Enemy(EnemyType.basic, basicTexture, new Rectangle(spawnPoint, enemyNormalSize)));
        }

        /// <summary>
        /// Creates a new large enemy to the enemy manager
        /// </summary>
        /// <param name="spawnPoint">The point at which the enemy (top left corner) will spawn at</param>
        public void CreateLargeEnemy(Point spawnPoint)
        {
            enemyList.Add(new Enemy(EnemyType.large, largeTexture, new Rectangle(spawnPoint, enemyLargeSize)));
        }


        /// <summary>
        /// Creates a new fast enemy to the enemy manager
        /// </summary>
        /// <param name="spawnPoint">The point at which the enemy (top left corner) will spawn at</param>
        public void CreateFastEnemy(Point spawnPoint)
        {
            enemyList.Add(new Enemy(EnemyType.fast, fastTexture, new Rectangle(spawnPoint, enemyNormalSize)));
        }

        /// <summary>
        /// Causes flash when big enemy takes damage
        /// </summary>
        public bool GreenFlash
        {
            get { return greenFlash; }
        }

        public bool SmallPrint
        {
            get { return smallPrint; }
        }

        /// <summary>
        /// Updates all of the enemies postions, handles screen, player, and projectile collisions
        /// </summary>
        /// <param name="gametime"></param>
        /// <param name="astronaut"></param>
        /// <param name="projectileList"></param>
        /// <param name="screenWidth"></param>
        /// <param name="screenHeight"></param>
        /// <returns> The total amount of score gained by killing enemies this frame</returns>
        public int Update(GameTime gametime, Player astronaut, List<Projectile> projectileList, int screenWidth, int screenHeight) 
        {
            List<Enemy> enemiesToBeRemoved = new List<Enemy>();
            List<Projectile> projectilesToBeRemoved = new List<Projectile>();

            int scoreGained = 0;
            greenFlash = false;
            smallTimer++;
            if(smallTimer >= 5)
            {
                smallPrint = false;
            }
            
            fastPrint = false;
            bigPrint = false;

            foreach (Enemy e in enemyList)
            {
                e.GetPlayerPosition(astronaut.rect);
                e.Update(gametime);
                e.HandleScreenCollisions(screenWidth, screenHeight);
                e.EnemyIntersection(astronaut);
				e.HandleEnemyCollisions(enemyList);
                foreach (Projectile p in projectileList)
                {
                    if (e.rect.Intersects(p.rect))
                    {
                        projectilesToBeRemoved.Add(p);
                        e.Health--;
                        if (e.Health == 0)
                        {
                            enemiesToBeRemoved.Add(e);
                        } else
                        {
                            greenFlash = true;
                        }
                    }
                }
            }

            // Removes all of the enemies and projectiles that need to be removed
            for (int i = 0; i < projectilesToBeRemoved.Count; i++)
            {
                projectileList.Remove(projectilesToBeRemoved[i]);
                if (i < enemiesToBeRemoved.Count)
                {
                    //Check the size of the enemy to determine how much to add to the score
                    switch (enemiesToBeRemoved[i].VelocityDampener)
                    {
                        case .97f:
                            scoreGained+=2;
                            smallTimer = 0;
                            smallPrint = true;
                            break;
                        case .985f:
                            scoreGained += 3;
                            break;
                        case .95f:
                            scoreGained += 4;
                            break;
                    }
                    Remove(enemiesToBeRemoved[i]);
                }
            }

            return scoreGained;
        }

        /// <summary>
        /// Draws in objects from other classes
        /// </summary>
        /// <param name="sb">allows for the call of the Draw method</param>
        public void Draw(SpriteBatch sb, Color C)
        {
            foreach(Enemy enemy in enemyList)
            {
                sb.Draw(enemy.Texture, enemy.rect, C);
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
