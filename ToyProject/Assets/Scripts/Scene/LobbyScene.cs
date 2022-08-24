using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LobbyScene : Scene
{
    GameObject gameModePannel;
    GameObject statusModifyPannel;
    GameObject canvas;
    SceneType selectedSceneType = SceneType.NONE;

    Image[] points;

    private LineRenderer lineRender;
    public LobbyScene(GameObject playerObject, CamFollow camFollow ) : base(playerObject, camFollow)
    {
        canvas = GameObject.Find("Canvas");
        points = new Image[5];

        gameModePannel = canvas.transform.Find("GameModeSelectPannel").gameObject;
        statusModifyPannel = canvas.transform.Find("StatusModifyPannel").gameObject;

        if (gameModePannel)
        {
            do
            {
                Button button = gameModePannel.transform.Find("ModeOneSelectButton").GetComponent<Button>();
                if (button)
                {
                    button.onClick.AddListener(() => { OnClickGameModeSelect_1(); });
                }
            } while ( false );

            do
            {
                Button button = gameModePannel.transform.Find("ModeTwoSelectButton").GetComponent<Button>();
                if (button)
                {
                    button.onClick.AddListener(() => { OnClickGameModeSelect_2(); });
                }
            } while (false);

            do
            {
                Button button = gameModePannel.transform.Find("GameStartButton").GetComponent<Button>();
                if (button)
                {
                    button.onClick.AddListener(() => { OnClickGameStartButton(); });
                }
            } while (false);

            do
            {
                Button button = gameModePannel.transform.Find("CloseButton").GetComponent<Button>();
                if (button)
                {
                    button.onClick.AddListener(() => { OnClickCloseGameModeSelectPannelButton(); });
                }
            } while (false);
        }

        if (statusModifyPannel)
        {
            do
            {
                Button button = statusModifyPannel.transform.Find("IncAttackButton").GetComponent<Button>();
                if (button)
                {
                    button.onClick.AddListener(() => { OnClickIncAttackButton(); });
                }
            } while (false);

            do
            {
                Button button = statusModifyPannel.transform.Find("IncAttackSpeedButton").GetComponent<Button>();
                if (button)
                {
                    button.onClick.AddListener(() => { OnClickIncAttackSpeedButton(); });
                }
            } while (false);

            do
            {
                Button button = statusModifyPannel.transform.Find("IncHpButton").GetComponent<Button>();
                if (button)
                {
                    button.onClick.AddListener(() => { OnClickIncHpButton(); });
                }
            } while (false);

            do
            {
                Button button = statusModifyPannel.transform.Find("IncLuckButton").GetComponent<Button>();
                if (button)
                {
                    button.onClick.AddListener(() => { OnClickIncLuckButton(); });
                }
            } while (false); 
            
            do
            {
                Button button = statusModifyPannel.transform.Find("IncSpeedButton").GetComponent<Button>();
                if (button)
                {
                    button.onClick.AddListener(() => { OnClickIncSpeedButton(); });
                }
            } while (false);

            do
            {
                Button button = statusModifyPannel.transform.Find("CloseButton").GetComponent<Button>();
                if (button)
                {
                    button.onClick.AddListener(() => { OnClickCloseStatusModePannelButton(); });
                }
            } while (false);

            do
            {
                points[0] = statusModifyPannel.transform.Find("AttackPoint").GetComponent<Image>();
                points[1] = statusModifyPannel.transform.Find("AttackSpeedPoint").GetComponent<Image>(); 
                points[2] = statusModifyPannel.transform.Find("LuckPoint").GetComponent<Image>(); 
                points[3] = statusModifyPannel.transform.Find("MoveSpeedPoint").GetComponent<Image>();
                points[4] = statusModifyPannel.transform.Find("HpPoint").GetComponent<Image>(); 
            } while (false);
        }
        lineRender = new GameObject("Line").AddComponent<LineRenderer>();
        lineRender.material = new Material(Shader.Find("Diffuse"));
        lineRender.positionCount = 6;

        lineRender.startWidth = 1.0f;
        lineRender.endWidth = 1.0f;
        
        lineRender.startColor = Color.black;

        //lineRender.SetColors(Color.black, Color.black);
        lineRender.useWorldSpace = true;

        if (statusModifyPannel && statusModifyPannel.activeSelf)
        {  
            lineRender.SetPosition(0, points[0].rectTransform.position);
            lineRender.SetPosition(1, points[1].rectTransform.position);
            lineRender.SetPosition(2, points[2].rectTransform.position);
            lineRender.SetPosition(3, points[3].rectTransform.position);
            lineRender.SetPosition(4, points[4].rectTransform.position);
            for (int i = 0; i < 5; ++i)
            {
                lineRender.SetPosition(i, points[i].rectTransform.position);
            }
            lineRender.SetPosition(5, points[0].rectTransform.position);
        }
    }
    void Start()
    {
        
    } 
    public override void Update()
    {
        
    }
       
    public void ActiveGameModePannel()
    {
        if (gameModePannel)
        {
            gameModePannel.SetActive(true);
        }
    }
    public void ActiveStatusModifyPannel()
    {
        if (statusModifyPannel)
        {
            statusModifyPannel.SetActive(true);
        }
    }

    public void OnClickGameModeSelect_1()
    {
        selectedSceneType = SceneType.GAME;
        Debug.Log("OnClickGameModeSelect_1");
    }
    public void OnClickGameModeSelect_2()
    {
        selectedSceneType = SceneType.GAME_INFINITE;
        Debug.Log("GameModeSelect_2");
    }
    public void OnClickGameStartButton()
    {
        switch (selectedSceneType)
        {
            case SceneType.GAME:
                {
                    SceneManager.LoadScene("Scenes/MainGame");
                } break;
            case SceneType.GAME_INFINITE:
                {
                    SceneManager.LoadScene("Scenes/InfiniteMode");
                } break;
        }
    }

    void OnClickIncAttackButton()
    { 
    }

    void OnClickIncAttackSpeedButton()
    {
    }

    void OnClickIncHpButton()
    {
    }

    void OnClickIncSpeedButton()
    {
    }

    void OnClickIncLuckButton()
    {
    }

    void OnClickCloseGameModeSelectPannelButton()
    {
        // 동시에 2개의 UI가 활성화되지 않도록
        if (statusModifyPannel)
        {
            statusModifyPannel.SetActive(false);
        }

        if (gameModePannel)
        {
            gameModePannel.SetActive(false);
        }
    }
    void OnClickCloseStatusModePannelButton()
    {
        // 동시에 2개의 UI가 활성화되지 않도록
        if (gameModePannel)
        {
            gameModePannel.SetActive(false);
        }

        if (statusModifyPannel)
        {
            statusModifyPannel.SetActive(false);
        }
    }
}
