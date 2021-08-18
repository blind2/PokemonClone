using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClone
{
    public static class Setting
    {
        public const int TileSize = 16;
        public const float Scale = 3f;
        public const float ScaledTileSize = TileSize * Scale;
        public const int ScreenWidth = 800;
        public const int ScreenHeight = 480;
        public const int MaxPokemonParty = 6;
        public const int PokemonSpriteSize = 200;
    }
}
