using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ArrowBehaviour : MonoBehaviour
{
    /*
    [SerializeField]
    private GameObject ArrowPrefab;


    private void Awake()
    {
        if (ArrowPrefab != null)
        {
            Debug.Log("Started");

            StartCoroutine(ArrowRoutine(5.0f));
           
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator ArrowRoutine(float Time) 
    {
        yield return new WaitForSeconds(Time);
        if (MotiAnimoManager.Instance.PositionIndex < 4)
        {
            float Reminder = MotiAnimoManager.Instance.PositionIndex % 2;
            if (Reminder == 0.0f)
            {

                Vector3 Position = MotiAnimoManager.Instance.ArrowPosition[MotiAnimoManager.Instance.PositionIndex];
                Vector3 Rotation = MotiAnimoManager.Instance.Rotation[MotiAnimoManager.Instance.PositionIndex];
                GameObject.Instantiate(ArrowPrefab, Position, Quaternion.Euler(Rotation));
                Destroy(this.gameObject);
            }

        }

        
    }
    */
}
