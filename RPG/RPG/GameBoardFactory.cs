using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG
{
    public class GameBoardFactory : AbstractGameBoardFactory
    {
        public override AbstractGameBoard CreateBoard()
        {
            return new GameBoard();
        }
    }
}
