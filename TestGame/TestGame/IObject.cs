using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame
{
    interface IObject   // интерфейс обекта 
    {
        public int Armor { get; set; }          //«Броня»
        public double Life { get; set; }           //«Жизнь»
        public double Health { get; set; }         //«Здоровье, которое в течение изменяется»
        public int Damage { get; set; }         //«Урон»
        public int CountBullet { get; set; }    //«Кол-во патронов»
        
        public void Shot(Tank B, int Probability);   //урон
        public void Repair();           //починка
        public void BuyBullet(int N);   // покупка пуль
    }
}
