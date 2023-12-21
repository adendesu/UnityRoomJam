using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using DG.Tweening;
public class DetectionVisualization : MonoBehaviour
{
    private SpriteRenderer SpriteRenderer;
    bool isPush = false;
    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
    }
    private async void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            isPush = true;
        }
        else isPush = false;
        await ChangeColor();
    }

    async UniTask ChangeColor()
    {
      //  while (true)
        //{
            if (isPush && SpriteRenderer.color.a < 0.5f)
            {
                SpriteRenderer.color += new Color(0, 0, 0f, 0.001f);
            }
            else if(SpriteRenderer.color.a >　0) SpriteRenderer.color += new Color(0, 0, 0f, -0.004f);
            await UniTask.Delay(1000);
       // }
        
    }
}
