using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokemonClone.Enums;

namespace PokemonClone.BattleSystem
{
    public class BattleText
    {
        private BattleView battleView;

        public BattleText(BattleView battleView)
        {
            this.battleView = battleView;
            GetDialogBoxText();           
        }

        private void GetDialogBoxText()
        {
            battleView.combatDialogBox.AddText("BUG CATCH Joe\nwould like to battle !");
            battleView.combatDialogBox.AddText("BUG CATCH Joe\nsend out Charmander !");
            battleView.combatDialogBox.AddText("A wild pokemon as appeared !");
            battleView.combatDialogBox.AddText("What will\n" + battleView.PlayerPokemon.PokemonStats.Name.ToUpper() + " do ?");
            battleView.combatDialogBox.AddText(battleView.PlayerPokemon.PokemonStats.Name.ToUpper() + " used\n" + battleView.PlayerPokemon.listMove[0].Name.ToUpper());
            battleView.combatDialogBox.AddText(battleView.OpponentPokemon.PokemonStats.Name + " used\n" + battleView.OpponentPokemon.listMove[0].Name.ToUpper());
        }      
    }
}
