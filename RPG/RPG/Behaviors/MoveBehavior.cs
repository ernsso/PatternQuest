using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class MoveBehavior : IAction
    {
        private Character character;
        private Direction direction;

        public MoveBehavior(Character c, Direction d)
        {
            this.character = c;
            this.direction = d;
        }

        public bool Execute()
        {
            bool result = false;
            if (character.HP > 0)
            {
                Location moveLocation = character.Location.GetAdjacentLocation(direction);
                if (character.GameBoard.InBounds(moveLocation))
                {
                    AbstractZone toZone = character.GameBoard.GetAbstractZone(moveLocation);
                    AbstractZone fromZone = character.GameBoard.GetAbstractZone(character.Location);
                    fromZone.RemoveContent();
                    result = toZone.TrySetContent(character);
                    character.HP -= 2;
                }
            }
            return result;
        }
    }
}
