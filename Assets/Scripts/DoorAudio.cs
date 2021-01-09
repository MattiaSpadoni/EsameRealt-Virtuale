using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DoorAudio : GazeableObject
{
    public GameObject ToActivate; //button to be activated

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Press()
    {
        // first interaction with the menu ever, nothing is running
        if (InitialSingleton.Instance.ActiveButton == null)
        {
            //assigning in the singleton the current active object and both Audiosource and Audioclip to be played
            //Audiosource tracked in singleton is assigned and then the audioclip is given
            InitialSingleton.Instance.ActiveButton = ToActivate;
            PlayerSingleton.Instance.AudioActive = AudioSource;
            PlayerSingleton.Instance.AudioActive.clip = MyClip;
            //coroutine to active the button only at the end
            StartCoroutine(Audio());
        }
        //what to do if the player click another button from the previous one, valid both on case of audio running or not
        else if (ToActivate != InitialSingleton.Instance.ActiveButton && InitialSingleton.Instance.ActiveButton != null)
        {

            InitialSingleton.Instance.ActiveButton.SetActive(false);
            InitialSingleton.Instance.ActiveButton = ToActivate;
            PlayerSingleton.Instance.AudioActive = AudioSource;
            PlayerSingleton.Instance.AudioActive.clip = MyClip;
            PlayerSingleton.Instance.AudioActive.Stop();
            PlayerSingleton.Instance.AudioActive.Play();
            StartCoroutine(Audio());
        }
        // case of user reclicking on the same button after the audio is already finished, the track is played again.
        else if (ToActivate == InitialSingleton.Instance.ActiveButton && PlayerSingleton.Instance.AudioActive.isPlaying == false)
        {
            PlayerSingleton.Instance.AudioActive.Play();
        }
        

    }

    IEnumerator Audio() 
    {
        //coroutine, checking continously if the current audio is playing, when finished it actives the object
        Debug.Log("arrived here");
        AudioSource.Play();
        Debug.Log("Started Audio");
        yield return new WaitWhile(() => PlayerSingleton.Instance.AudioActive.isPlaying);
        ToActivate.SetActive(true);

    }

}
