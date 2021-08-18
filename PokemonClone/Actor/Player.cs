using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Engine;
using PokemonClone.Inputs;
using PokemonClone.PokemonData;
using PokemonClone.Screen;
using Type = PokemonClone.PokemonData.Type;

namespace PokemonClone.Actor
{
    public class Player : Character
    {
        private readonly PlayerInput playerInput;
        
        public Player(World world, TextureRegion textureRegion, Vector2 position) : base(world, textureRegion, position)
        {
            playerInput = new PlayerInput();
            //GetParty();
                   
        }

        public void GetParty(ContentManager content)
        {
            Texture2D charizardBack = content.Load<Texture2D>("Pokemon\\Back\\charizard_back");
            Texture2D charizardFront = content.Load<Texture2D>("Pokemon\\Front\\charizard_front");

            Pokemon charizard = new Pokemon(new PokemonStats(50, "Charizard", 78, 84, 78, 109, 85, 100, Type.Fire),
                new SpriteSet(charizardFront, charizardBack));
           
            charizard.addMove(new Move("Famethrower", 90, 100, 10, Type.Fire));
            party.addPokemon(charizard);
        }
      
        public override void  ChangerDirection(GameTime  gameTime)
        {
            switch (playerInput.input)
            {
                case PlayerInput.Input.Up:
                    direction = Direction.Up;
                    break;
                case PlayerInput.Input.Down:
                    direction = Direction.Down;
                    break;
                case PlayerInput.Input.Left:
                    direction = Direction.Left;
                    break;
                case PlayerInput.Input.Right:
                    direction = Direction.Right;
                    break;
            }
        }

        public override void Update(GameTime gameTime)
        {
            playerInput.Update();
           
            base.Update(gameTime);
        }
    }
}