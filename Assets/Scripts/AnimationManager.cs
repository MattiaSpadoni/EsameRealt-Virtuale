using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : GazeableObject
{
    
    public Animator AnimationStart;
    public string Action;

    public override void Press()
    {
        base.Press();
        switch (Action)
        {
            case "Start":
                AnimationStart.Play("Razzi");
                PlayerSingleton.Instance.AudioManager(AudioSource, MyClip);
                break;
            case "Stop":
                AnimationStart.Play("Controller");
                PlayerSingleton.Instance.AudioActive.Stop();
                break;
        }
    }
}
