using System;
using System.Collections.Generic;
using System.Text;

namespace NoughtsAndCrosses
{
    public interface IPlayer
    {
        Move GetNextMove(char[,] board);
    }
}
