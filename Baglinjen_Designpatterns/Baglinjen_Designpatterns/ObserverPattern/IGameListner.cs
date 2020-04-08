using Baglinjen_Designpatterns.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baglinjen_Designpatterns.ObserverPattern
{
    public interface IGameListner
    {
        void Notify(GameEvent gameEvent, Component component);
    }
}
