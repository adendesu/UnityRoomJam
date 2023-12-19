using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;

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
        while (true)
        {
            if (isPush && SpriteRenderer.color.a < 125)
            {
                SpriteRenderer.color += new Color(0, 0, 0f, 1);
            }
            else if(SpriteRenderer.color.a >0) SpriteRenderer.color += new Color(0, 0, 0f, -1);
        }
        await UniTask.Delay(100);
    }
}
