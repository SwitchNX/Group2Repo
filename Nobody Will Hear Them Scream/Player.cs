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
    /// player-controlled lil guy
    /// </summary>
    internal class Player : Actor
    {
        //Fields
        private GraphicsDeviceManager _graphics;

        //Constructor
        public Player (Texture2D objectTexture, Rectangle objectBounds, GraphicsDeviceManager _graphics) :
            base (objectTexture, objectBounds)
        {
            this._graphics = _graphics;
        }

    }
}
