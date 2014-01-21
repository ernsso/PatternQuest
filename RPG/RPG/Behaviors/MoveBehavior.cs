using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class MoveBehavior : AbstractMoveBehavior
    {
        private Direction direction;

        public MoveBehavior(Character c, Direction d) : base(c)
        {
            this.direction = d;
        }

        public override bool Execute()
        {
            bool result = false;
            if (this.character.HP > 0)
            {
                Location moveLocation = this.character.Location.GetAdjacentLocation(direction);
                if (this.character.GameBoard.InBounds(moveLocation))
                {
                    AbstractZone toZone = this.character.GameBoard.GetAbstractZone(moveLocation);
                    AbstractZone fromZone = this.character.GameBoard.GetAbstractZone(character.Location);
                    fromZone.RemoveContent();
                    result = toZone.TrySetContent(this.character);
                    this.character.HP -= 2;
                }
            }
            return result;
        }
    }
}
