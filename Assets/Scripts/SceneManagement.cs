using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class SceneManagement : MonoBehaviour, IEventCaller
{
    [SerializeField] string[] sceneName;

    GameObject player;
    GameObject scenePanel;
    GameObject stageE;
    CanvasGroup scenePanelCanvas;
    GameObject mainCamera;
    public int sceneNumber;
    float sizeFloat = 5;
    float moveFloat1;
    float moveFloat2;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        FindPanel();
    }
    private void Update()
    {
        // Camera.main.gameObject.GetComponent<Camera>().orthographicSize = sizeFloat;
       /* Camera.main.gameObject.GetComponent<Camera>().orthographicSize = sizeFloat;
        if(CameraManager.canCameraMove == false)
        {
            var posi = Camera.main.gameObject.transform.position;
            posi.x = moveFloat1;
            posi.y = moveFloat2;
        }*/
    }
    // Update is called once per frame

    void FindPanel()
    {
        scenePanel = GameObject.FindGameObjectWithTag("Scenepanel");
        player = GameObject.FindGameObjectWithTag("Player");
        stageE = GameObject.FindGameObjectWithTag("StageE");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        scenePanelCanvas = scenePanel.GetComponent<CanvasGroup>();
    }

   public void SceneMove(int sceneSet)

    {
        CameraManager.canCameraMove = false;
        Destroy(player);
        FindPanel();
        SerchScene();
        sceneNumber += sceneSet;
        Sequence sceneSequence = DOTween.Sequence();
      /*  DOTween.To(() => 5, (_) => sizeFloat = _, 25, 1)
                .OnUpdate(() => Camera.main.gameObject.GetComponent<Camera>().orthographicSize = sizeFloat);

        DOTween.To(() => Camera.main.gameObject.transform.position.x, (_) => moveFloat1 = _, 0, 1)
                .OnUpdate(() =>
                {
                    var posi = mainCamera.transform.position;
                    posi.x = moveFloat1;
                });

        DOTween.To(() => Camera.main.gameObject.transform.position.y, (_) => moveFloat2 = _, 20, 1)
                .OnUpdate(() => {
                    var posi = mainCamera.transform.position;
                    posi.y = moveFloat2;
                   
                });*/

         sceneSequence
             .AppendCallback(() =>
             {
                 // Camera.main.gameObject.transform.position = new Vector3(stageE.transform.position.x, stageE.transform.position.y,-8.44f); 
                 player.GetComponent<Rigidbody2D>().simulated = false;
             })
            /* .AppendCallback(() =>
             {
                 /* DOVirtual.Float(5, 25, 1,
                  onVirtualUpdate: (sizeFloat) =>
                  {
                  Camera.main.gameObject.GetComponent<Camera>().orthographicSize = sizeFloat;
                  });*/

        /* DOVirtual.Float(Camera.main.gameObject.transform.position.x, stageE.transform.position.x, 1,
         onVirtualUpdate: (posiFloat) =>
         {
             var posi = Camera.main.gameObject.transform.position;
             posi.x = posiFloat;
         });
         DOVirtual.Float(Camera.main.gameObject.transform.position.y, stageE.transform.position.y, 1,
         onVirtualUpdate: (posiFloatY) =>
         {
             var posi = Camera.main.gameObject.transform.position;
             posi.y = posiFloatY;
         });

    })
    .AppendInterval(1)*/
    .AppendCallback(() =>
    {
        sizeFloat = 5;

    })
    .Append(scenePanelCanvas.DOFade(1, 1))
    .OnComplete(()=> Invoke("SceneMovement",1));

    }

    void SerchScene()
    {
       var sceneName = SceneManager.GetActiveScene().name;

       switch (sceneName)
        {
            case "stage1":
                sceneNumber = 0;
                break;
            case "Main":
                sceneNumber = 1;
                break;
            case "Stage3":
                sceneNumber = 2;
                break;
            case "Stage2":
                sceneNumber = 3;
                break;
            case "Stage4":
                sceneNumber = 4;
                break;
            default:
                sceneNumber = -1;
                break;
        }
    }
    void SceneMovement()
    {
        SceneManager.LoadScene(sceneName[sceneNumber]);
    }
}
