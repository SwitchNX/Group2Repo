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
        public int Width
        {
            get { return objectBounds.Width; }
        }
        public int Height
        {
            get { return objectBounds.Height; }
        }
        public int X
        {
            get { return objectBounds.X; }
        }
        public int Y
        {
            get { return objectBounds.Y; }
        }

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
    }
}
