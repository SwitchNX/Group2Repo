﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

// Hudson, Anthony, Kai
// Manager for enemy objects

namespace Nobody_Will_Hear_Them_Scream
{
    internal class EnemyManager
    {
        // Fields

        private List<Enemy> enemyList;
        private Texture2D basicTexture;
        private Texture2D largeTexture;
        private Texture2D fastTexture;
        private static Point enemyNormalSize = new Point(40, 40);
        private static Point enemySmallSize = new Point(30, 30);
        private static Point enemyLargeSize = new Point(60, 60);

        //Fields for printing scores when destroyed, and flashing when damaged
        private bool redFlash = false;
        private bool smallPrint = false;
        private List<Enemy> enemiesToScore;
        private List<Enemy> enemiesToFlash;
        int smallTimer = 10;
        int flashTimer = 5;


        // Properties

        /// <summary>
        /// How many enenies there are
        /// </summary>
        public int EnemyCount { get { return enemyList.Count; } }


        // Constructor

        /// <summary>
        /// Creates a new enemy manager object
        /// </summary>
        /// <param name="basicTexture">Texture for basic enemy</param>
        /// <param name="largeTexture">Texture for large enemy</param>
        /// <param name="fastTexture">Texture for fast enemy</param>
        public EnemyManager (Texture2D basicTexture, Texture2D largeTexture, Texture2D fastTexture)
        {
            this.basicTexture = basicTexture;
            this.largeTexture = largeTexture;
            this.fastTexture = fastTexture;
            enemyList = new List<Enemy>();
            enemiesToScore = new List<Enemy>();
            enemiesToFlash = new List<Enemy>();
        }


        // Methods

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
            enemyList.Add(new Enemy(EnemyType.fast, fastTexture, new Rectangle(spawnPoint, enemySmallSize)));
        }

        /// <summary>
        /// Checks if an enemy score needs to be printed
        /// </summary>
        public bool SmallPrint
        {
            get { return smallPrint; }
            set { smallPrint = value; }
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
            // Create a list for enemies and projectiles to be removed
            List<Enemy> enemiesToBeRemoved = new List<Enemy>();
            List<Projectile> projectilesToBeRemoved = new List<Projectile>();

            int scoreGained = 0;
            flashTimer++;
            smallTimer++;

            if(smallTimer >= 30)
            {
                smallPrint = false;
                enemiesToScore.Clear();
            }
            if (flashTimer >= 10)
            {
                redFlash = false;
                enemiesToFlash.Clear();
            }

            // Update each enemy
            foreach (Enemy e in enemyList)
            {
                e.GetPlayerPosition(astronaut.rect);
                e.Update(gametime);
                e.HandleScreenCollisions(screenWidth, screenHeight);
                e.EnemyIntersection(astronaut);
				e.HandleEnemyCollisions(enemyList);

                // Remove each projectile and hurt each enemy they touch if they intersect
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
                            flashTimer = 0;
                            redFlash = true;
                            enemiesToFlash.Add(e);
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
                            break;
                        case .985f:
                            scoreGained += 3;
                            break;
                        case .95f:
                            scoreGained += 4;
                            break;
                    }
                    smallTimer = 0;
                    smallPrint = true;
                    enemiesToScore.Add(enemiesToBeRemoved[i]);
                    Remove(enemiesToBeRemoved[i]);
                }
            }

            return scoreGained;
        }

        /// <summary>
        /// Draws in objects from other classes
        /// </summary>
        /// <param name="sb">allows for the call of the Draw method</param>
        /// <param name="C">the color of the enemy</param>
        /// <param name="font">the font used to display the scores each enemy provides</param>
        public void Draw(SpriteBatch sb, Color C, SpriteFont font)
        {
            // Draw every enemy
            foreach (Enemy enemy in enemyList)
            {
                if (enemiesToFlash.Contains(enemy))
                {
                    sb.Draw(enemy.Texture, enemy.rect, Color.Red);
                } else
                {
                    sb.Draw(enemy.Texture, enemy.rect, C);
                }
            }
            // Draw each pop up score
            foreach (Enemy enemy in enemiesToScore)
            {
                enemy.DrawScore(sb, font, this);
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
