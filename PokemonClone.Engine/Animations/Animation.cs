using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Engine.Components;
using System;

namespace PokemonClone.Engine.Animations
{
    public class Animation
    {
        private int frame;
        private float timer;
        private float interval = 100;
        private bool isFinished = false;
        private TextureRegion textureRegion;
        public static GameTime gameTime;
        public GameTime GameTime { get; }

        private int compteur = 0;

        public Animation(TextureRegion textureRegion)
        {
            this.textureRegion = textureRegion;

        }

        public Animation() { }

        public void MoveSpriteLeft(Sprite sprite, int speed, int endPosition)
        {

            if (sprite.Rectangle.X > endPosition)
            {
                sprite.RectangleX -= speed;
                isFinished = false;
            }
            else
            {
                isFinished = true;
            }
        }

        public void MoveSpriteRight(Sprite sprite, int speed, int endPosition)
        {


            if (sprite.RectangleX < endPosition)
            {
                sprite.RectangleX += speed;
                isFinished = false;
            }
            else
            {
                isFinished = true;
            }
        }

        public void TakeDommage(Sprite sprite)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;

            if (compteur < 2)
            {
                if (timer < 70)
                {
                    sprite.IsVisible = false;
                }
                if (timer > 70)
                {
                    sprite.IsVisible = true;
                    if (timer > 100)
                    {
                        timer = 0;
                        compteur++;
                    }

                }

            }
            else
            {

                isFinished = true;
            }



        }



        public void Play(GameTime gameTime, int minFrame, int maxFrame)
        {

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;

            if (timer > interval)
            {
                frame++;
                timer = 0;

                if (frame > maxFrame || frame < minFrame)
                {
                    frame = minFrame;

                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            textureRegion.Draw(spriteBatch, position, frame);
        }

        public bool Isfinished()
        {
            return isFinished;
        }

        public void Execute(Action action)
        {
            action.Invoke();
        }

        public Rectangle Rectangle
        {
            get { return textureRegion.GetRectangle(frame); }
        }
    }
}
