using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catapulta : MonoBehaviour
{
    public GameObject itemToDelete;
    public float deletionRadius = 10.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, itemToDelete.transform.position);
        
        if (distance < deletionRadius)
        {
            Destroy(itemToDelete);
        }
    }
}
