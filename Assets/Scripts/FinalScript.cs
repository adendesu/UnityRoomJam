using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinalScript : MonoBehaviour
{
    int tutorialNumber;
   [SerializeField] int tutorialSerihuNumber = 0;
    [SerializeField] string[] tutorialSerihu;
    [SerializeField] Text tutorialText;
    [SerializeField] GameObject playerPosi;
    [SerializeField] GameObject player;
    [SerializeField] GameObject starParticle;
    [SerializeField] CanvasGroup canvasGroup;
    bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        if (tutorialNumber == 0)
        {
            nextSerirhu(tutorialSerihu[tutorialSerihuNumber]);
            playerPosi.transform.rotation = Quaternion.Euler(0, 180, 0);
            PlayerController.canPlay = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canMove == true)
        {
            if (tutorialSerihuNumber < 2)
            {
                nextSerirhu(tutorialSerihu[tutorialSerihuNumber]);
                canMove = false;
            }

            
            if (tutorialSerihuNumber == 2)
            {
                player.SetActive(false);
                Instantiate(starParticle, player.transform.position += new Vector3(0, 0, -1), Quaternion.identity);
                nextFinal();
                tutorialNumber++;
            }


        }
        
    }



    void nextSerirhu(string serihu)
    {
        tutorialText.text = " ";
        Sequence sceneSequence = DOTween.Sequence();
        sceneSequence.Append(tutorialText.DOText(serihu, serihu.Length / 10).SetEase(Ease.Linear))
            .OnComplete(() =>{ canMove = true; tutorialSerihuNumber++; });
        
    }

    void nextFinal()
    {
        
        tutorialText.text = " ";
        Sequence sceneSequence = DOTween.Sequence();
        sceneSequence.Append(canvasGroup.DOFade(0, 1))
            .OnComplete(() => SceneManager.LoadScene("Ed"));
        tutorialSerihuNumber++;
    }
}
