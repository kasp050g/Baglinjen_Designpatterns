using Baglinjen_Designpatterns.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baglinjen_Designpatterns.FactoryPattern
{
    class FriendFactory : Factory
    {
        private static FriendFactory instance;

        public static FriendFactory Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FriendFactory();
                }
                return instance;
            }
        }

        private static Random rnd = new Random();

        public override GameObject Create(string type)
        {
            GameObject go = new GameObject();
            SpriteRenderer sr = new SpriteRenderer();
            go.AddComponent(sr);
            go.Tag = "Friend";


            switch (type)
            {
                case "Friend":
                    sr.SetSprite("Image/enemyPixel");
                    go.AddComponent(new Collider(sr) { CheckCollisionEvents = true });
                    go.AddComponent(new Friend());
                    break;
            }

            return go;
        }
    }
}
