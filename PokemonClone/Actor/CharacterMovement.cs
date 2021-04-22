using Microsoft.Xna.Framework;

namespace PokemonClone.Actor
{
    public class CharacterMovement
    {
        private Character character;
        private Vector2 startPosition;
        private Vector2 endPosition;
        private float timer = 0.0f;
        private bool isFinish = true;
        
        public CharacterMovement(Character character)
        {
            this.character = character;
        }

        public void Move(int x, int y)
        {

            if (isFinish == true)
            {
                timer = 0.0f;
                startPosition = new Vector2(character.PositionX, character.PositionY);
                endPosition = character.Move(x, y);
                isFinish = false;
                character.currentDirection = character.direction;
                
            }

            if (isFinish == false)
            {
                timer += 0.1f / Setting.Scale;
                character.LerpPosition(startPosition, endPosition, timer);
                
                if (timer >= 1)
                {
                    character.direction = Character.Direction.Idle;
                    character.currentDirection = Character.Direction.Idle;
                   
                    isFinish = true;
                }
            }
        }

        public void Walk()
        {
            switch (character.direction)
            {
                case Character.Direction.Up:
                    Move(0, -Setting.TileSize);
                    break;
                case Character.Direction.Down:
                    Move(0, Setting.TileSize);
                    break;
                case Character.Direction.Left:
                    Move(-Setting.TileSize, 0);
                    break;
                case Character.Direction.Right:
                    Move(Setting.TileSize, 0);
                    break;
            }
        }
    }
}
