using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] GameObject titleE;
    [SerializeField] GameObject titleRogo;
    [SerializeField] GameObject titlePanel;
    [SerializeField] Image titleImage;
    [SerializeField] CanvasGroup titleCanvasGroup;
    [SerializeField] CanvasGroup titleRogoCanvasGroup;
    [SerializeField] AudioSource audioSource;

    bool canScene = false;
    // Start is called before the first frame update
    void Start()
    {
        TitleMosion();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) && canScene == true)
        {
            Sequence titleSequence = DOTween.Sequence();

            titleSequence.Append(titleCanvasGroup.DOFade(1,2))
                .OnComplete(()=> SceneManager.LoadScene("Op"));
            canScene = false;
        }
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
            .Append(titleRogoCanvasGroup.DOFade(1,1))
            .OnComplete(()=>canScene=true);
    }

}
