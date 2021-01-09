using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GazeableButton : GazeableObject
{
    [SerializeField]
    private string Action;
    [SerializeField]
    private string ElementToLoad;
    public override void Press()
    {
        switch (Action) 
        {
            case null:
                Debug.Log("action not assigned, please correct");
                break;
            case "Quit":
                Application.Quit();
                break;

            case "LoadScene":
                SceneManager.LoadScene(ElementToLoad);
                break;
            case "EasterEgg":
                PlayerSingleton.Instance.AudioManager(AudioSource, MyClip);
                break;



        }

    }
}
