using Microsoft.Xna.Framework;
using PokemonClone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClone.BattleSystem.BattleState
{
    public class SelectAction : IState
    {
        private Battle battle;

        public SelectAction(Battle battle)
        {
            this.battle = battle;
        }

        public void GoToNextState()
        {
            battle.curentState = battle.selectMove;
        }

        public void Select()
        {
            battle.combatText.UseText("SelectOption");
            battle.selectionBoxMove.SetVisibility(false);
            battle.selectionBoxAction.SetVisibility(true);

            switch (battle.selectionBoxAction.Select())
            {
                case 1:
                    GoToNextState();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            Select();
        }
    }
}
