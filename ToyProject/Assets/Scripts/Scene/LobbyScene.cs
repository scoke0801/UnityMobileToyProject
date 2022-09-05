 
using UnityEngine; 

using Cinemachine;
public class LobbyScene : BaseScene
{
    private CinemachineVirtualCamera _vcam;
    private GameObject _player;
    public GameObject Player { get { return _player; } }
    protected override bool Init()
    {
        DebugWrapper.Log("LobbyScene < Init Begin");
        if (base.Init() == false)
        {
            return false;
        }

        SceneType = Define.Scene.SCENE_TYPE_LOBBY;

        InitPlayer();
        InitUI();

        // 카메라 초기화는 플레이어 초기화 이후에 실행되어야 합니다!
        InitCamera();

        DebugWrapper.Log("LobbyScene < Init End");
        return true;
    }

    private void InitUI()
    {
        Managers.UI.PushPopupUI<UIGameModeSelect>();
        Managers.UI.HidePopupUI<UIGameModeSelect>();

        Managers.UI.PushPopupUI<UIStartEffectSelect>();
        Managers.UI.HidePopupUI<UIStartEffectSelect>();
    }

    private void InitPlayer()
    {
        _player = Managers.Resource.Instantiate(Managers.Prefab.GetPrefab(Define.PrefabTypeName.PLAYER), transform);
        _player.transform.position = _sceneData.playerPos;

        Managers.Game.Player = _player;
    }

    private void InitCamera()
    {
        _vcam = FindObjectOfType<CinemachineVirtualCamera>();
        _vcam.m_Follow = _player.transform;
        _vcam.m_LookAt = _player.transform;
    } 
}
    