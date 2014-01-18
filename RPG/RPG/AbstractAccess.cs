using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    abstract public class AbstractAccess
    {
        protected AbstractZone A { get; set; }
        protected AbstractZone B { get; set; }
        protected bool CanGoToA { get; set; }
        protected bool CanGoToB { get; set; }
    }
}
