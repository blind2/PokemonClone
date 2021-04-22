using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PokemonClone.Model
{
    public interface IScreen
    {
        void Initialize();

        void LoadContent(ContentManager content);

        void UnloadContent(ContentManager content);

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);
    }
}
