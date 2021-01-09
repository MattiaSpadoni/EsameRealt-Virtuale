using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialSingleton : MonoBehaviour
{
    public GameObject ActiveButton;
    public List<GameObject> ToDeactivate = new List<GameObject>();
    private static InitialSingleton _Instance;
    public static InitialSingleton Instance
    {
        get
        {
            if (_Instance == null)
                Debug.Log("Singleton not created");
            return _Instance;

        }
    }
    private void Awake()
    {
        _Instance = this;
    }
}
