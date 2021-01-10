using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapButton : GazeableObject
{
    public string ActionType;
    public List<string> Paths = new List<string>();
    public List<string> Years = new List<string>();
    [SerializeField]
    private GameObject ImagePanel;
    [SerializeField]
    private GameObject YearPanel;
    [SerializeField]
    private List<GameObject> ToActive = new List<GameObject>();
    
    public override void Press()
    {
        Debug.Log("started");
        switch (ActionType)
        {
            case "Explanation":
                PlayerSingleton.Instance.AudioManager(AudioSource, MyClip);
                break;
            case "InfluenceMap":
                Clear(YearPanel, ImagePanel);
                AddElements(YearPanel, ImagePanel);
                Pointers(ToActive);
                PlayerSingleton.Instance.AudioManager(AudioSource, MyClip);
                break;
            

        }


    }

  /*  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Press();
        }

    }
   */


    private void Clear(GameObject Object1, GameObject Object2)
    {
        foreach (Transform Child in Object1.transform)
        {
            Child.gameObject.GetComponent<Text>().text = "Scegli un'opzione";
            Debug.Log(Child.gameObject.GetComponent<Text>().text);
        }
        foreach (Transform Child in Object2.transform)
        {
            Child.gameObject.GetComponent<RawImage>().texture = null;
            
        }
        Debug.Log("Done Clear");
    }
    private void AddElements(GameObject Object1, GameObject Object2) 
    {
        List<Text> TextList = new List<Text>();
        List<RawImage> TextureList = new List<RawImage>();
        int CheckIndex = 0;
        foreach (Transform Child in Object1.transform)
        {
            TextList.Add(Child.gameObject.GetComponent<Text>());
            
        }
        foreach (Transform Child in Object2.transform)
        {
            TextureList.Add(Child.gameObject.GetComponent<RawImage>());
        }
        while (CheckIndex < TextList.Count )
        {
            Debug.Log("Iteration Number " + CheckIndex);
            TextList[CheckIndex].text = Years[CheckIndex];
            TextureList[CheckIndex].texture = Resources.Load(Paths[CheckIndex]) as Texture;
            Debug.Log(CheckIndex);
            CheckIndex++;
        }
        Debug.Log("Done Adding");
    }
    private void Pointers(List<GameObject> List1) 
    {
       
        foreach (GameObject Pointer in InfluenceSingleton.Instance.Deactivate)
        {
            Pointer.SetActive(false);
        }
        InfluenceSingleton.Instance.Deactivate.Clear();
        foreach (GameObject Pointer in List1)
        {
            Pointer.SetActive(true);
            InfluenceSingleton.Instance.Deactivate.Add(Pointer);
        }

    }
    /*
     * 
     * 
     * 
     * 
     * 
     * 
    private void PointersUpdated(List<GameObject> List1) 
    {
    foreach (GameObject Object in MotiAnimoManager.Instance.Deactivate)
        {
            Object.SetActive(false);
        }
    MotiAnimoManager.Instance.Deactivate.Clear();
    foreach (GameObject ToActivate in List1) 
    {
        ToActivate.SetActive(true);
        MotiAnimoManager.Instance.Deactivate.Add(ToActivate);
    }
        Debug.Log("Done");

    }

    private void UpdatedAddElements(GameObject Object1, GameObject Object2) 
    {
    List<Text> TextList = new List<Text>();
    List<RawImage> TextureList = new List<RawImage>();
    int CheckIndex = 0;
        foreach (Transform Child in Object1.transform)
        {
            TextList.Add(Child.gameObject.GetComponent<Text>());
            
        }
        foreach (Transform Child in Object2.transform)
        {
            TextureList.Add(Child.gameObject.GetComponent<RawImage>());
        }
        while (CheckIndex < Years.Count )
        {
            TextList[CheckIndex].text = Years[CheckIndex];
            TextureList[CheckIndex].texture = Resources.Load(Paths[CheckIndex]) as Texture;
            //Debug.Log(TextureList[CheckIndex]);
            CheckIndex++;
        }
        Debug.Log("Done Adding");
    }




    */


}
