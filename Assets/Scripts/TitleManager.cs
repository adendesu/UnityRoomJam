using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject titleE;
    [SerializeField] GameObject titleRogo;
    [SerializeField] GameObject titlePanel;
    [SerializeField] Image titleImage;
    [SerializeField] CanvasGroup titleCanvasGroup;
    [SerializeField] CanvasGroup titleRogoCanvasGroup;
    [SerializeField] AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        TitleMosion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TitleMosion()
    {
        Sequence titleSequence = DOTween.Sequence();

        titleSequence
            .Append(titleImage.DOColor(Color.white, 3))
            .AppendCallback(() => {
                titlePanel.SetActive(false);
                audioSource.Play();                   
                                  })
            .Append(titleCanvasGroup.DOFade(0, 3))
            .Join(titleE.transform.DOMoveY(0.11f, 5))
            .Append(titleRogoCanvasGroup.DOFade(1,1));
    }

}
