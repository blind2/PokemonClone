using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Engine;

namespace PokemonClone.GameUI
{
    public class GUI
    {
        private DialogBox dialogBox;

        public GUI()
        {
            
        }

        public void LoadContent(ContentManager content)
        {
            dialogBox = new DialogBox(content.Load<Texture2D>("dialog_box"), new Rectangle(30,140, 235, 47));
            dialogBox.LoadContent(content,12, 6, new Color(150, 152, 160, 255));
            dialogBox.GetDialogFromFile("Dialog\\trainer_dialog.txt");

        }


        public void Update(GameTime gameTime)
        {
            dialogBox.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null,Matrix.CreateScale(Setting.Scale));
            dialogBox.Draw(spriteBatch, 20,  0.8f);
            spriteBatch.End();
        }
    }
}
