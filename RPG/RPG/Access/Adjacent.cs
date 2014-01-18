using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Adjacent : AbstractAccess
    {
        public Adjacent(Cell a, Cell b)
        {
            this.A = a;
            this.B = b;
            this.CanGoToA = true;
            this.CanGoToB = true;
        }
    }
}
