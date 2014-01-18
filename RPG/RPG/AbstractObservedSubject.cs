using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    abstract public class AbstractObservedSubject
    {
        protected List<AbstractObserver> ObserverList;
        abstract public void Attach();
        abstract public void Detach();
        abstract public void Notify();
    }
}
