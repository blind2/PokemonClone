using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Model;
using PokemonClone.PokemonData;
using System;

namespace PokemonClone.Animations
{
    public class HealthBarAnimation : IAnimation
    {
        private bool isDone;
        private HealthBar healthBar;


        public HealthBarAnimation(HealthBar healthBar)
        {
            this.healthBar = healthBar;
        }

        public bool IsDone => isDone;


        public void LoadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {


            healthBar.Update(gameTime);
            if (healthBar.IsFinished)
            {
                isDone = true;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            throw new NotImplementedException();
        }

    }
}
