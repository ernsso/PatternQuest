using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Zone : AbstractZone
    {
        public string Name { get; set; }
        public Character SelectedCharacter { get; set; }
        public int RowCount { get; set; }
        public int ColumnCount { get; set; }
        protected Cell[][] childs;

        public Zone(string name, Location location) : base(location)
        {
            this.Name = name;
        }

        public Zone(string name, Location location, Cell[][] c) : this(name, location)
        {
            this.childs = c;
        }

        public void Load(int rowCount, int columnCount)
        {
            this.RowCount = columnCount;
            this.ColumnCount = columnCount;
            this.childs = new Cell[rowCount][];
            for (int i = 0; i < rowCount; i++)
            {
                this.childs[i] = new Cell[columnCount];
                for (int j = 0; j < columnCount; j++)
                {
                    this.childs[i][j] = new Cell(CellType.Floor, new Location(i, j));
                    //if (j < 0)
                    //{
                    //    this.childs[i][j].leftAccess = new Adjacent((Cell)this.childs[i][j], (Cell)this.childs[i][j - 1]);
                    //}
                    //if (i < 0)
                    //{
                    //    this.childs[i][j].topAccess = new Adjacent((Cell)this.childs[i][j], (Cell)this.childs[i - columnCount][j]);
                    //}
                }
            }
        }

        public Cell getCell(int row, int column)
        {
            return this.childs[row][column];
        }

        public Cell getCell(Location location)
        {
            return this.getCell(location.RowNumber, location.ColumnNumber);
        }

        public bool InBounds(Location location)
        {
            return (location.RowNumber >= 0
                && location.RowNumber < RowCount
                && location.ColumnNumber >= 0
                && location.ColumnNumber < ColumnCount);
        }

        public override bool TrySetContent(IZoneContent content)
        {
            throw new NotImplementedException();
        }
    }
}
