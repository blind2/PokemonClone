using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClone.PokemonData
{
    public class Move
    {
        string name;
        int power;
        int accuracy;
        int pp;
        Type type;
        

        public Move(string name, int power, int accuracy, int pp, Type type)
        {
            this.name = name;
            this.power = power;
            this.accuracy = accuracy;          
            this.pp = pp;
            this.type = type;
        }

        public string Name
        {
            get { return name; }
        }

        public int Power
        {
            get { return power; }
        }
    }
}
