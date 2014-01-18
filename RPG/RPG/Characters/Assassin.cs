using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Assassin : Character
    {
        public Assassin(AbstractGameBoard gameBoard, string n)
            : base(gameBoard, n)
        {
            this.FightBehavior = new ComportementAvecDague();
            this.EmitSoundBehavior = new TalkBehavior();
        }

        public override string Show()
        {
            return "I'm the assassin" + this.Name;
        }

        public override string EmitSound()
        {
            return "...";
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
