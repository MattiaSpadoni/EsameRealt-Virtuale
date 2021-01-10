using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualInitial : GazeableObject
{
    [SerializeField]
    private GameObject ObjectToLoad; //Object to be loaded on the scene
    [SerializeField]
    private GameObject Quad; //temporary setting
    [SerializeField]
    private string Function; //String defining the type of action of being performed
    [SerializeField]
    private string Path; //Path of texture to be put in the space.

    public override void Press()
    {
        base.Press();
        switch (Function)
        {
            case "Forward":
                
                ObjectToLoad.SetActive(true);
                Debug.Log(this.transform.root.gameObject.name);
                this.transform.root.gameObject.SetActive(false);
                Quad.SetActive(true);
                break;
            case "Back":
                ObjectToLoad.SetActive(true);
                Debug.Log(this.transform.root.gameObject.name);
                this.transform.root.gameObject.SetActive(false);
                Quad.SetActive(false);
                Quad.GetComponent<MeshRenderer>().material.mainTexture = Resources.Load(Path) as Texture;
                break;
            case "Load":
                PlayerSingleton.Instance.AudioManager(AudioSource, MyClip);
                Quad.SetActive(true);
                Quad.GetComponent<MeshRenderer>().material.mainTexture = Resources.Load(Path) as Texture;
                break;

        // action of frame activation
            case "Frame":
                PlayerSingleton.Instance.AudioManager(AudioSource, MyClip);
                //accessing the singleton list of previous active Objects and deactivate them
                foreach (var Frame in InitialSingleton.Instance.ToDeactivate) 
                {
                    Frame.SetActive(false);
                }
                //clear the list
                InitialSingleton.Instance.ToDeactivate.Clear();
                //set active new object and put them in the singleton's list
                ObjectToLoad.SetActive(true);
                InitialSingleton.Instance.ToDeactivate.Add(ObjectToLoad);
                break;

        }

    }
}
