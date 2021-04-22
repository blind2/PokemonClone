using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClone.PokemonData
{
    public class Pokemon
    {
        private PokemonStats pokemonStats;
        private PokemonExperience pokemonExperience;
        private SpriteSet spriteSet;
        public List<Move> listMove;

      
        public Pokemon(PokemonStats pokemonStats, SpriteSet spriteSet)            
        {
            this.pokemonStats = pokemonStats;
            this.spriteSet = spriteSet;

            this.pokemonExperience = new PokemonExperience(this);
            listMove = new List<Move>();
        }
      
        public void Attack(Move move, Pokemon pokemon)
        {
            if (pokemon.pokemonStats.CurrentHp > 0)
            {
                int dommage = (pokemonStats.Level * 2 ) * (move.Power * pokemonStats.Attack / pokemon.pokemonStats.Defense / 20);
                
                pokemon.pokemonStats.CurrentHp -= dommage;
            }
        }

        public void Hit()
        {

        }

        public void addMove(Move move)
        {
            if (listMove.Count < 4)
            {
                listMove.Add(move);
            }
        }

        public bool isDead()
        {
            if (pokemonStats.CurrentHp < 0)
            {
                return true;
            }
            return false;
        }

        public string GetMoveName(int index)
        {
            if (listMove.Count >index)
            {
                return listMove[index].Name;
            }
            return "----";
        }

        public PokemonStats PokemonStats
        {
            get { return pokemonStats; }
        }

        public SpriteSet SpriteSet
        {
            get { return spriteSet; }
        }
    }
}
