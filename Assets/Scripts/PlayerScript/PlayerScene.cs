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
        ray = new Ray2D(transform.position, -transform.up); // Ray�𐶐��A-transform.up�͐i�s����
        hit = Physics2D.Raycast(ray.origin, ray.direction, 0.5f);//Raycast�𐶐�
        ray1 = new Ray2D(transform.position, transform.up); // Ray�𐶐��A-transform.up�͐i�s����
        hit1 = Physics2D.Raycast(ray1.origin, ray1.direction, 1.9f);//Raycast�𐶐�
        Debug.DrawRay(ray.origin, ray.direction * 1f, Color.green, 0.015f); // ����1f�A�ΐF��1�t���[������

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
    /// ���̃C�x���g�Ŏw�肷��C���^�t�F�[�X�̃��\�b�h�ł��B
    /// </Summary>
    void CallMyEvent(IEventCaller inf, BaseEventData eventData)
    {
        inf.SceneMove(eveData);
    }
}
