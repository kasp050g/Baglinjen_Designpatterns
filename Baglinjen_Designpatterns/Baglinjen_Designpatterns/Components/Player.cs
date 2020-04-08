using Baglinjen_Designpatterns.CommandPattern;
using Baglinjen_Designpatterns.ObserverPattern;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baglinjen_Designpatterns.Components
{
    public class Player : Component, IGameListner
    {
        private float speed;
        //private SpriteRenderer spriteRenderer;

        public Player()
        {
            this.speed = 300;
			InputHandler.Instance.Entity = this;
        }

        public void Move(Vector2 velocity)
        {
            if (velocity != Vector2.Zero)
            {
                velocity.Normalize();
            }

            velocity *= speed;

            GameObject.Transform.Translate(velocity * GameWorld.Instance.DeltaTime);
        }

        public override void Awake()
        {
            GameObject.Transform.Position = new Vector2(GameWorld.Instance.GraphicsDevice.Viewport.Width / 2,
            GameWorld.Instance.GraphicsDevice.Viewport.Height / 2);
        }

        public override void Start()
        {

        }

        public override string ToString()
        {
            return "Player";
        }

        public override void Destroy()
        {
            GameWorld.Instance.Colliders.Remove((Collider)GameObject.GetComponent("Collider"));
        }

        public void Notify(GameEvent gameEvent, Component other)
        {
            if (gameEvent.Title == "Collider" && other.GameObject.Tag == "Friend")
            {
                other.GameObject.Destroy();
            }
        }
    }
}
