using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCounter : MonoBehaviour
{
    public static int JumpCount = 1;
    public static bool canJump = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(canJump);
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "stage")
        {
            JumpCount = 1;
            canJump = true;
            Debug.Log(canJump);
        }

    }*/

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("hit");
        if (collision.gameObject.CompareTag("Stage"))
        {
            JumpCount = 1;
            canJump = true;
            Debug.Log(canJump);
        }
    }

}
