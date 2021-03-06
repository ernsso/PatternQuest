﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.ComponentModel;

namespace RPG
{
    public class Item : IZoneContent
    {
        private SynchronizationContext context;

        public string Name { get; set; }
        public Location Location { get; private set; }
        public AbstractGameBoard GameBoard { get; private set; }
        public AbstractZone Zone
        {
            get
            {
                return GameBoard.GetAbstractZone(Location);
            }
            set
            {
                this.Location = value.Location;
                OnPropertyChanged("Location");
            }
        }

        public Item(AbstractGameBoard gameBoard, string n)
        {
            this.Name = n;
            this.GameBoard = gameBoard;

            this.context = SynchronizationContext.Current;
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
