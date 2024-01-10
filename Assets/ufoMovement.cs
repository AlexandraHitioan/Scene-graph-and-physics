using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ufoMovement : MonoBehaviour
{
    public float speedRot = 30f;
    public float radiusOrb= 25f;
    public float speedOrb = 2f;
   
    
    public Vector3 orbitCenter = new Vector3(20f, 0f, 30f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the UFO around its own axis
        transform.Rotate(Vector3.up * speedRot * Time.deltaTime);

        // Move the UFO in a circular orbit
        float angle = Time.time * speedOrb;
        float x = orbitCenter.x + Mathf.Cos(angle) * radiusOrb;
        float z = orbitCenter.z + Mathf.Sin(angle) * radiusOrb;
        float y = 7f; 
        transform.position = new Vector3(x, y, z);
    }
}
