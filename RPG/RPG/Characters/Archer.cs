using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Archer : Character
    {
        new public Weapon Weapon
        {
            get { return base.Weapon; }
            set
            {
                if (value.Type == WeaponType.bow)
                    base.Weapon = value;
            }
        }

        public Archer(AbstractGameBoard gameBoard, string n)
            : base(gameBoard, n)
        {
        }

        public override string Show()
        {
            return "I'm the archer" + this.Name;
        }

        public override bool Move(Direction direction)
        {
            return base.Move(direction);
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
