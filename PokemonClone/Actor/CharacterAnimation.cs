using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Engine;

namespace PokemonClone.Actor
{
    public class CharacterAnimation
    {
        private readonly Animation animation;
        private readonly Character character;
        private  TextureRegion textureRegion;
        private int lastDirection = 1; // direction par default

        public CharacterAnimation(Character character, TextureRegion textureRegion)
        {
            this.character = character;
            this.textureRegion = textureRegion;
            animation = new Animation(textureRegion);
        }

        public void WalkAnimation(GameTime gameTime)
        {
            switch (character.currentDirection)
            {
                case Character.Direction.Up:
                    animation.Play(gameTime, 6, 8);
                    lastDirection = 0;
                    break;
                case Character.Direction.Down:
                    animation.Play(gameTime, 3, 5);
                    lastDirection = 1;
                    break;
                case Character.Direction.Left:
                    animation.Play(gameTime, 9, 11);
                    lastDirection = 2;
                    break;
                case Character.Direction.Right:
                    animation.Play(gameTime, 0, 2);
                    lastDirection = 3;
                    break;
                case Character.Direction.Idle:
                    IdleAnimation(gameTime);
                    break;
                   
            }
        }

        public void IdleAnimation(GameTime gameTime)
        {
            switch (lastDirection)
            {
                case 0:
                    animation.Play(gameTime, 7, 7);
                    break;
                case 1:
                    animation.Play(gameTime, 4, 4);
                    break;
                case 2:
                    animation.Play(gameTime, 10, 10);
                    break;
                case 3:
                    animation.Play(gameTime, 1, 1);
                    break;
            }
        }


        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            animation.Draw(spriteBatch, position);
        }

    }
}
