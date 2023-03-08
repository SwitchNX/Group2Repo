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
    /// <summary>
    /// Parent to all objects on-screen that will
    /// interact with each other
    /// </summary>
    internal class GameObject
    {
        //Fields
        private Texture2D objectTexture;
        private Rectangle objectBounds;

        //Properties
        public int Width { get { return objectBounds.Width; } set { objectBounds.Width = value; } }

        public int Height { get { return objectBounds.Height; } set { objectBounds.Height = value; } }

        public int X { get { return objectBounds.X; } set { objectBounds.X = value; } }

        public int Y { get { return objectBounds.Y; } set { objectBounds.Y = value; } }

        public Rectangle rect
        {
            get { return objectBounds; }
        }
        public Texture2D ObjectTexture
        {
            get { return objectTexture; }
        }

        //Constructor
        public GameObject (Texture2D objectTexture, Rectangle objectBounds)
        {
            this.objectTexture = objectTexture;
            this.objectBounds = objectBounds;
        }

        /// <summary>
        /// Updates GameObjects over time
        /// </summary>
        public virtual void Update(GameTime gameTime) { }

        /// <summary>
        /// Draws in objects from other classes
        /// </summary>
        /// <param name="sb">allows for the call of the Draw method</param>
        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(objectTexture, objectBounds, Color.White);
        }
    }
}
