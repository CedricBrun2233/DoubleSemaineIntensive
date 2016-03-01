using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject creditsMenu;
    public GameObject winMenu;
    public GameObject loseMenu;
    public GameObject tutorialMenu;

    void HideAll()
    {
        mainMenu.SetActive(false);
        creditsMenu.SetActive(false);
        winMenu.SetActive(false);
        loseMenu.SetActive(false);
        tutorialMenu.SetActive(false);
    }
}
