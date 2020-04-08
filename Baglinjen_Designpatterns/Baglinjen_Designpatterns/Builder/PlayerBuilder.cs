using Baglinjen_Designpatterns.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baglinjen_Designpatterns.Builder
{
	class PlayerBuilder : IBuilder
	{
		private GameObject go;

		public void BuildGameObject()
		{
			go = new GameObject();

			go.AddComponent(new Player());
			go.AddComponent(new SpriteRenderer());
		}

		public GameObject GetResult()
		{
			return go;
		}
	}
}
