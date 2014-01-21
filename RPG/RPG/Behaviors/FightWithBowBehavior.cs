using System;
using System.Linq;

namespace RPG
{
    public class FightWithBowBehavior : FightBehavior
    {
        private Weapon weapon;

        public FightWithBowBehavior(Character a, Character t, Weapon w)
            : base(a, t)
        {
            this.weapon = w;
        }

        new public bool Execute()
        {
            bool result = true;
            try
            {
                this.target.HP -= this.attacker.inventory.Where(i => i.GetType().Equals(typeof(Weapon))).Cast<Weapon>().Where(w => w.Type == WeaponType.bow).Sum(w => w.Attack);
            }
            catch (Exception ex) { result = false; }
            return result;
        }
    }
}
