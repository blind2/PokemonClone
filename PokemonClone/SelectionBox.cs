using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PokemonClone.Engine;
using PokemonClone.Model;
using System.Collections.Generic;
using Timer = PokemonClone.Engine.Timer;

namespace PokemonClone
{
    public class SelectionBox : IVisible
    {
        private Sprite box;
        private Sprite cursor;
        private List<Label> optionList;
        private int index = 1;
        private bool isActivate = false;
        private Timer timer;


        public SelectionBox(Sprite box)
        {
            this.box = box;
            optionList = new List<Label>();
            timer = new Timer();
        }

        public void AddOption(Label option)
        {
            optionList.Add(option);
        }

        public void Input2Option()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                cursor.RectangleY = (int)optionList[0].Position.Y;
                index = 1;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                cursor.RectangleY = (int)optionList[1].Position.Y;
                index = 2;
            }
        }

        public void Input()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                cursor.RectangleY = (int)optionList[0].Position.Y;
                index = 1;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                cursor.RectangleY = (int)optionList[2].Position.Y;
                index = 2;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                cursor.RectangleX = (int)optionList[0].Position.X - 22;
                index = 3;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                cursor.RectangleX = (int)optionList[3].Position.X - 22;
                index = 4;
            }
        }

        public int Select()
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                return index;
            }

            return 0;
        }

        public void SetVisibility(bool visible)
        {
            box.SetVisibility(visible);
            cursor.SetVisibility(visible);

            foreach (Label label in optionList)
            {
                label.SetVisibility(visible);
            }

            if (visible)
            {


                isActivate = true;


            }
            else
            {
                isActivate = false;
            }
        }

        public void LoadContent(ContentManager content, int sizeX, int sizeY, int offsetX, int offsetY)
        {
            cursor = new Sprite(content.Load<Texture2D>("cursor"),
                new Rectangle(box.RectangleX + offsetX, box.RectangleY + offsetY, sizeX, sizeY));

        }

        public void Update(GameTime gameTime)
        {
            if (isActivate)
            {
                if (optionList.Count > 2)
                {
                    Input();
                }
                else
                {
                    Input2Option();
                }


            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            box.Draw(spriteBatch);
            cursor.Draw(spriteBatch);

            foreach (Label label in optionList)
            {
                label.Draw(spriteBatch, 2.4f);
            }
        }

        public void Draw(SpriteBatch spriteBatch, int border, float textSize)
        {

            box.Draw(spriteBatch, border);
            cursor.Draw(spriteBatch);

            foreach (Label label in optionList)
            {
                label.Draw(spriteBatch, textSize);
            }
        }

        public int Index
        {
            get { return index; }
        }
    }
}
