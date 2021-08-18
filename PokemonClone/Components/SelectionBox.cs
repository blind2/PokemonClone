using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Engine.Components;
using PokemonClone.Inputs;
using PokemonClone.Model;
using System.Collections.Generic;

namespace PokemonClone.Components
{
    public class SelectionBox : IVisible
    {
        public SelectionBoxInput SelectionBoxInput { get; }
        private readonly List<Label> optionList = new List<Label>();
        private readonly List<Sprite> cursorList = new List<Sprite>();
        private readonly Sprite box;
        private int activeCursor;

        public SelectionBox(Sprite box)
        {
            this.box = box;
            SelectionBoxInput = new SelectionBoxInput(cursorList);
        }

        public void AddOption(Label option)
        {
            optionList.Add(option);
        }

        private Sprite CreateCursor(ContentManager content, int width, int height, int positionX, int positionY)
        {
            var cursor = new Sprite(content.Load<Texture2D>("cursor"),
                new Rectangle(positionX, positionY, width, height))
            { IsVisible = false };

            return cursor;
        }

        public void LoadContent(ContentManager content)
        {
            foreach (var label in optionList)
            {
                cursorList.Add(CreateCursor(content, 15, 26, (int)label.Position.X - 17, (int)label.Position.Y));
            }

            cursorList[0].IsVisible = true;

        }

        public void Update(GameTime gameTime)
        {
            SelectionBoxInput.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            box.Draw(spriteBatch);

            foreach (var cursor in cursorList)
            {
                cursor.Draw(spriteBatch);
            }

            foreach (var label in optionList)
            {
                label.Draw(spriteBatch);
            }
        }

        public void SetVisibility(bool visible)
        {

            box.IsVisible = visible;
            SelectionBoxInput.Enable = visible;

            cursorList[activeCursor].IsVisible = visible;

            foreach (var label in optionList)
            {
                label.IsVisible = visible;
            }

        }
    }
}
