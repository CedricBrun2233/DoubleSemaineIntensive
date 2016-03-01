using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{
    static InputManager instance;

	void Awake ()
    {
        DontDestroyOnLoad(this);   
	}
	
    public static InputManager GetInstance()
    {
        if(instance = null)
        {
            instance = new InputManager();
        }
        return instance;
    }

    void Update ()
    {
#if UNITY_STANDALONE_WIN


#endif
#if UNITY_STANDALONE_OSX


#endif
    }
}
