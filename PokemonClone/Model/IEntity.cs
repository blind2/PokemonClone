using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PokemonClone.Model
{
    public interface IEntity
    {
        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);
    }
}
