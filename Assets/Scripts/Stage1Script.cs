using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y< -0.16f)
        {
            transform.position = new Vector3(20.91f, 4.9f, 0.06f);
        }
    }
}
