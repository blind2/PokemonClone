using System.Collections.Generic;
using PokemonClone.Engine;

namespace PokemonClone.BattleSystem
{
    public class CombatTextManager
    {
        private Battle battle;
        public Dictionary<string, string> messageDictionary = new Dictionary<string, string>();

        public CombatTextManager(Battle battle)
        {
            this.battle = battle;
            BattleCombatText();
        }


        private void BattleCombatText()
        {
            /*
            battle.combatDialogBox.AddText("RIVAL GARY\nwould like to battle !");
            battle.combatDialogBox.AddText("RIVAL GARY send out\n" + battle.OpponentPokemon.PokemonStats.Name.ToUpper() + " !");
            battle.combatDialogBox.AddText("Go ! " + battle.PlayerPokemon.PokemonStats.Name.ToUpper() + " !");
            battle.combatDialogBox.AddText("What will\n" + battle.PlayerPokemon.PokemonStats.Name.ToUpper() + " do ?");
            battle.combatDialogBox.AddText(battle.PlayerPokemon.PokemonStats.Name.ToUpper() + " used\n" + battle.PlayerPokemon.listMove[0].Name.ToUpper());
            battle.combatDialogBox.AddText(battle.OpponentPokemon.PokemonStats.Name + " used " + battle.OpponentPokemon.listMove[0].Name.ToUpper());
            battle.combatDialogBox.AddText("Foe "+ battle.OpponentPokemon.PokemonStats.Name.ToUpper() + "\nfainted !");
            battle.combatDialogBox.AddText("You have beat Gary");
            */
        }


    }
}
