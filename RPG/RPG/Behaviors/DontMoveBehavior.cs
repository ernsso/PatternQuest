using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class DontMoveBehavior : MoveBehavior
    {
        public bool Move(Character character, Direction direction)
        {
            return false;
        }
    }
}
