using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame
{
    class Tank : IObject
    {
        public int Armor { get; set; }              //«Броня»
        public double Life { get; set; }            //«Жизнь»
        public double Health { get; set; }          //«Здоровье, которое в течение изменяется»
        public int Damage { get; set; }             //«Урон»
        public int CountBullet { get; set; }        //«Кол-во патронов» 
        public Tank(int armor, double life, int damage, int bullet)
        {
            this.Armor = armor;
            this.Life = this.Health = life;
            this.Damage = damage;
            this.CountBullet = bullet;
        }

        public void Shot(Tank B, int Probability)
        {
            //нанесение урона с учетом брони и вероятностью критического урона или
            B.Health = (this.Damage - B.Armor) + ((this.Damage - B.Armor) * (Probability / 100));
            this.CountBullet--;
        }
        public void Repair()
        {/*увеличение жизни на 50% от урона*/
            if(this.Health < this.Life)  this.Health += (this.Damage * 0.5);
            /*Если уровень здаровья превышает начальные показания, то вычитаем лишние*/
            if (this.Health >= this.Life)  this.Health -= (this.Health - this.Life);
        }
        public void BuyBullet(int N) {//покупка пуль
            this.CountBullet += N;
        }
        ~Tank() { }
    }
}
