using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingleton : MonoBehaviour
{
    public AudioClip CurrentClip;
    public AudioSource AudioActive;
    public bool Confirmation = false;
    public GazeableObject ActiveButton;
    public GameObject LastHit;


    private static PlayerSingleton _Instance;
    public static PlayerSingleton Instance
    {
        get
        {
            if (_Instance == null)
                Debug.Log("Singleton not created");
            return _Instance;

        }

    }


    public void Awake()
    {
        _Instance = this;

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void AudioManager(AudioSource Source, AudioClip Clip)
    {
        if (AudioActive != null)
        {
            if (AudioActive.isPlaying == false)
            {
                AudioActive = Source;
                AudioActive.clip = Clip;
                AudioActive.Play();
            }
            else if (AudioActive.isPlaying == true && AudioActive.clip != Clip)
            {
                AudioActive.Stop();
                AudioActive = Source;
                AudioActive.clip = Clip;
                AudioActive.Play();
            }

        }
        else 
        {
            AudioActive = Source;
            AudioActive.clip = Clip;
            AudioActive.Play();
        }



    }



}

// old code, not used
/*
 *     public bool LeftIconographic = false;
    public Vector3 LeftBackupDimensions;
    public bool RightIconographic = false;
    public Vector3 RightBackupDimensions;
    public int PeterIndex;
    public int JohnIndex;
    public int ChristIndex;
    public int JudasIndex;
    public List<string> PeterObjects = new List<string>(){ "DetailPeter1", "DetailPeter2", "DetailPeter3", "DetailPeter4"};
    public List<string> JohnObjects = new List<string>() { "DetailJohn1", "DetailJohn2", "DetailJohn3", "DetailJohn4" };
    public List<string> ChristObjects = new List<string>() { "DetailChrist1", "DetailChrist2", "DetailChrist3", "DetailChrist4" };
    public List<string> JudasObjects = new List<string>() { "DetailJudas1", "DetailJudas2", "DetailJudas3", "DetailJudas4" };

    */

/*    public void LoadSomething(string PrefabToDestroy, string PrefabToCreate, string NameToGive)
    {

        GameObject DebuggerObject = GameObject.Find(PrefabToDestroy);
        Destroy(DebuggerObject);
        GameObject ObjectToCreate = Resources.Load(PrefabToCreate) as GameObject;
        ObjectToCreate.name = NameToGive;
        var FinalObject = Instantiate(ObjectToCreate);
        FinalObject.name = NameToGive;

    }
*/
