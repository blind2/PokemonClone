
using PokemonClone.Engine;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using PokemonClone.Engine.Animations;
using PokemonClone.Enums;

namespace PokemonClone.BattleSystem
{
    public class AnimationManager
    {
        private readonly BattleView battle;
        private BattleEvent battleEvent = new BattleEvent() {IsFinished = true};

        public AnimationManager(BattleView battle)
        {
            this.battle = battle;
        }

       

        public void HealthBarAnimation(GameTime gameTime)
        {
            battleEvent = new BattleEvent();
            battleEvent.HealthBarAnimation(battle.opponentHealthBar, gameTime);
        }

        public void TextEvent(GameTime gameTime)
        {
            //battleEvent = new BattleEvent();
            battleEvent.TextAnimation(battle.combatDialogBox, 2, gameTime);
        }

        public void UseAnimation(Action action)
        {
            if (battleEvent.IsFinished)
            {
                action.Invoke();
            }
        }
   }
}
