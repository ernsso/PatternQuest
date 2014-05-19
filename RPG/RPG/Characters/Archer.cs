using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Archer : Character
    {
        public Archer(AbstractGameBoard gameBoard, string n)
            : base(gameBoard, n)
        {
            this.FightBehavior = new ComportementAvecArc();
            this.EmitSoundBehavior = new TalkBehavior();
            this.State = true;
            this.LosePower = 10;
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
