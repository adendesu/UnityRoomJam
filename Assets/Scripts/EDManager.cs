using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class EDManager : MonoBehaviour
{
    [SerializeField] CanvasGroup panael1;
    [SerializeField] CanvasGroup panael2;
    [SerializeField] CanvasGroup ed1;
    [SerializeField] CanvasGroup ed2;

    bool canScene = false;
    // Start is called before the first frame update
    void Start()
    {
        Ed();
    }

    // Update is called once per frame
    void Update()
    {
        if (canScene == true && Input.GetMouseButtonDown(0))
        {
            Ed2();
        }

    }

    void Ed()
    {
        Sequence edSequence = DOTween.Sequence();

        edSequence
            .Append(panael1.DOFade(0, 2))
            .Append(ed1.DOFade(1, 2))
             .Append(ed2.DOFade(1, 2))
            .OnComplete(() => canScene = true);
    }

    void Ed2()
    {
        Sequence opSequence = DOTween.Sequence();

        opSequence
            .Append(panael2.DOFade(1, 2))
            .OnComplete(() => SceneManager.LoadScene("Title"));
    }
}
