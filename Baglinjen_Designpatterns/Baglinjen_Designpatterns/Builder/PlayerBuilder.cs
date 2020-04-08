using Baglinjen_Designpatterns.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baglinjen_Designpatterns.Builder
{
	public class PlayerBuilder : IBuilder
	{
		private GameObject go;

		public void BuildGameObject()
		{
			go = new GameObject();
            Player player = new Player();

            go.AddComponent(player);
            SpriteRenderer sr= new SpriteRenderer("Image/playerPixel");

            go.AddComponent(sr);
            go.AddComponent(new Collider(sr, player));
            GameWorld.Instance.Colliders.Add((Collider)go.GetComponent("Collider"));
		}

		public GameObject GetResult()
		{
			return go;
		}
	}
}
