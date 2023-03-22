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
    internal class EnemyManager : GameObject
    {
        private List<Enemy> enemyList;

        public EnemyManager(int enemyNum, Texture2D objectTexture, Rectangle objectBounds) :
            base(objectTexture, objectBounds)
        {
            enemyList = new List<Enemy>(enemyNum);

            for (int i = 0; i < enemyNum; i++)
            {
                enemyList.Add(new Enemy(objectTexture, objectBounds));
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
            foreach(Enemy enemy in enemyList)
            {
                sb.Draw(Texture, rect, C);
            }
        }

        // Remove
        public void Remove(Enemy enemy)
        {
            enemyList.Remove(enemy);
        }

        //Check Intersections
        public void Check(Player astronaut)
        {
            foreach (Enemy enemy in enemyList)
            {
                enemy.EnemyIntersection(astronaut);
            }
        }
    }
}
