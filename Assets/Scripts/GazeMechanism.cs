using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeMechanism : MonoBehaviour
{
    public GameObject PositionSphere;
    public GameObject GuideSphere;
    private Color ColorActive = Color.green;
    private Color Inactive = Color.gray;
    private Color NotTeleport = Color.red;
    public GazeableObject ActiveObject;
    private bool IsCollision = false;
    [SerializeField]
    private float RayTracingDistance;

    //public string DebuggerString;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space)) 
        {
            string PrefabToCreate = "Prefabs/ChoiceThemeMenu";
            string NameToGive = "ChoiceThemeMenu";
            GameObject ObjectToCreate = Resources.Load(PrefabToCreate) as GameObject;
            Debug.Log(ObjectToCreate.name);
            ObjectToCreate.name = NameToGive;
            Debug.Log(ObjectToCreate.name);
            var FinalObject = Instantiate(ObjectToCreate);
            FinalObject.name = NameToGive;
            
        }*/

        Ray();
        CardboardInput();
        //Debugger();

    }

    public void Ray()
    {
        //Creo il raggio da sparare verso fuori e lo inserisco in una variabile.
        Ray DirectionaRay = new Ray(transform.position, transform.forward);
        RaycastHit InfoHit;
        Debug.DrawRay(DirectionaRay.origin, DirectionaRay.direction * 100, Color.red);
        //inizio a maneggiare la collisione
        if (Physics.Raycast(DirectionaRay, out InfoHit, RayTracingDistance))
        {
            IsCollision = true;
            //controll if the object hit it's gazeable.
            GameObject HitObject = InfoHit.collider.gameObject;
            GazeableObject InteractableObject = HitObject.GetComponent<GazeableObject>();
            if (InteractableObject != null)
            {
                //change the pointer color to make the user understand
                GuideSphere.GetComponent<MeshRenderer>().material.color = ColorActive;
                //keeps tracks of the looked oject.
                if (InteractableObject != ActiveObject)
                {
                    ActiveObject = InteractableObject;

                }

                //do some operations
                //probably need for an head movement tracker
            }
            else //rechange the color of the pointer to a not active one, discard object from variable due to not using it anymore.
            {
                GuideSphere.GetComponent<MeshRenderer>().material.color = NotTeleport;
                ActiveObject = null;


            }

        }
        else 
        {
            IsCollision = false;
            GuideSphere.GetComponent<MeshRenderer>().material.color = Inactive;
        }



    }
    public void CardboardInput()
    {
        if (IsCollision == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 Yposition = new Vector3();
                Yposition.y = PlayerSingleton.Instance.transform.position.y;
                Yposition.x = PositionSphere.transform.position.x;
                Yposition.z = PositionSphere.transform.position.z;
                PlayerSingleton.Instance.transform.position = Yposition;
                Debug.Log("mi sono spostato");
            }
        }
        else if (IsCollision == true) 
        {
            if (Input.GetMouseButtonDown(0) && ActiveObject != null)
            {
                ActiveObject.Press();
                Debug.Log("ho fatto delle azioni");
            }
        }
        /**else if (Input.GetMouseButtonDown(0) && ActiveObject == null)
        {
            Vector3 Yposition = new Vector3();
            Yposition.y = PlayerSingleton.Instance.transform.position.y;
            Yposition.x = GuideSphere.transform.position.x;
            Yposition.z = GuideSphere.transform.position.z;
            PlayerSingleton.Instance.transform.position = Yposition;
        }**/

    }
    public void Debugger() 
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ///var ObjectToChange = GameObject.Find("OtherLastSupper");
            //Debug.Log(ObjectToChange.name);
            //ObjectToChange.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
            //var ObjectToChange = GameObject.Find("LastSupperOriginal");
            //Texture NewTexture = Resources.Load("Materials/ImageTextures/Gaudenzio_Ferrari,_ultima_cena") as Texture;
            //Debug.Log(NewTexture.name);
            //ObjectToChange.GetComponent<MeshRenderer>().material.mainTexture = NewTexture;

        }
    }
}
