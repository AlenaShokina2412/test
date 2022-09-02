using System;
using System.Collections.Generic;
using System.Text;

namespace TestGame
{
    class Object : IComputer, IObject
    {
        public int Armor { get; set; }          //«Броня»
        public double Life { get; set; }        //«Жизнь»
        public double Health { get; set; }      //«Здоровье, которое в течение изменяется»
        public int Damage { get; set; }         //«Урон»
        public int CountBullet { get; set; }    //«Кол-во патронов» 
        public int BuyCount = 3;                //«Возможное кол-во патронов»

        public Object TankComputer;
        public Object TankPlayer;

        /*Конструктор*/
        public Object(int Armor, double Life, int Damage, int CountBullet, int Armor1, double Life1, int Damage1, int CountBullet1) {
            TankPlayer = new Object(Armor, Life, Damage, CountBullet);
            TankComputer = new Object(Armor1, Life1, Damage1, CountBullet1);
        }
        public Object(int Armor, double Life, int Damage, int CountBullet)
        {
            this.Armor = Armor;
            this.Life = this.Health =Life;
            this.Damage = Damage;
            this.CountBullet = CountBullet;
        }
        /*Урон*/
        public double Shot( int EnemyArmor, int Probability) { 
            //нанесение урона с учетом брони и вероятностью критического урона или промаха
            double EnemyHealth = (this.Damage - EnemyArmor) + ((this.Damage - EnemyArmor) * (Probability / 100));
            this.CountBullet--;
            return EnemyHealth;
        }
        /*Починка*/
        public void Repair(){
            if (this.Health < this.Life) this.Health += (this.Damage * 0.5);
            /*Если уровень здаровья превышает начальные показания, то вычитаем лишние*/
            if (this.Health >= this.Life) this.Health -= (this.Health - this.Life);
        }
        /*Покупка пуль*/
        public void BuyBullet(int N){
            this.CountBullet += N;
        }
        /*Ход компьютера*/
        public double ComputerStep( double TankPlayerHealth, int TankPlayerArmor) {
            Random rnd = new Random();      // для случайного выбора действия
            int StepComputer;
            double HealthEnemy = 0;         //Здоровье пративника, которое отнимается у него при ударе

            if (this.Health == this.Life){   //Если максимальное здоровье, то выполняется только выстрел 
                StepComputer = 1;
            } 
            else {                           //Если нет, выбирается случайным образом действие
                StepComputer = rnd.Next(1, 3); 
            }    
            if (StepComputer == 1){         // При StepComputer=1 компьютер совершает удар
                if (this.CountBullet == 0) {           //Если закончились патроны, компьютер покупает их и выполняет выстрел.
                    this.BuyBullet(BuyCount);
                }
                HealthEnemy = this.Shot( TankPlayerArmor, 1);
                Console.WriteLine($"Вам нанесли урон.");
            } 
            else { this.Repair(); }         //иначе совершается восстановление
            return HealthEnemy;
        }
        
        public void AlgorithmGame(){
            int CountShot = 1;
            /*Первый шаг делает игрок, после делает шаг компьютер */
            while ((this.TankPlayer.Health > 0 && this.TankComputer.Health > 0)) {
                Console.WriteLine($"Жизни моего танка: {this.TankPlayer.Health}, кол-во пуль: {this.TankPlayer.CountBullet}");
                Console.WriteLine($"Жизни танка противник: {this.TankComputer.Health}, кол-во пуль: {this.TankComputer.CountBullet}");
                Console.WriteLine("Выберите требуемое действие(при выборе нажмите цифру 1,2 или 3):\n 1.Огонь\n 2.Ремонт \n 3.Купить патроны\n");
                string StepPlayer = Console.ReadLine();   // получаем число от 1 до 3
                switch (StepPlayer)
                {
                    case "1":     // Выстрел
                        if (this.TankPlayer.CountBullet == 0){   // При нехватки патронов, игрок не может стрелять 
                            Console.WriteLine("Не хватает патронов, необходимо их купить! \n");
                            continue;
                        }
                        if (CountShot % 3 == 0){   // каждый 3 удар с промохом
                            this.TankComputer.Health -= this.TankPlayer.Shot( TankComputer.Armor, -10);  // удар с вероятностью промоха
                        }
                        else this.TankComputer.Health -= this.TankPlayer.Shot( TankComputer.Armor, 20);// удар с вероятностью критического удара
                        Console.WriteLine("Вы нанесли урон.");
                        break;
                    case "2":     //Починка 
                        this.TankPlayer.Repair();
                        Console.WriteLine("Ваш танк восстановлен.");
                        break;
                    case "3":     //Покупка пуль
                        this.TankPlayer.BuyBullet(BuyCount);
                        break;
                    default:    // При неверном ввидении выводится предупреждение
                        Console.WriteLine("Неверное указанно действие(при выборе необходимо нажать цифру 1,2 или 3)");
                        continue;
                }
                this.TankPlayer.Health -= this.TankComputer.ComputerStep(TankPlayer.Health, TankPlayer.Armor);
                Console.WriteLine("Для продолжения игры нажмите любую клавишу...");
                Console.ReadLine(); 
                CountShot++;
            }
            /*Вывод результатов игры*/
            if (this.TankPlayer.Health < 0 && this.TankComputer.Health < 0){
                Console.WriteLine("Ничья");
            }else{
                if (TankPlayer.Health > 0){
                    Console.WriteLine("Вы победили");
                }else{
                    Console.WriteLine("Вы проиграли");
                }
            }
        }
        ~Object() { }
    }
}
