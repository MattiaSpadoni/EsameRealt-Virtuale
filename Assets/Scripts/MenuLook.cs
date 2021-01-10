using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuLook : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
    }

    public void LookAtPlayer()
    {
        Vector3 playerPos = PlayerSingleton.Instance.transform.position;
        Vector3 vecToPlayer = playerPos - transform.position;

        Vector3 lookAtPos = transform.position - vecToPlayer;
        transform.LookAt(lookAtPos);

    }
}
