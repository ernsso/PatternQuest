using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class GameBoard : AbstractGameBoard
    {
        public GameBoard() : base()
        {
        }

        public GameBoard(int rowNumber, int columnNumber) : this()
        {
            this.Load(rowNumber, columnNumber);
        }

        public override void Load(int rowNumber, int columnNumber)
        {
            Cell anotherCell;
            for (int i = 0; i < rowNumber; i++)
            {
                for (int j = 0; j < columnNumber; j++)
                {
                    Cell cell = new Cell(CellType.Floor, new Location(i, j));
                    if ((anotherCell = this.GetCell(i, j - 1)) != null)
                        this.accessList.Add(cell.LeftAdjacent = new Adjacent(cell, anotherCell));
                    if ((anotherCell = this.GetCell(i - 1, j)) != null)
                        this.accessList.Add(cell.TopAdjacent = new Adjacent(cell, anotherCell));
                    if ((anotherCell = this.GetCell(i, j + 1)) != null)
                        this.accessList.Add(cell.RightAdjacent = new Adjacent(cell, anotherCell));
                    if ((anotherCell = this.GetCell(i + 1, j)) != null)
                        this.accessList.Add(cell.BottomAdjacent = new Adjacent(cell, anotherCell));
                    this.zoneList.Add(cell);
                }
            }

            OnPropertyChanged("GameBoardState");
            this.GameBoardState = GameBoardState.Running;
        }

        public Cell GetCell(int rowNumber, int columnNumber)
        {
            return (Cell)base.GetAbstractZone(rowNumber, columnNumber);
        }

        public Cell GetCell(Location location)
        {
            return (Cell)base.GetAbstractZone(location);
        }
    }
}
