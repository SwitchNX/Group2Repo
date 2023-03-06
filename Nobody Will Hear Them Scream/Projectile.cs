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
    /// Projectiles fired from the player's weapon
    /// </summary>
    internal class Projectile : GameObject
    {
        //Constructor
        public Projectile(Texture2D objectTexture, Rectangle objectBounds) : base(objectTexture, objectBounds) { }
    }
}
