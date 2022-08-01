using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public CamFollow camFollow;
    public GameObject playerObject;

    public SceneType sceneType;

    Scene currentScene;

     
    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        switch (sceneType)
        {
            case SceneType.LOBBY:
                {
                    currentScene = new LobbyScene(playerObject, camFollow);
                } break;
            case SceneType.GAME:
                {
                    currentScene = new GameScene(playerObject, camFollow);
                } break;
            case SceneType.GAME_INFINITE:
                { 
                
                } break;
            default:
                { } break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScene != null)
        {
            currentScene.Update();
        } 
    }
    private void OnDrawGizmosSelected()
    { 
        // util.OnDrawGizmos();
    } 
    public GameObject GetPlayerObject()
    {
        // ���� ���� ���� ��ü���� Player�� ���� ã�� �� �ֵ���
        return currentScene.GetPlayerObject();
    }
    public Player GetPlayer()
    {
        // ���� ���� ���� ��ü���� Player�� ���� ã�� �� �ֵ���
        return currentScene.GetPlayer();
    }

    public void RefreshWaveCount(GameObject gameObject)
    {
        GameScene gameScene = (GameScene)currentScene;
        if (gameScene != null)
        {
            gameScene.RefreshWaveCount(gameObject);
        }
    }
     
    public Scene GetCurrentScene()
    {
        return currentScene;
    }  
}
