using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    abstract public class AbstractObservedSubject
    {
        protected List<AbstractObserver> ObserverList = new List<AbstractObserver>();

        public void Attach(AbstractObserver observer)
        {
            this.ObserverList.Add(observer);
        }

        public void Detach(AbstractObserver observer)
        {
            this.ObserverList.Remove(observer);
        }

        public void Notify()
        {
            foreach (AbstractObserver o in this.ObserverList)
            {
                o.Update();
            }
        }
    }
}
