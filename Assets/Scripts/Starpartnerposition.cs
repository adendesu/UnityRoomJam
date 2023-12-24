using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Starpartnerposition : MonoBehaviour
{
    GameObject player;
    GameObject starPartner;

    bool setReset = true;
    // Start is called before the first frame update
    void Start()
    {
       starPartner= GameObject.FindGameObjectWithTag("StarPartner");
        Invoke("OnReset", 1f);
        starPartner.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
            Debug.Log("reset1");

            // Debug.Log(canJump);
            Ray2D rayW = new Ray2D(transform.position, transform.up);
            Ray2D rayS = new Ray2D(transform.position, -transform.up);
            Ray2D rayA = new Ray2D(transform.position, -transform.right);
            Ray2D rayD = new Ray2D(transform.position, transform.right); // Rayを生成、-transform.upは進行方向
            RaycastHit2D hitW = Physics2D.Raycast(rayW.origin, rayW.direction, 0.5f);
            RaycastHit2D hitS = Physics2D.Raycast(rayS.origin, rayS.direction, 0.5f);
            RaycastHit2D hitA = Physics2D.Raycast(rayA.origin, rayA.direction, 0.5f);
            RaycastHit2D hitD = Physics2D.Raycast(rayD.origin, rayD.direction, 0.5f);//Raycastを生成

            //Debug.DrawRay(ray.origin, ray.direction * 1f, Color.green, 0.015f); // 長さ1f、緑色で1フレーム可視化

            if (hitW.collider.gameObject.tag == "stage")
            {
                OnReset();
            }
            if (hitS.collider.gameObject.tag == "stage")
            {
                OnReset();
            }
            if (hitA.collider.gameObject.tag == "stage")
            {
                OnReset();
            }
            if (hitD.collider.gameObject.tag == "stage")
            {
                OnReset();
            }
           
                
                setReset = false;
            
        
    }


   public void OnReset()
    {
        starPartner.SetActive(true);

        Destroy(gameObject);
        Debug.Log("reset");
    }

}
    

