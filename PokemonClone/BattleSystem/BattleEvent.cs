using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PokemonClone.Components;
using PokemonClone.Engine.Components;
using PokemonClone.Model;
using PokemonClone.PokemonData;

namespace PokemonClone.BattleSystem
{
    public class BattleEvent
    {
        public bool IsFinished { get; set; } = false;
        public static GameTime gameTime1;
        public BattleEvent()
        {

        }

        public void HealthBarAnimation(HealthBar healthBar, GameTime gameTime)
        {
            healthBar.Update(gameTime);
            if (healthBar.IsFinished)
            {
                IsFinished = true;
            }
            
        }

        public void MoveSpriteLeft(Sprite sprite, int speed, int endPosition)
        {

            if (sprite.Rectangle.X > endPosition)
            {
                sprite.RectangleX -= speed;
                IsFinished = false;
            }
            else
            {
                IsFinished = true;
            }
        }
        public void MoveSpriteRight(Sprite sprite, int speed, int endPosition)
        {


            if (sprite.RectangleX < endPosition)
            {
                sprite.RectangleX += speed;
                IsFinished = false;
            }
            else
            {
                IsFinished = true;
            }
        }
        public void TextAnimation(DialogBox dialogBox, int index, GameTime gameTime)
        {
            IsFinished= false;
            dialogBox.SetTextIndex(index);
            dialogBox.Update(gameTime);
            if (dialogBox.isFinish)
            {
                IsFinished = true;
            }
        }

      
    }
    public class TextEvent: IEvent
    {

        private bool isFinished = false;

        public bool IsFinished()
        {
            return isFinished;
        }
        public void TextEventAnimation(DialogBox dialogBox, int index, GameTime gameTime)
        {
            dialogBox.SetTextIndex(index);
            dialogBox.Update(gameTime);
            if (dialogBox.isFinish)
            {
                isFinished = true;
            }
        }

        public void Execute(Action action)
        {

        }
    }

   
       
}
