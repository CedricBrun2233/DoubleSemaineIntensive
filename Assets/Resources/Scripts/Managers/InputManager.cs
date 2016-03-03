using UnityEngine;
using System.Collections;
using System;

public class InputManager : MonoBehaviour
{
    static InputManager instance;

    private Card cardPreSelected;
    private Dice dicePreSelected;
    
    private bool globalTurnPlayer1;
    private bool globalTurnPlayer2;

    public bool handActive;
    public bool inStartTurnPlayer;
    public bool inTacticalView;
    public bool inShootView;
    public bool diceSended;
    public bool inSelectSpell;
    public bool inSelectDice;
    public bool inCastSpell;

    void Awake ()
    {
        DontDestroyOnLoad(this);
        instance = this;

        //To UI
        globalTurnPlayer1 = false;
        globalTurnPlayer2 = false;
        handActive = false;
        inStartTurnPlayer = true;
        inTacticalView = false;
        inShootView = false;
        diceSended = false;
        inSelectSpell = false;
        inSelectDice = false;
        inCastSpell = false;

        //ToSelectDice&Card
        cardPreSelected = null;
        dicePreSelected = null;
}
	
    public static InputManager GetInstance()
    {
        if(instance == null)
        {
            instance = new InputManager();
        }
        return instance;
    }

    public void OnPressButtonA()
    {
        if (handActive || inTacticalView)
        {
            return;
        }

        if(inStartTurnPlayer)
        {
            inStartTurnPlayer = false;
            inShootView = true;
            //ChangeCamera
            UIManager.GetInstance().UpdateUI();
            return;
        }
        if(inSelectDice)
        {
            inSelectDice = false;
            inCastSpell = true;
            UIManager.GetInstance().UpdateUI();
            return;
        }
        if(inSelectSpell)
        {
            inSelectSpell = false;
            inSelectDice = true;
            TurnManager.GetInstance().SelectCard(cardPreSelected);
            UIManager.GetInstance().UpdateUI();
        }
    }
    public void OnPressButtonB()
    {
        if(handActive)
        {
            handActive = false;
            UIManager.GetInstance().UpdateUI();
            return;
        }
        if(inShootView)
        {
            inShootView = false;
            inStartTurnPlayer = true;
            UIManager.GetInstance().UpdateUI();
            return;
        }
        if(inSelectDice)
        {
            inSelectDice = false;
            inSelectSpell = true;
            UIManager.GetInstance().UpdateUI();
        }
    }
    public void OnPressButtonX()
    {
        if(handActive)
        {
            return;
        }
        if(inTacticalView)
        {
            inTacticalView = false;
            //ChangeCamera
            UIManager.GetInstance().UpdateUI();
            return;                
        }
        if(inStartTurnPlayer || inShootView || inSelectSpell || inSelectDice)
        {
            inTacticalView = true;
            //ChangeCamera
            UIManager.GetInstance().UpdateUI();
            return;
        }
    }
    public void OnPressButtonY()
    {
        if (handActive)
        {
            handActive = false;
            UIManager.GetInstance().UpdateUI();
            return;
        }
        if (inStartTurnPlayer || inShootView)
        {
            handActive = true;
            UIManager.GetInstance().UpdateUI();
        }
    }
    public void OnPressButtonLB()
    {
        if(handActive)
        {
            return;
        }
        if(inShootView)
        {
            TurnManager.GetInstance().playerGameObject.transform.GetChild(0).GetComponent<CameraScript>().changeAngle(-1);
            UIManager.GetInstance().UpdateUI();
        }
    }
    public void OnPressButtonRB()
    {
        if (handActive)
        {
            return;
        }
        if (inShootView)
        {
            TurnManager.GetInstance().playerGameObject.transform.GetChild(0).GetComponent<CameraScript>().changeAngle(1);
            UIManager.GetInstance().UpdateUI();
        }
    }

    void Update ()
    {/*
        if (Input.GetMouseButtonDown(0))
        {
            if(waitingSelectCard)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                Physics.Raycast(ray, out hit, 1000);
                if (hit.collider.gameObject.tag == "Card")
                {
                    selected = hit.collider.gameObject.GetComponent<Card>();
                    TurnManager.GetInstance().SelectCard(selected);
                }
            }
        }*/
        if (Input.GetButtonDown("ButtonA"))
        {
            OnPressButtonA();
        }
        if (Input.GetButtonDown("ButtonB"))
        {
            OnPressButtonB();
        }
        if (Input.GetButtonDown("ButtonX"))
        {
            OnPressButtonX();
        }
        if (Input.GetButtonDown("ButtonY"))
        {
            OnPressButtonY();
        }
        if (Input.GetButtonDown("ButtonLB"))
        {
            OnPressButtonLB();
        }
        if (Input.GetButtonDown("ButtonRB"))
        {
            OnPressButtonRB();
        }
    }
}
