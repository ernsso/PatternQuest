using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    abstract public class AbstractObserver
    {
        protected AbstractObservedSubject observedSubject;
        abstract public void Update();
    }
}
