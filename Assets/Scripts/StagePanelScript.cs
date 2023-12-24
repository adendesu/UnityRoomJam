using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class StagePanelScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var stageCanvas = gameObject.GetComponent<CanvasGroup>();
        stageCanvas.DOFade(0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
