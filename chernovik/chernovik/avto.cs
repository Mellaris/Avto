using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace chernovik
{
    internal class avto
    {
        private string number;
        private float kol_benz;
        private float rasxod;
        private int speed;
        private string otvet = "";
        private int benz = 0;
        private float itog = 0;
        private float x;
        private float y;
        private float ostatok;
        private int road;
        float counter = 0;
        float km;

        public void Info()
        {
            Console.WriteLine("Введите номер вашего авто: ");
            number = Console.ReadLine();
            Console.WriteLine("Введите количество вашего бензина: ");
            kol_benz = float.Parse(Console.ReadLine());
            Console.WriteLine("Введите расход на 100км: ");
            rasxod = float.Parse(Console.ReadLine());
            Console.WriteLine("Введите с какой скоростью хотите ехать: ");
            speed = Convert.ToInt32(Console.ReadLine());
        }
        public void Challenge()
        {
            Console.WriteLine($"Номер вашего авто: {number}; Количество бензина: {kol_benz}; Расход на 100км: {rasxod}; Ваша скорость: {speed}");
        }
        private void Refill()
        {
            Console.WriteLine("Хотите заправить авто?");
            Console.WriteLine("Напишите ниже: 'Да' или 'Нет'.");
            otvet = Console.ReadLine();
            if (otvet == "Да")
            {
                Console.Write("Укажите сколько хотите добавить литров бензина: ");
                benz = Convert.ToInt32(Console.ReadLine());
                kol_benz = kol_benz + benz;
                Console.WriteLine($"Количество вашего бензина: {kol_benz}");
                if (benz < itog)
                {
                    itog = itog - benz;
                }
                else 
                {
                    y = itog - benz;
                    kol_benz = kol_benz - x;
                    Ostatok();
                }
            }
            else if (otvet == "Нет")
            {
                km = rasxod / 100;
                km = km * kol_benz;
                Console.WriteLine($"Вам хватит на {km} km");
                Ostatok();
            }
        }
        public void Trip()
        {
            
            do { 
            Random random = new Random();
            road = random.Next(5, 2000);
            Console.WriteLine($"Необходимо проехать: {road}");
            if (speed > 90)
                {
                    x = road * rasxod * 2 / 100;
                }
            else if (speed < 60)
                {
                    x = road * rasxod / 2 / 100;
                }
                else
                {
                    x = road * rasxod / 100;
                }
                
                if (x < kol_benz || x == kol_benz)
                {
                    Console.WriteLine("Вам хватает бензина");
                    kol_benz = kol_benz - x;
                    Ostatok();
                    Refill();
                    Mileage();
                }
                itog = x - kol_benz;
                y = itog;
                do
                {
                    if (x > kol_benz)
                    {
                        itog = x - kol_benz;
                        Console.WriteLine($"Вам не хватает: {itog} литров бензина");
                        Refill();
                        if (y < kol_benz)
                        {
                            Mileage();
                        }
                        
                        if (otvet == "Нет")
                        {
                            break;
                        }
                    }
                } while (y >= kol_benz);
            } while (otvet == "Да");
        }

        private void Ostatok()
        {
            ostatok = kol_benz;
            Console.WriteLine($"У вас осталось: {ostatok} литров бензина");
        }
        public void Braking()
        { }
        public void Overclocking()
        { }
        private void Mileage()
        {
                counter = counter + road;
                Console.WriteLine($"Общий пробег: {counter}");
        }

    }
}
