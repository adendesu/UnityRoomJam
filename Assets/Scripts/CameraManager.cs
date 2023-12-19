using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void LateUpdate()
    {
        var afteroffset = player.transform.position + offset;
        afteroffset = new Vector3(0.91f, afteroffset.y, -6.28f);
        transform.position = Vector3.Lerp(transform.position, afteroffset, 6.0f * Time.deltaTime);
    }
}
