using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using PokemonClone.BattleSystem.BattleStates;
using PokemonClone.Enums;
using PokemonClone.Model;
using PokemonClone.PokemonData;
using System;

namespace PokemonClone.BattleSystem
{
    public class Battle
    {
        private Pokemon playerPokemon;
        private Pokemon opponentPokemon;
        public  BattleView battleView { get; }

        private bool pokemonCanAttack = false;
        private int selectedMove;
        private int turn;

        private BattleEvent battleEvent = new BattleEvent();
        public static event Action<BattleState> StateChanged;
        private BattleState state = BattleState.Start;


        private BattleText battleText;
        public Introduction Introduction { get; }
        public  SelectAction SelectAction { get; }
        public  PlayerTurn PlayerTurn { get; }

        //TODO check if currentt state can be static
        public IState CurrentState { get; set; }

        public Battle(BattleView battleView)
        {
            this.battleView = battleView;


            playerPokemon = battleView.PlayerPokemon;
            opponentPokemon = battleView.OpponentPokemon;

            Introduction = new Introduction(this);
            battleText = new BattleText(battleView);
            SelectAction = new SelectAction(this);
            PlayerTurn = new PlayerTurn(this);

            CurrentState = Introduction;
        }


     

        public void LoadContent(ContentManager content)
        {
            CurrentState.LoadContent(content);
        }

        public void Update(GameTime gameTime)
        {
            CurrentState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            CurrentState.Draw(spriteBatch);
        }
    }
}
