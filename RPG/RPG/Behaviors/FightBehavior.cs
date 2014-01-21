using System.Linq;

namespace RPG
{
    public class FightBehavior : IAction
    {
        protected int bareHandAttack = 2;
        protected Character attacker, target;

        public FightBehavior(Character a, Character t)
        {
            this.attacker = a;
            this.target = t;
        }
        
        public bool Execute()
        {
            this.target.HP -= this.bareHandAttack;
            return true;
        }
    }
}
