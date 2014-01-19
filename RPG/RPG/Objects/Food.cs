using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Food : Item
    {
        public int HpRecovery { get; set; }

        public Food(AbstractGameBoard gameBoard, string n)
            : base(gameBoard, n)
        {
        }

        public Food(AbstractGameBoard gameBoard, string n, int h)
            : base(gameBoard, n)
        {
            this.HpRecovery = h;
        }
    }
}
