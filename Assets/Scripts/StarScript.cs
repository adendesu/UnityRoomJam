using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    [SerializeField] GameObject starPosition;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - starPosition.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        
            var afteroffset = starPosition.transform.position + offset;
            afteroffset = new Vector3(afteroffset.x, afteroffset.y, -0.189445f);
            transform.position = Vector3.Lerp(transform.position, afteroffset, 6.0f * Time.deltaTime);
        
    }

}
