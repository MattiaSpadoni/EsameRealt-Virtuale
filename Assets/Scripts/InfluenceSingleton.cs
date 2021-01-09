using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class InfluenceSingleton : MonoBehaviour
{
    private static InfluenceSingleton _Instance;
    public static InfluenceSingleton Instance
    {
        get
        {
            if (_Instance == null)
                Debug.Log("Singleton not created");
            return _Instance;

        }
    }
    public List<GameObject> Deactivate = new List<GameObject>();
    public Dictionary<int, string> References = new Dictionary<int, string>
    {
        {1, ("Ultima Cena, particolare, volto di S. Filippo") },
        {2, ("Le tre età, Giorgione, particolare di volto") },
        {3, ("Ultima Cena, visione prospettica") },
        {4, ("Ultima Cena, Durer, visione prospettica") },
        {5, ("Ultima Cena, particolare compositivo sugli apostoli") },
        {6, ("Ultima Cena, Durer, particolare compositivo") },
        {7, ("Ultima Cena, particolare compositivo sugli apostoli") },
        {8, ("Ultima Cena, V. Aelst, particolare compositivo sugli apostoli") },
        {9, ("Ultima Cena, figura di Taddeo") },
        {10, ("Adorazione dei Pastori, Boccaccino, pastore anziano") },
        {11, ("Ultima Cena, L. da Vinci") },
        {12, ("J. E. Millais, 'Mrs James Wyatt Jr', particolare su miniatura ") },
    };


    // Start is called before the first frame update
    private void Awake()
    {
        _Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Clear(GameObject Object1, GameObject Object2)
    {
        foreach (Transform Child in Object1.transform)
        {
            Child.gameObject.GetComponent<Text>().text = "Scegli un'opzione";
            Debug.Log(Child.gameObject.GetComponent<Text>().text);
        }
        foreach (Transform Child in Object2.transform)
        {
            Child.gameObject.GetComponent<RawImage>().texture = null;

        }
        Debug.Log("Done Clear");

    }

}
