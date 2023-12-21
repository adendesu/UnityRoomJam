using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSkillController : MonoBehaviour
{
    [SerializeField] GameObject throwObject;
    [SerializeField] GameObject star;
    [SerializeField] float pawer;
    [SerializeField] GameObject player;

    public static int throwCount;
    // Start is called before the first frame update
    void Start()
    {
        throwCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var insObj = GameObject.FindGameObjectWithTag("ThrowObject");
            if(insObj == null)
            {
                ThrowSimulation(throwObject);
            }
            Time.timeScale = 0.1f;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            var insObj = GameObject.FindGameObjectWithTag("ThrowObject");
            if (insObj != null)
            {
                Destroy(insObj);
            }

            Time.timeScale = 1;
            if (GameObject.FindGameObjectWithTag("star") == null)
            { 
            ThrowSimulation(star);
            }

        }

        if (Input.GetMouseButtonDown(1) && throwCount>0)
        {
            
            var insObj = GameObject.FindGameObjectWithTag("star");
            if (insObj != null)
            {
                throwCount--;
                player.transform.position = new Vector3(insObj.transform.position.x, insObj.transform.position.y, player.transform.position.z);
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                Destroy(insObj);
            }
        }
    }

    void ThrowSimulation(GameObject obj)
    {
        var insObj = Instantiate(obj, transform.position+ new Vector3(0,0,-1), Quaternion.identity);
        var rb = insObj.GetComponent<Rigidbody>();
        Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        var rbForce = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        rbForce.z = 0;
        rbForce = rbForce.normalized;
        
        rb.AddForce(rbForce * pawer,ForceMode.Impulse);
    }
}
