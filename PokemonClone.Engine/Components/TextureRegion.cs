using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PokemonClone.Engine
{
    public class TextureRegion
    {
        public int SpriteWidth { get; }
        public int SpriteHeight { get; }

        private int totalSprite;
        private readonly Texture2D spritesheet;
        private Rectangle[] rectangleArray;


        public TextureRegion(Texture2D spritesheet, int spriteWidth, int spriteHeight)
        {
            this.spritesheet = spritesheet;
            SpriteWidth = spriteWidth;
            SpriteHeight = spriteHeight;
            MakeArray();
        }


        private void MakeArray()
        {
            totalSprite = spritesheet.Width / SpriteWidth;

            rectangleArray = new Rectangle[totalSprite];

            for (int i = 0; i < totalSprite; i++)
            {
                rectangleArray[i] = new Rectangle(i * SpriteWidth, 0, SpriteWidth, SpriteHeight);

            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, int index)
        {
            spriteBatch.Draw(spritesheet, position, rectangleArray[index], Color.White);
        }

        public Rectangle GetRectangle(int index)
        {
            return rectangleArray[index];
        }
    }
}
