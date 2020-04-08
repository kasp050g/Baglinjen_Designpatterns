﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baglinjen_Designpatterns.ObjectPool
{
    public abstract class ObjectPool
    {
        protected List<GameObject> active = new List<GameObject>();

        protected Stack<GameObject> inactive = new Stack<GameObject>();

        public GameObject GetObject()
        {
            GameObject go;

            if (inactive.Count > 0)
            {
                go = inactive.Pop();
            }
            else
            {
                go = Create();
            }

            return go;
        }

        public void ReleaseObject(GameObject gameObject)
        {
            GameWorld.Instance.RemoveGameObject(gameObject);
            active.Remove(gameObject);
            inactive.Push(gameObject);
        }

        protected abstract GameObject Create();

        protected abstract void Cleanup(GameObject gameObject);
    }
}
