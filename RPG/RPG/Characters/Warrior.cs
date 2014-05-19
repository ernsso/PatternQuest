using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Warrior : Character
    {
        public Warrior(AbstractGameBoard gameBoard, string n)
            : base(gameBoard ,n)
        {
            this.FightBehavior = new ComportementApiedAvecHache();
            this.EmitSoundBehavior = new ScreamBehavior();
            this.State = true;
            this.LosePower = 2;
        }

        public override string Show()
        {
            return "I'm the bloody " + this.Name;
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
