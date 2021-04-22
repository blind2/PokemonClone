using Microsoft.Xna.Framework;
using PokemonClone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClone.BattleSystem.BattleState
{
    public class End : IState
    {
        private Battle battle;

        public End(Battle battle)
        {
            this.battle = battle;
        }

        public void GoToNextState()
        {
            throw new NotImplementedException();
        }

        public void Update(GameTime gameTime)
        {
            battle.combatText.UseText("End");
            Main.screen = Main.world;
        }
    }
}
