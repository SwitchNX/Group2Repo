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
    /// Objects that interact with the space physics
    /// </summary>
    internal class Actor : GameObject
    {
        //Constructor
        public Actor(Texture2D objectTexture, Rectangle objectBounds) : base(objectTexture, objectBounds) { }

    }
}
