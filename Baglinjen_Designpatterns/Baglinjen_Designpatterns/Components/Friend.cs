using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baglinjen_Designpatterns.Components
{
    public class Friend : Component
    {
        public override void Awake()
        {
            base.Awake();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Start()
        {
            base.Start();            
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Destroy()
        {

        }

        public Friend Clone()
        {
            return (Friend)this.MemberwiseClone();
        }

        public override string ToString()
        {
            return "Friend";
        }
    }
}
