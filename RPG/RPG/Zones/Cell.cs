using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;

namespace RPG
{
    public enum CellType { Floor, Wall }
    public class Cell : AbstractZone
    {
        public CellType Type { get; set; }

        public Adjacent LeftAdjacent
        { 
            get { return (Adjacent)this.leftAccess; }
            set { this.leftAccess = value; }
        }
        public Adjacent TopAdjacent
        {
            get { return (Adjacent)this.topAccess; }
            set { this.topAccess = value; }
        }
        public Adjacent RightAdjacent
        {
            get { return (Adjacent)this.rightAccess; }
            set { this.rightAccess = value; }
        }
        public Adjacent BottomAdjacent
        {
            get { return (Adjacent)this.bottomAccess; }
            set { this.bottomAccess = value; }
        }

        public Cell(CellType type, Location location, Adjacent left = null, Adjacent top = null, Adjacent right = null, Adjacent bot = null) : base(location)
        {
            this.Content = null;
            this.Type = type;
            this.leftAccess = left;
            this.topAccess = top;
            this.rightAccess = right;
            this.bottomAccess = bot;
        }

        public override bool TrySetContent(IZoneContent content)
        {
            if (CanEnter)
            {
                this.Content = content;
                content.Zone = this;
                OnPropertyChanged("Content");
                return true;
            }
            return false;
        }
    }
}
