using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class Treasure : Item
    {
        public int Value { get; set; }

        public Treasure(AbstractGameBoard gameBoard, string n, int value) : base(gameBoard, n)
        {
            this.Value = value;
        }
    }
}
