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
        public ZooMethods zooMethods = new ZooMethods();
            
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

            animals.Add(new Bear("Ted"));
            animals.Add(new Wolf("Vovk"));
            animals.Add(new Fox("Sister"));
            animals.Add(new Tiger("Bob"));
            animals.Add(new Tiger("BigBob"));
            animals.Add(new Elephant("Slon"));
            animals.Add(new Lion("Leon"));


            Console.WriteLine("Виберiть дiю для тварини");
            Console.WriteLine("1 - щоб добавити ");
            Console.WriteLine("2 - щоб погодувати");
            Console.WriteLine("3 - щоб вилiкувати");
            Console.WriteLine("4 -Видалити мертвих тварин з зоопарку");
            Console.WriteLine("5 -для LINQ");
            while (animals.Count() != 0)
            {
                try
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
                                    animals.Add(new Bear(name));
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
                            Console.WriteLine("доблено {0} тварину {1} :\t", animals[animals.Count - 1].GetType().Name, name);
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
                            Console.WriteLine("Ви нагодували {0}", name);
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
                        // LINQ тут
                        case 5: // Linq Operations
                            {
                                Console.WriteLine("Виберіт дію: " +
                                    "\n1 Показать всех животных, сгруппированных по виду животного" +
                                    "\n2 Показать животных по состоянию - в параметрах передать Состояние" +
                                     "\n3 Показать всех тигров, которые больны" +
                                       "\n4 Показать слона с определенной кличкой, которая задается в параметре" +
                                              "\n5 Показать список всех кличек животных, которые голодны" +
                                        "\n6 Показать самых здоровых животных каждого вида(по одному на каждый вид)" +
                                        "\n7 Показать количество мертвых животных каждого вида" +
                                        "\n8 Показать всех волков и медведей, у которых здоровье выше 3" +
                                        "\n9 Показать животное с максимальным здоровьем и животное с минимальным здоровьем(описать одним выражением)" +
                                        "\n10 Показать средней количество здоровья у животных в зоопарке");


                                int linqSwitchOperator = Convert.ToInt32(Console.ReadLine());
                                switch (linqSwitchOperator)
                                {
                                    case 1:
                                        {
                                            zooMethods.ShowAllSortAnimals(animals);
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("Виберіть стан: \n1 Sated. \n2 Hungry. \n3 Ill.");
                                            int state = Convert.ToInt32(Console.ReadLine());
                                            switch (state)
                                            {
                                                case 1:
                                                    zooMethods.ShowAnimalsCond(Condition.Sated, animals);
                                                    break;
                                                case 2:
                                                    zooMethods.ShowAnimalsCond(Condition.Hungry, animals);
                                                    break;
                                                case 3:
                                                    zooMethods.ShowAnimalsCond(Condition.Ill, animals);
                                                    break;
                                                default:
                                                    break;
                                            }
                                            break;
                                        }
                                    case 3:
                                        {
                                            zooMethods.ShowIllTigers(animals);
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.WriteLine("Введіть кличку слона:");
                                            string elephantAlias = Console.ReadLine();
                                            zooMethods.ShowElephantAlias(elephantAlias, animals);
                                            break;
                                        }
                                    case 5:
                                        {
                                            zooMethods.HungryAnimalsAlias(animals);
                                            break;
                                        }
                                    case 6:
                                        {
                                            zooMethods.ShowTheHealthiestAnimals(animals);
                                            break;
                                        }
                                    case 7:
                                        {
                                            zooMethods.DeadAnimals(animals);
                                            break;
                                        }
                                    case 8:
                                        {
                                            zooMethods.WolfsBearsWitheHealth3(animals);
                                            break;
                                        }
                                    case 9:
                                        {
                                            zooMethods.ShowMaxAndMin(animals);
                                            break;
                                        }
                                    case 10:
                                        {
                                            zooMethods.ShowAverageHealth(animals);
                                            break;
                                        }
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
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }


            }
        }
    }
}
