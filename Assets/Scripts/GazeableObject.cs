using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        if (PlayerSingleton.Instance.LastHit == null)
        {
            PlayerSingleton.Instance.LastHit = this.gameObject;
            Debug.Log(PlayerSingleton.Instance.LastHit.name);
            PlayerSingleton.Instance.LastHit.GetComponent<Image>().color = Color.gray;
        }
        else if (PlayerSingleton.Instance.LastHit != null)
        {
            PlayerSingleton.Instance.LastHit.GetComponent<Image>().color = Color.white;
            PlayerSingleton.Instance.LastHit = this.gameObject;
            PlayerSingleton.Instance.LastHit.GetComponent<Image>().color = Color.gray;
        }
    }

}
