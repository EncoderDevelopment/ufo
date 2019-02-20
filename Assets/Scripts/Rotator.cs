using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float r;//,x,y,z;
    public GameObject player;
    

    private void Start()
    {
        r = Random.Range(-500.0f, 500.0f);    
        /*x = Random.Range(-600.0f, 600.0f);
        y = Random.Range(-400.0f, 400.0f);
        z = Random.Range(-300.0f, 300.0f);*/
    }
    // Update is called once per frame
    void Update()
    {       
        transform.Rotate(new Vector3(0, 0, r) * Time.deltaTime);        
    }
}
