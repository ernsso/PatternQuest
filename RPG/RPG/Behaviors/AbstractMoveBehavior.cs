using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public abstract class AbstractMoveBehavior : IAction
    {
        protected Character character;
        public AbstractMoveBehavior(Character c)
        {
            this.character = c;
        }

        public abstract bool Execute();
    }
}
