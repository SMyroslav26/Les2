using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Zoo.Animals;

namespace Zoo
{
    class ZooSimulation
    {
        private Timer timer;
        private Random random = new Random();

     public   List<Animal> animals =new List<Animal>();
      
            
        private void ChangeSomeAnimal(object someOBJ)
        {
            if (animals.Count != 0)
            {
                animals[random.Next(0, animals.Count - 1)].changeCondition();
            }
        }

        
        public void Start()
       {
            TimerCallback timeback = new TimerCallback(ChangeSomeAnimal);
            timer = new Timer(timeback, null, 0, 15000);
            //добавимо декілька тваринок

            animals.Add(new Bear("Тед") );
            animals.Add(new Fox("Сестричка"));

            Console.WriteLine("Виберіть дію для тварини");
            Console.WriteLine("1 - щоб добавити ");
            Console.WriteLine("2 - щоб погодувати");
            Console.WriteLine("3 - щоб вилікувати" );
            Console.WriteLine("4 -Видалити мертвих тварин з зоопарку");
            while (animals.Count() != 0)
            {
                //початок 
                int variant = Convert.ToInt32(Console.ReadLine());
                switch (variant)
                {
                    //додати тварину
                    case 1:
                        Console.WriteLine(
                            "Яку тварину додати?\n 1-Ведмідь \n 2-Слон\n 3-Лисицю\n 4-Лев\n 5-Тигер\n 6-Вовк");
                        int animalType = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введіть імя тварини :\t");
                        var name = Console.ReadLine();
                        switch (animalType)
                        {
                            case 1:
                                animals.Add(new Bear(name) );
                                break;
                            case 2:
                                animals.Add(new Elephant(name));
                                break;
                            case 3:
                                animals.Add(new Fox(name));
                                break;
                            case 4:
                                animals.Add(new Lion(name));
                                break;
                            case 5:
                                animals.Add(new Tiger(name));
                                break;
                            case 6:
                                animals.Add(new Wolf(name));
                                break;
                            default:
                                break;
                        }
                        break;
                        //нагодувати тварину
                    case 2:
                        Console.WriteLine("Яку тварину, або тварин ви хочете нагодувати? Покличте їх) (Введіть кличку) ");
                        name = Console.ReadLine();
                        for (int i = 0; i < animals.Count; i++)
                        {
                            if (animals[i].Alias == name)
                                animals[i].Feed();
                        }
                        break;
                        // 
                    case 3:
                        Console.WriteLine("Введіть кличку тварин(и) які ви хочете полікувати ");
                        name = Console.ReadLine();
                        for (int i = 0; i < animals.Count; i++)
                        {
                            if (animals[i].Alias == name)
                                animals[i].Health++;
                        }
                        break;
                    case 4:
                    //    animals.Remove
                        break;
                    case 5:
                     //   animals.ShowAnimals();
                        break;
                    default:
                        break;
                }
                if (animals.Count == 0)
                {
                    Console.WriteLine("\n\nВсі тварини померли...");
                }



            }

        }
        
    }
}
