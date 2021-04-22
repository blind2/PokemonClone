using Microsoft.Xna.Framework;
using PokemonClone.Engine;

namespace PokemonClone.Actor
{
    public class Camera
    {
        public Matrix transform;

        public void Follow(Player player)
        {
            var position = Matrix.CreateTranslation(
                -(float)player.PositionX - (player.TextureRegion.SpriteWidth / 2)
                , -(float)player.PositionY - (player.TextureRegion.SpriteHeight / 2), 0);

            //Divise la largeur et hauteur de l'écran pour placer le joueur au millieux
            var offset = Matrix.CreateTranslation(Setting.ScreenWidth / 2, Setting.ScreenHeight / 2, 0);

            transform = position * Matrix.CreateScale(Setting.Scale) * offset;
        }
 
    }
}
