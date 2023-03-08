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
        int lives;

        //Properties
        public int Lives
        {
            get { return lives; }
            set { lives = value; }
        }

        //Constructor
        public Player (Texture2D objectTexture, Rectangle objectBounds, Vector2 actorVelocity, GraphicsDeviceManager _graphics) :
            base (objectTexture, objectBounds, actorVelocity)
        {
            this._graphics = _graphics;
            this.lives = 3;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            MouseState ms = Mouse.GetState();

            if (ms.LeftButton == ButtonState.Pressed) { ; }
        }

        //public void 
    }
}
