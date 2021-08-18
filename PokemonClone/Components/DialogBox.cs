using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Engine;
using PokemonClone.Engine.Components;
using PokemonClone.Engine.Extensions;
using PokemonClone.Model;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Input;
using PokemonClone.Actor;
using PokemonClone.Inputs;

namespace PokemonClone.Components
{
    public  class DialogBox : IVisible
    {
        protected Texture2D texture;
        protected Rectangle rectangle;
        public List<string> listDialog;
        protected Timer timer;
        protected Label label;

        protected string fullText;
        protected string currentText = "";
        protected int currentTextIndex = 0;
        public int index = 0;

        public bool isFinish = false;
        protected bool isVisible = true;

        public bool next = false;
        public int BorderSize { get; set; }

        private PlayerInput playerInput;


        public DialogBox(Texture2D texture, Rectangle rectangle, Label label)
        {
            this.texture = texture;
            this.rectangle = rectangle;
            this.label = label;
            
            listDialog = new List<string>();

            timer = new Timer();
        }

        public void InstantText()
        {
            currentText = fullText;
        }

        public void Show()
        {
            if (CharaterCollision.isColliding && Keyboard.GetState().IsKeyDown(Keys.A))
            {
                isVisible = true;
            }
            isVisible = false;
        }
        public void ResetText()
        {
            fullText = "";
            currentText = "";
        }

        public void AddText(string text)
        {
            listDialog.Add(text);
        }

        public void SetTextIndex(int textIndex)
        {

            index = textIndex;
        }

        public void GetDialogFromFile(string file)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    listDialog.Add(line);
                }
            }
        }

       public  void DisplayTextOverTime(GameTime gameTime)
        {

            if (timer.SetTimer(20, gameTime))
            {
                if (listDialog.Count != 0)
                {
                    fullText = listDialog[index];
                    fullText.ToCharArray();

                    if (currentTextIndex < fullText.Length)
                    {
                        currentText += fullText[currentTextIndex];
                        currentTextIndex++;
                    }
                    if (currentText == fullText)
                    {
                        isFinish = true;

                    }
                }
            }
        }

    

        public void Update(GameTime gameTime)
        {
            label.Text = currentText;

            DisplayTextOverTime(gameTime);
            if (isFinish)
            {

                if (currentText != fullText)
                {
                    currentTextIndex = 0;
                    currentText = "";

                    isFinish = false;
                }
            }
        }

        public void UpdateTest(GameTime gameTime)
        {

            DisplayTextOverTime(gameTime);
            playerInput.Update();
            Show();


            if (playerInput.input == PlayerInput.Input.Accept && isFinish)
            {
                if (index < listDialog.Count - 1)
                {
                    index += 1;
                    currentTextIndex = 0;
                    currentText = "";
                    isFinish = false;
                }
                else
                {
                    index = 0;
                    isVisible = false;
                }

            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
            {
                spriteBatch.DrawNinePatchRect(rectangle, texture, BorderSize, Color.White);
                label.Draw(spriteBatch);

            }
        }


        public void SetVisibility(bool visible)
        {
            isVisible = visible;
        }

    }
}
