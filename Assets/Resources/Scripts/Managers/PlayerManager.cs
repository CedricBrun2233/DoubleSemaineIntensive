using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;

    private Player player1;
    private Player player2;

    void Awake()
    {

    }

    public static PlayerManager GetInstance()
    {
        if (instance = null)
        {
            instance = new PlayerManager();
        }
        return instance;
    }

    public void PlayTurn(bool isPlayer1)
    {
        if (isPlayer1)
        {
            foreach (Dice dice in player1.dices)
            {
                dice.RollDice();
                //Une fois le mouvement du dé terminé : Checker le result
                int result = dice.GetResult();
                player1.AddMana(result);
            }
            //UI pour la main du joueur
            //Selection du Spell a lancer
            //Lancement du Spell
            player1.EndOfTurn();
        }
        else
        {
            foreach (Dice dice in player2.dices)
            {
                dice.RollDice();
                //Une fois le mouvement du dé terminé : Checker le result
                int result = dice.GetResult();
                player2.AddMana(result);
            }
            //UI pour la main du joueur
            //Selection du Spell a lancer
            //Lancement du Spell
            player2.EndOfTurn();
        }
    }
}
