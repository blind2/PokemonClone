using PokemonClone.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonClone.BattleSystem
{
    public class AnimationManager
    {
        private Dictionary<string, Action> animationDictionary;
        private Animation animation = new Animation();
        private Battle battle;

        public AnimationManager(Battle battle)
        {
            this.battle = battle;
            BattleAnimation();
        }

        private void BattleAnimation()
        {         
            animationDictionary = new Dictionary<string, Action>();
            animationDictionary.Add("MoveLeft", new Action(() => animation.MoveSpriteLeft(battle.playerTextureRectangle, 7, 170)));
            animationDictionary.Add("MoveRight", new Action(() => animation.MoveSpriteRight(battle.opponentTextureRectangle, 7, 490)));
            animationDictionary.Add("PlayerSendPokemon", new Action(() => animation.MoveSpriteRight(battle.playerPokemonSprite, 7, 100)));
            animationDictionary.Add("PlayerSwitchPokemon", new Action(() => animation.MoveSpriteLeft(battle.playerTextureRectangle, 7, -250)));
            animationDictionary.Add("OpponentSwitchPokemon", new Action(() => animation.MoveSpriteRight(battle.opponentTextureRectangle, 7, 900)));
            animationDictionary.Add("OpponentSendPokemon", new Action(() => animation.MoveSpriteLeft(battle.opponentPokemonSprite, 7, 525)));
            animationDictionary.Add("ShowOpponentBattleFrame", new Action(() => battle.OpponentBattleFrame(true)));
            animationDictionary.Add("ShowPlayerBattleFrame", new Action(() => battle.PlayerBattleFrame(true)));
            
            animationDictionary.Add("OpponentTakeDammage", new Action(() => animation.TakeDommage(battle.opponentPokemonSprite)));
            animationDictionary.Add("PlayerTakeDammage", new Action(() => animation.TakeDommage(battle.playerPokemonSprite)));
        }

        public void UseAnimation(string name)
        {
            if (animation.Isfinished())
            {
                animationDictionary[name].Invoke();
            }
        }

        public void Invoke(string name)
        {
            animationDictionary[name].Invoke();
        }

        public Animation Animation
        {
            get { return animation; }
        }

        public Dictionary<string, Action> AnimationDictionary
        {
            get { return animationDictionary; }
        }

    }
}
