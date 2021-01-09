using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfluenceButton : GazeableObject
{
    [SerializeField]
    private string ActionType;
    public List<string> Paths = new List<string>();

    [SerializeField]
    private GameObject ObjectToChange; 
    [SerializeField]
    private GameObject ObjectToChange2;
    [SerializeField]
    private Text TextToChange;
    [SerializeField]
    private Text TextToChange2;
    [SerializeField]
    private int DictionaryIndex;
    public override void Press()
    {
        switch (ActionType) 
        {
            case "ChangeMenu": //classic case of changing menù
                ObjectToChange.SetActive(true);
                this.transform.root.gameObject.SetActive(false);
                break;
            case "Explanation": // only audio needed
                PlayerSingleton.Instance.AudioManager(AudioSource, MyClip);
                break;
            case "Influence":
                // linearly changing all texture of objects with the new one
                //retrieving the Texture from assets through paths in the initial list
                Texture TextureToLoad1 = Resources.Load(Paths[0]) as Texture;
                Texture TextureToLoad2 = Resources.Load(Paths[1]) as Texture;
                //assigning these textures to Raw Images
                ObjectToChange.GetComponent<RawImage>().texture = TextureToLoad1;
                ObjectToChange2.GetComponent<RawImage>().texture = TextureToLoad2;
                //checking if the key (Dictionary Index) is in the dictionary
                if (InfluenceSingleton.Instance.References.ContainsKey(DictionaryIndex)) 
                {
                    //recovering the value having the index as key
                    TextToChange.text = InfluenceSingleton.Instance.References[DictionaryIndex];
                    //adding 1 to the key to retrieve to immediate following key
                    DictionaryIndex++;
                    TextToChange2.text = InfluenceSingleton.Instance.References[DictionaryIndex];
                    //reestablish the normal value to the index
                    DictionaryIndex--;
                }
                PlayerSingleton.Instance.AudioManager(AudioSource, MyClip);
                break;

        }


    }
}
/*
 * 
 * 
 * 
 * 
 * 
 * 
 * 
 * ------------------------- OLD CODE ------------------------
 * 
 * 
 * case "LateInfluence":
     Texture TextureToLoad = Resources.Load(Paths[0]) as Texture;
     ObjectToChange.GetComponent<RawImage>().texture = TextureToLoad;
     TextToChange.text = InfluenceSingleton.Instance.LateInfluence[DictionaryIndex];
     Debug.Log(InfluenceSingleton.Instance.LateInfluence[DictionaryIndex]);
     //do something with Audio.
     break;*/
