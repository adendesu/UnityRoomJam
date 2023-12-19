using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowSkillController : MonoBehaviour
{
    [SerializeField] GameObject throwObject;
    [SerializeField] float pawer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var insObj = GameObject.FindGameObjectWithTag("ThrowObject");
            if(insObj == null)
            {
                ThrowSimulation();
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            var insObj = GameObject.FindGameObjectWithTag("ThrowObject");
            if (insObj != null)
            {
                Destroy(insObj);
            }
        }
    }

    void ThrowSimulation()
    {
        var insObj = Instantiate(throwObject, transform.position+ new Vector3(0,0,-1), Quaternion.identity);
        var rb = insObj.GetComponent<Rigidbody>();
        Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        var rbForce = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        rbForce.z = 0;
        rbForce = rbForce.normalized;
        rb.AddForce(rbForce * pawer,ForceMode.Impulse);
    }
}
