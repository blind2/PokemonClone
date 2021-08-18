using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClone.Enums
{
    public enum BattleState
    {
        Start,
        SelectAction,
        SelectMove,
        ChangeTurn,
        PlayerTurn,
        OpponentTurn,
        End,
        Animation
    }
}
