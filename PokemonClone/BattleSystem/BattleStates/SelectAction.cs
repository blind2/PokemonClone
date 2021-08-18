using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.Animations;
using PokemonClone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClone.BattleSystem.BattleStates
{
    public class SelectAction : IState
    {
        private Battle battle;
        private TextAnimation textAnimation;
        private bool isDone;

        public SelectAction(Battle battle)
        {
            this.battle = battle;
            textAnimation = new TextAnimation(battle.battleView.combatDialogBox, 3);
            battle.battleView.selectionBoxAction.SelectionBoxInput.Select += SelectionBoxInput_Select;
        }

        private void SelectionBoxInput_Select()
        {
            var selection = battle.battleView.selectionBoxAction.SelectionBoxInput.ActiveCursor;
            if (selection == 0)
            {
                battle.CurrentState = new ChangeTurn(battle);
            }
        }
       
        public void GoToNextState()
        {
            battle.CurrentState = battle.PlayerTurn;
        }

        public void Update(GameTime gameTime)
        {



            textAnimation.Update(gameTime);
            battle.battleView.selectionBoxAction.SetVisibility(true);
            battle.battleView.selectionBoxMove.SetVisibility(false);

        }

        public void LoadContent(ContentManager content)
        {
            throw new NotImplementedException();
        }

        public void Draw(SpriteBatch spriteBtach)
        {
            //throw new NotImplementedException();
        }
    }
}
