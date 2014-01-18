using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Knight : Character
    {
        public Knight(AbstractGameBoard gameBoard, string n)
            : base(gameBoard, n)
        {
            this.FightBehavior = new ComportementAcheval();
            this.EmitSoundBehavior = new ScreamBehavior();
        }

        public override string Show()
        {
            return "I'm the knight" + this.Name;
        }

        public override string EmitSound()
        {
            return "I bawl !!";
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
