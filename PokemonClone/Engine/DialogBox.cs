using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using PokemonClone.Actor;
using System.Collections.Generic;
using System.IO;

namespace PokemonClone.Engine
{
    public class DialogBox
    {
        private Texture2D texture;
        private Rectangle rectangle;
        private Label label;
        private PlayerInput playerInput;
        private List<string> listDialog;
        private Timer timer;
       
        public string fullText;
        private string currentText = "";
        private int currentTextIndex = 0;
        private int index = 0;

        public bool isFinish = false;
        private bool isVisible = true;


        public DialogBox(Texture2D texture, Rectangle rectangle)
        {
            this.texture = texture;
            this.rectangle = rectangle;
            listDialog = new List<string>();
            playerInput = new PlayerInput();
            timer = new Timer();
        }

        public void LoadContent(ContentManager content, int offsetX, int offsetY, Color color)
        {
            //new Color(37, 150, 190)
            label = new Label(content.Load<SpriteFont>("Font\\pokemon"), new Vector2(rectangle.X + offsetX, rectangle.Y + offsetY), color);
            //GetDialogFromFile(file);
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

        public void GetDialog(string text)
        {
            isVisible = true;
            listDialog.Add(text);
        }

        private void DisplayTextOverTime(GameTime gameTime)
        {

            if (timer.SetTimer(20, gameTime))
            {
                fullText = listDialog[index];
                fullText.ToCharArray();

                if (currentTextIndex<fullText.Length)
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

        public void Show()
        {
            if (CharaterCollision.isColliding && Keyboard.GetState().IsKeyDown(Keys.A))
            {
                isVisible = true;
            }
            isVisible = false;
        }


        public void Update(GameTime gameTime)
        {

            DisplayTextOverTime(gameTime);
            playerInput.Update();
            Show();


            if ( playerInput.input == PlayerInput.Input.Accept && isFinish)
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

       
        public void Draw(SpriteBatch spriteBatch, int borderSize, float textSize)
        {
            if (isVisible)
            {
                spriteBatch.DrawRoundedRect(rectangle, texture, borderSize, Color.White);
                label.Draw(spriteBatch, currentText, textSize);
            }
            
        }

 
        public Rectangle Rectangle
        {
            get { return rectangle; }
        }
    }
}
