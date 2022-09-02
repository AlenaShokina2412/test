using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame
{
    interface IComputer// интерфейс компьютера
    {
        double ComputerStep( double Health, int Armor);
    }
}
