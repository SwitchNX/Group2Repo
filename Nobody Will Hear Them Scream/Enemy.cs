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
    /// Aliens that chase the player
    /// </summary>
    internal class Enemy : Actor
    {
        //Constructor
        public Enemy(Texture2D objectTexture, Rectangle objectBounds) : base(objectTexture, objectBounds) { }
    }
}
