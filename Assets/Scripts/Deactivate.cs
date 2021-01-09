using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deactivate : MonoBehaviour
{
    private void OnDisable()
    {
        foreach (var Frame in InitialSingleton.Instance.ToDeactivate)
        {
            Frame.SetActive(false);
        }
        InitialSingleton.Instance.ToDeactivate.Clear();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
