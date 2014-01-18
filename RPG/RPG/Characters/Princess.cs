using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Princess : Character
    {
        public Princess(AbstractGameBoard gameBoard, string n)
            : base(gameBoard, n)
        {
            this.FightBehavior = null;
            this.EmitSoundBehavior = new ComportementParlerPrincesse();
        }

        public override string Show()
        {
            return "I'm the princess" + this.Name;
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
