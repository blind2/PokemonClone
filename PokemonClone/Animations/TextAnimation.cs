using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Components;
using PokemonClone.Model;

namespace PokemonClone.Animations
{
    internal class TextAnimation : IAnimation
    {
        private DialogBox dialogBox;
        private bool isDone;
        private int index;

        public bool IsDone => isDone;

        public TextAnimation(DialogBox dialogBox, int index)
        {
            
            this.dialogBox = dialogBox;
            this.index = index;
        }

        public void LoadContent(ContentManager content)
        {
            throw new System.NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            isDone = false;
            dialogBox.SetTextIndex(index);
            dialogBox.Update(gameTime);
            if (dialogBox.isFinish)
            {
                isDone = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            throw new System.NotImplementedException();
        }
    }
}
