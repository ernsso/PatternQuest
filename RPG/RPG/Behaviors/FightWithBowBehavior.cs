using System;
using System.Linq;

namespace RPG
{
    public class FightWithBowBehavior : FightBehavior
    {
        public FightWithBowBehavior(Character a, Character t)
            : base(a, t)
        {
        }

        new public bool Execute()
        {
            bool result = false;
            if (this.attacker.Weapon != null)
            {
                this.target.HP -= this.attacker.Weapon.Attack;
                result = true;
            }
            return result;
        }
    }
}
