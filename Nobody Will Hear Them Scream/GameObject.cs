using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

// [names here]
// Parent class for game objects

namespace Nobody_Will_Hear_Them_Scream
{
    /// <summary>
    /// Parent to all objects on-screen that will
    /// interact with each other
    /// </summary>
    internal class GameObject
    {
        // Fields

        private Texture2D objectTexture;
        private Rectangle objectBounds;


        //Properties

        /// <summary>
        /// Get or set the texture
        /// </summary>
        public Texture2D Texture { get { return objectTexture; } set { objectTexture = value; } }

        /// <summary>
        /// Get or set the width
        /// </summary>
        public int Width { get { return objectBounds.Width; } set { objectBounds.Width = value; } }

        /// <summary>
        /// Get or set the height
        /// </summary>
        public int Height { get { return objectBounds.Height; } set { objectBounds.Height = value; } }

        /// <summary>
        /// Get or set the TOP LEFT x
        /// </summary>
        public int X { get { return objectBounds.X; } set { objectBounds.X = value; } }

        /// <summary>
        /// Get or set the TOP LEFT y
        /// </summary>
        public int Y { get { return objectBounds.Y; } set { objectBounds.Y = value; } }

        /// <summary>
        /// Get the CENTER x
        /// </summary>
        public int CenterX { get { return X + Width / 2; } }

        /// <summary>
        /// Get the CENTER y
        /// </summary>
        public int CenterY { get { return Y + Height / 2; } }

        /// <summary>
        /// Get or set the rectangle
        /// </summary>
        public Rectangle rect { get { return objectBounds; } set { objectBounds = value; } }


        // Constructor

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
        public virtual void Draw(SpriteBatch sb, Color c)
        {
            sb.Draw(objectTexture, objectBounds, c);
        }
    }
}
