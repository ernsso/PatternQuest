using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class GameEnvironment
    {
        public AbstractGameBoard GameBoard { get; private set; }

        public GameEnvironment(AbstractGameBoardFactory factory)
        {
            this.GameBoard = factory.CreateBoard();
        }
    }
}
