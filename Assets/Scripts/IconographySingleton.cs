using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconographySingleton : MonoBehaviour
{

    public GameObject Empty;
    public List<GameObject> ToChange = new List<GameObject>();
    public int FinalInt;

    private static IconographySingleton _instance;
    public static IconographySingleton Instance 
    {
        get 
        {
            if (_instance == null)
                Debug.Log("Singleton not loaded");
            return _instance;
        }
    }
    private void Awake()
    {
        _instance = this;
    }
}


//old pieces of the script

/*
public int Index;
public int Index2;
public List<GameObject> ObjectsToChange = new List<GameObject>();
public List<Text> TextsToChange = new List<Text>();
public List<GameObject> ObjectsToChange2 = new List<GameObject>();
public List<Text> TextsToChange2 = new List<Text>();
*/
