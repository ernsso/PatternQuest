using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Assassin : Character
    {
        new public Weapon Weapon
        {
            get { return base.Weapon; }
            set
            {
                if (value.Type == WeaponType.sword || value.Type == WeaponType.dagger)
                    base.Weapon = value;
            }
        }

        public Assassin(AbstractGameBoard gameBoard, string n)
            : base(gameBoard, n)
        {
        }

        public override string Show()
        {
            return "I'm the assassin" + this.Name;
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
