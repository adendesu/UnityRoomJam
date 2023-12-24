using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class PlayerScene : MonoBehaviour
{
    int eveData;

    Ray2D ray;
    RaycastHit2D hit;
    Ray2D ray1;
    RaycastHit2D hit1;

   

    // Update is called once per frame
    void Update()
    {
        ray = new Ray2D(transform.position, -transform.up); // Rayを生成、-transform.upは進行方向
        hit = Physics2D.Raycast(ray.origin, ray.direction, 0.5f);//Raycastを生成
        ray1 = new Ray2D(transform.position, transform.up); // Rayを生成、-transform.upは進行方向
        hit1 = Physics2D.Raycast(ray1.origin, ray1.direction, 1.9f);//Raycastを生成
        Debug.DrawRay(ray.origin, ray.direction * 1f, Color.green, 0.015f); // 長さ1f、緑色で1フレーム可視化

        if (hit.collider.gameObject.tag == "sceneDown")
        {
            eveData = -1;
            NotifyEvent(GameObject.FindGameObjectWithTag("SceneMane"));
        }
        if (hit1.collider.gameObject.tag == "sceneUp")
        {
            eveData = 1;
            NotifyEvent(GameObject.FindGameObjectWithTag("SceneMane"));
        }

    }

    void NotifyEvent(GameObject targetObj)
    {
        ExecuteEvents.Execute<IEventCaller>(
                        target: targetObj,
                        eventData: null,
                        functor: CallMyEvent
                        );
    }

    /// <Summary>
    /// このイベントで指定するインタフェースのメソッドです。
    /// </Summary>
    void CallMyEvent(IEventCaller inf, BaseEventData eventData)
    {
        inf.SceneMove(eveData);
    }
}
