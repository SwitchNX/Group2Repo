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
        private int lives;
        private MouseState ms;
        private Vector2 mousePos;

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
            ms = Mouse.GetState();
            mousePos = new Vector2(ms.X, ms.Y);

            if (ms.LeftButton == ButtonState.Pressed)
            {
                if (X - ms.X > 0)
                {
                    X += 5;
                }
                if(X - ms.X < 0)
                {
                    X -= 5;
                }

                if (Y - ms.Y > 0)
                {
                    Y += 5;
                }
                if (Y - ms.Y < 0)
                {
                    Y -= 5;
                }
            }
        }
    }
}
