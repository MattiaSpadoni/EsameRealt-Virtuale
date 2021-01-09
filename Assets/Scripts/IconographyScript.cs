using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconographyScript : GazeableObject
{
    [SerializeField]
    private Text TextToChange; // This is the text under the visual representation, its value will be changed to store the textual data.
    [SerializeField]
    private GameObject ObjectToChange; // this is the object that will be changed adding the photo

    public string ElementInText; // this string store the value that will be the content of TextToChange
    public string Path; // this string store the path where the system will locate the position of the image inside Game Assets.
    [SerializeField]
    private string Function; // defines which actions the button will do.

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
        base.Press();
        switch(Function)
        {
            //the button has only an audio attached to it, it playes it
            case "Explanation":
                Debug.Log("Started");
                PlayerSingleton.Instance.AudioManager(AudioSource, MyClip);
                
                break;
            //the button change the current menu loading a new one.
            case "ChangeMenu":
                ObjectToChange.SetActive(true);
                Debug.Log(this.transform.root.gameObject.name);
                this.transform.root.gameObject.SetActive(false);
                break;
            //simple case of loading, the object modifies texture and text of target GameObjects
            case "LoadSimple":
                ObjectToChange.GetComponent<MeshRenderer>().material.mainTexture = Resources.Load(Path) as Texture;
                PlayerSingleton.Instance.AudioManager(AudioSource, MyClip);
                break;
            case "test":
                Debug.Log(ObjectToChange.GetComponentInChildren<Text>().text);
                break;
            case "LoadFinal":
                // First action in absolute, the system firstly assign as currently active object in the singleton the one in the variable
                if (IconographySingleton.Instance.Empty == null)
                {
                    IconographySingleton.Instance.Empty = ObjectToChange;
                    //In the singleton a list of objects children of the previous one is populated
                    foreach (Transform child in ObjectToChange.transform)
                    {
                        IconographySingleton.Instance.ToChange.Add(child.gameObject);

                    }
                    //finalInt is an index inside the singleton, at the start it is 0, the system populate the first quad with the first interaction
                    GameObject ToTransform = IconographySingleton.Instance.ToChange[IconographySingleton.Instance.FinalInt];
                    ToTransform.GetComponent<MeshRenderer>().material.mainTexture = Resources.Load(Path) as Texture;
                    ToTransform.GetComponentInChildren<Text>().text = ElementInText;
                    //index is upgraded.
                    IconographySingleton.Instance.FinalInt++;


                }
                //continuinuing to add, the user is interacting with the same set of objects
                else if (IconographySingleton.Instance.Empty == ObjectToChange 
                        && 
                        IconographySingleton.Instance.FinalInt < IconographySingleton.Instance.ToChange.Count)
                        

                {
                   
                    GameObject ToTransform = IconographySingleton.Instance.ToChange[IconographySingleton.Instance.FinalInt];
                    ToTransform.GetComponent<MeshRenderer>().material.mainTexture = Resources.Load(Path) as Texture;
                    ToTransform.GetComponentInChildren<Text>().text = ElementInText;
                    IconographySingleton.Instance.FinalInt++;
                }

                // Case the user went from one set of visualiser objects to another one.
                else if (IconographySingleton.Instance.Empty != ObjectToChange)
                {
                    
                     IconographySingleton.Instance.Empty = ObjectToChange;
                     foreach(var Item in IconographySingleton.Instance.ToChange)
                     {
                        //system reset the elements in the old set without interacting with the new one
                        Item.GetComponentInChildren<Text>().text = "Scegli un'opzione";
                        Item.GetComponent<MeshRenderer>().material.mainTexture = null;
                     }
                     //list in the singleton is cleared and Index = 0 to start another interaction
                     IconographySingleton.Instance.ToChange.Clear();
                     IconographySingleton.Instance.FinalInt = 0;
                    //from here it is equal to the first case, the system create a list of Objects to be changed and select them
                    //with an index. The first interaction populates the first square.
                     foreach (Transform child in ObjectToChange.transform)
                     {
                        IconographySingleton.Instance.ToChange.Add(child.gameObject);

                     }
                    GameObject ToTransform = IconographySingleton.Instance.ToChange[IconographySingleton.Instance.FinalInt];
                    ToTransform.GetComponent<MeshRenderer>().material.mainTexture = Resources.Load(Path) as Texture;
                    ToTransform.GetComponentInChildren<Text>().text = ElementInText;
                    IconographySingleton.Instance.FinalInt++;

                }
                break;
            //Cancel in case of complex load system
            case "CancelFinal":
                //not cancel anything if everything is already canceled.
                if (IconographySingleton.Instance.FinalInt > 0)
                {
                    //system use the index, due to the index being currently higher than currently populated quad firstly it decrease it
                    IconographySingleton.Instance.FinalInt--;
                    //selecting and cleaning the object
                    GameObject ToTransform = IconographySingleton.Instance.ToChange[IconographySingleton.Instance.FinalInt];
                    ToTransform.GetComponent<MeshRenderer>().material.mainTexture = Resources.Load(Path) as Texture;
                    ToTransform.GetComponentInChildren<Text>().text = "scegli un opzione";

                }
                break;

            case "Load":
                TextToChange.text = ElementInText;
                ObjectToChange.GetComponent<MeshRenderer>().material.mainTexture = Resources.Load(Path) as Texture;
                PlayerSingleton.Instance.AudioManager(AudioSource, MyClip);
                break;

        }
        

    }
}





//old scripts


/*case "LoadComplex":

    if (IconographySingleton.Instance.Index < 5)
    {
        IconographySingleton.Instance.ObjectsToChange[IconographySingleton.Instance.Index].GetComponent<MeshRenderer>().material.mainTexture = Resources.Load(Path) as Texture;
        IconographySingleton.Instance.TextsToChange[IconographySingleton.Instance.Index].text = ElementInText;
        IconographySingleton.Instance.Index++;
    }
    break;
case "Cancel":
    if(IconographySingleton.Instance.Index > 0)
    {
        IconographySingleton.Instance.Index--;
        IconographySingleton.Instance.ObjectsToChange[IconographySingleton.Instance.Index].GetComponent<MeshRenderer>().material.mainTexture = null;
        IconographySingleton.Instance.TextsToChange[IconographySingleton.Instance.Index].text = "scegli un'opzione";


    }
    break;
case "LoadComplex2":
    Debug.Log("Started");
    if (IconographySingleton.Instance.Index2 < 3)
    {
        IconographySingleton.Instance.ObjectsToChange2[IconographySingleton.Instance.Index2].GetComponent<MeshRenderer>().material.mainTexture = Resources.Load(Path) as Texture;
        IconographySingleton.Instance.TextsToChange2[IconographySingleton.Instance.Index2].text = ElementInText;
        IconographySingleton.Instance.Index2++;
    }
    break;
case "Cancel2":
    Debug.Log("Started");
    if (IconographySingleton.Instance.Index2 > 0)
    {
        IconographySingleton.Instance.Index2--;
        IconographySingleton.Instance.ObjectsToChange2[IconographySingleton.Instance.Index2].GetComponent<MeshRenderer>().material.mainTexture = null;
        IconographySingleton.Instance.TextsToChange2[IconographySingleton.Instance.Index2].text = "scegli un'opzione";


    }
    break;*/
