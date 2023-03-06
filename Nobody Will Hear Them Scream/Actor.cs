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
        private Vector2 actorVelocity;

        //Constructor
        public Actor(Texture2D objectTexture, Rectangle objectBounds, Vector2 actorVelocity) : base(objectTexture, objectBounds)
        {
            this.actorVelocity = actorVelocity;
        }

        public override void Update(GameTime gameTime)
        {
            DampenVelocity();
        }

        public void DampenVelocity()
        {
            actorVelocity.X -= actorVelocity.X / 3;
            actorVelocity.Y -= actorVelocity.Y / 3;
        }
    }
}
