using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class LobbyEnterHelper : MonoBehaviour
{
    [SerializeField] Define.Scene _sceneType;

    LobbyScene _scene;

    public void Start()
    {
        _scene = (LobbyScene)Managers.Scene.CurrentScene;        
    }

    private void OnTriggerEnter(Collider other)
    { 
        switch (_sceneType)
        {
            case Define.Scene.SCENE_INNER_TYPE_SHOP:
                {
//                     Managers.UI.ShowPopupUI<>();
                }break;
            case Define.Scene.GameScene:
                {
                    Managers.UI.ShowPopupUI<UIGameModeSelect>();
                }
                break;
            case Define.Scene.SCENE_INNER_TYPE_MANAGEMENT:
                {
                    Managers.UI.ShowPopupUI<UIStartEffectSelect>();
                }break;
        }
    }
}
 