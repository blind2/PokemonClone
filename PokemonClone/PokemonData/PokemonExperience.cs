using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClone.PokemonData
{
    public class PokemonExperience
    {
        private Pokemon pokemon;
        private int experienceRequired;
        private int experienceTotal = 0;
        private int experience = 0;
        private int levelCompleted = 0;

        public PokemonExperience(Pokemon pokemon)
        {
            this.pokemon = pokemon;
        }

        public void GainExperience(int amount)
        {
            experienceTotal += amount;
            experience += amount;

            while (experience >= experienceRequired)
            {
                experience -= experienceRequired;
                levelCompleted += 1;
                levelUp();
            }
        }

        public int GetAmountExperience(Pokemon opponent)
        {
            return (int)Math.Round(Math.Pow(opponent.PokemonStats.Level, 1.8));
        }

        public void levelUp()
        {
            pokemon.PokemonStats.Level += 1;
            experienceRequired = (int)Math.Round(Math.Pow(pokemon.PokemonStats.Level, 1.8) + pokemon.PokemonStats.Level * 4);
        }

    }
}
