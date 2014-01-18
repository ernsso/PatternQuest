using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RPG
{
    abstract public class AbstractGameBoard : INotifyPropertyChanged
    {
        protected List<AbstractZone> zoneList;
        protected List<AbstractAccess> accessList;
        private SynchronizationContext context;

        public GameBoardState GameBoardState { get; protected set; }

        protected AbstractGameBoard()
        {
            this.zoneList = new List<AbstractZone>();
            this.accessList = new List<AbstractAccess>();
            this.context = SynchronizationContext.Current;
        }

        public abstract void Load(int rowNumber, int columnNumber);

        public void AddZone(AbstractZone z)
        {
            this.zoneList.Add(z);
            this.OnPropertyChanged("GameBoardState");
        }

        public void AddAccess(AbstractAccess a)
        {
            this.accessList.Add(a);
            this.OnPropertyChanged("GameBoardState");
        }

        public int GetRowCount()
        {
            return this.zoneList.Max(c => c.Location.RowNumber) + 1;
        }

        public int GetColumnCount()
        {
            return this.zoneList.Max(c => c.Location.ColumnNumber) + 1;
        }

        public AbstractZone GetFirstZone()
        {
            return this.zoneList.First(); ;
        }

        public bool InBounds(Location location)
        {
            return (location.RowNumber >= 0
                && location.RowNumber < this.GetRowCount()
                && location.ColumnNumber >= 0
                && location.ColumnNumber < this.GetColumnCount());
        }

        public AbstractZone GetAbstractZone(int rowNumber, int columnNumber)
        {
            return this.zoneList.Find(c => c.Location.RowNumber == rowNumber && c.Location.ColumnNumber == columnNumber);
        }

        public AbstractZone GetAbstractZone(Location location)
        {
            return this.zoneList.Find(c => c.Location.RowNumber == location.RowNumber && c.Location.ColumnNumber == location.ColumnNumber);
        }

        #region PropertyChangedEventHandler
        event PropertyChangedEventHandler propertyChanged;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                propertyChanged += value;
            }
            remove
            {
                propertyChanged -= value;
            }
        }

        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (propertyChanged != null)
            {
                propertyChanged(this, e);
            }
        }

        protected void OnPropertyChanged(string property)
        {
            if (context != null)
            {
                context.Send(delegate
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(property));
                }, null);
            }
            else
            {
                context = SynchronizationContext.Current;
                if (context == null)
                {
                    OnPropertyChanged(new PropertyChangedEventArgs(property));
                }
                else
                {
                    OnPropertyChanged(property);
                }
            }
        }
        #endregion
    }
}
