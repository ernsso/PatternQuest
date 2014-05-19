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
        public Mode mode { get; set; }
        public Organization parent { get; set; }

        public Organization()
        { }

        public Organization(Organization _parent)
        {
            this.parent = _parent;
        }

        public override void Notify()
        {
            throw new NotImplementedException();
        }

        public override void Attach()
        {
            throw new NotImplementedException();
        }

        public override void Detach()
        {
            throw new NotImplementedException();
        }
    }
}
