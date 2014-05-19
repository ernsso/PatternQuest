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
          

                Location moveLocation = character.Location.GetAdjacentLocation(direction);
                if (moveLocation.ColumnNumber >= 0 || moveLocation.ColumnNumber <= 10)
                {
                    if (moveLocation.RowNumber >= 0 || moveLocation.RowNumber <= 10)
                    {
                        if (character.GameBoard.InBounds(moveLocation))
                        {
                            lock (this)
                            {
                                AbstractZone toZone = character.GameBoard.GetAbstractZone(moveLocation);
                                AbstractZone fromZone = character.GameBoard.GetAbstractZone(character.Location);
                                fromZone.RemoveContent();
                                result = toZone.TrySetContent(character);
                                character.HP -= character.LosePower;
                                if (character.HP == 0)
                                {
                                    
                                    AbstractZone fromZone2 = character.GameBoard.GetAbstractZone(character.Location);
                                    fromZone2.RemoveContent();
                                }
                            }
                        }
                    }
                }
           
              
            return result;
        }
    }
}
