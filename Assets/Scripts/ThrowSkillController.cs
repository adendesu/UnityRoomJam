using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ThrowSkillController : MonoBehaviour
{
    [SerializeField] GameObject throwObject;
    [SerializeField] GameObject star;
    [SerializeField] GameObject starPartner;
    [SerializeField] float pawer;
    [SerializeField] GameObject player;
    [SerializeField] GameObject startPosition;
    [SerializeField] GameObject starEffect;
    Vector3 rbForce;
    GameObject instanObj;
   public static bool canStarMove;
    public static int throwCount;
    // Start is called before the first frame update
   void Start()
    {
        canStarMove = false;
        //await StarMove();
        throwCount = 2;
    }

    // Update is called once per frame
   void Update()
    {
        if (PlayerController.canPlay)
        {
            //await StarMove();
            if (Input.GetKeyDown(KeyCode.E))
            {


                var insObj = GameObject.FindGameObjectWithTag("ThrowObject");
                if (insObj == null)
                {
                    instanObj = Instantiate(throwObject, startPosition.transform.position + new Vector3(0, 0, -1), Quaternion.identity);

                }
                Time.timeScale = 0f;
            }
            else if (Input.GetKey(KeyCode.E))
            {
                var za = Vector3.ProjectOnPlane(startPosition.transform.position + new Vector3(0, 0, -1), Camera.main.ScreenToWorldPoint(Input.mousePosition));
                var zahyo = GetAngle(startPosition.transform.position + new Vector3(0, 0, -1), Camera.main.ScreenToWorldPoint(Input.mousePosition));
                instanObj.transform.rotation = Quaternion.Euler(0, 0, zahyo);
            }
            else if (Input.GetKeyUp(KeyCode.E))
            {

                Destroy(instanObj);
                /* var insObj = GameObject.FindGameObjectWithTag("ThrowObject");
                 var rb = insObj.GetComponent<Rigidbody>();
                 var rBForce = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
                 rBForce.z = 0;
                 rbForce = rBForce.normalized;*/
                canStarMove = true;
                Time.timeScale = 1;


                // Invoke("ResetMove", 1);
                // await StarMove();
                /*rb.AddForce(rbForce * pawer, ForceMode.Impulse);
                 if (insObj != null)
                 {
                     Destroy(insObj);
                 }
                */

                if (GameObject.FindGameObjectWithTag("star") == null)
                {
                    ThrowSimulation(star);
                }
                //starPartner.SetActive(false);
            }

            if (Input.GetMouseButtonDown(1) && throwCount > 0)
            {
                var insObj = GameObject.FindGameObjectWithTag("star");
                if (insObj != null)
                {
                    starPartner.SetActive(true);
                    canStarMove = false;
                    throwCount--;

                    player.transform.position = new Vector3(insObj.transform.position.x, insObj.transform.position.y, player.transform.position.z);
                    Instantiate(starEffect, player.transform.position + new Vector3(0, 0, -1), Quaternion.identity);
                    player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    Destroy(insObj);
                }

                //  ResetMove();
            }
        }

    }

    void ThrowSimulation(GameObject obj)
    {
        var insObj = Instantiate(obj, startPosition.transform.position+ new Vector3(0,0,-1), Quaternion.identity);
        var rb = insObj.GetComponent<Rigidbody>();
        var rbForce = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        rbForce.z = 0;
        rbForce = rbForce.normalized;
        
        rb.AddForce(rbForce * pawer,ForceMode.Impulse);
    }
  
    void ResetMove()
    {
            ExecuteEvents.Execute<IEventCaller>(
                    target: gameObject,
                    eventData: null,
                    functor: CallMyEvent);
        
    }
    void CallMyEvent(IEventCaller inf, BaseEventData eventData)
    {
      //  inf.OnReset();
    }

    float GetAngle(Vector2 start, Vector2 target)
    {
        Vector2 dt = target - start;
        float rad = Mathf.Atan2(dt.y, dt.x);
        float degree = rad * Mathf.Rad2Deg;

        return degree;
    }
}

