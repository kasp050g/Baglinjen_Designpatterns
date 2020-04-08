﻿using Baglinjen_Designpatterns.ObserverPattern;
using Baglinjen_Designpatterns.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baglinjen_Designpatterns.Components
{
    class Collider : Component
    {
        public bool CheckCollisionEvents { get; set; }

        private GameEvent onCollisionEvent = new GameEvent("Collision");

        private Vector2 size;

        private Vector2 origin;

        private Texture2D texture;

        public Rectangle CollisionBox
        {
            get
            {
                return new Rectangle
                (
                    (int)(GameObject.Transform.Position.X - origin.X),

                    (int)(GameObject.Transform.Position.Y - origin.Y),

                    (int)size.X,
                    (int)size.Y
                );
            }
        }

        public Collider(SpriteRenderer spriteRenderer)
        {
            this.origin = spriteRenderer.Origin;
            this.size = new Vector2(spriteRenderer.Sprite.Width, spriteRenderer.Sprite.Height);
            texture = GameWorld.Instance.Content.Load<Texture2D>("CollisionBox");
        }

        public Collider(SpriteRenderer spriteRenderer, IGameListner gameListner)
        {
            onCollisionEvent.Attach(gameListner);
            this.origin = spriteRenderer.Origin;
            this.size = new Vector2(spriteRenderer.Sprite.Width, spriteRenderer.Sprite.Height);
            texture = GameWorld.Instance.Content.Load<Texture2D>("CollisionBox");
        }



        public void OnCollisionEnter(Collider other)
        {
            if (CheckCollisionEvents)
            {
                if (other != this)
                {
                    if (CollisionBox.Intersects(other.CollisionBox))
                    {
                        onCollisionEvent.Notify(other);
                    }
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, CollisionBox, null, Color.Red, 0, origin, SpriteEffects.None, 0);
        }

        public override string ToString()
        {
            return "Collider";
        }
    }
}
