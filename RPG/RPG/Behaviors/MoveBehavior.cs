using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class MoveBehavior
    {
        public bool Move(Character character, Direction direction)
        {
            bool result = false;
            if (character.HP > 0)
            {
                Location moveLocation = character.Location.GetAdjacentLocation(direction);
                if (character.GameBoard.InBounds(moveLocation))
                {
                    lock (this)
                    {
                        AbstractZone toZone = character.GameBoard.GetAbstractZone(moveLocation);
                        AbstractZone fromZone = character.GameBoard.GetAbstractZone(character.Location);
                        fromZone.RemoveContent();
                        result = toZone.TrySetContent(character);
                        character.HP -= 10;
                    }
                }
            }
            return result;
        }
    }
}
