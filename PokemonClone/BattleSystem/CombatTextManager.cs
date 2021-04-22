using System.Collections.Generic;

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

            messageDictionary.Add("intro", "RIVAL GARY\nwould like to battle !");
            messageDictionary.Add("OpponentSendPokemon", "RIVAL GARY send out\n" + battle.opponentPokemon.PokemonStats.Name.ToUpper() + " !");
            messageDictionary.Add("PlayerSendPokemon", "Go ! " + battle.playerPokemon.PokemonStats.Name.ToUpper() + " !");
            messageDictionary.Add("SelectOption", "What will\n" + battle.playerPokemon.PokemonStats.Name.ToUpper() + " do ?");
            messageDictionary.Add("PlayerPokemonAttack", battle.playerPokemon.PokemonStats.Name.ToUpper() + " used\n" + battle.playerPokemon.listMove[0].Name.ToUpper());
            messageDictionary.Add("OpponentPokemonAttck", battle.opponentPokemon.PokemonStats.Name + " used " + battle.opponentPokemon.listMove[0].Name.ToUpper());
            messageDictionary.Add("OpponentPokemonDeath", "Foe " + battle.opponentPokemon.PokemonStats.Name.ToUpper() + "\nfainted !");
            messageDictionary.Add("End", "You have beat Gary");
        }


        public void UseText(string name)
        {

            battle.dialogBox.GetDialog(messageDictionary[name]);

        }

    }
}
