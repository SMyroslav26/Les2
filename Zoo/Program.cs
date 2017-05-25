using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Zoo.Animals;

namespace Zoo
{
   

    
    class Program
    {
        static void Main(string[] args)
        {
            ZooSimulation zoozoo = new ZooSimulation();
            
            zoozoo.Start();
            Console.ReadLine();

            
        }
    }
}
