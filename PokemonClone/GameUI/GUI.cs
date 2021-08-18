using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Components;
using PokemonClone.Engine.Components;

namespace PokemonClone.GameUI
{
    public class GUI
    {
        private DialogBox dialogBox;
        private SpriteFont font;

        public GUI()
        {

        }

        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("Font\\pokemon");

            dialogBox = new DialogBox(content.Load<Texture2D>("dialog_box"), new Rectangle(20, 110, 235, 47), new Label() {Font = font })
            {
                BorderSize = 20

            };

            dialogBox.GetDialogFromFile("Dialog\\trainer_dialog.txt");

        }


        public void Update(GameTime gameTime)
        {
            dialogBox.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, Matrix.CreateScale(Setting.Scale));
            dialogBox.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
