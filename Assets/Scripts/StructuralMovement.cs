using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StructuralMovement : GazeableObject
{
    [SerializeField]
    private string ActionType;
    [SerializeField]
    private string Scene;
    [SerializeField]
    private GameObject DoorButton;

    public override void Press()
    {
        switch (ActionType)
        {
            case "Quit":

                if (PlayerSingleton.Instance.Confirmation == false)
                 {
                     PlayerSingleton.Instance.AudioActive = AudioSource;
                     PlayerSingleton.Instance.AudioActive.clip = MyClip;
                     PlayerSingleton.Instance.AudioActive.Play();
                     PlayerSingleton.Instance.Confirmation = true;
                     Debug.Log("Ho cliccato la prima volta");
                 }
                 else
                 {
                    
                     Application.Quit();
                     Debug.Log("Ho cliccato la seconda volta");
                 }
                  
                break;
            
            case "LoadScene":
                Debug.Log("attivato");
                PlayerSingleton.Instance.AudioActive = AudioSource;
                PlayerSingleton.Instance.AudioActive.clip = MyClip;
                StartCoroutine(Audio());
                break;
            case "ConfirmedScene":
                SceneManager.LoadScene(Scene);
                break;
        }
    }
    IEnumerator Audio()
    {
        Debug.Log("arrived here");
        AudioSource.Play();
        Debug.Log("Started Audio");
        yield return new WaitWhile(() => PlayerSingleton.Instance.AudioActive.isPlaying);
        DoorButton.SetActive(true);

    }
}
