using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    static InputManager instance;

    private Card selected;
    public bool waitingSelectCard;

	void Awake ()
    {
        DontDestroyOnLoad(this);
        instance = this;

        waitingSelectCard = false;
        selected = null;
    }
	
    public static InputManager GetInstance()
    {
        if(instance == null)
        {
            instance = new InputManager();
        }
        return instance;
    }

    void Update ()
    {
#if UNITY_STANDALONE_WIN
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
                    waitingSelectCard = false;
                }
            }
        }
#endif
    }
}
