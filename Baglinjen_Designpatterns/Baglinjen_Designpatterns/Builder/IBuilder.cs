using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baglinjen_Designpatterns.Builder
{
	public interface IBuilder
	{
		GameObject GetResult();

		void BuildGameObject();
	}
}
