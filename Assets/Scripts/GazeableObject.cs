using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeableObject : MonoBehaviour
{
    [SerializeField]
    protected AudioSource AudioSource;
    [SerializeField]
    protected AudioClip MyClip;

    public virtual void TestGazeEnter()
    {
        Debug.Log("Sto guardando" + gameObject.name);
    }
    public virtual void Press() 
    {
        Debug.Log("Cardboard Input Pressed");
    }

}
