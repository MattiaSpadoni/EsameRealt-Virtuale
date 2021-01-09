using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawingSingleton : MonoBehaviour
{
    public List<GameObject> Deactivate = new List<GameObject>();

    private static DrawingSingleton _Instance;
    public static DrawingSingleton Instance
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
