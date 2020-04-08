using Baglinjen_Designpatterns.FactoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baglinjen_Designpatterns.ObjectPool
{
    public class FriendPool : ObjectPool
    {
        private static FriendPool instance;

        public static FriendPool Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FriendPool();
                }
                return instance;
            }
        }

        protected override void Cleanup(GameObject gameObject)
        {

        }

        protected override GameObject Create()
        {
            return FriendFactory.Instance.Create("Friend");
        }
    }
}
