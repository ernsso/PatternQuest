using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    abstract public class AbstractGameBoardFactory
    {
        abstract public AbstractGameBoard CreateBoard();
    }
}
