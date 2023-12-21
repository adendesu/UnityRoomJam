using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    private Vector3 offset;
    [SerializeField] float maxX,minX, camZ;
    [SerializeField] float maxY, minY;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void LateUpdate()
    {
        var afteroffset = player.transform.position + offset;
        afteroffset = new Vector3(afteroffset.x, afteroffset.y, camZ);
        transform.position = Vector3.Lerp(transform.position, afteroffset, 6.0f * Time.deltaTime);
        var pos = transform.position;
        if(transform.position.y > maxY)
        {
            pos.y = maxY;
        }
        else if(transform.position.y < minY)
        {
            pos.y = minY;
        }

        if(transform.position.x > maxX)
        {
            pos.x = maxX; 
        }
        else if(transform.position.x < minX)
        {
            pos.x = minX;
        }
        transform.position = pos;
    }

}
