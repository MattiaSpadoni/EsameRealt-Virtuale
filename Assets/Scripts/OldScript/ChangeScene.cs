using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : GazeableObject
{
    [SerializeField]
    private string SceneToLoad;
    public override void Press()
    {
        SceneManager.LoadScene(SceneToLoad);
    }
}
