using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class Princess : Character
    {
        new public Weapon Weapon { get { return null; } private set { } }
     
        public Princess(AbstractGameBoard gameBoard, string n)
            : base(gameBoard, n)
        {
        }

        public override string Show()
        {
            return "I'm the princess" + this.Name;
        }

        new public bool Fight(Character target)
        {
            return false;
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
    }
}
