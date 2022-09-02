using System;

namespace TestGame
{ 
    class Program
    {
        /*жизнь, урон и броня компьютера*/
        const double LifeTankPlayer = 30;
        const int ArmorTankPlayer = 4;
        const int DamageTankPlayer = 6;

        /*жизнь, урон и броня игрока*/
        const double LifeTankComputer = 20;
        const int ArmorTankComputer = 3;
        const int DamageTankComputer = 7;

        static void Main(string[] args)
        {
            /*Создание объекта и запуск игры(каждому дается по 5 пуль)*/
            Object Gme = new Object(ArmorTankPlayer,LifeTankPlayer,DamageTankPlayer, 5 , ArmorTankComputer, LifeTankComputer,  DamageTankComputer,5);
            Gme.AlgorithmGame();
        }
    }
}
