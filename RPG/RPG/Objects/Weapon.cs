using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    public class Weapon : Item
    {
        public WeaponType Type { get; set; }
        public int Attack { get; set; }

        public Weapon(AbstractGameBoard gameBoard, string n, int a, WeaponType wt)
            : base(gameBoard, n)
        {
            this.Attack = a;
            this.Type = wt;
        }
    }
}
