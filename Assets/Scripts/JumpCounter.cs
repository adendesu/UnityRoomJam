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
        Ray2D ray = new Ray2D(transform.position, -transform.up); // Rayを生成、-transform.upは進行方向
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, 2f);//Raycastを生成

        Debug.DrawRay(ray.origin, ray.direction * 1f, Color.green, 0.015f); // 長さ1f、緑色で1フレーム可視化
 
        if (hit.collider.gameObject != null)
        {
            JumpCount = 1;
            canJump = true;
            ThrowSkillController.throwCount = 2;
            //   Debug.Log(hit.collider.gameObject.tag);//Rayが当たった物をログ表示
            Debug.DrawRay(hit.point, hit.normal * 2f, Color.green, 0.015f); // 法線ベクトル表示、長さ2f、緑色で1フレーム可視化
        }
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
           
        }
    }

}
