using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading;

namespace RPG
{
    abstract public class AbstractZone : INotifyPropertyChanged
    {
        public AbstractAccess topAccess;
        public AbstractAccess bottomAccess;
        public AbstractAccess leftAccess;
        public AbstractAccess rightAccess;

        private SynchronizationContext context = SynchronizationContext.Current;

        public Location Location { get; set; }
        public IZoneContent Content { get; protected set; }
        
        public AbstractZone(Location location)
        {
            this.Location = location;
            this.leftAccess = null;
            this.topAccess = null;
            this.rightAccess = null;
            this.bottomAccess = null;
        }

        public bool CanEnter
        {
            get
            {
                return this.Content == null;
            }
        }

        public void RemoveContent()
        {
            this.Content = null;
            OnPropertyChanged("Content");
        }

        public abstract bool TrySetContent(IZoneContent content);

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

        void OnPropertyChanged(PropertyChangedEventArgs e)
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
