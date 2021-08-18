using Microsoft.Xna.Framework.Input;

namespace PokemonClone.Inputs
{
    public class PlayerInput
    {
        public Input input = Input.Idle;

        public enum Input
        {
            Up,
            Down,
            Left,
            Right,
            Accept,
            Back,
            Idle
        }

        public void Update()
        {

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                input = Input.Up;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                input = Input.Down;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                input = Input.Left;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                input = Input.Right;
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                input = Input.Accept;
            }
            else
            {
                input = Input.Idle;
            }
        }
    }
}
