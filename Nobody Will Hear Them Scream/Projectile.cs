﻿using System;
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
        // Fields

        Vector2 velocity;


        // Constructor

        /// <summary>
        /// Creates a new projectile object
        /// </summary>
        /// <param name="objectTexture"></param>
        /// <param name="objectBounds"></param>
        /// <param name="velocity"></param>
        public Projectile(Texture2D objectTexture, Rectangle objectBounds, Vector2 velocity) : base(objectTexture, objectBounds)
        {
            this.velocity = velocity;
        }


        // Methods

        // Add draw and update methods
    }
}
