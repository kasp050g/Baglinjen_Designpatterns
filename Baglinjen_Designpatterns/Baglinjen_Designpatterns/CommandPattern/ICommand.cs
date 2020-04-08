using Baglinjen_Designpatterns.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baglinjen_Designpatterns.CommandPattern
{
    public interface ICommand
    {
        void Execute(Player player);
    }
}
