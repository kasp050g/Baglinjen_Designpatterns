using Baglinjen_Designpatterns.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baglinjen_Designpatterns.CommandPattern
{
    class InputHandler
    {
		public Player Entity;
		public Dictionary<Keys, ICommand> keybinds = new Dictionary<Keys, ICommand>();
		private static InputHandler instance;

        public static InputHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InputHandler();
                }
                return instance;
            }
        }

        private InputHandler()
        {
            keybinds.Add(Keys.D, new MoveCommand(new Vector2(1, 0)));
            keybinds.Add(Keys.A, new MoveCommand(new Vector2(-1, 0)));
            keybinds.Add(Keys.W, new MoveCommand(new Vector2(0, -1)));
            keybinds.Add(Keys.S, new MoveCommand(new Vector2(0, 1)));

        }

        public void Execute()
        {
            KeyboardState keyState = Keyboard.GetState();

            foreach (Keys key in keybinds.Keys)
            {
                if (keyState.IsKeyDown(key))
                {
                    keybinds[key].Execute(Entity);
                }
            }
        }
    }
}
