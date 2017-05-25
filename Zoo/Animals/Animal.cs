using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Animals
{
    enum Condition 
    {
        Sated ,
        Hungry,
        Ill  ,
        Dead 
    }
    class Animal
    {
      
        private Condition _condition;
        private byte _healthAnimal;
        private byte _health;
        private string _alias;
        public Animal() { }
        public Animal( String alias, Byte health)
        {
            this._alias = alias;
            this._health = health;
            this._healthAnimal = health;
        }

        public Condition Condition
        { get { return _condition; }
            set { _condition = value; }
        }
        public void Feed()
        {
            _condition = Condition.Sated;
        }
        public byte Health
        { get { return _health; }
          set { if (value == 0)
                { Console.WriteLine("Тварина мертва :("); }
                else if (value == _healthAnimal)
                { Console.WriteLine("Тварина потребаує лікування :("); }
                else  _health = value;
            }  
        }
        public string Alias { get; }

        public void changeCondition()
        {
            if (_condition != Condition.Dead)
            {
                switch (_condition)
                {
                    case Condition.Sated:
                        _condition = Condition.Hungry;
                        Console.WriteLine("Тварина {0} голодна", Alias);
                        break;
                    case Condition.Hungry:
                        _condition = Condition.Ill;
                        Console.WriteLine("Тварина {0} хворіє", Alias);
                        break;
                    case Condition.Ill:
                        
                        _health--;
                        if (_health == 0)
                        {
                            Console.WriteLine("Тварина {0} померла" , Alias);
                            _condition = Condition.Dead;
                        }
                        break;
                }
            }

        }


    }
}
