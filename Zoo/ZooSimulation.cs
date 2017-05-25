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
            timer = new Timer(timeback, null, 0, 5000);
            //добавимо декілька тваринок

            animals.Add(new Bear("Ted") );
            animals.Add(new Wolf("Vovk"));
            animals.Add(new Fox("Sister"));
            animals.Add(new Tiger("Bob"));

            Console.WriteLine("Виберiть дiю для тварини");
            Console.WriteLine("1 - щоб добавити ");
            Console.WriteLine("2 - щоб погодувати");
            Console.WriteLine("3 - щоб вилiкувати" );
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
                            "Яку тварину додати?\n 1-Ведмiдь \n 2-Слон\n 3-Лисицю\n 4-Лев\n 5-Тигер\n 6-Вовк");
                        int animalType = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Введiть iмя тварини :\t");
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
                        Console.WriteLine("доблено тварину {0} :\t", name);
                        break;
                        //нагодувати тварину
                    case 2:
                        Console.WriteLine("Яку тварину, або тварин ви хочете нагодувати? Покличте їх) (Введiть кличку) ");
                        name = Console.ReadLine();
                        for (int i = 0; i < animals.Count; i++)
                        {
                            if (animals[i].Alias == name)
                                animals[i].Feed();
                        }
                        Console.WriteLine("Ви нагодували {0}",name);
                        break;
                        // 
                    case 3:
                        Console.WriteLine("Введiть кличку тварин(и) якi ви хочете полiкувати ");
                        name = Console.ReadLine();
                        for (int i = 0; i < animals.Count; i++)
                        {
                            if (animals[i].Alias == name)
                                animals[i].Health++;
                        }
                        Console.WriteLine("Ви полiкували {0}", name);
                        break;
                    case 4:
                        Console.WriteLine("Яку тварину видалити? Введiть кличку ");
                        name = Console.ReadLine();
                        for (int i = 0; i < animals.Count; i++)
                        {
                            if (animals[i].Alias == name && animals[i].Condition == Condition.Dead)
                            { 
                                animals.Remove(animals[i]);
                            Console.WriteLine("{0} видалено", name);
                            }
                        }
                       
                        break;
                                              
                   
                    default:
                        break;
                }
                if (animals.Count == 0)
                {
                    Console.WriteLine("\n\nВсi тварини померли...");
                }



            }

        }
        
    }
}
