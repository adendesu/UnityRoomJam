using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    int tutorialNumber;
    int tutorialSerihuNumber = 0;
    [SerializeField] string[] tutorialSerihu;
    [SerializeField] Text tutorialText;
    [SerializeField] GameObject playerPosi;
    [SerializeField] GameObject tutorialBord;
    bool canMove = true;
    // Start is called before the first frame update
    void Start()
    {
        tutorialNumber = PlayerPrefs.GetInt("Tutorial", 0);
        if(tutorialNumber == 0)
        {
            nextText(tutorialSerihu[tutorialSerihuNumber]);
            playerPosi.transform.rotation = Quaternion.Euler(0, 180, 0);
            PlayerController.canPlay = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canMove==true)
        {
            if (tutorialSerihuNumber < 10)
            {
                nextText(tutorialSerihu[tutorialSerihuNumber]);
                canMove = false;
            }
            
            else if(tutorialSerihuNumber == 10)
            {
                PlayerPrefs.SetInt("Tutorial", 1);
                PlayerPrefs.Save();
                playerPosi.transform.rotation = Quaternion.Euler(0, 0, 0);
                PlayerController.canPlay = true;
                Destroy(gameObject);
            }
            if (tutorialSerihuNumber == 8)
            {
                tutorialBord.SetActive(true);
            }
            else tutorialBord.SetActive(false);
        }
    }



    void nextText(string serihu)
    {
        tutorialText.text = " ";
        Sequence sceneSequence = DOTween.Sequence();
        sceneSequence.Append(tutorialText.DOText(serihu, serihu.Length / 10).SetEase(Ease.Linear))
            .OnComplete(()=>canMove =true);
        tutorialSerihuNumber++;
    }
}
