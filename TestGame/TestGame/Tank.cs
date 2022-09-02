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

        public double Shot(  int EnemyArmor, int Probability)
        {
            double EnemyHealth = 0.0;
            //нанесение урона с учетом брони и вероятностью критического урона или
            EnemyHealth = (this.Damage - EnemyArmor)+((this.Damage - EnemyArmor)* (Probability / 100));
            this.CountBullet--;
            return EnemyHealth;
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
