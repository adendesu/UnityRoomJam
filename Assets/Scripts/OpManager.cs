using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class OpManager : MonoBehaviour
{
    [SerializeField] CanvasGroup panael1;
    [SerializeField] CanvasGroup op1;
    [SerializeField] CanvasGroup op2;

    bool canScene = false;
    // Start is called before the first frame update
    void Start()
    {
        Op();
    }

    // Update is called once per frame
    void Update()
    {
        if(canScene == true && Input.GetMouseButtonDown(0))
        {
            Op2();
        }
        
    }

    void Op()
    {
        Sequence opSequence = DOTween.Sequence();

        opSequence
            .Append(panael1.DOFade(0, 2))
            .Append(op1.DOFade(1, 2))
            .Append(op2.DOFade(1, 2))
            .OnComplete(() => canScene = true);
    }

    void Op2()
    {
        Sequence opSequence = DOTween.Sequence();

        opSequence
            .Append(panael1.DOFade(1, 2))
            .OnComplete(() => SceneManager.LoadScene("stage1"));
    }

}
