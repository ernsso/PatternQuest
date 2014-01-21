using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class RandomMoveBehavior : AbstractMoveBehavior
    {
        public RandomMoveBehavior(Character c) : base(c)
        {
        }

        public override bool Execute()
        {
            bool result = false;
            Random r = new Random();
            switch (r.Next(4))
            {
                case 1:
                    result = (new MoveBehavior(this.character, Direction.Up)).Execute();
                    break;
                case 2:
                    result = (new MoveBehavior(this.character, Direction.Down)).Execute();
                    break;
                case 3:
                    result = (new MoveBehavior(this.character, Direction.Left)).Execute();
                    break;
                case 4:
                    result = (new MoveBehavior(this.character, Direction.Right)).Execute();
                    break;
            }
            return result;
        }
    }
}
