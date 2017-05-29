using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Animals;

namespace Zoo
{
    class ZooMethods
    {
        //сортування тварин
        public void ShowAllSortAnimals(List<Animal> ListOfAnimals)
        {
            var animalQuery = ListOfAnimals.GroupBy(a => a.GetType().Name).Select(a => new { AnimalType = a.Key, Animals = a.Select(s => s)
               });
            foreach (var animal in animalQuery)
            {
                Console.WriteLine($"\n{animal.AnimalType}: ");
                foreach (var group in animal.Animals)
                {

                    Console.Write($"{group.Alias}   ");
                }

            }
        }
        //тварини по стану
        public void ShowAnimalsCond(Condition cond, List<Animal> ListOfAnimals)
        {
            var animalsQuery = ListOfAnimals.Where(animal => animal.Condition == cond).ToList();
            foreach (var b in animalsQuery)
            {
                Console.WriteLine("{0} {1}  ",b.GetType().Name, b.Alias );
            }
        }


        //хворий тигр
        public void ShowIllTigers(List<Animal> ListOfAnimals)
        {
            var animalsQuery = ListOfAnimals.Where(animal => animal.Condition == Condition.Ill)
                  .Where(animal => animal.GetType().Name == "Tiger").ToList();
            foreach (var b in animalsQuery)
                Console.WriteLine("{0}  {1} хворіє",b.GetType().Name,  b.Alias);
            
        }
        //
        public void ShowElephantAlias(string name, List<Animal> ListOfAnimals)
        {
            var animalsQuery = ListOfAnimals
                .Where(animal => animal.GetType().Name == "Elephant" && animal.Alias == name)                .ToList();
            foreach (var alias in animalsQuery)
            {
                Console.WriteLine(alias.Alias);
            }

        }
        //голодні тварини
        public void HungryAnimalsAlias(List<Animal> ListOfAnimals)
        {
            var animalsQuery = ListOfAnimals.Where(animal => animal.Condition == Condition.Hungry)
                .Select(animal => animal.Alias).ToList();
            if (animalsQuery.Count != 0)
            {
                foreach (var alias in animalsQuery)
                {                    
                    Console.WriteLine(alias);                   
                }
            }
            else
            {               
                Console.WriteLine("Немає голодних тварин в зоопарку");
               
            }

        }

        public void ShowTheHealthiestAnimals(List<Animal> ListOfAnimals)
        {
            var animalsQuery = ListOfAnimals.OrderByDescending(animal => animal.Health)
                .GroupBy(animal => animal.GetType().Name)
                .Select(a => new
                {
                    AnimalType = a.Key,
                    Animals = a.Select(animal => animal)
                });
            Console.WriteLine("Найздоровіші тварини кожного виду");
            foreach (var animal in animalsQuery)
            {
                
                Console.WriteLine(animal.AnimalType);
                foreach (var group in animal.Animals)
                {
                  
                    Console.WriteLine($"{group.Alias} + {group.Health}/{group.HealthAnimal}");
                }
               
            }
        }

        // всі метод 
        public void DeadAnimals(List<Animal> ListOfAnimals)
        {
            var animalQuery = ListOfAnimals.Where(animal => animal.Condition == Condition.Dead).
                GroupBy(a => a.GetType().Name)
                .Select(a => new
                {
                    AnimalType = a.Key,
                    Count = a.Count()
                });
            if (animalQuery.Count() == 0)
            {
                Console.WriteLine("Всі тварини живі");
            }
            foreach (var animal in animalQuery)
            {
                
                Console.WriteLine($"{animal.AnimalType}: {animal.Count}");
               
            }
        }

      
        public void WolfsBearsWitheHealth3(List<Animal> ListOfAnimals)
        {
            Console.WriteLine("Вовки і ведмеді в якиз здоровя більше 3х одиниць");
            var animalsQuery = ListOfAnimals.Where(animal => animal.Health > 3)
                .Where(animal => animal.GetType().Name == "Wolf" || animal.GetType().Name == "Bear")
                .ToList();
            foreach (var b in animalsQuery)
            {
                Console.WriteLine("{0} {1}  ", b.GetType().Name, b.Alias);
            }
        }

       
        public void ShowMaxAndMin(List<Animal> ListOfAnimals)
        {
            var animalsQuery = ListOfAnimals
                .GroupBy(animal => 1)
                .Select(a => new
                {
                    Min = a.Min(x => x.Health),
                    Max = a.Max(x => x.Health)
                }).First();

            Console.WriteLine($"Мінімальне - {animalsQuery.Min},та максимальне - {animalsQuery.Max} здоровя");
        }

       
        public void ShowAverageHealth(List<Animal> ListOfAnimals)
        {
            var average = ListOfAnimals.Average(a => a.Health);
            Console.WriteLine($"Середнє здоровя тварин - {average}");
        }
        //ост

    }
}
