using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//public class GameManager : MonoBehaviour
//{
//    private static GameManager _instance;
//    public static GameManager instance
//    {
//        get
//        {
//            if (_instance == null)
//            {
//                _instance = FindObjectOfType<GameManager>();
//            }
//            return _instance;
//        } 
//    }
//    public CamFollow camFollow;
//    public GameObject playerObject;

//    public SceneType sceneType;

//    Scene currentScene; 

//    // Start is called before the first frame update
//    void Awake()
//    { 
//        switch (sceneType)
//        {
//            case SceneType.LOBBY:
//                {
//                    currentScene = new LobbyScene(playerObject, camFollow);
//                } break;
//            case SceneType.GAME:
//                {
//                    //currentScene = new GameScene(playerObject, camFollow);
//                } break;
//            case SceneType.GAME_INFINITE:
//                { 

//                } break;
//            default:
//                { } break;
//        }
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        if (currentScene != null)
//        {
//            currentScene.Update();
//        } 
//    } 
//    public GameObject GetPlayerObject()
//    {
//        // 게임 월드 상의 객체들이 Player를 쉽게 찾을 수 있도록
//        return currentScene.GetPlayerObject();
//    }
//    public Player GetPlayer()
//    {
//        // 게임 월드 상의 객체들이 Player를 쉽게 찾을 수 있도록
//        return currentScene.GetPlayer();
//    }

//    public void RefreshWaveCount(GameObject gameObject)
//    {
//        //GameScene gameScene = (GameScene)currentScene;
//        //if (gameScene != null)
//        {
//            //gameScene.RefreshWaveCount(gameObject);
//        }
//    }

//    public Scene GetCurrentScene()
//    {
//        return currentScene;
//    }  
//}
public class GameManager 
{
    public void Init()
    {
    }
    //public Player GetPlayer()
    //{
    //    // 게임 월드 상의 객체들이 Player를 쉽게 찾을 수 있도록
    //    return currentScene.GetPlayer();
    //}

    public void RefreshWaveCount(GameObject gameobject)
    {

    }

    //public Scene GetCurrentScene()
    //{
    //    return currentScene;
    //}

}