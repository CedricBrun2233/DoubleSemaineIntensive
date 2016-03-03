using UnityEngine;
using System.Collections;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [HideInInspector]
    public int currentPlayer;
    
    public GameObject progressBarre;
    public GameObject pressAToContinue;
    public GameObject pressXToTacticalView;
    public GameObject pressXToBack;
    public GameObject pressYToShowHand;
    public GameObject pressYToCloseHand;
    public GameObject pressBToBack;
    public GameObject pressTriggertoShoot;
    public GameObject coneVise;
    public GameObject shoot;
    public GameObject animRightJoystickShoot;
    public GameObject score;
    public GameObject selectedCard;

    [HideInInspector]
    public bool UIHandActive;
    [HideInInspector]
    public bool UIInStartTurnPlayer;
    [HideInInspector]
    public bool UIInTacticalView;
    [HideInInspector]
    public bool UIInShootView;
    [HideInInspector]
    public bool UIDiceSended;
    [HideInInspector]
    public bool UIInSelectSpell;
    [HideInInspector]
    public bool UIInSelectDice;
    [HideInInspector]
    public bool UIInCastSpell;

    void Awake ()
    {
        instance = this;
        progressBarre.SetActive(false);
        pressAToContinue.SetActive(false);
        pressXToTacticalView.SetActive(false);
        pressXToBack.SetActive(false);
        pressYToShowHand.SetActive(false);
        pressYToCloseHand.SetActive(false);
        pressBToBack.SetActive(false);
        coneVise.SetActive(false);
        shoot.SetActive(false);
        score.SetActive(false);
        animRightJoystickShoot.SetActive(false);
        pressTriggertoShoot.SetActive(false);
        selectedCard.SetActive(false);
    }
    

    public static UIManager GetInstance()
    {
        if (instance == null)
        {
            instance = new UIManager();
        }
        return instance;
    }

    public void HideAll()
    {
        progressBarre.SetActive(false);
        pressAToContinue.SetActive(false);
        pressXToTacticalView.SetActive(false);
        pressXToBack.SetActive(false);
        pressYToShowHand.SetActive(false);
        pressYToCloseHand.SetActive(false);
        pressBToBack.SetActive(false);
        coneVise.SetActive(false);
        shoot.SetActive(false);
        score.SetActive(false);
        animRightJoystickShoot.SetActive(false);
        pressTriggertoShoot.SetActive(false);
        selectedCard.SetActive(false);
    }

    public void UpdateUI()
    {
        UIHandActive = InputManager.GetInstance().handActive;
        UIInTacticalView = InputManager.GetInstance().inTacticalView;
        UIInStartTurnPlayer = InputManager.GetInstance().inStartTurnPlayer;
        UIInShootView = InputManager.GetInstance().inShootView;
        UIDiceSended = InputManager.GetInstance().diceSended;
        UIInSelectSpell = InputManager.GetInstance().inSelectSpell;
        UIInSelectDice = InputManager.GetInstance().inSelectDice;
        UIInCastSpell = InputManager.GetInstance().inCastSpell;

        if (UIInStartTurnPlayer)
        {
            HideAll();
            //Panneau
            progressBarre.SetActive(true);
            pressAToContinue.SetActive(true);
            pressXToTacticalView.SetActive(true);
            pressYToShowHand.SetActive(true);
        }
        else if (UIInShootView)
        {
            HideAll();
            //Panneau
            progressBarre.SetActive(true);
            coneVise.SetActive(true);
            animRightJoystickShoot.SetActive(true);
            pressYToShowHand.SetActive(true);
            pressXToTacticalView.SetActive(true);
            pressTriggertoShoot.SetActive(true);
            pressBToBack.SetActive(true);
        }
        else if (UIDiceSended)
        {
            HideAll();
            //Panneau

            progressBarre.SetActive(true);
        }
        else if (UIInSelectSpell)
        {
            HideAll();
            //Panneau

            progressBarre.SetActive(true);
            PrintHandToChooseSpell();
            pressXToTacticalView.SetActive(true);
            score.SetActive(true);
            pressAToContinue.SetActive(true);

        }
        else if (UIInSelectDice)
        {
            HideAll();
            //Panneau
            progressBarre.SetActive(true);
            selectedCard.SetActive(true);
            pressXToTacticalView.SetActive(true);
            pressAToContinue.SetActive(true);
        }
        else if (UIInCastSpell)
        {
            HideAll();
            //Panneau
            progressBarre.SetActive(true);

        }

        if (UIInTacticalView)
        {
            HideAll();
            progressBarre.SetActive(true);
            pressXToBack.SetActive(true);
        }
        else if (UIHandActive)
        {
            //Panneau
            PrintHand();
            pressYToCloseHand.SetActive(true);
        }
    }

    private void PrintHandToChooseSpell()
    {

    }

    private void PrintHand()
    {

    }
}
