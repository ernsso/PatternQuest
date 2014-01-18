using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Location
    {
        public int RowNumber
        {
            get;
            private set;
        }
        public int ColumnNumber
        {
            get;
            private set;
        }

        public Location(int rowNumber, int columnNumber)
        {
            RowNumber = rowNumber;
            ColumnNumber = columnNumber;
        }

        public Location GetAdjacentLocation(Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    return new Location(RowNumber - 1, ColumnNumber);
                case Direction.Down:
                    return new Location(RowNumber + 1, ColumnNumber);
                case Direction.Left:
                    return new Location(RowNumber, ColumnNumber - 1);
                case Direction.Right:
                    return new Location(RowNumber, ColumnNumber + 1);
                default:
                    throw new Exception("Unkown direction. " + direction.ToString("G"));
            }
        }

        public bool IsAdjacentLocation(Location location)
        {
            return !location.Equals(this)
                   && ((ColumnNumber == location.ColumnNumber
                        && RowNumber <= location.RowNumber + 1
                        && RowNumber >= location.RowNumber - 1)
                       ||
                       (RowNumber == location.RowNumber
                        && ColumnNumber <= location.ColumnNumber + 1
                        && ColumnNumber >= location.ColumnNumber - 1)
                      );
        }

        public Direction GetDirection(Location location)
        {
            if (!IsAdjacentLocation(location))
            {
                throw new Exception("location is not adjacent.");
            }

            if (location.ColumnNumber > ColumnNumber)
            {
                return Direction.Right;
            }
            else if (location.ColumnNumber < ColumnNumber)
            {
                return Direction.Left;
            }
            else if (location.RowNumber > RowNumber)
            {
                return Direction.Down;
            }

            return Direction.Up;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Location loc = obj as Location;
            if (loc == null)
            {
                return false;
            }
            return loc.RowNumber == RowNumber && loc.ColumnNumber == ColumnNumber;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:Location"/>.
        /// The XOR of the <see cref="RowNumber"/> and <see cref="ColumnNumber"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return RowNumber ^ ColumnNumber;
        }

        public override string ToString()
        {
            return string.Format("Column {0}, Row {1}", ColumnNumber, RowNumber);
        }
    }
}
