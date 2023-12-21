using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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

        if (hitW.collider.gameObject != null)
        {
            Destroy(gameObject);
        }
        if (hitS.collider.gameObject != null)
        {
            Destroy(gameObject);
        }
        if (hitA.collider.gameObject != null)
        {
            Destroy(gameObject);
        }
        if (hitD.collider.gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}
