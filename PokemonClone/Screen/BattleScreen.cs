using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.BattleSystem;
using PokemonClone.Model;
using PokemonClone.PokemonData;
using System;
using Type = PokemonClone.PokemonData.Type;

namespace PokemonClone.Screen
{
    public class BattleScreen : IScreen
    {
        private Pokemon bulbasaur;
        private Pokemon tyranitar;
        private Battle battle;

        public void Initialize()
        {
           
         
        }

        public void LoadContent(ContentManager content)
        {

            Texture2D charizardBack = content.Load<Texture2D>("Pokemon\\Back\\bulbasaur_back");
            Texture2D charizardFront = content.Load<Texture2D>("Pokemon\\Front\\charizard_front");
            Texture2D tyranitarBack = content.Load<Texture2D>("Pokemon\\Back\\tyranitar_back");
            Texture2D tyranitarFront = content.Load<Texture2D>("Pokemon\\Front\\charmander_front");

            bulbasaur = new Pokemon(new PokemonStats(5, "Bulbasaur", 78, 84, 78, 109, 85, 100, Type.Fire), new SpriteSet(charizardFront, charizardBack));
            tyranitar = new Pokemon(new PokemonStats(5, "Charmander", 78, 84, 78, 109, 85, 100, Type.Rock), new SpriteSet(tyranitarFront, tyranitarBack));
            bulbasaur.addMove(new Move("Tackle", 40, 100, 35, Type.Normal));
            bulbasaur.addMove(new Move("Vine Whip", 45, 100, 25, Type.Grass));
            tyranitar.addMove(new Move("Flamethrower", 90, 100, 10, Type.Fire));

            battle = new Battle(bulbasaur, tyranitar);

            battle.LoadContent(content);

        }

        public void UnloadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
          
           battle.Update(gameTime);
           
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            battle.Draw(spriteBatch);
        }

    }
}
