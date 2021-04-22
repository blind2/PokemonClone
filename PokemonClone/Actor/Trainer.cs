using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Engine;
using PokemonClone.Screen;
using System;

namespace PokemonClone.Actor
{
    public class Trainer : Character
    {
        private Timer timer;
        private bool isDefeated = false;
        private int dialogIndex;

        public Trainer(World world, TextureRegion textureRegion, Vector2 position, int dialogIndex) : base(world, textureRegion, position)
        {
            world.trainerList.Add(this);
            this.dialogIndex = dialogIndex;
            timer = new Timer();
        }

        public override void ChangerDirection(GameTime gameTime)
        {
                  
        }

       

        public void Fight(Player player)
        {
            throw new Exception("fight started");
        }
    }
}
