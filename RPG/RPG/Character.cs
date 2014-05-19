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
        public int HP { get; set; }
        public string Name { get; set; }
        public Location Location { get; set; }
        public AbstractGameBoard GameBoard { get; set; }
        public Organization Organization { get; set; }
        public FightBehavior FightBehavior { get; set; }
        public EmitSoundBehavior EmitSoundBehavior { get; set; }
        public MoveBehavior MoveBehavior { get; set; }
        public List<Item> inventory;

        private SynchronizationContext context;

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
            this.FightBehavior = null;
            this.EmitSoundBehavior = null;
            this.MoveBehavior = new MoveBehavior();
            this.inventory = new List<Item>();
        }

        virtual public string Show()
        {
            return this.Name;
        }

        virtual public string EmitSound()
        {
            if (this.EmitSoundBehavior != null)
                return this.EmitSoundBehavior.EmitSound();
            return "noise";
        }

        virtual public bool Move(Direction direction)
        {
            if (this.MoveBehavior != null)
                return this.MoveBehavior.Move(this, direction);
            return false;
        }

        virtual public string Fight()
        {
            if (this.FightBehavior != null)
                return this.FightBehavior.Fight();
            return "I don't fight."; 
        }

        public override void Update() { }
        public void Update(Mode m)
        {
            switch(m)
            {
                case Mode.DontMove:
                    this.MoveBehavior = new DontMoveBehavior();
                    break;
                case Mode.InPeace:
                    break;
                case Mode.InWar:
                    break;
                case Mode.Move:
                    this.MoveBehavior = new MoveBehavior();
                    break;
                case Mode.Withdrawal:
                    break;
                default :
                    break;
            }
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
