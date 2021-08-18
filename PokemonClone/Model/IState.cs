using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Enums;

namespace PokemonClone.Model
{
    public interface IState
    {
        void Update(GameTime gameTime);
        void GoToNextState();

        void LoadContent(ContentManager content);
        void Draw(SpriteBatch spriteBtach);
       
    }
}
