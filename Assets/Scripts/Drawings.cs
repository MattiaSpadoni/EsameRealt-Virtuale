using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drawings : GazeableObject
{
    public string ActionType;
    public List<string> Paths = new List<string>(); //storing all paths to images.
    public List<string> Years = new List<string>(); //storing all list of texts to be changed each time
    [SerializeField]
    private GameObject ImagePanel; //father of all raw images used for showing preparatory works
    [SerializeField]
    private GameObject YearPanel; //father of all texts used to give more information about them.
    [SerializeField]
    private List<GameObject> ToActive = new List<GameObject>();
    public override void Press()
    {
        base.Press();

        Debug.Log("started");
        switch (ActionType)
        {
            
            //system acting to load the content
            case "Drawings":
                //before it delete previous elements
                Clear(YearPanel, ImagePanel);
                //System updates
                UpdatedAddElements(YearPanel, ImagePanel);
                PointersUpdated(ToActive);
                PlayerSingleton.Instance.AudioManager(AudioSource, MyClip);
                break;
            case "Explanation":
                PlayerSingleton.Instance.AudioManager(AudioSource, MyClip);
                break;


        }

        }

    // this function clear the complete set of objects of previous values
    private void Clear(GameObject Object1, GameObject Object2)
    {
        //system access all textual element child of canavas containing Textual element (Object 1)
        foreach (Transform Child in Object1.transform)
        {
            Child.gameObject.GetComponent<Text>().text = "Scegli un'opzione";
            Debug.Log(Child.gameObject.GetComponent<Text>().text);
        }
        //system access the canvas father of raw images ((Object 2), then goes inside them and cancel the texture. 
        foreach (Transform Child in Object2.transform)
        {
            Child.gameObject.GetComponent<RawImage>().texture = null;

        }
        Debug.Log("Done Clear");

    }
    //This function Deactivate already active Frames on Last Supper work and then activate new ones.
    private void PointersUpdated(List<GameObject> List1)
    {
        //accessing the Singleton to deactivate each object inside the list of objects to be deactivate
        foreach (GameObject Object in DrawingSingleton.Instance.Deactivate)
        {
            Object.SetActive(false);
        }
        //clearing the list and prepararing it for the new ones objects incoming
        DrawingSingleton.Instance.Deactivate.Clear();
        //Activating new frames and adding them to the list of the singleton to be deactivated at the next interaction
        foreach (GameObject ToActivate in List1)
        {
            ToActivate.SetActive(true);
            DrawingSingleton.Instance.Deactivate.Add(ToActivate);
        }
        Debug.Log("Done");

    }
    //Changing text and images of preparatory drawings, using canvas father of Text elements and canvas father of images elements
    private void UpdatedAddElements(GameObject Object1, GameObject Object2)
    {
        //creating empty list for storing objects to be changed
        List<Text> TextList = new List<Text>();
        List<RawImage> TextureList = new List<RawImage>();
        //creating an index in order to check which object to check each time.
        int CheckIndex = 0;
        //populating the 2 lists with children of respctive canvas
        foreach (Transform Child in Object1.transform)
        {
            TextList.Add(Child.gameObject.GetComponent<Text>());

        }
        foreach (Transform Child in Object2.transform)
        {
            TextureList.Add(Child.gameObject.GetComponent<RawImage>());
        }
        //using the index to modify the correct text and correct image with the corresponding values inside initial lists.
        while (CheckIndex < Years.Count)
        {
            TextList[CheckIndex].text = Years[CheckIndex];
            TextureList[CheckIndex].texture = Resources.Load(Paths[CheckIndex]) as Texture;
            //Debug.Log(TextureList[CheckIndex]);
            CheckIndex++;
        }
        Debug.Log("Done Adding");
    }
}