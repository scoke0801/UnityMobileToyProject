using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; 

public enum SceneType
{
    NONE = -1,
    LOBBY,
    SHOP,
    GAME,
    GAME_INFINITE,
    MANAGEMENT,
}

public class LobbyEnterHelper : MonoBehaviour
{
    [SerializeField] SceneType sceneType;
      
    private void OnTriggerEnter(Collider other)
    {
        Scene scene = GameManager.instance.GetCurrentScene();
        switch (sceneType)
        {
            case SceneType.SHOP:
                {
                    Debug.Log("OnTriggerEnter < case SceneEnterTriggerType.SHOP");
                }break;
            case SceneType.GAME:
            case SceneType.GAME_INFINITE:
                {
                    LobbyScene lobbyScene = (LobbyScene)scene;
                    if (lobbyScene == null)
                    {
                        Debug.LogWarning("OnTriggerEnter < lobbyScene is empty");
                        break;
                    }
                    lobbyScene.ActiveGameModePannel();
                    Debug.Log("OnTriggerEnter < case SceneEnterTriggerType.GAME");
                }
                break;

            case SceneType.MANAGEMENT:
                {
                    LobbyScene lobbyScene = (LobbyScene)scene;
                    if (lobbyScene == null)
                    {
                        Debug.LogWarning("OnTriggerEnter < lobbyScene is empty");
                        break;
                    }
                    lobbyScene.ActiveStatusModifyPannel();
                    Debug.Log("OnTriggerEnter < case SceneEnterTriggerType.MANAGEMENT");
                }
                break;
            default:
                { 
                }break;
        }
    }
}
 