using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public enum Direction
    {
        Up,Down,Left,Right
    }

    public class MoveCommand
    {
        Zone zone;

        public Direction Direction
        {
            get;
            private set;
        }

        public MoveCommand(Zone _zone, Direction _direction)
        {
            if (_zone == null)
            {
                throw new ArgumentNullException("zone");
            }
            Direction = _direction;
            this.zone = _zone;
        }

        public void Execute()
        {
            zone.SelectedCharacter.Move(Direction);
        }
    }
}
