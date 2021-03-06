﻿using System;
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
                { Console.WriteLine("Тварина мертва :( "); }
                else if (value == _healthAnimal)
                { Console.WriteLine("Тварина потребаує лiкування :("); }
                else  _health = value;
            }  
        }
        public string Alias { get { return _alias; } }
        public byte HealthAnimal { get { return _healthAnimal; } }

        public void changeCondition()
        {
            if (_condition != Condition.Dead)
            {
                switch (_condition)
                {
                    case Condition.Sated:
                        _condition = Condition.Hungry;
                        Console.WriteLine("Тварина {0} голодна \n", _alias);
                        break;
                    case Condition.Hungry:
                        _condition = Condition.Ill;
                        Console.WriteLine("Тварина {0} хворiє \n", _alias);
                        break;
                    case Condition.Ill:
                        
                        _health--;

                        if (_health == 0)
                        {
                            Console.WriteLine("Тварина {0} померла \n", _alias);
                            _condition = Condition.Dead;
                        }
                        else
                        {
                            Console.WriteLine("Тварина {0} продовжує хворiти \n", _alias);

                        }
                        break;
                }
            }

        }


    }
}
