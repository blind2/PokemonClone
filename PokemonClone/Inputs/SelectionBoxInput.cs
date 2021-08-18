using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using PokemonClone.Engine;
using PokemonClone.Engine.Components;
using System;
using System.Collections.Generic;

namespace PokemonClone.Inputs
{
    public class SelectionBoxInput
    {
        public event Action Select;
        public event Action Back;

        public int ActiveCursor { get; private set; }
        private readonly List<Sprite> cursorList;
        public bool Enable { get; set; }

        public SelectionBoxInput(List<Sprite> cursorList)
        {
            this.cursorList = cursorList;
            Enable = true;
        }

        private void KeyPressedSelect()
        {
            if (CustomKeyboard.HasBeenPressed(Keys.Enter))
            {
                Select();
            }
        }

        private void KeyPressedBack()
        {
            if (CustomKeyboard.HasBeenPressed(Keys.B))
            {
                Back();
            }
        }

        private void KeyPressedUp()
        {
            if (CustomKeyboard.HasBeenPressed(Keys.Up))
            {
                if (ActiveCursor - 2 >= 0)
                {
                    foreach (var cursor in cursorList)
                    {
                        cursor.IsVisible = false;
                    }

                    cursorList[ActiveCursor - 2].IsVisible = true;
                }
            }
        }

        private void KeyPressedDown()
        {
            if (CustomKeyboard.HasBeenPressed(Keys.Down))
            {
                if (ActiveCursor + 2 < cursorList.Count)
                {
                    foreach (var cursor in cursorList)
                    {
                        cursor.IsVisible = false;
                    }
                    cursorList[ActiveCursor + 2].IsVisible = true;
                }
            }
        }

        private void KeyPressedLeft()
        {
            if (CustomKeyboard.HasBeenPressed(Keys.Left))
            {
                if (ActiveCursor - 1 >= 0)
                {
                    foreach (var cursor in cursorList)
                    {
                        cursor.IsVisible = false;
                    }

                    cursorList[ActiveCursor - 1].IsVisible = true;
                }
            }
        }
        private void KeyPressedRight()
        {
            if (CustomKeyboard.HasBeenPressed(Keys.Right))
            {
                if (ActiveCursor + 1 < cursorList.Count)
                {
                    foreach (var cursor in cursorList)
                    {
                        cursor.IsVisible = false;
                    }
                    cursorList[ActiveCursor + 1].IsVisible = true;
                }
            }
        }

        private void GetActiveCursor()
        {
            foreach (var cursor in cursorList)
            {
                if (cursor.IsVisible)
                {
                    ActiveCursor = cursorList.IndexOf(cursor);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if (Enable)
            {
                CustomKeyboard.GetState();
                GetActiveCursor();
                KeyPressedUp();
                KeyPressedDown();
                KeyPressedLeft();
                KeyPressedRight();
                KeyPressedSelect();
            }
        }
    }
}
