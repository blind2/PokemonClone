using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PokemonClone.Engine
{
    public class TextureRegion
    {
        private Texture2D spritesheet;
        private Rectangle[] rectangleArray;

        private int spriteWidth;
        private int spriteHeight;
        private int totalSprite;

        /// <summary>
        /// Make a array of sprite
        /// </summary>
        /// <param name="spritesheet">atlas of the textures</param>
        /// <param name="spriteWidth">the width of a single frame</param>
        /// <param name="spriteHeight">the height of a single frame</param>
        public TextureRegion(Texture2D spritesheet, int spriteWidth, int spriteHeight)
        {
            this.spritesheet = spritesheet;
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
            MakeArray();
        }

        private void MakeArray()
        {
            totalSprite = spritesheet.Width / spriteWidth;

            rectangleArray = new Rectangle[totalSprite];

            for (int i = 0; i < totalSprite; i++)
            {             
                rectangleArray[i] = new Rectangle(i * spriteWidth, 0, spriteWidth, spriteHeight);

            }
        }
        
        public void Draw(SpriteBatch spriteBatch, Vector2 position, int index)
        {
            spriteBatch.Draw(spritesheet, position, rectangleArray[index], Color.White);
        }

        /// <summary>
        /// Retourne une tuile à partir de sont index de la region de texture
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>une tuile</returns>
        public Rectangle GetRectangle(int index)
        {
            return rectangleArray[index];
        }

        public int SpriteWidth
        {
            get { return spriteWidth; }
        }

        public int SpriteHeight
        {
            get { return spriteHeight; }
        }
    }
}
