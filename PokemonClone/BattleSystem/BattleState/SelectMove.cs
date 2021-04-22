using Microsoft.Xna.Framework;
using PokemonClone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClone.BattleSystem.BattleState
{
    public class SelectMove : IState
    {
        private Battle battle;
        private float timer;

        public SelectMove(Battle battle)
        {
            this.battle = battle;
        }

        public void Select()
        {

            battle.selectionBoxMove.SetVisibility(true);
            battle.selectionBoxAction.SetVisibility(false);

            //currentMove = selectionBoxMove.Select();
            if (timer > 100)
            {
                if (battle.selectionBoxMove.Select() == 1)
                {
                    GoToNextState();
                }
            }
           
        }

        public void GoToNextState()
        {
            battle.curentState = battle.changeAction;
            timer = 0;
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 2;

            Select();
        }
    }
}
