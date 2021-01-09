using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this script is an old one not being used in the final version of the environment. Be careful it is not more supported in the environment,
// if you want to use it be careful and adapt it. 
// this script is terrible inefficient, its concept is old.


/*
public class PaintingButton : GazeableObject
{
    [SerializeField]
    private float ScalingCoefficientX;
    [SerializeField]
    private float ScalingCoefficientY;
    [SerializeField]
    private string TextureToLoad;
    [SerializeField]
    private string ActionType;
    public GameObject Menu;
    [SerializeField]
    private string QuadToChange;
    public override void Press()
    {


        switch (ActionType)
        {
            case "Menu":
                {
                    this.transform.root.gameObject.SetActive(false);
                    Menu.SetActive(true);
                }
                break;
            case "TextureLeft":
                {
                    if (PlayerSingleton.Instance.LeftIconographic == false) // if it's the first transformation
                    {
                        var ObjectToChange = GameObject.Find(QuadToChange);
                        float NewDimensionY = ObjectToChange.transform.localScale.y;
                        float NewDimensionX = ObjectToChange.transform.localScale.x;
                        float ConstantDimensionz = ObjectToChange.transform.localScale.z;
                        PlayerSingleton.Instance.LeftBackupDimensions = new Vector3(NewDimensionX, NewDimensionY, ConstantDimensionz);
                        NewDimensionX = NewDimensionX * ScalingCoefficientX;
                        NewDimensionY = NewDimensionY * ScalingCoefficientY;
                        Vector3 NewDimensions = new Vector3(NewDimensionX, NewDimensionY, ConstantDimensionz);
                        ObjectToChange.transform.localScale = NewDimensions;
                        Texture NewTexture = Resources.Load(TextureToLoad) as Texture;
                        ObjectToChange.GetComponent<MeshRenderer>().material.mainTexture = NewTexture;
                        PlayerSingleton.Instance.LeftIconographic = true;
                        Debug.Log(PlayerSingleton.Instance.LeftIconographic);

                    }
                    else //if it's not the first transformation
                    {
                        var ObjectToChange = GameObject.Find(QuadToChange);
                        ObjectToChange.transform.localScale = PlayerSingleton.Instance.LeftBackupDimensions;
                        float NewDimensionY = ObjectToChange.transform.localScale.y;
                        float NewDimensionX = ObjectToChange.transform.localScale.x;
                        float ConstantDimensionz = ObjectToChange.transform.localScale.z;
                        NewDimensionX = NewDimensionX * ScalingCoefficientX;
                        NewDimensionY = NewDimensionY * ScalingCoefficientY;
                        Vector3 NewDimensions = new Vector3(NewDimensionX, NewDimensionY, ConstantDimensionz);
                        ObjectToChange.transform.localScale = NewDimensions;
                        Texture NewTexture = Resources.Load(TextureToLoad) as Texture;
                        ObjectToChange.GetComponent<MeshRenderer>().material.mainTexture = NewTexture;
                        PlayerSingleton.Instance.LeftIconographic = true;
                        Debug.Log(PlayerSingleton.Instance.LeftIconographic);
                    }



                }
                break;
            case "TextureRight":
                {
                    if (PlayerSingleton.Instance.RightIconographic == false) // if it's the first transformation
                    {
                        var ObjectToChange = GameObject.Find(QuadToChange);
                        float NewDimensionY = ObjectToChange.transform.localScale.y;
                        float NewDimensionX = ObjectToChange.transform.localScale.x;
                        float ConstantDimensionz = ObjectToChange.transform.localScale.z;
                        PlayerSingleton.Instance.RightBackupDimensions = new Vector3(NewDimensionX, NewDimensionY, ConstantDimensionz);
                        NewDimensionX = NewDimensionX * ScalingCoefficientX;
                        NewDimensionY = NewDimensionY * ScalingCoefficientY;
                        Vector3 NewDimensions = new Vector3(NewDimensionX, NewDimensionY, ConstantDimensionz);
                        ObjectToChange.transform.localScale = NewDimensions;
                        Texture NewTexture = Resources.Load(TextureToLoad) as Texture;
                        ObjectToChange.GetComponent<MeshRenderer>().material.mainTexture = NewTexture;
                        PlayerSingleton.Instance.RightIconographic = true;
                        Debug.Log(PlayerSingleton.Instance.RightIconographic);

                    }
                    else //if it's not the first transformation
                    {
                        var ObjectToChange = GameObject.Find(QuadToChange);
                        ObjectToChange.transform.localScale = PlayerSingleton.Instance.RightBackupDimensions;
                        float NewDimensionY = ObjectToChange.transform.localScale.y;
                        float NewDimensionX = ObjectToChange.transform.localScale.x;
                        float ConstantDimensionz = ObjectToChange.transform.localScale.z;
                        NewDimensionX = NewDimensionX * ScalingCoefficientX;
                        NewDimensionY = NewDimensionY * ScalingCoefficientY;
                        Vector3 NewDimensions = new Vector3(NewDimensionX, NewDimensionY, ConstantDimensionz);
                        ObjectToChange.transform.localScale = NewDimensions;
                        Texture NewTexture = Resources.Load(TextureToLoad) as Texture;
                        ObjectToChange.GetComponent<MeshRenderer>().material.mainTexture = NewTexture;
                        PlayerSingleton.Instance.RightIconographic = true;
                        Debug.Log(PlayerSingleton.Instance.RightIconographic);
                    }



                }
                break;
            case "Explanation":
                //other actions
                break;
            case "PeterDetail":
                if (PlayerSingleton.Instance.PeterIndex < 4)
                {
                    QuadToChange = PlayerSingleton.Instance.PeterObjects[PlayerSingleton.Instance.PeterIndex];
                    var DetailPeterObject = GameObject.Find(QuadToChange);
                    
                    Texture PeterTexture = Resources.Load(TextureToLoad) as Texture;
                    DetailPeterObject.GetComponent<MeshRenderer>().material.mainTexture = PeterTexture;
                    Debug.Log(QuadToChange + "The index is " + PlayerSingleton.Instance.PeterIndex + " the object is " + DetailPeterObject.name);
                    PlayerSingleton.Instance.PeterIndex++;
                }
                else 
                { 
                    // do nothing
                }
                


                break;
            case "PeterCancel":
                if (PlayerSingleton.Instance.PeterIndex > 0) 
                {
                    PlayerSingleton.Instance.PeterIndex--;
                    QuadToChange = PlayerSingleton.Instance.PeterObjects[PlayerSingleton.Instance.PeterIndex];
                    Debug.Log(PlayerSingleton.Instance.PeterIndex + " other element is " + QuadToChange);
                    var DetailPeterDelete = GameObject.Find(QuadToChange);
                    Debug.Log("initial Index is " + PlayerSingleton.Instance.PeterIndex + " string to locate is " + QuadToChange + " Object name is " + DetailPeterDelete.name);
                    DetailPeterDelete.GetComponent<MeshRenderer>().material.mainTexture = null;
                    Debug.Log(PlayerSingleton.Instance.PeterIndex);

                }
                
                break;
            case "PeterReset":
                GameObject[] ResetListPeter = new GameObject[4];
                ResetListPeter = GameObject.FindGameObjectsWithTag("DetailPeter");
                foreach (var Quad in ResetListPeter) 
                {
                    Quad.GetComponent<MeshRenderer>().material.mainTexture = null;
                    Debug.Log(Quad.name);
                }
                PlayerSingleton.Instance.PeterIndex = 0;
                Debug.Log(PlayerSingleton.Instance.PeterIndex);

                break;
                

                --------------------------------------------------------------------
                ------------------------------------------------------------------
                ------------------------- John detail case---------

            
            case "JohnDetail":
                if (PlayerSingleton.Instance.JohnIndex < 4)
                {
                    QuadToChange = PlayerSingleton.Instance.JohnObjects[PlayerSingleton.Instance.JohnIndex];
                    var DetailJohnObject = GameObject.Find(QuadToChange);

                    Texture JohnTexture = Resources.Load(TextureToLoad) as Texture;
                    DetailJohnObject.GetComponent<MeshRenderer>().material.mainTexture = JohnTexture;
                    Debug.Log(QuadToChange + "The index is " + PlayerSingleton.Instance.JohnIndex + " the object is " + DetailJohnObject.name + JohnTexture.name);
                    PlayerSingleton.Instance.JohnIndex++;
                }
                else
                {
                    // do nothing
                }

                break;
            case "JohnCancel":
                if (PlayerSingleton.Instance.JohnIndex > 0)
                {
                    PlayerSingleton.Instance.JohnIndex--;
                    QuadToChange = PlayerSingleton.Instance.JohnObjects[PlayerSingleton.Instance.JohnIndex];
                    Debug.Log(PlayerSingleton.Instance.JohnIndex + " other element is " + QuadToChange);
                    var DetailJohnDelete = GameObject.Find(QuadToChange);
                    Debug.Log("initial Index is " + PlayerSingleton.Instance.JohnIndex + " string to locate is " + QuadToChange + " Object name is " + DetailJohnDelete.name);
                    DetailJohnDelete.GetComponent<MeshRenderer>().material.mainTexture = null;
                    Debug.Log(PlayerSingleton.Instance.JohnIndex);

                }

                break;
            case "JohnReset":
                GameObject[] ResetListJohn = new GameObject[4];
                ResetListJohn = GameObject.FindGameObjectsWithTag("DetailPeter");
                foreach (var Quad in ResetListJohn)
                {
                    Quad.GetComponent<MeshRenderer>().material.mainTexture = null;
                    Debug.Log(Quad.name);
                }
                PlayerSingleton.Instance.JohnIndex = 0;
                Debug.Log(PlayerSingleton.Instance.JohnIndex);
                break;

            --------------------------------------------------------------------
                ------------------------------------------------------------------
                ------------------------- Judas detail case---------
            case "JudasDetail":
                if (PlayerSingleton.Instance.JudasIndex < 4)
                {
                    QuadToChange = PlayerSingleton.Instance.JudasObjects[PlayerSingleton.Instance.JudasIndex];
                    var DetailJudasObject = GameObject.Find(QuadToChange);

                    Texture JudasTexture = Resources.Load(TextureToLoad) as Texture;
                    DetailJudasObject.GetComponent<MeshRenderer>().material.mainTexture = JudasTexture;
                    Debug.Log(QuadToChange + "The index is " + PlayerSingleton.Instance.JudasIndex + " the object is " + DetailJudasObject.name);
                    PlayerSingleton.Instance.JudasIndex++;
                }
                else
                {
                    // do nothing
                }

                break;
            case "JudasCancel":
                if (PlayerSingleton.Instance.JudasIndex > 0)
                {
                    PlayerSingleton.Instance.JudasIndex--;
                    QuadToChange = PlayerSingleton.Instance.JudasObjects[PlayerSingleton.Instance.JudasIndex];
                    Debug.Log(PlayerSingleton.Instance.JudasIndex + " other element is " + QuadToChange);
                    var DetailJudasDelete = GameObject.Find(QuadToChange);
                    Debug.Log("initial Index is " + PlayerSingleton.Instance.JudasIndex + " string to locate is " + QuadToChange + " Object name is " + DetailJudasDelete.name);
                    DetailJudasDelete.GetComponent<MeshRenderer>().material.mainTexture = null;
                    Debug.Log(PlayerSingleton.Instance.JudasIndex);

                }

                break;
            case "JudasReset":
                GameObject[] ResetListJudas = new GameObject[4];
                ResetListJudas = GameObject.FindGameObjectsWithTag("DetailPeter");
                foreach (var Quad in ResetListJudas)
                {
                    Quad.GetComponent<MeshRenderer>().material.mainTexture = null;
                    Debug.Log(Quad.name);
                }
                PlayerSingleton.Instance.JudasIndex = 0;
                Debug.Log(PlayerSingleton.Instance.JudasIndex);
                break;

            --------------------------------------------------------------------
            ------------------------------------------------------------------
            ------------------------- Christ detail case---------

            case "ChristDetail":
                if (PlayerSingleton.Instance.ChristIndex < 4)
                {
                    QuadToChange = PlayerSingleton.Instance.ChristObjects[PlayerSingleton.Instance.ChristIndex];
                    var DetailChristObject = GameObject.Find(QuadToChange);

                    Texture ChristTexture = Resources.Load(TextureToLoad) as Texture;
                    DetailChristObject.GetComponent<MeshRenderer>().material.mainTexture = ChristTexture;
                    Debug.Log(QuadToChange + "The index is " + PlayerSingleton.Instance.ChristIndex + " the object is " + DetailChristObject.name);
                    PlayerSingleton.Instance.ChristIndex++;
                }
                else
                {
                    // do nothing
                }

                break;
            case "ChristCancel":
                if (PlayerSingleton.Instance.ChristIndex > 0)
                {
                    PlayerSingleton.Instance.ChristIndex--;
                    QuadToChange = PlayerSingleton.Instance.ChristObjects[PlayerSingleton.Instance.ChristIndex];
                    Debug.Log(PlayerSingleton.Instance.ChristIndex + " other element is " + QuadToChange);
                    var DetailChristDelete = GameObject.Find(QuadToChange);
                    Debug.Log("initial Index is " + PlayerSingleton.Instance.ChristIndex + " string to locate is " + QuadToChange + " Object name is " + DetailChristDelete.name);
                    DetailChristDelete.GetComponent<MeshRenderer>().material.mainTexture = null;
                    Debug.Log(PlayerSingleton.Instance.ChristIndex);

                }

                break;
            case "ChristReset":
                GameObject[] ResetListChrist = new GameObject[4];
                ResetListChrist = GameObject.FindGameObjectsWithTag("DetailPeter");
                foreach (var Quad in ResetListChrist)
                {
                    Quad.GetComponent<MeshRenderer>().material.mainTexture = null;
                    Debug.Log(Quad.name);
                }
                PlayerSingleton.Instance.ChristIndex = 0;
                Debug.Log(PlayerSingleton.Instance.ChristIndex);
                break;



        }


    }
}

    */