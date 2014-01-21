using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public enum Mode
    {
        Undefined, InWar, InPeace, Withdrawal
    }

    public class Organization : AbstractObservedSubject
    {
        private Mode mode;

        public Mode Mode
        {
            get { return this.mode; }
            set { this.mode = value; this.Notify(); }
        }
        public Organization parent { get; set; }

        public Organization()
        { }

        public Organization(Organization _parent)
        {
            this.parent = _parent;
        }

        public void Order(IAction action)
        {
            foreach (Character c in this.ObserverList)
            {
                c.Execute(action);
            }
        }
    }
}
