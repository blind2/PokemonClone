using PokemonClone.PokemonData;
using System.Collections.Generic;

namespace PokemonClone.Actor
{
    public class Party
    {
        private int index = 0;
        private Pokemon currentPokemon;
        private List<Pokemon> listPokemon;

        public Party()
        {
            listPokemon = new List<Pokemon>();      
        }

        public void addPokemon(Pokemon pokemon)
        {
            listPokemon.Add(pokemon);
            currentPokemon = listPokemon[index];
        }

        /// <summary>
        /// Remove a pokemon from the party
        /// </summary>
        /// <param name="pokemon">pokemon to remove</param>
        public void removePokemon(Pokemon pokemon)
        {
            listPokemon.Remove(pokemon);
        }

        public bool CheckPartyEmpty()
        {
            Pokemon nextPokemon = listPokemon[index + 1];

            if (index <= Setting.MaxPokemonParty)
            {
                currentPokemon = nextPokemon;
                return true;
            }

            //N'a plus de pokemon dans l'équipe
            return false;
        }
    }
}
