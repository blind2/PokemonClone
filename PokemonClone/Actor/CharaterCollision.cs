using Microsoft.Xna.Framework;
using PokemonClone.Engine;
using PokemonClone.Screen;
using System;

namespace PokemonClone.Actor
{
    public class CharaterCollision
    {
        private readonly Character character;
        private Vector2 characterNextStep;
        private Vector2 trainerCurrentPosition;
        public static bool isColliding;


        public CharaterCollision(Character character)
        {
            this.character = character;
        }
        public void Collision()
        {

        }

        public bool HasCollision(World world, int x, int y)
        {
            double roundX = Math.Round(character.PositionX);
            double roundY = Math.Round(character.PositionY);

            for (int i = 0; i < world.tileMap.Count; i++)
            {
                var map = world.tileMap.ToArray();

                foreach (Tile tile in map[i].tileList)
                {

                    characterNextStep = new Vector2((float)roundX + x, (float)roundY + y);

                    if (characterNextStep == tile.Position && tile.Solid == true)
                    {
                        return true;
                    }
                }
                
            }
         
            foreach (Trainer trainer in world.trainerList)
            {
                double tRoundX = Math.Round(trainer.PositionX);
                double tRoundY = Math.Round(trainer.PositionY);

                trainerCurrentPosition = new Vector2((float)tRoundX, (float)tRoundY);

                if (characterNextStep == trainerCurrentPosition)
                {
                    isColliding = true;
                    return true;
                }
            }

            isColliding = false;
            return false;
        }

        public bool IsColliding
        {
            get { return isColliding; }
        }

    }
}
