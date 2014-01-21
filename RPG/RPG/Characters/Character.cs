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
        public Weapon Weapon { get; protected set; }
        public Organization Organization { get; set; }
        public Location Location { get; protected set; }
        public AbstractGameBoard GameBoard { get; set; }
        public IAction Action { get; protected set; }
        public FightBehavior FightBehavior { get; set; }
        public AbstractMoveBehavior MoveBehavior { get; set; }
        public IZoneContent Goal{ get; set; }

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
            this.Action = new RandomMoveBehavior(this);
            this.inventory = new List<Item>();

            this.context = SynchronizationContext.Current;
        }

        virtual public string Show()
        {
            return this.Name;
        }
        
        virtual public bool Move()
        {
            this.MoveBehavior = new RandomMoveBehavior(this);
            return this.MoveBehavior.Execute();
        }

        virtual public bool Move(Direction direction)
        {
            this.Action = new MoveBehavior(this, direction);
            return this.Action.Execute();
        }

        virtual public bool Fight(Character target)
        {
            this.FightBehavior = new FightBehavior(this, target);
            return this.FightBehavior.Execute();
        }

        public void Execute(IAction action)
        {
            action.Execute();
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
