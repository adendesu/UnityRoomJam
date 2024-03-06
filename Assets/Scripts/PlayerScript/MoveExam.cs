using UnityEngine;

public class MoveExam : MonoBehaviour
{
    [SerializeField] GameObject tutorialPanel;

    // Update is called once per frame
    void Update()
    {
        SetActiveTutorialPanel();
    }

    void SetActiveTutorialPanel()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            tutorialPanel.SetActive(true);
        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            tutorialPanel.SetActive(false);
        }
    }
}
