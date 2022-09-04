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

    LobbyScene _scene;

    public void Start()
    {
        _scene = (LobbyScene)Managers.Scene.CurrentScene;        
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (sceneType)
        {
            case SceneType.SHOP:
                {
//                     Managers.UI.ShowPopupUI<>();
                }break;
            case SceneType.GAME:
                {
                    Managers.UI.ShowPopupUI<UIGameModeSelect>();
                }
                break;
            case SceneType.MANAGEMENT:
                {
                    Managers.UI.ShowPopupUI<UIStartEffectSelect>();
                }break;
        }
    }
}
 