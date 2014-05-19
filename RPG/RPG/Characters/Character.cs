using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RPG
{
    abstract public class Character : AbstractObserver, IZoneContent
    {
        public List<Item> inventory;

        private int hp;
        private SynchronizationContext context;

        public string Name { get; set; }
        public Location Location { get; private set; }
        public AbstractGameBoard GameBoard { get; set; }
        public MoveBehavior MoveBehavior { get; set; }
        public FightBehavior FightBehavior { get; set; }
        public EmitSoundBehavior EmitSoundBehavior { get; set; }
        public IZoneContent Goal{ get; set; }
        public Boolean State { get; set; }
        public int LosePower { get; set; }

        public int HP
        {
            get { return this.hp; }
            set { this.hp = value; OnPropertyChanged("HP"); }
        }
        public AbstractZone Zone
        {
            get
            {
                return GameBoard.GetAbstractZone(Location);
            }
            set
            {
                this.Location = value.Location;
                OnPropertyChanged("Cell");
                OnPropertyChanged("Location");
            }
        }

        public Character(AbstractGameBoard gameBoard, string n)
        {
            this.HP = 100;
            this.Name = n;
            this.GameBoard = gameBoard;
            this.MoveBehavior = new MoveBehavior();
            this.FightBehavior = null;
            this.EmitSoundBehavior = null;
            this.inventory = new List<Item>();

            this.context = SynchronizationContext.Current;
        }

        virtual public string Show()
        {
            return this.Name;
        }

        virtual public string EmitSound()
        {
            if (null != this.EmitSoundBehavior)
                return this.EmitSoundBehavior.EmitSound();
            return "noise";
        }

        virtual public bool Move(Direction direction)
        {
            if (null == this.MoveBehavior)
                this.MoveBehavior = new MoveBehavior();
            return this.MoveBehavior.Move(this, direction);
        }

        virtual public string Fight()
        {
            if (null != this.FightBehavior)
                return this.FightBehavior.Fight();
            return "I don't fight."; 
        }

        public override void Update()
        {
            throw new NotImplementedException();
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
                OnPropertyChanged(new PropertyChangedEventArgs(property));
            }
        }
        #endregion
    }
}
